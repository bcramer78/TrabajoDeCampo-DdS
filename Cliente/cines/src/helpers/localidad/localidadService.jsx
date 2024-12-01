import axios from "axios";

// GET
export async function getLocalidades() {
    try {
        const response = await axios.get("https://localhost:7297/api/Localidad/obtenerLocalidades");
        return response;
    } catch (error) {
        console.log(error.response);
        throw new Error(error.response.data.mensaje);
    }
}

// POST
export async function createLocalidad(nuevaLocalidad) {
    try {
        const response = await axios.post("https://localhost:7297/api/Localidad/crearLocalidad", nuevaLocalidad);
        return response;
    } catch (error) {
        console.log("Este es el error: ", error.response.data.mensaje)
        throw new Error(error.response.data.mensaje);
    }
};

//DELETE
export async function deleteLocalidad(localidadId) {
    try {
        const response = await axios.delete(`https://localhost:7297/api/Localidad/eliminarLocalidad?id=${localidadId}`);
        return response;
    } catch (error) {
        throw new Error(error.response.data.mensaje);
    }
}

//EDIT
export async function updateLocalidad(localidadId, localidadData) {
    try {
        const response = await axios.put(`https://localhost:7297/api/Localidad/modificarLocalidad?id=${localidadId}`, localidadData);
        return response;
    } catch (error) {
        console.log("Error en el service", error.response);
        throw new Error(error.response.data.mensaje);
    } 
};