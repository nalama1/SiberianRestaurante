using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using RestauranteWebApi.Models;

namespace RestauranteWebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class outputRestaurantesController : ControllerBase
    {
        private readonly SiberianDBContext _context;

        public outputRestaurantesController(SiberianDBContext context)
        {
            _context = context;
        }


        // POST: api/outputs
        [HttpPost]
        public async Task<ActionResult<IEnumerable<outputRestaurante>>> Getoutput(InputRestaurante input)
        {
            string StoredProc = "exec Sp_Restaurantes  " +
                "@opcion = " + input.Opcion + "," +
                "@IDRestaurante = " + input.IDRestaurante + "," +
                "@nombreRestaurante = '" + input.nombreRestaurante + "'," +
                "@idCiudad = " + input.IDCiudad + "," +
                "@numeroAforo = " + input.NumeroAforo + "," +
                "@telefono = " + input.Telefono + "," +
                "@fecha = '" + input.Fecha + "'"
                ;            
            return await _context.outputRestaurante.FromSqlRaw(StoredProc).ToListAsync();
        }
    }
}
