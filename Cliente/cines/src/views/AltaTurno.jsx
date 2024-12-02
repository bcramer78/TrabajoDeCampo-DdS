import React, {useState} from 'react';
import { Form, Button, Container, Row, Col } from 'react-bootstrap'
import GuardarBtn from '../components/buttons/GuardarBtn';
import CancelarBtn from '../components/buttons/CancelarBtn';
import { useNavigate, useLocation } from 'react-router-dom';
import { createTurno } from '../helpers/turno/turnoService'
import { useForm } from 'react-hook-form';

const AltaTurno = () => {
    const navigate = useNavigate(); 
    const location = useLocation(); 
    const { register, handleSubmit, formState: { errors, isSubmitting } } = useForm();

    const handleCancel = () => {
        if (location.state?.from === 'turnos') {
            navigate('/altaCine'); 
        } else {
            navigate('/'); 
        }
    };

    const onSubmit = async (data) => {
        try {
            const response = await createTurno(data); 
            console.log('Turno creado exitosamente:', response);
            if (location.state?.from === 'turnos') {
                navigate('/altaCine'); 
            } else {
                navigate('/'); 
            }
        } catch (error) {
            console.error('Error al crear turno:', error);
        }
    };

    return (
        <div className='d-flex justify-content-center align-items-center w-100' style={{ height: '100vh' }}>
            <div className='d-flex flex-column align-items-center'>
                <Container className="mt-4">
                    <Form onSubmit={handleSubmit(onSubmit)}>
                        <Row className="mb-4">
                            <Col md={12}>
                                <Form.Group controlId="formName">
                                    <Form.Label>Nombre del turno</Form.Label>
                                    <Form.Control
                                        type="text"
                                        placeholder="tipo turno"
                                        {...register('tipo', { required: 'El tipo del turno es obligatorio' })} 
                                    />
                                </Form.Group>
                            </Col>
                        </Row>

                        <div className="d-flex justify-content-end gap-2">
                            <GuardarBtn type="submit" disabled={isSubmitting}/>
                            <CancelarBtn onClick={handleCancel}/>
                        </div>
    
                    </Form>
                </Container>
            </div>
        </div>
    )
}

export default AltaTurno;