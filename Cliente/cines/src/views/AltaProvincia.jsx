import React from 'react'
import { Form, Container, Row, Col } from 'react-bootstrap'
import GuardarBtn from '../components/buttons/GuardarBtn';
import CancelarBtn from '../components/buttons/CancelarBtn';
import { useNavigate, useLocation } from 'react-router-dom';
import { createProvincia } from '../helpers/provincia/provinciaService'
import { useForm } from 'react-hook-form';

const AltaProvincia = () => {
    const { register, handleSubmit, formState: { errors, isSubmitting } } = useForm();
    const navigate = useNavigate(); 
    const location = useLocation(); 

    const handleCancel = () => {
        if (location.state?.from === 'domicilio') {
            navigate('/altaCine'); 
        } else {
            navigate('/'); 
        }
    };

    const onSubmit = async (data) => {
        try {
            const response = await createProvincia(data); 
            console.log('Provincia creada exitosamente:', response);
            if (location.state?.from === 'domicilio') {
                navigate('/altaCine'); 
            } else {
                navigate('/'); 
            }
        } catch (error) {
            console.error('Error al crear provincia:', error);
        }
    };

    return (
        <div className='d-flex justify-content-center align-items-center w-100' style={{ height: '100vh' }}>
            <div className='d-flex flex-column align-items-center'>
                <Container className="mt-4">
                    <Form onSubmit={handleSubmit(onSubmit)}>
                        <Row className="mb-4">
                            <Col md={12}>
                                <Form.Group controlId="provinciaId">
                                    <Form.Label>Nombre</Form.Label>
                                    <Form.Control
                                        type="text" 
                                        placeholder="nombre provincia"
                                        {...register('nombre', { required: 'El nombre es obligatorio' })} 
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

export default AltaProvincia;