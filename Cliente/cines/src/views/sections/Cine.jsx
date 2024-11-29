import React, {useState} from 'react';
import { Form, Button, Container, Row, Col } from 'react-bootstrap'
import CancelarBtn from '../../components/buttons/CancelarBtn';
import GuardarBtn from '../../components/buttons/GuardarBtn';
import { useNavigate } from 'react-router-dom';

const Cine = () =>{
    const navigate = useNavigate(); 
    const handleCancel = () => {
       
        navigate('/'); 
        
    };

    return (
        <Container className="mt-4">
        <Form>
            <Row className="mb-3">
                <Col md={6}>
                    <Form.Group controlId="formName">
                        <Form.Label>Nombre</Form.Label>
                        <Form.Control type="text" />
                    </Form.Group>
                </Col>
                <Col md={6}>
                    <Form.Group controlId="formNumber">
                        <Form.Label>Numero</Form.Label>
                        <Form.Control type="text" disabled className="bg-secondary text-white" />
                    </Form.Group>
                </Col>
            </Row>

            <Form.Group className="mb-5" controlId="formPhone">
                <Form.Label>Teléfono</Form.Label>
                <Form.Control type="tel" />
            </Form.Group>

            <div className="d-flex justify-content-end gap-2">
                <GuardarBtn/>
                <CancelarBtn onClick={handleCancel}/>
            </div>
        </Form>
    </Container>
    )
}

export default Cine;