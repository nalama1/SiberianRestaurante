using Microsoft.AspNetCore.Mvc;
using RestauranteWebApi.Models;
using RestauranteWebApi.Models.Response;
using System;
using System.Collections.Generic;
using System.Linq;

namespace RestauranteWebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CiudadesController : ControllerBase
    {
        private readonly SiberianDBContext _context;

        public CiudadesController(SiberianDBContext context)
        {
            _context = context;
        }

        //consultar todos
        [HttpGet]
        public IActionResult Get()
        {
            Respuesta<List<Ciudad>> oRespuesta = new Respuesta<List<Ciudad>>();
            try
            {                
                var list = _context.Ciudads.ToList();
                oRespuesta.Exito = 1;
                oRespuesta.Data = list;                
            }
            catch (Exception ex)
            {
                oRespuesta.Mensaje = ex.Message;
            }
            return Ok(oRespuesta);
        }

        //consulta especifica por Id
        [HttpGet("{Id}")]
        public IActionResult Get(int Id)
        {
            Respuesta<Ciudad> oRespuesta = new Respuesta<Ciudad>();
            try
            {
                var registro = _context.Ciudads.Find(Id);
                oRespuesta.Exito = 1;
                oRespuesta.Data = registro;
            }
            catch (Exception ex)
            {
                oRespuesta.Mensaje = ex.Message;
            }
            return Ok(oRespuesta);

        }

        //grabar
        [HttpPost]
        public IActionResult Add(Ciudad model)
        {
            Respuesta<object> oRespuesta = new Respuesta<object>();
            try
            {
                Ciudad oCiudad = new Ciudad();
                oCiudad.NombreCiudad = model.NombreCiudad;
                oCiudad.FechaCreacion = model.FechaCreacion;
                _context.Ciudads.Add(oCiudad);
                _context.SaveChanges();
                oRespuesta.Exito = 1;
            }
            catch (Exception ex)
            {
                oRespuesta.Mensaje = ex.Message;
            }
            return Ok(oRespuesta);
        }


        //editar
        [HttpPut]
        public IActionResult Edit(Ciudad model)
        {
            Respuesta<object> oRespuesta = new Respuesta<object>();
            try
            {
                Ciudad oCiudad = _context.Ciudads.Find(model.Idciudad);
                oCiudad.NombreCiudad = model.NombreCiudad;
                oCiudad.FechaCreacion = model.FechaCreacion;
                _context.Entry(oCiudad).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
                _context.SaveChanges();
                oRespuesta.Exito = 1;
            }
            catch (Exception ex)
            {
                oRespuesta.Mensaje = ex.Message;
            }
            return Ok(oRespuesta);
        }

        //eliminar
        [HttpDelete("{Id}")]
        public IActionResult Delete(int Id )
        {
            Respuesta<object> oRespuesta = new Respuesta<object>();
            try
            {
                Ciudad oCiudad = _context.Ciudads.Find(Id);
                _context.Remove(oCiudad);
                _context.SaveChanges();
                oRespuesta.Exito = 1;
            }
            catch (Exception ex)
            {
                oRespuesta.Mensaje = ex.Message;
            }
            return Ok(oRespuesta);
        }
    }
}


//using (SiberianDBContext db = new SiberianDBContext())
//{
//    var list = db.Ciudads.ToList();
//    oRespuesta.Exito = 1;
//    oRespuesta.Data = list;
//}