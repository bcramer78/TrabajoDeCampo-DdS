using CORE.DTOs;
using DataBase.Models;

namespace Servicios.Interfaces
{
    public interface ITurnoPrecioService
    {
        Task<RespuestaPrivada<ICollection<TurnoPrecioDTOConId>>> GetTurnosPrecios();
        Task<RespuestaPrivada<TurnoPrecioDTO>> PostTurnoPrecio(TurnoPrecioDTO turnoPrecioDTO);
        Task<RespuestaPrivada<TurnoPrecio>> DeleteTurnoPrecio(int id);
        Task<RespuestaPrivada<TurnoPrecioDTO>> PutTurnoPrecio(int id, TurnoPrecioDTO turnoPrecioDTO);
    }
}