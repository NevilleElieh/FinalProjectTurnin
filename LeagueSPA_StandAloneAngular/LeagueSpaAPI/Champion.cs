using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace LeagueSpaAPI;

public partial class Champion
{
    [Key]
    [Column("ID")]
    public int Id { get; set; }

    [StringLength(15)]
    public string Name { get; set; } = null!;

    [InverseProperty("Champion")]
    public virtual ICollection<Ability> Abilities { get; set; } = new List<Ability>();
}
