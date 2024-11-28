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
    public class LocalidadService : ILocalidadService
    {
        //Instanciacion de la base de datos
        private readonly dsiContext _context;

        public LocalidadService(dsiContext context)
        {
            _context = context;
        }

        //consulta 
        public async Task<RespuestaPrivada<ICollection<LocalidadDTOConId>>> GetLocalidades()
        {
            var respuesta = new RespuestaPrivada<ICollection<LocalidadDTOConId>>();
            respuesta.Datos = null;

            try
            {
                var localidadesBD = await _context.Localidades.ToListAsync();
                if (localidadesBD.Count() != 0)
                {
                    var localidadesDTO = new List<LocalidadDTOConId>();
                    foreach (var localidad in localidadesBD)
                    {
                        var localidadDTO = localidad.Adapt<LocalidadDTOConId>();
                        localidadesDTO.Add(localidadDTO);
                    }
                    respuesta.Datos = localidadesDTO;
                    respuesta.Exito = true;
                    respuesta.Mensaje = "Se recuperaron correctamente todas las localidades";
                    return respuesta;
                }

                respuesta.Mensaje = "No se hallaron localidades";
                return (respuesta);
            }
            catch (Exception ex)
            {
                respuesta.Mensaje = "Error interno : " + ex.Message;
                return (respuesta);
            }
        }

        //alta
        public async Task<RespuestaPrivada<LocalidadDTO>> PostLocalidad(LocalidadDTO localidadDTO)
        {
            var respuesta = new RespuestaPrivada<LocalidadDTO>();
            respuesta.Datos = null;

            try
            {
                var provinciaBD = await _context.Provincias.FirstOrDefaultAsync(x => x.Id == localidadDTO.ProvinciaId);
                if (provinciaBD == null)
                {
                    respuesta.Mensaje = "La provincia que quiere agregarle a la localidad no existe";
                    return (respuesta);

                }

                var localidadNueva = new Localidad();
                localidadNueva.Nombre = localidadDTO.Nombre;
                localidadNueva.ProvinciaId = localidadDTO.ProvinciaId;
                localidadNueva.Provincia = provinciaBD;

                await _context.Localidades.AddAsync(localidadNueva);
                await _context.SaveChangesAsync();
                respuesta.Exito = true;
                respuesta.Mensaje = "La localidad se ha creado correctamente";
                respuesta.Datos = localidadNueva.Adapt<LocalidadDTO>();
                return (respuesta);
            }
            catch (Exception ex)
            {
                respuesta.Mensaje = "Error interno : " + ex.Message;
                return (respuesta);
            }
        }

        //baja 
        public async Task<RespuestaPrivada<Localidad>> DeleteLocalidad(int id)
        {
            var respuesta = new RespuestaPrivada<Localidad>();
            respuesta.Datos = null;

            try
            {
                var localidadBD = await _context.Localidades.FindAsync(id);
                if (localidadBD != null)
                {
                    _context.Localidades.Remove(localidadBD);
                    await _context.SaveChangesAsync();
                    respuesta.Datos = localidadBD;
                    respuesta.Exito = true;
                    respuesta.Mensaje = "La localidad se ha eliminado correctamente ";
                    return respuesta;
                }
                respuesta.Mensaje = "La localidad a eliminar no fue hallada";
                return (respuesta);
            }
            catch (Exception ex)
            {
                respuesta.Mensaje = "Error interno" + ex.Message;
                return respuesta;
            }
        }

        //modificacion

        public async Task<RespuestaPrivada<LocalidadDTO>> PutLocalidad(int id, LocalidadDTO localidadDTO)
        {
            var respuesta = new RespuestaPrivada<LocalidadDTO>();
            respuesta.Datos = null;

            try
            {
                var localidadBD = await _context.Localidades.FindAsync(id);
                if (localidadBD != null)
                {
                    var provinciaBD = await _context.Provincias.FirstOrDefaultAsync(x => x.Id == localidadDTO.ProvinciaId);
                    if (provinciaBD == null)
                    {
                        respuesta.Mensaje = "La provincia que quiere agregarle a la localidad no existe";
                        return (respuesta);

                    }

                    localidadBD.Nombre = localidadDTO.Nombre;
                    localidadBD.ProvinciaId = localidadDTO.ProvinciaId;
                    localidadBD.Provincia = provinciaBD;

                    await _context.SaveChangesAsync();
                    respuesta.Datos = localidadBD.Adapt<LocalidadDTO>();
                    respuesta.Exito = true;
                    respuesta.Mensaje = "La localidad se ha modificado correctamente";
                    return respuesta;
                }
                respuesta.Mensaje = "La localidad a modificar no fue hallada";
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
