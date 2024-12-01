using CORE.DTOs;
using DataBase.Models;
using Microsoft.AspNetCore.Mvc;
using Servicios.Interfaces;

namespace backend_dsi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SalaController : ControllerBase
    {
        private readonly ISalaService _service;

        public SalaController(ISalaService service)
        {
            _service = service;
        }

        // GET: SalaController
        [HttpGet("obtenerSalas")]
        public async Task<ActionResult<RespuestaPrivada<ICollection<SalaDTOConId>>>> obtenerSalas()
        {
            var respuesta = await _service.GetSalas();
            if (respuesta.Datos == null)
            {
                if (respuesta.Mensaje.StartsWith("Error interno"))
                {
                    return StatusCode(StatusCodes.Status500InternalServerError, respuesta);
                }
                return BadRequest(respuesta);
            }
            return Ok(respuesta);
        }

        // POST: SalaController
        [HttpPost("crearSala")]
        public async Task<ActionResult<RespuestaPrivada<SalaDTO>>> crearSala(SalaDTO salaDTO)
        {
            var respuesta = await _service.PostSala(salaDTO);
            if (respuesta.Datos == null)
            {
                if (respuesta.Mensaje.StartsWith("Error interno"))
                {
                    return StatusCode(StatusCodes.Status500InternalServerError, respuesta);
                }
                return BadRequest(respuesta);
            }
            return StatusCode(StatusCodes.Status201Created, respuesta);
        }

        // DELETE: SalaController/eliminarSala/5
        [HttpDelete("eliminarSala")]
        public async Task<ActionResult<RespuestaPrivada<Sala>>> eliminarSala(int id)
        {
            var respuesta = await _service.DeleteSala(id);
            if (respuesta.Datos == null)
            {
                if (respuesta.Mensaje.StartsWith("Error interno"))
                {
                    return StatusCode(StatusCodes.Status500InternalServerError, respuesta);
                }
                return NotFound(respuesta);
            }
            return Ok(respuesta);
        }

        // PUT: SalaController/modificarSala/5
        [HttpPut("modificarSala")]
        public async Task<ActionResult<RespuestaPrivada<SalaDTO>>> modificarSala(int id, SalaDTO salaDTO)
        {
            var respuesta = await _service.PutSala(id, salaDTO);
            if (respuesta.Datos == null)
            {
                if (respuesta.Mensaje.StartsWith("Error interno"))
                {
                    return StatusCode(StatusCodes.Status500InternalServerError, respuesta);
                }
                return BadRequest(respuesta);
            }
            return Ok(respuesta);
        }
    }
}
