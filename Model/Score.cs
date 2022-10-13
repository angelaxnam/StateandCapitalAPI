﻿using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

[Table("Score")]
public class Score
{
    [Key]
    [Column("id")]
    public long id { get; set; }
    [Column("score")]
    public long score { get; set; }
}