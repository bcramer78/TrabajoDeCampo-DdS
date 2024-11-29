using System;
using System.Collections.Generic;
using System.Data;
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
    public class TurnoPrecioService : ITurnoPrecioService
    {
        //Instanciacion de la base de datos
        private readonly dsiContext _context;

        public TurnoPrecioService(dsiContext context)
        {
            _context = context;
        }

        //consulta 
        public async Task<RespuestaPrivada<ICollection<TurnoPrecioDTOConId>>> GetTurnosPrecios()
        {
            var respuesta = new RespuestaPrivada<ICollection<TurnoPrecioDTOConId>>();
            respuesta.Datos = null;

            try
            {
                var turnosPreciosBD = await _context.TurnoPrecios.ToListAsync();
                if (turnosPreciosBD.Count() != 0)
                {
                    var turnosPreciosDTO = new List<TurnoPrecioDTOConId>();
                    foreach (var turnoPrecio in turnosPreciosBD)
                    {
                        var turnoPrecioDTO = turnoPrecio.Adapt<TurnoPrecioDTOConId>();
                        turnosPreciosDTO.Add(turnoPrecioDTO);
                    }
                    respuesta.Datos = turnosPreciosDTO;
                    respuesta.Exito = true;
                    respuesta.Mensaje = "Se recuperaron correctamente todos los turnosPrecios";
                    return respuesta;
                }

                respuesta.Mensaje = "No se hallaron turnosPrecios";
                return (respuesta);
            }
            catch (Exception ex)
            {
                respuesta.Mensaje = "Error interno : " + ex.Message;
                return (respuesta);
            }
        }

        //alta
        public async Task<RespuestaPrivada<TurnoPrecioDTO>> PostTurnoPrecio(TurnoPrecioDTO turnoPrecioDTO)
        {
            var respuesta = new RespuestaPrivada<TurnoPrecioDTO>();
            respuesta.Datos = null;

            try
            {

                var cineBD = await _context.Cines.FirstOrDefaultAsync(x => x.Id == turnoPrecioDTO.CineId);
                var turnoBD = await _context.Turnos.FirstOrDefaultAsync(x => x.Id == turnoPrecioDTO.TurnoId);
                if (cineBD == null)
                {
                    respuesta.Mensaje = "El cine al que quiere agregarle el turnoPrecio no existe";
                    return (respuesta);

                } else if (turnoBD == null)
                {
                    respuesta.Mensaje = "El turno que quiere agregarle al turnoPrecio no existe";
                    return (respuesta);
                }

                var turnoPrecioNuevo = new TurnoPrecio();
                turnoPrecioNuevo.Precio = turnoPrecioDTO.Precio;
                turnoPrecioNuevo.TurnoId = turnoPrecioDTO.TurnoId;
                turnoPrecioNuevo.CineId = turnoPrecioDTO.CineId;
                turnoPrecioNuevo.Cine = cineBD;
                turnoPrecioNuevo.Turno = turnoBD;

                await _context.TurnoPrecios.AddAsync(turnoPrecioNuevo);
                await _context.SaveChangesAsync();
                respuesta.Exito = true;
                respuesta.Mensaje = "El turnoPrecio se ha creado correctamente";
                respuesta.Datos = turnoPrecioNuevo.Adapt<TurnoPrecioDTO>();
                return (respuesta);
            }
            catch (Exception ex)
            {
                respuesta.Mensaje = "Error interno : " + ex.Message;
                return (respuesta);
            }
        }

        //baja 
        public async Task<RespuestaPrivada<TurnoPrecio>> DeleteTurnoPrecio(int id)
        {
            var respuesta = new RespuestaPrivada<TurnoPrecio>();
            respuesta.Datos = null;

            try
            {
                var turnoPrecioBD = await _context.TurnoPrecios.FindAsync(id);
                if (turnoPrecioBD != null)
                {
                    _context.TurnoPrecios.Remove(turnoPrecioBD);
                    await _context.SaveChangesAsync();
                    respuesta.Datos = turnoPrecioBD;
                    respuesta.Exito = true;
                    respuesta.Mensaje = "El turnoPrecio se ha eliminado correctamente";
                    return respuesta;
                }
                respuesta.Mensaje = "El turnoPrecio a eliminar no fue hallado";
                return (respuesta);
            }
            catch (Exception ex)
            {
                respuesta.Mensaje = "Error interno" + ex.Message;
                return respuesta;
            }
        }

        //modificacion

        public async Task<RespuestaPrivada<TurnoPrecioDTO>> PutTurnoPrecio(int id, TurnoPrecioDTO turnoPrecioDTO)
        {
            var respuesta = new RespuestaPrivada<TurnoPrecioDTO>();
            respuesta.Datos = null;

            try
            {
                var turnoPrecioBD = await _context.TurnoPrecios.FindAsync(id);
                if (turnoPrecioBD != null)
                {
                    var cineBD = await _context.Cines.FirstOrDefaultAsync(x => x.Id == turnoPrecioDTO.CineId);
                    var turnoBD = await _context.Turnos.FirstOrDefaultAsync(x => x.Id == turnoPrecioDTO.TurnoId);
                    if (cineBD == null)
                    {
                        respuesta.Mensaje = "El cine al que quiere agregarle el turnoPrecio no existe";
                        return (respuesta);

                    }
                    else if (turnoBD == null)
                    {
                        respuesta.Mensaje = "El turno que quiere agregarle al turnoPrecio no existe";
                        return (respuesta);
                    }

                    turnoPrecioBD.Precio = turnoPrecioDTO.Precio;
                    turnoPrecioBD.TurnoId = turnoPrecioDTO.TurnoId;
                    turnoPrecioBD.CineId = turnoPrecioDTO.CineId;
                    turnoPrecioBD.Cine = cineBD;
                    turnoPrecioBD.Turno = turnoBD;

                    await _context.SaveChangesAsync();
                    respuesta.Datos = turnoPrecioBD.Adapt<TurnoPrecioDTO>();
                    respuesta.Exito = true;
                    respuesta.Mensaje = "El turnoPrecio se ha modificado correctamente";
                    return respuesta;
                }
                respuesta.Mensaje = "El turnoPrecio a modificar no fue hallado";
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
