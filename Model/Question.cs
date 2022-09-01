using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

[Table("Question")]
public class Question
{
    [Key]
    [Column("id")]
    public long id { get; set; }
    [Column("question")]
    public string question { get; set; }
    [Column("correctAnswer")]
    public string correctAnswer { get; set; }
    [Column("a")]
    public string a { get; set; }
    [Column("b")]
    public string b { get; set; }
    [Column("c")]
    public string c { get; set; }
    [Column("d")]
    public string d { get; set; }
    [Column("scoreId")]
    public long scoreId { get; set; }

}