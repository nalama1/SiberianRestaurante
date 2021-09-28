using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace RestauranteWebApi.Models
{
    public class InputCiudad
    {
        [Key]
        public int IDCiudad { get; set; }
        public int Opcion { get; set; }        
        public string NombreCiudad { get; set; }
        public DateTime Fecha { get; set; }
    }

    public class InputRestaurante
    {
        [Key]
        public int IDRestaurante { get; set; }
        public int Opcion { get; set; }        
        public string nombreRestaurante { get; set; }
        public int IDCiudad { get; set; }
        public int NumeroAforo { get; set; }
        public int Telefono { get; set; }
        public DateTime Fecha { get; set; }
    }
  

}
