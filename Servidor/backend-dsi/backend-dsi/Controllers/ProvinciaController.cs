using CORE.DTOs;
using DataBase.Models;
using Microsoft.AspNetCore.Mvc;
using Servicios.Interfaces;

namespace backend_dsi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProvinciaController : ControllerBase
    {
        private readonly IProvinciaService _service;

        public ProvinciaController(IProvinciaService service)
        {
            _service = service;
        }

        // GET: ProvinciaController
        [HttpGet("obtenerProvincias")]
        public async Task<ActionResult<RespuestaPrivada<ICollection<ProvinciaDTOConId>>>> obtenerProvincias()
        {
            var respuesta = await _service.GetProvincias();
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

        // POST: ProvinciaController
        [HttpPost("crearProvincia")]
        public async Task<ActionResult<RespuestaPrivada<ProvinciaDTO>>> crearProvincia(ProvinciaDTO provinciaDTO)
        {
            var respuesta = await _service.PostProvincia(provinciaDTO);
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

        // DELETE: ProvinciaController/eliminarProvincia/5
        [HttpDelete("eliminarProvincia")]
        public async Task<ActionResult<RespuestaPrivada<Provincia>>> eliminarProvincia(int id)
        {
            var respuesta = await _service.DeleteProvincia(id);
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

        // PUT: ProvinciaController/modificarProvincia/5
        [HttpPut("modificarProvincia")]
        public async Task<ActionResult<RespuestaPrivada<ProvinciaDTO>>> modificarProvincia(int id, ProvinciaDTO provinciaDTO)
        {
            var respuesta = await _service.PutProvincia(id, provinciaDTO);
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
