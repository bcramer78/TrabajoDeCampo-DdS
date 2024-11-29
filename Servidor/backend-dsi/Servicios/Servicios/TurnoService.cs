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
    public class TurnoService : ITurnoService
    {
        //Instanciacion de la base de datos
        private readonly dsiContext _context;

        public TurnoService(dsiContext context)
        {
            _context = context;
        }

        //consulta 
        public async Task<RespuestaPrivada<ICollection<TurnoDTOConId>>> GetTurnos()
        {
            var respuesta = new RespuestaPrivada<ICollection<TurnoDTOConId>>();
            respuesta.Datos = null;

            try
            {
                var turnosBD = await _context.Turnos.ToListAsync();
                if (turnosBD.Count() != 0)
                {
                    var turnosDTO = new List<TurnoDTOConId>();
                    foreach (var turno in turnosBD)
                    {
                        var turnoDTO = turno.Adapt<TurnoDTOConId>();
                        turnosDTO.Add(turnoDTO);
                    }
                    respuesta.Datos = turnosDTO;
                    respuesta.Exito = true;
                    respuesta.Mensaje = "Se recuperaron correctamente todos los turnos";
                    return respuesta;
                }

                respuesta.Mensaje = "No se hallaron turnos";
                return (respuesta);
            }
            catch (Exception ex)
            {
                respuesta.Mensaje = "Error interno : " + ex.Message;
                return (respuesta);
            }
        }

        //alta
        public async Task<RespuestaPrivada<TurnoDTO>> PostTurno(TurnoDTO turnoDTO)
        {
            var respuesta = new RespuestaPrivada<TurnoDTO>();
            respuesta.Datos = null;

            try
            {

                var turnoNuevo = new Turno();
                turnoNuevo.Tipo = turnoDTO.Tipo;

                await _context.Turnos.AddAsync(turnoNuevo);
                await _context.SaveChangesAsync();
                respuesta.Exito = true;
                respuesta.Mensaje = "El turno se ha creado correctamente";
                respuesta.Datos = turnoNuevo.Adapt<TurnoDTO>();
                return (respuesta);
            }
            catch (Exception ex)
            {
                respuesta.Mensaje = "Error interno : " + ex.Message;
                return (respuesta);
            }
        }

        //baja 
        public async Task<RespuestaPrivada<Turno>> DeleteTurno(int id)
        {
            var respuesta = new RespuestaPrivada<Turno>();
            respuesta.Datos = null;

            try
            {
                var turnoBD = await _context.Turnos.FindAsync(id);
                if (turnoBD != null)
                {
                    _context.Turnos.Remove(turnoBD);
                    await _context.SaveChangesAsync();
                    respuesta.Datos = turnoBD;
                    respuesta.Exito = true;
                    respuesta.Mensaje = "El turno se ha eliminado correctamente";
                    return respuesta;
                }
                respuesta.Mensaje = "El turno a eliminar no fue hallado";
                return (respuesta);
            }
            catch (Exception ex)
            {
                respuesta.Mensaje = "Error interno" + ex.Message;
                return respuesta;
            }
        }

        //modificacion

        public async Task<RespuestaPrivada<TurnoDTO>> PutTurno(int id, TurnoDTO turnoDTO)
        {
            var respuesta = new RespuestaPrivada<TurnoDTO>();
            respuesta.Datos = null;

            try
            {
                var turnoBD = await _context.Turnos.FindAsync(id);
                if (turnoBD != null)
                {

                    turnoBD.Tipo = turnoDTO.Tipo;

                    await _context.SaveChangesAsync();
                    respuesta.Datos = turnoBD.Adapt<TurnoDTO>();
                    respuesta.Exito = true;
                    respuesta.Mensaje = "El turno se ha modificado correctamente";
                    return respuesta;
                }
                respuesta.Mensaje = "El turno a modificar no fue hallado";
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
