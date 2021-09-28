using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using RestauranteWebApi.Models;
using RestauranteWebApi.Models.Response;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RestauranteWebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RestaurantesController : ControllerBase
    {
        private readonly SiberianDBContext _context;

        public RestaurantesController(SiberianDBContext context)
        {
            _context = context;
        }

        //consultar todos
        [HttpGet]
        public IActionResult Get()
        {
            Respuesta<List<Restaurante>> oRespuesta = new Respuesta<List<Restaurante>>();
            try
            {
                var lista = _context.Restaurantes.ToList();
                oRespuesta.Exito = 1;
                oRespuesta.Data = lista;
            }
            catch (Exception ex)
            {
                oRespuesta.Mensaje = ex.Message;
            }
            return Ok(oRespuesta);
        }

        //consulta especifica
        [HttpGet("{Id}")]
        public IActionResult Get(int Id)
        {
            Respuesta<Restaurante> oRespuesta = new Respuesta<Restaurante>();
            try
            {
                var registro = _context.Restaurantes.Find(Id);
                oRespuesta.Exito = 1;
                oRespuesta.Data = registro;
            }
            catch (Exception ex)
            {
                oRespuesta.Mensaje = ex.Message;               
            }
            return Ok(oRespuesta);
        }

        //Guardar
        [HttpPost]
        public IActionResult Add(Restaurante model)
        {
            Respuesta<object> oRespuesta = new Respuesta<object>();
            try
            {
                Restaurante oRestaurante = new Restaurante();
                oRestaurante.NombreRestaurante = model.NombreRestaurante;
                oRestaurante.NumeroAforo = model.NumeroAforo;
                oRestaurante.Telefono = model.Telefono;
                oRestaurante.FechaCreacion = model.FechaCreacion;
                oRestaurante.Idciudad = model.Idciudad;
                _context.Restaurantes.Add(oRestaurante);
                _context.SaveChanges();
                oRespuesta.Exito = 1;
            }
            catch (Exception ex)
            {
                oRespuesta.Mensaje = ex.Message;
            }
            return Ok(oRespuesta);
        }

        //Editar
        [HttpPut]
        public IActionResult Edit(Restaurante model)
        {
            Respuesta<object> oRespuesta = new Respuesta<object>();
            try
            {
                Restaurante oRestaurante = _context.Restaurantes.Find(model.Idrestaurante);
                oRestaurante.NombreRestaurante = model.NombreRestaurante;
                oRestaurante.NumeroAforo = model.NumeroAforo;
                oRestaurante.Telefono = model.Telefono;
                oRestaurante.FechaCreacion = model.FechaCreacion;
                oRestaurante.Idciudad = model.Idciudad;
                _context.Entry(oRestaurante).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
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
        public IActionResult Delete(int Id)
        {
            Respuesta<object> oRespuesta = new Respuesta<object>();
            try
            {
                Restaurante oRestaurant = _context.Restaurantes.Find(Id);
                _context.Restaurantes.Remove(oRestaurant);
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
