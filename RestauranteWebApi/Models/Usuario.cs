using System;
using System.Collections.Generic;

#nullable disable

namespace RestauranteWebApi.Models
{
    public partial class Usuario
    {
        public int Iduser { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }
    }
}
