import React from 'react';
import { Form, Container, Row, Col } from 'react-bootstrap'
import GuardarBtn from '../components/buttons/GuardarBtn';
import CancelarBtn from '../components/buttons/CancelarBtn';
import { useNavigate} from 'react-router-dom';

const AltaTurnoPrecio = () => {
    const navigate = useNavigate();
    const handleCancel = () => {
        navigate('/'); 
    };

    return (
        <div className='d-flex justify-content-center align-items-center w-100' style={{ height: '100vh' }}>
            <div className='d-flex flex-column align-items-center'>
                <Container className="mt-4">
                    <Row className="mb-4 align-items-end">
                        <Col md={4}>
                            <Form.Group className="mt-0 mb-3" controlId="formPrecio">
                                <Form.Label>Precio</Form.Label>
                                <Form.Control type="number"placeholder="Ingrese el precio"/>
                            </Form.Group>
                        </Col>
                        <Col md={4}>
                            <Form.Group className="mb-3" controlId="formTurno">
                                <Form.Label>Turno</Form.Label>
                                <Form.Select>
                                <option value="">Seleccione un turno</option>
                                <option value="mañana">Mañana</option>
                                <option value="tarde">Tarde</option>
                                <option value="noche">Noche</option>
                                </Form.Select>
                            </Form.Group>
                        </Col>
                        <Col md={4}>
                        <Form.Group className="mb-3" controlId="formCine">
                                <Form.Label>Cine</Form.Label>
                                <Form.Select>
                                    <option value="">Seleccione un cine</option>
                                </Form.Select>
                            </Form.Group>
                        </Col>
                    </Row>

                    <div className="d-flex justify-content-end gap-2">
                        <GuardarBtn/>
                        <CancelarBtn onClick={handleCancel}/>
                    </div>
                </Container>
            </div>
        </div>
    )
};

export default AltaTurnoPrecio;