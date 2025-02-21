using System;
using System.ComponentModel.DataAnnotations;

namespace L01_2020CM606_2023LG651.Models.Tablas;

public class Usuarios
{
        [Key]
        public int usuarioId { get; set; }
        public int rolId { get; set; }
        public string nombreUsuario { get; set; }
        public string clave { get; set; }
        public string nombre { get; set; }
        public string apellido { get; set; }
    }
