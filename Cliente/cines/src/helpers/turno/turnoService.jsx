import axios from "axios";

// GET
export async function getTurnos() {
    try {
        const response = await axios.get("https://localhost:7297/api/Turno/obtenerTurno");
        return response;
    } catch (error) {
        console.log(error.response);
        throw new Error(error.response.data.mensaje);
    }
}

// POST
export async function createTurno(nuevoTurno) {
    try {
        const response = await axios.post("https://localhost:7297/api/Turno/crearTurno", nuevoTurno);
        return response;
    } catch (error) {
        console.log("Este es el error: ", error.response.data.mensaje)
        throw new Error(error.response.data.mensaje);
    }
};

//DELETE
export async function deleteTurno(turnoId) {
    try {
        const response = await axios.delete(`https://localhost:7297/api/Turno/eliminarTurno?id=${turnoId}`);
        return response;
    } catch (error) {
        throw new Error(error.response.data.mensaje);
    }
}

//EDIT
export async function updateTurno(turnoId, turnoData) {
    try {
        const response = await axios.put(`https://localhost:7297/api/Turno/modificarTurno?id=${turnoId}`, turnoData);
        return response;
    } catch (error) {
        console.log("Error en el service", error.response);
        throw new Error(error.response.data.mensaje);
    } 
};