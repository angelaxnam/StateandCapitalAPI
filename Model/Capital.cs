using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

[Table("Capital")]
public class Capital
{
    [Key]
    [Column("id")]
    public long id { get; set; }
    [Column("capital")]
    public string capital { get; set; }
 
}