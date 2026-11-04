using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Domain.Entities
{
    public class Characters
    {
        [Key]
        public int idCharacter { get; set; }
        public string Nombre { get; set; }
        public string Descripcion { get; set; }
        public int Vida { get; set; }
        public int Ataque { get; set; }
        public int Defensa { get; set; }
        public string Imagen { get; set; }


    }
}
