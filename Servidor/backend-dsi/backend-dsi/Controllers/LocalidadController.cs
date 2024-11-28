using CORE.DTOs;
using DataBase.Models;
using Microsoft.AspNetCore.Mvc;
using Servicios.Interfaces;

namespace backend_dsi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LocalidadController : ControllerBase
    {
        private readonly ILocalidadService _service;

        public LocalidadController(ILocalidadService service)
        {
            _service = service;
        }

        // GET: LocalidadController
        [HttpGet("obtenerLocalidades")]
        public async Task<ActionResult<RespuestaPrivada<ICollection<LocalidadDTOConId>>>> obtenerLocalidades()
        {
            var respuesta = await _service.GetLocalidades();
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

        // POST: LocalidadController
        [HttpPost("crearLocalidad")]
        public async Task<ActionResult<RespuestaPrivada<LocalidadDTO>>> crearLocalidad(LocalidadDTO localidadDTO)
        {
            var respuesta = await _service.PostLocalidad(localidadDTO);
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

        // DELETE: LocalidadController/eliminarLocalidad/5
        [HttpDelete("eliminarLocalidad")]
        public async Task<ActionResult<RespuestaPrivada<Localidad>>> eliminarLocalidad(int id)
        {
            var respuesta = await _service.DeleteLocalidad(id);
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

        // PUT: LocalidadController/modificarLocalidad/5
        [HttpPut("modificarLocalidad")]
        public async Task<ActionResult<RespuestaPrivada<LocalidadDTO>>> modificarLocalidad(int id, LocalidadDTO localidadDTO)
        {
            var respuesta = await _service.PutLocalidad(id, localidadDTO);
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
