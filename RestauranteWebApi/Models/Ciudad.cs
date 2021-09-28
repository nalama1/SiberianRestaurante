using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

#nullable disable

namespace RestauranteWebApi.Models
{
    public partial class Ciudad
    {
        public Ciudad()
        {
            Restaurantes = new HashSet<Restaurante>();
        }

        public int Idciudad { get; set; }

        [Required]
        [MinLength(2, ErrorMessage ="Ingrese mínimo 2 caracteres")]
        public string NombreCiudad { get; set; }

        [Required]
        public DateTime FechaCreacion { get; set; }

        public virtual ICollection<Restaurante> Restaurantes { get; set; }
    }
}
