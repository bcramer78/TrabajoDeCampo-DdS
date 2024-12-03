using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CORE.DTOs;
using DataBase.Data;
using DataBase.Models;
using Mapster;
using Microsoft.EntityFrameworkCore;
using Servicios.Interfaces;

namespace Servicios.Servicios
{
    public class DomicilioService : IDomicilioService
    {
        //Instanciacion de la base de datos
        private readonly dsiContext _context;

        public DomicilioService(dsiContext context)
        {
            _context = context;
        }

        //consulta
        public async Task<RespuestaPrivada<ICollection<DomicilioDTOConId>>> GetDomicilios()
        {
            var respuesta = new RespuestaPrivada<ICollection<DomicilioDTOConId>>();
            respuesta.Datos = null;

            try
            {
                var domiciliosBD = await _context.Domicilios.ToListAsync();
                if (domiciliosBD.Count() != 0)
                {
                    var domiciliosDTO = new List<DomicilioDTOConId>();
                    foreach (var domicilio in domiciliosBD)
                    {
                        var domicilioDTO = domicilio.Adapt<DomicilioDTOConId>();
                        domiciliosDTO.Add(domicilioDTO);
                    }
                    respuesta.Datos = domiciliosDTO;
                    respuesta.Exito = true;
                    respuesta.Mensaje = "Se recuperaron correctamente todos los domicilios";
                    return respuesta;
                }

                respuesta.Mensaje = "No se hallaron domicilios";
                return (respuesta);
            }
            catch (Exception ex)
            {
                respuesta.Mensaje = "Error interno : " + ex.Message;
                return (respuesta);
            }
        }

        //alta
        public async Task<RespuestaPrivada<DomicilioDTO>> PostDomicilio(DomicilioDTO domicilioDTO)
        {
            var respuesta = new RespuestaPrivada<DomicilioDTO>();
            respuesta.Datos = null;

            try
            {
                var localidadBD = await _context.Localidades.FirstOrDefaultAsync(x => x.Id == domicilioDTO.LocalidadId);
                if (localidadBD == null)
                {
                    respuesta.Mensaje = "La localidad que quiere agregarle al domicilio no existe";
                    return (respuesta);

                }

                var domicilioNuevo = new Domicilio();
                domicilioNuevo.Calle = domicilioDTO.Calle;
                domicilioNuevo.Numero = domicilioDTO.Numero;
                domicilioNuevo.LocalidadId = domicilioDTO.LocalidadId;
                domicilioNuevo.Localidad = localidadBD;

                await _context.Domicilios.AddAsync(domicilioNuevo);
                await _context.SaveChangesAsync();
                respuesta.Exito = true;
                respuesta.Mensaje = "El domicilio se ha creado correctamente";
                respuesta.Datos = domicilioNuevo.Adapt<DomicilioDTO>();
                return (respuesta);
            }
            catch (Exception ex)
            {
                respuesta.Mensaje = "Error interno : " + ex.Message;
                return (respuesta);
            }
        }

        //baja 
        public async Task<RespuestaPrivada<Domicilio>> DeleteDomicilio(int id)
        {
            var respuesta = new RespuestaPrivada<Domicilio>();
            respuesta.Datos = null;

            try
            {
                var domicilioBD = await _context.Domicilios.FindAsync(id);
                if (domicilioBD != null)
                {
                    _context.Domicilios.Remove(domicilioBD);
                    await _context.SaveChangesAsync();
                    respuesta.Datos = domicilioBD;
                    respuesta.Exito = true;
                    respuesta.Mensaje = "El domicilio se ha eliminado correctamente ";
                    return respuesta;
                }
                respuesta.Mensaje = "El domicilio a eliminar no fue hallado ";
                return (respuesta);
            }
            catch (Exception ex)
            {
                respuesta.Mensaje = "Error interno" + ex.Message;
                return respuesta;
            }
        }

        //modificacion

        public async Task<RespuestaPrivada<DomicilioDTO>> PutDomicilio(int id, DomicilioDTO domicilioDTO)
        {
            var respuesta = new RespuestaPrivada<DomicilioDTO>();
            respuesta.Datos = null;

            try
            {
                var domicilioBD = await _context.Domicilios.FindAsync(id);
                if (domicilioBD != null)
                {
                    var localidadBD = await _context.Localidades.FirstOrDefaultAsync(x => x.Id == domicilioDTO.LocalidadId);
                    if (localidadBD == null)
                    {
                        respuesta.Mensaje = "La localidad que quiere agregarle al domicilio no existe";
                        return (respuesta);

                    }

                    domicilioBD.Calle = domicilioDTO.Calle;
                    domicilioBD.Numero = domicilioDTO.Numero;
                    domicilioBD.LocalidadId = domicilioDTO.LocalidadId;
                    domicilioBD.Localidad = localidadBD;

                    await _context.SaveChangesAsync();
                    respuesta.Datos = domicilioBD.Adapt<DomicilioDTO>();
                    respuesta.Exito = true;
                    respuesta.Mensaje = "El domicilio se ha modificado correctamente";
                    return respuesta;
                }
                respuesta.Mensaje = "El domicilio a modificar no fue hallado";
                return (respuesta);
            }
            catch (Exception ex)
            {
                respuesta.Mensaje = "Error interno : " + ex.Message;
                return respuesta;
            }
        }

        public async Task<RespuestaPrivada<int>> GetDomicilioId(int calle, int numero)
        {
            var respuesta = new RespuestaPrivada<int>();
            respuesta.Datos = 0; 

            try
            {
                var domicilioBD = await _context.Domicilios
                    .FirstOrDefaultAsync(d => d.Calle == calle && d.Numero == numero);

                if (domicilioBD != null)
                {
                    respuesta.Datos = domicilioBD.Id; // Retorna el ID del domicilio
                    respuesta.Exito = true;
                    respuesta.Mensaje = "Domicilio encontrado correctamente";
                }
                else
                {
                    respuesta.Mensaje = "No se encontró un domicilio con esa calle y número";
                }
            }
            catch (Exception ex)
            {
                respuesta.Mensaje = "Error interno: " + ex.Message;
            }

            return respuesta;
        }

    }
}
