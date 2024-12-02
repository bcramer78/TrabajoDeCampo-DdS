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

// GET
export async function getDomicilios() {
    try {
        const response = await axios.get("https://localhost:7297/api/Localidad/obtenerLocalidades");
        return response;
    } catch (error) {
        console.log(error.response);
        throw new Error(error.response.data.mensaje);
    }
}


