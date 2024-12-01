using CORE.DTOs;
using DataBase.Models;
using Microsoft.AspNetCore.Mvc;
using Servicios.Interfaces;

namespace backend_dsi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TurnoController : ControllerBase
    {
        private readonly ITurnoService _service;

        public TurnoController(ITurnoService service)
        {
            _service = service;
        }

        // GET: TurnoController
        [HttpGet("obtenerTurno")]
        public async Task<ActionResult<RespuestaPrivada<ICollection<TurnoDTOConId>>>> obtenerTurno()
        {
            var respuesta = await _service.GetTurnos();
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

        // POST: TurnoController
        [HttpPost("crearTurno")]
        public async Task<ActionResult<RespuestaPrivada<TurnoDTO>>> crearTurno(TurnoDTO turnoDTO)
        {
            var respuesta = await _service.PostTurno(turnoDTO);
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

        // DELETE: TurnoController/eliminarTurno/5
        [HttpDelete("eliminarTurno")]
        public async Task<ActionResult<RespuestaPrivada<Turno>>> eliminarTurno(int id)
        {
            var respuesta = await _service.DeleteTurno(id);
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

        // PUT: TurnoController/modificarTurno/5
        [HttpPut("modificarTurno")]
        public async Task<ActionResult<RespuestaPrivada<TurnoDTO>>> modificarTurno(int id, TurnoDTO turnoDTO)
        {
            var respuesta = await _service.PutTurno(id, turnoDTO);
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
