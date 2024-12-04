import axios from "axios";

// POST
export async function createTurnoPrecio(nuevoTurnoPrecio) {
    try {
        const response = await axios.post("https://localhost:7297/api/TurnoPrecio/crearTurnoPrecio", nuevoTurnoPrecio);
        return response;
    } catch (error) {
        console.log("Este es el error: ", error.response.data.mensaje)
        throw new Error(error.response.data.mensaje);
    }
};

//DELETE
export async function deleteTurnoPrecio(turnoPrecioId) {
    try {
        const response = await axios.delete(`https://localhost:7297/api/TurnoPrecio/eliminarTurnoPrecio?id=${turnoPrecioId}`);
        return response;
    } catch (error) {
        throw new Error(error.response.data.mensaje);
    }
}