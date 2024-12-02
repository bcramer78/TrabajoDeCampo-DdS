import React, {useState} from 'react';
import { Form, Button, Container, Row, Col } from 'react-bootstrap'
import CancelarBtn from '../../components/buttons/CancelarBtn';
import GuardarBtn from '../../components/buttons/GuardarBtn';
import { useNavigate } from 'react-router-dom';

const Cine = ({ cineData, setCineData, onGuardar }) =>{
    const navigate = useNavigate();

    const handleCancel = () => {
       
        navigate('/'); 
        
    };

    const handleGuardar = () => {
        const cineData = { nombre, numero, telefono };
        onGuardar(cineData); // Llama a la función pasada por props con los datos del cine
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
                <GuardarBtn />
                <CancelarBtn onClick={handleCancel}/>
            </div>
        </Form>
    </Container>
    )
}

export default Cine;