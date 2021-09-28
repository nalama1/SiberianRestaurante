using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RestauranteWebApi.Models.Response
{
    public class Respuesta<T> //clase refactorizada
    {
        public int Exito { get; set; }
        public string Mensaje { get; set; }        
        public T Data { get; set; }

        public Respuesta()
        {
            this.Exito = 0;
        }
    }
}
