using System;
using System.ComponentModel.DataAnnotations;

namespace L01_2020CM606_2023LG651.Models;

public class Roles
{
    [Key]
    public int rolId { get; set; }
    public string rol { get; set; }
}
