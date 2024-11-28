import React from 'react';
import { Form, Container, Row, Col } from 'react-bootstrap'
import GuardarBtn from '../components/buttons/GuardarBtn';
import CancelarBtn from '../components/buttons/CancelarBtn';

const AltaProvincia = () => {
    return (
        <div className='d-flex justify-content-center align-items-center w-100' style={{ height: '100vh' }}>
            <div className='d-flex flex-column align-items-center'>
                <Container className="mt-4">
                    <Form>
                        <Row className="mb-4">
                            <Col md={12}>
                                <Form.Group controlId="formName">
                                    <Form.Label>Nombre</Form.Label>
                                    <Form.Control type="text" />
                                </Form.Group>
                            </Col>
                        </Row>
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

export default AltaProvincia;