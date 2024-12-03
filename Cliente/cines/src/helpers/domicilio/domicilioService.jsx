import axios from "axios";

// POST
export async function createDomicilio(nuevoDomicilio) {
    try {
        const response = await axios.post("https://localhost:7297/api/Domicilio/crearDomicilio", nuevoDomicilio);
        return response;
    } catch (error) {
        console.log("Este es el error: ", error.response.data.mensaje)
        throw new Error(error.response.data.mensaje);
    }
};

// GET: Obtener ID del domicilio
export async function obtenerDomicilioId(calle, numero) { 
    try {
        const response = await axios.get(`https://localhost:7297/api/Domicilio/obtenerDomicilioId?calle=${calle}&numero=${numero}`);
        return response;
    } catch (error) {
        console.log("Este es el error al obtener el domicilio: ", error.response.data.mensaje);
        throw new Error(error.response.data.mensaje);
    }
};



