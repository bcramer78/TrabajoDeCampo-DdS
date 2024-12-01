import axios from "axios";

// GET
export async function getSalas() {
    try {
        const response = await axios.get("https://localhost:7297/api/Sala/obtenerSalas");
        return response;
    } catch (error) {
        console.log(error.response);
        throw new Error(error.response.data.mensaje);
    }
}

// POST
export async function createSala(nuevaSala) {
    try {
        const response = await axios.post("https://localhost:7297/api/Sala/crearSala", nuevaSala);
        return response;
    } catch (error) {
        console.log("Este es el error: ", error.response.data.mensaje)
        throw new Error(error.response.data.mensaje);
    }
};

//DELETE
export async function deleteSala(salaId) {
    try {
        const response = await axios.delete(`https://localhost:7297/api/Sala/eliminarSala?id=${salaId}`);
        return response;
    } catch (error) {
        throw new Error(error.response.data.mensaje);
    }
}

//EDIT
export async function updateTurno(salaId, salaData) {
    try {
        const response = await axios.put(`https://localhost:7297/api/Sala/modificarSala?id=${salaId}`, salaData);
        return response;
    } catch (error) {
        console.log("Error en el service", error.response);
        throw new Error(error.response.data.mensaje);
    } 
};