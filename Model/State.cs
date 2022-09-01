using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

[Table("State")]
public class State
{
    [Key]
    [Column("id")]
    public long id { get; set; }
    [Column("state")]
    public string state { get; set; }
    [Column("capital_id")]
    public long capital_id { get; set; }

}