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
    public class SalaService : ISalaService
    {
        //Instanciacion de la base de datos
        private readonly dsiContext _context;

        public SalaService(dsiContext context)
        {
            _context = context;
        }

        //consulta 
        public async Task<RespuestaPrivada<ICollection<SalaDTOConId>>> GetSalas()
        {
            var respuesta = new RespuestaPrivada<ICollection<SalaDTOConId>>();
            respuesta.Datos = null;

            try
            {
                var salasBD = await _context.Salas.ToListAsync();
                if (salasBD.Count() != 0)
                {
                    var salasDTO = new List<SalaDTOConId>();
                    foreach (var sala in salasBD)
                    {
                        var salaDTO = sala.Adapt<SalaDTOConId>();
                        salasDTO.Add(salaDTO);
                    }
                    respuesta.Datos = salasDTO;
                    respuesta.Exito = true;
                    respuesta.Mensaje = "Se recuperaron correctamente todas las salas";
                    return respuesta;
                }

                respuesta.Mensaje = "No se hallaron salas";
                return (respuesta);
            }
            catch (Exception ex)
            {
                respuesta.Mensaje = "Error interno : " + ex.Message;
                return (respuesta);
            }
        }

        //alta
        public async Task<RespuestaPrivada<SalaDTO>> PostSala(SalaDTO salaDTO)
        {
            var respuesta = new RespuestaPrivada<SalaDTO>();
            respuesta.Datos = null;

            try
            {

                var cineBD = await _context.Cines.FirstOrDefaultAsync(x => x.Id == salaDTO.CineId);
                if (cineBD == null)
                {
                    respuesta.Mensaje = "El cine al que quiere agregarle la sala no existe";
                    return (respuesta);

                }

                var salaNueva = new Sala();
                salaNueva.Numero = salaDTO.Numero;
                salaNueva.Tipo = salaDTO.Tipo;
                salaNueva.CineId = salaDTO.CineId;
                salaNueva.Cine = cineBD;

                await _context.Salas.AddAsync(salaNueva);
                await _context.SaveChangesAsync();
                respuesta.Exito = true;
                respuesta.Mensaje = "La sala se ha creado correctamente";
                respuesta.Datos = salaNueva.Adapt<SalaDTO>();
                return (respuesta);
            }
            catch (Exception ex)
            {
                respuesta.Mensaje = "Error interno : " + ex.Message;
                return (respuesta);
            }
        }

        //baja 
        public async Task<RespuestaPrivada<Sala>> DeleteSala(int id)
        {
            var respuesta = new RespuestaPrivada<Sala>();
            respuesta.Datos = null;

            try
            {
                var salaBD = await _context.Salas.FindAsync(id);
                if (salaBD != null)
                {
                    _context.Salas.Remove(salaBD);
                    await _context.SaveChangesAsync();
                    respuesta.Datos = salaBD;
                    respuesta.Exito = true;
                    respuesta.Mensaje = "La sala se ha eliminado correctamente";
                    return respuesta;
                }
                respuesta.Mensaje = "La sala a eliminar no fue hallada";
                return (respuesta);
            }
            catch (Exception ex)
            {
                respuesta.Mensaje = "Error interno" + ex.Message;
                return respuesta;
            }
        }

        //modificacion

        public async Task<RespuestaPrivada<SalaDTO>> PutSala(int id, SalaDTO salaDTO)
        {
            var respuesta = new RespuestaPrivada<SalaDTO>();
            respuesta.Datos = null;

            try
            {
                var salaBD = await _context.Salas.FindAsync(id);
                if (salaBD != null)
                {
                    var cineBD = await _context.Cines.FirstOrDefaultAsync(x => x.Id == salaDTO.CineId);
                    if (cineBD == null)
                    {
                        respuesta.Mensaje = "El cine al que quiere agregarle la sala no existe";
                        return (respuesta);

                    }

                    salaBD.Numero = salaDTO.Numero;
                    salaBD.Tipo = salaDTO.Tipo;
                    salaBD.CineId = salaDTO.CineId;
                    salaBD.Cine = cineBD;

                    await _context.SaveChangesAsync();
                    respuesta.Datos = salaBD.Adapt<SalaDTO>();
                    respuesta.Exito = true;
                    respuesta.Mensaje = "La sala se ha modificado correctamente";
                    return respuesta;
                }
                respuesta.Mensaje = "La sala a modificar no fue hallada";
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
