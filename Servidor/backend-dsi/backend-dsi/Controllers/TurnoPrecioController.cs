using CORE.DTOs;
using DataBase.Models;
using Microsoft.AspNetCore.Mvc;
using Servicios.Interfaces;

namespace backend_dsi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TurnoPrecioController : ControllerBase
    {
        private readonly ITurnoPrecioService _service;

        public TurnoPrecioController(ITurnoPrecioService service)
        {
            _service = service;
        }

        // GET: TurnoPrecioController
        [HttpGet("obtenerTurnoPrecio")]
        public async Task<ActionResult<RespuestaPrivada<ICollection<TurnoPrecioDTOConId>>>> obtenerTurnoPrecio()
        {
            var respuesta = await _service.GetTurnosPrecios();
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

        // POST: TurnoPrecioController
        [HttpPost("crearTurnoPrecio")]
        public async Task<ActionResult<RespuestaPrivada<TurnoPrecioDTOConId>>> crearTurnoPrecio(TurnoPrecioDTO turnoPrecioDTO)
        {
            var respuesta = await _service.PostTurnoPrecio(turnoPrecioDTO);
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

        // DELETE: TurnoPrecioController/eliminarTurnoPrecio/5
        [HttpDelete("eliminarTurnoPrecio")]
        public async Task<ActionResult<RespuestaPrivada<TurnoPrecio>>> eliminarTurnoPrecio(int id)
        {
            var respuesta = await _service.DeleteTurnoPrecio(id);
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

        // PUT: TurnoPrecioController/modificarTurnoPrecio/5
        [HttpPut("modificarTurnoPrecio")]
        public async Task<ActionResult<RespuestaPrivada<TurnoPrecioDTO>>> modificarTurnoPrecio(int id, TurnoPrecioDTO turnoPrecioDTO)
        {
            var respuesta = await _service.PutTurnoPrecio(id, turnoPrecioDTO);
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
