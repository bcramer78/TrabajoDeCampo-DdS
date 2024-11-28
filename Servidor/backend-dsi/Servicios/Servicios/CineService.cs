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
    public class CineService : ICineService
    {
        //Instanciacion de la base de datos
        private readonly dsiContext _context;

        public CineService(dsiContext context)
        {
            _context = context;
        }

        //consulta
        public async Task<RespuestaPrivada<ICollection<CineDTOConId>>> GetCines()
        {
            var respuesta = new RespuestaPrivada<ICollection<CineDTOConId>>();
            respuesta.Datos = null;

            try
            {
                var cinesBD = await _context.Cines.ToListAsync();
                if (cinesBD.Count() != 0)
                {
                    var cinesDTO = new List<CineDTOConId>();
                    foreach (var cine in cinesBD)
                    {
                        var cineDTO = cine.Adapt<CineDTOConId>();
                        cinesDTO.Add(cineDTO);
                    }
                    respuesta.Datos = cinesDTO;
                    respuesta.Exito = true;
                    respuesta.Mensaje = "Se recuperaron correctamente todos los cines";
                    return respuesta;
                }

                respuesta.Mensaje = "No se hallaron cines";
                return (respuesta);
            }
            catch (Exception ex)
            {
                respuesta.Mensaje = "Error interno : " + ex.Message;
                return (respuesta);
            }
        }

        //alta
        public async Task<RespuestaPrivada<CineDTO>> PostCine(CineDTO cineDTO)
        {
            var respuesta = new RespuestaPrivada<CineDTO>();
            respuesta.Datos = null;

            try
            {
                var domicilioBD = await _context.Domicilios.FirstOrDefaultAsync(x => x.Id == cineDTO.DomicilioId);
                if (domicilioBD == null)
                {
                    respuesta.Mensaje = "El domicilio que quiere agregarle al cine no existe";
                    return (respuesta);

                }

                var cineExistente = await _context.Cines.FirstOrDefaultAsync(x => x.DomicilioId == cineDTO.DomicilioId);
                if (cineExistente != null)
                {
                    respuesta.Mensaje = "El domicilio ya está asociado a otro cine";
                    return respuesta;
                }

                //var cineNuevo = cineDTO.Adapt<Cine>();
                var cineNuevo = new Cine();
                cineNuevo.Nombre = cineDTO.Nombre;
                cineNuevo.Numero = cineDTO.Numero;
                cineNuevo.Telefono = cineDTO.Telefono;
                cineNuevo.DomicilioId = cineDTO.DomicilioId;
                cineNuevo.Domicilio = domicilioBD;

                await _context.Cines.AddAsync(cineNuevo);
                await _context.SaveChangesAsync();
                respuesta.Exito = true;
                respuesta.Mensaje = "El cine se ha creado correctamente";
                respuesta.Datos = cineNuevo.Adapt<CineDTO>();
                return (respuesta);
            }
            catch (Exception ex)
            {
                respuesta.Mensaje = "Error interno : " + ex.Message;
                return (respuesta);
            }
        }

        //baja 
        public async Task<RespuestaPrivada<Cine>> DeleteCine(int id)
        {
            var respuesta = new RespuestaPrivada<Cine>();
            respuesta.Datos = null;

            try
            {
                var cineBD = await _context.Cines.FindAsync(id);
                if (cineBD != null)
                {
                    _context.Cines.Remove(cineBD);
                    await _context.SaveChangesAsync();
                    respuesta.Datos = cineBD;
                    respuesta.Exito = true;
                    respuesta.Mensaje = "El cine se ha eliminado correctamente ";
                    return respuesta;
                }
                respuesta.Mensaje = "El cine a eliminar no fue hallado ";
                return (respuesta);
            }
            catch (Exception ex)
            {
                respuesta.Mensaje = "Error interno" + ex.Message;
                return respuesta;
            }
        }

        //modificacion

        public async Task<RespuestaPrivada<CineDTO>> PutCine(int id, CineDTO cineDTO)
        {
            var respuesta = new RespuestaPrivada<CineDTO>();
            respuesta.Datos = null;

            try
            {
                var cineBD = await _context.Cines.FindAsync(id);
                if (cineBD != null)
                {
                    var domicilioBD = await _context.Domicilios.FirstOrDefaultAsync(x => x.Id == cineDTO.DomicilioId);
                    if (domicilioBD == null)
                    {
                        respuesta.Mensaje = "El domicilio que quiere agregarle al cine no existe";
                        return (respuesta);

                    }

                    var cineExistente = await _context.Cines.FirstOrDefaultAsync(x => x.DomicilioId == cineDTO.DomicilioId);
                    if (cineExistente != null)
                    {
                        respuesta.Mensaje = "El domicilio ya está asociado a otro cine";
                        return respuesta;
                    }

                    cineBD.Nombre = cineDTO.Nombre;
                    cineBD.Numero = cineDTO.Numero;
                    cineBD.Telefono = cineDTO.Telefono;
                    cineBD.DomicilioId = cineDTO.DomicilioId;
                    cineBD.Domicilio = domicilioBD;

                    await _context.SaveChangesAsync();
                    respuesta.Datos = cineBD.Adapt<CineDTO>();
                    respuesta.Exito = true;
                    respuesta.Mensaje = "El cine se ha modificado correctamente";
                    return respuesta;
                }
                respuesta.Mensaje = "El cine a modificar no fue hallado";
                return (respuesta);
            }
            catch (Exception ex)
            {
                respuesta.Mensaje = "Error interno : " + ex.Message;
                return respuesta;
            }
        }
    }
}
