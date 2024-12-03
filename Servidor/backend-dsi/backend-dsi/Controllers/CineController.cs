using CORE.DTOs;
using DataBase.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Servicios.Interfaces;

namespace backend_dsi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CineController : ControllerBase
    {
        private readonly ICineService _service;

        public CineController(ICineService service)
        {
            _service = service;
        }

        // GET: CineController
        [HttpGet("obtenerCines")]
        public async Task<ActionResult<RespuestaPrivada<ICollection<CineDTOConId>>>> obtenerCines()
        {
            var respuesta = await _service.GetCines();
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

        // POST: CineController
        [HttpPost("crearCine")]
        public async Task<ActionResult<RespuestaPrivada<CineDTO>>> crearCine(CineDTO cineDTO)
        {
            var respuesta = await _service.PostCine(cineDTO);
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

        // DELETE: CineController/eliminarCine/5
        [HttpDelete("eliminarCine")]
        public async Task<ActionResult<RespuestaPrivada<Cine>>> eliminarCine(int id)
        {
            var respuesta = await _service.DeleteCine(id);
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

        // PUT: CineController/modificarCine/5
        [HttpPut("modificarCine")]
        public async Task<ActionResult<RespuestaPrivada<CineDTO>>> modificarCine(int id, CineDTO cineDTO)
        {
            var respuesta = await _service.PutCine(id, cineDTO);
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

        // GET: DomicilioController
        [HttpGet("obtenerCineId")]
        public async Task<ActionResult<RespuestaPrivada<int>>> obtenerCineId(string nombre)
        {
            var respuesta = await _service.GetCineIdByNombre(nombre);
            if (respuesta.Datos == 0)
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
