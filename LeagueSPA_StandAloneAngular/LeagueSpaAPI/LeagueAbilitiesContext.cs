using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace LeagueSpaAPI;

public partial class LeagueAbilitiesContext : IdentityDbContext<ApplicationUser>
{
    public LeagueAbilitiesContext()
    {
    }

    public LeagueAbilitiesContext(DbContextOptions<LeagueAbilitiesContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Ability> Abilities { get; set; }

    public virtual DbSet<Champion> Champions { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=LeagueAbilities;User Id = cs584; Password=cs584;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False");
    
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
        modelBuilder.Entity<Ability>(entity =>
        {
            entity.Property(e => e.Description).IsFixedLength();

            entity.HasOne(d => d.Champion).WithMany(p => p.Abilities)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Abilities_Champions");
        });

        modelBuilder.Entity<Champion>(entity =>
        {
            entity.Property(e => e.Name).IsFixedLength();
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
