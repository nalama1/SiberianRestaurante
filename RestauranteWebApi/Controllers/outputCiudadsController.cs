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
    public class outputCiudadsController : ControllerBase
    {
        private readonly SiberianDBContext _context;

        public outputCiudadsController(SiberianDBContext context)
        {
            _context = context;
        }

        // POST: api/outputs
        [HttpPost]
        public async Task<ActionResult<IEnumerable<outputCiudad>>> Getoutput(InputCiudad input)
        {
            string StoredProc = "exec Sp_Ciudad  " +
                "@opcion = " + input.Opcion + "," +
                "@IDCiudad = " + input.IDCiudad + "," +
                "@nombreCiudad = '" + input.NombreCiudad + "'," +
                "@fecha = '" + input.Fecha + "'"
                ;
            //return await _context.InputCiudad.ToListAsync();
            return await _context.outputCiudad.FromSqlRaw(StoredProc).ToListAsync();
        }
    }
}
