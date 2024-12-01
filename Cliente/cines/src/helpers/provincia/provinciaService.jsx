import axios from "axios";

// GET
export async function getProvincias() {
    try {
        const response = await axios.get("https://localhost:7297/api/Provincia/obtenerProvincias");
        return response;
    } catch (error) {
        console.log(error.response);
        throw new Error(error.response.data.mensaje);
    }
}

// POST
export async function createProvincia(nuevaProvincia) {
    try {
        const response = await axios.post("https://localhost:7297/api/Provincia/crearProvincia", nuevaProvincia);
        return response;
    } catch (error) {
        console.log("Este es el error: ", error.response.data.mensaje)
        throw new Error(error.response.data.mensaje);
    }
};

//DELETE
export async function deleteProvincia(provinciaId) {
    try {
        const response = await axios.delete(`https://localhost:7297/api/Provincia/eliminarProvincia?id=${provinciaId}`);
        return response;
    } catch (error) {
        throw new Error(error.response.data.mensaje);
    }
}

//EDIT
export async function updateProvincia(provinciaId, provinciaData) {
    try {
        const response = await axios.put(`https://localhost:7297/api/Provincia/modificarProvincia?id=${provinciaId}`, provinciaData);
        return response;
    } catch (error) {
        console.log("Error en el service", error.response);
        throw new Error(error.response.data.mensaje);
    } 
};