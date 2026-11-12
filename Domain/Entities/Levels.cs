using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Domain.Entities
{
    public class Levels
    {
        [Key]
        public int idLevel { get; set; }
        public string Nombre { get; set; }
        public string descripcion { get; set; }
        public string? Imagen { get; set; }

    }
}
