using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

[Table("Quiz")]
public class Quiz
{
    [Key]
    [Column("id")]
    public long id { get; set; }
}