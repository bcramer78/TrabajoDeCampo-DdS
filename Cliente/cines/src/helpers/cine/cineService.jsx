import axios from "axios";

// GET
export async function getCines() {
    try {
        const response = await axios.get("https://localhost:7297/api/Cine/obtenerCines");
        return response;
    } catch (error) {
        console.log(error.response);
        throw new Error(error.response.data.mensaje);
    }
}

// POST
export async function createCine(nuevoCine) {
    try {
        const response = await axios.post("https://localhost:7297/api/Cine/crearCine", nuevoCine);
        return response;
    } catch (error) {
        console.log("Este es el error: ", error.response.data.mensaje)
        throw new Error(error.response.data.mensaje);
    }
};

//DELETE
export async function deleteCine(cineId) {
    try {
        const response = await axios.delete(`https://localhost:7297/api/Cine/eliminarCine?id=${cineId}`);
        return response;
    } catch (error) {
        throw new Error(error.response.data.mensaje);
    }
}

//EDIT
export async function updateCine(cineId, cineData) {
    try {
        const response = await axios.put(`https://localhost:7297/api/Cine/modificarCine?id=${cineId}`, cineData);
        return response;
    } catch (error) {
        console.log("Error en el service", error.response);
        throw new Error(error.response.data.mensaje);
    } 
};

// GET: Obtener ID del cine
export async function obtenerCineId(nombre) { 
    try {
        const response = await axios.get(`https://localhost:7297/api/Cine/obtenerCineId?nombre=${nombre}`);
        return response;
    } catch (error) {
        console.log("Este es el error al obtener el cine: ", error.response.data.mensaje);
        throw new Error(error.response.data.mensaje);
    }
};