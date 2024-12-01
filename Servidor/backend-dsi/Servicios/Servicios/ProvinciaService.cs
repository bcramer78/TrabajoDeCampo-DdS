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
    public class ProvinciaService : IProvinciaService
    {
        //Instanciacion de la base de datos
        private readonly dsiContext _context;

        public ProvinciaService(dsiContext context)
        {
            _context = context;
        }

        //consulta 
        public async Task<RespuestaPrivada<ICollection<ProvinciaDTOConId>>> GetProvincias()
        {
            var respuesta = new RespuestaPrivada<ICollection<ProvinciaDTOConId>>();
            respuesta.Datos = null;

            try
            {
                var provinciasBD = await _context.Provincias.ToListAsync();
                if (provinciasBD.Count() != 0)
                {
                    var provinciasDTO = new List<ProvinciaDTOConId>();
                    foreach (var provincia in provinciasBD)
                    {
                        var provinciaDTO = provincia.Adapt<ProvinciaDTOConId>();
                        provinciasDTO.Add(provinciaDTO);
                    }
                    respuesta.Datos = provinciasDTO;
                    respuesta.Exito = true;
                    respuesta.Mensaje = "Se recuperaron correctamente todas las provincias";
                    return respuesta;
                }

                respuesta.Mensaje = "No se hallaron provincias";
                return (respuesta);
            }
            catch (Exception ex)
            {
                respuesta.Mensaje = "Error interno : " + ex.Message;
                return (respuesta);
            }
        }

        //alta
        public async Task<RespuestaPrivada<ProvinciaDTO>> PostProvincia(ProvinciaDTO provinciaDTO)
        {
            var respuesta = new RespuestaPrivada<ProvinciaDTO>();
            respuesta.Datos = null;

            try
            {

                var provinciaNueva = new Provincia();
                provinciaNueva.Nombre = provinciaDTO.Nombre;

                await _context.Provincias.AddAsync(provinciaNueva);
                await _context.SaveChangesAsync();
                respuesta.Exito = true;
                respuesta.Mensaje = "La provincia se ha creado correctamente";
                respuesta.Datos = provinciaNueva.Adapt<ProvinciaDTO>();
                return (respuesta);
            }
            catch (Exception ex)
            {
                respuesta.Mensaje = "Error interno : " + ex.Message;
                return (respuesta);
            }
        }

        //baja 
        public async Task<RespuestaPrivada<Provincia>> DeleteProvincia(int id)
        {
            var respuesta = new RespuestaPrivada<Provincia>();
            respuesta.Datos = null;

            try
            {
                var provinciaBD = await _context.Provincias.FindAsync(id);
                if (provinciaBD != null)
                {
                    _context.Provincias.Remove(provinciaBD);
                    await _context.SaveChangesAsync();
                    respuesta.Datos = provinciaBD;
                    respuesta.Exito = true;
                    respuesta.Mensaje = "La provincia se ha eliminado correctamente";
                    return respuesta;
                }
                respuesta.Mensaje = "La provincia a eliminar no fue hallada";
                return (respuesta);
            }
            catch (Exception ex)
            {
                respuesta.Mensaje = "Error interno" + ex.Message;
                return respuesta;
            }
        }

        //modificacion

        public async Task<RespuestaPrivada<ProvinciaDTO>> PutProvincia(int id, ProvinciaDTO provinciaDTO)
        {
            var respuesta = new RespuestaPrivada<ProvinciaDTO>();
            respuesta.Datos = null;

            try
            {
                var provinciaBD = await _context.Provincias.FindAsync(id);
                if (provinciaBD != null)
                {
                    provinciaBD.Nombre = provinciaDTO.Nombre;

                    await _context.SaveChangesAsync();
                    respuesta.Datos = provinciaBD.Adapt<ProvinciaDTO>();
                    respuesta.Exito = true;
                    respuesta.Mensaje = "La provincia se ha modificado correctamente";
                    return respuesta;
                }
                respuesta.Mensaje = "La provincia a modificar no fue hallada";
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
