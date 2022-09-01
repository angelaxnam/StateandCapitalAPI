using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

[Table("Score")]
public class Score
{
    [Key]
    [Column("id")]
    public long id { get; set; }
    [Column("percentage")]
    public long percentage { get; set; }
}