using System;
using System.ComponentModel.DataAnnotations;

namespace L01_2020CM606_2023LG651.Models.Tablas;

public class Comentarios
{
    [Key]
    public int cometarioId { get; set; }
    public int publicacionId { get; set; }
    public string comentario { get; set; }
    public int usuarioId { get; set; }
}
