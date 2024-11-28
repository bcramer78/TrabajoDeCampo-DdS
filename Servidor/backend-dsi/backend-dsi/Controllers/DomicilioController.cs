using CORE.DTOs;
using DataBase.Models;
using Microsoft.AspNetCore.Mvc;
using Servicios.Interfaces;

namespace backend_dsi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DomicilioController : ControllerBase
    {
        private readonly IDomicilioService _service;

        public DomicilioController(IDomicilioService service)
        {
            _service = service;
        }

        // GET: DomicilioController
        [HttpGet("obtenerDomicilios")]
        public async Task<ActionResult<RespuestaPrivada<ICollection<DomicilioDTOConId>>>> obtenerDomicilios()
        {
            var respuesta = await _service.GetDomicilios();
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

        // POST: DomicilioController
        [HttpPost("crearDomicilio")]
        public async Task<ActionResult<RespuestaPrivada<DomicilioDTO>>> crearDomicilio(DomicilioDTO domicilioDTO)
        {
            var respuesta = await _service.PostDomicilio(domicilioDTO);
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

        // DELETE: DomicilioController/eliminarDomicilio/5
        [HttpDelete("eliminarDomicilio")]
        public async Task<ActionResult<RespuestaPrivada<Domicilio>>> eliminarDomicilio(int id)
        {
            var respuesta = await _service.DeleteDomicilio(id);
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

        // PUT: DomicilioController/modificarDomicilio/5
        [HttpPut("modificarDomicilio")]
        public async Task<ActionResult<RespuestaPrivada<DomicilioDTO>>> modificarDomicilio(int id, DomicilioDTO domicilioDTO)
        {
            var respuesta = await _service.PutDomicilio(id, domicilioDTO);
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
