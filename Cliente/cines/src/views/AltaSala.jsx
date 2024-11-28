import React, {useState} from 'react';
import { Form, Button, Container, Row, Col } from 'react-bootstrap'
import GuardarBtn from '../components/buttons/GuardarBtn';
import CancelarBtn from '../components/buttons/CancelarBtn';

const AltaSala = () => {
    return (
        <div className='d-flex justify-content-center align-items-center w-100' style={{ height: '100vh' }}>
            <div className='d-flex flex-column align-items-center'>
                <Container className="mt-4">
                    <Form>
                        <Row className="mb-2">
                            <Col md={12}>
                                <Form.Group controlId="formNumber">
                                    <Form.Label>Numero</Form.Label>
                                    <Form.Control type="text" />
                                </Form.Group>
                            </Col>
                        </Row>

                        <Form.Group className="mb-4" controlId="formProvince">
                            <Form.Label>Tipo</Form.Label>
                            <Form.Select>
                                <option value="">Seleccione un tipo</option>
                                <option value="hd">HD</option>
                                <option value="3d">3D</option>
                                <option value="4d">4D</option>
                            </Form.Select>
                        </Form.Group>

                        <div className="d-flex justify-content-end gap-2">
                            <GuardarBtn/>
                            <CancelarBtn/>
                        </div>
    
                    </Form>
                </Container>
            </div>
        </div>
    )
}

export default AltaSala;