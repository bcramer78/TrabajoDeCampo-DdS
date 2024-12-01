using CORE.DTOs;
using DataBase.Models;

namespace Servicios.Interfaces
{
    public interface ITurnoService
    {
        Task<RespuestaPrivada<ICollection<TurnoDTOConId>>> GetTurnos();
        Task<RespuestaPrivada<TurnoDTO>> PostTurno(TurnoDTO turnoDTO);
        Task<RespuestaPrivada<Turno>> DeleteTurno(int id);
        Task<RespuestaPrivada<TurnoDTO>> PutTurno(int id, TurnoDTO turnoDTO);
    }
}