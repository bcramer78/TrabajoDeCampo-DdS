import React, {useState} from 'react';
import { Form, Button, Container, Row, Col } from 'react-bootstrap'
import CancelarBtn from '../../components/buttons/CancelarBtn';
import GuardarBtn from '../../components/buttons/GuardarBtn';
import { useNavigate } from 'react-router-dom';
import { createCine, obtenerCineId } from '../../helpers/cine/cineService'

const Cine = ({ cineData, setCineData, onGuardar, domicilioId, setCineId }) =>{
    const navigate = useNavigate();
    console.log("Estoy en la seccion cine, id del domicilio: ", domicilioId);

    const handleCancel = () => {
       
        navigate('/'); 
        
    };

    const handleGuardar = async () => {
        const { nombre, numero, telefono } = cineData;
    
        if (nombre && numero && telefono && domicilioId) {
            const cineWithDomicilio = { ...cineData, domicilioId };

            try {
                const response = await createCine(cineWithDomicilio);
                console.log('Cine creado exitosamente:', response);

                const cineIdResponse = await obtenerCineId(cineWithDomicilio.nombre);
                if (cineIdResponse?.data?.datos) {
                    const cineId = cineIdResponse.data.datos;
                    setCineId(cineId);  
                    console.log('Estoy en la seccion cine, id', cineId);
                }
                onGuardar(cineData); 
            } catch (error) {
                console.error('Error al crear el cine:', error);
                alert('Hubo un error al guardar el cine');
            }

             
        } else {
          alert("Por favor, complete todos los campos antes de guardar.");
        }
      };

    const handleChange = (e) => {
        const { id, value } = e.target;
        setCineData({ ...cineData, [id]: value }); 
    };

    return (
        <Container className="mt-4">
        <Form>
            <Row className="mb-3">
                <Col md={6}>
                    <Form.Group controlId="nombre">
                        <Form.Label>Nombre</Form.Label>
                        <Form.Control
                            type="text"
                            value={cineData.nombre}
                            onChange={handleChange} 
                        />
                    </Form.Group>
                </Col>
                <Col md={6}>
                    <Form.Group controlId="numero">
                        <Form.Label>Numero</Form.Label>
                        <Form.Control 
                            type="text"
                            value={cineData.numero}
                            onChange={handleChange}
                        />
                    </Form.Group>
                </Col>
            </Row>

            <Form.Group className="mb-5" controlId="telefono">
                <Form.Label>Teléfono</Form.Label>
                <Form.Control 
                    type="tel"
                    value={cineData.telefono}
                    onChange={handleChange} 
                />
            </Form.Group>

            <div className="d-flex justify-content-end gap-2">
                <Button variant="primary" onClick={handleGuardar}>
                    Guardar
                </Button>
                <CancelarBtn onClick={handleCancel}/>
            </div>
        </Form>
    </Container>
    )
}

export default Cine;