using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BlazorServer.Data
{
    public class Ciudad
    {
        public int Idciudad { get; set; }
        public string NombreCiudad { get; set; }
        public DateTime? FechaCreacion { get; set; }
    }
}
