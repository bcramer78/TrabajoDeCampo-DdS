import React, {useState} from 'react';
import { Form, Button, Container, Row, Col } from 'react-bootstrap'
import GuardarBtn from '../components/buttons/GuardarBtn';
import CancelarBtn from '../components/buttons/CancelarBtn';
import { useNavigate, useLocation } from 'react-router-dom';

const AltaTurno = () => {
    const navigate = useNavigate(); 
    const location = useLocation(); 
    const handleCancel = () => {
        if (location.state?.from === 'turnos') {
            navigate('/altaCine'); 
        } else {
            navigate('/'); 
        }
    };

    return (
        <div className='d-flex justify-content-center align-items-center w-100' style={{ height: '100vh' }}>
            <div className='d-flex flex-column align-items-center'>
                <Container className="mt-4">
                    <Form>
                        <Row className="mb-4">
                            <Col md={12}>
                                <Form.Group controlId="formName">
                                    <Form.Label>Nombre del turno</Form.Label>
                                    <Form.Control type="text" />
                                </Form.Group>
                            </Col>
                        </Row>

                        <div className="d-flex justify-content-end gap-2">
                            <GuardarBtn/>
                            <CancelarBtn onClick={handleCancel}/>
                        </div>
    
                    </Form>
                </Container>
            </div>
        </div>
    )
}

export default AltaTurno;