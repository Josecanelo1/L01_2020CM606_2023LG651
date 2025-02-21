using System;
using System.ComponentModel.DataAnnotations;

namespace L01_2020CM606_2023LG651.Models.Tablas;

public class Publicaciones
{
    [Key]
    public int publicacionId { get; set; }
    public string titulo { get; set; }
    public string descripcion { get; set; }
    public int usuarioId { get; set; }
}
