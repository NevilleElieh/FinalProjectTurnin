using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace LeagueSpaAPI;

public partial class Ability
{
    [Key]
    [Column("ID")]
    public int Id { get; set; }

    [Column("ChampionID")]
    public int ChampionId { get; set; }

    [StringLength(400)]
    public string Description { get; set; } = null!;

    [ForeignKey("ChampionId")]
    [InverseProperty("Abilities")]
    public virtual Champion Champion { get; set; } = null!;
}
