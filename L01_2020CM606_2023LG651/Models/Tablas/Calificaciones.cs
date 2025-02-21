using System;
using System.ComponentModel.DataAnnotations;

namespace L01_2020CM606_2023LG651.Models.Tablas;

public class Calificaciones
{
        [Key]
        public int calificacionId { get; set; }
        public int publicacionId { get; set; }
        public int usuarioId { get; set; }
        public int calificacion { get; set; }
    }
