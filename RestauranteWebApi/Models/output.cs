using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace RestauranteWebApi.Models
{     
    public partial class outputCiudad
    {
        [Key]
        public int IDCiudad { get; set; }
        public string NombreCiudad { get; set; }
        public DateTime FechaCreacion { get; set; }
    }

    public partial class outputRestaurante
    {
        [Key]
        public int IDRestaurante { get; set; }
        public string NombreRestaurante { get; set; }        
        public int NumeroAforo { get; set; }
        public int Telefono { get; set; }
        public DateTime FechaCreacion { get; set; }
        public string NombreCiudad { get; set; }        
    }
}
