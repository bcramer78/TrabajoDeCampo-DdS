import { Form, Container, Row, Col, Button } from 'react-bootstrap'
import React from 'react';
import CancelarBtn from '../../components/buttons/CancelarBtn';
import GuardarBtn from '../../components/buttons/GuardarBtn';
import { useNavigate } from 'react-router-dom';

const Domicilio = () => {
    const navigate = useNavigate();

    const handleClickProvincia = () => {
      navigate('/altaProvincia', { state: { from: 'domicilio' } });  
    };

    const handleClickLocalidad = () => {
      navigate('/altaLocalidad', { state: { from: 'domicilio' } })
    }

    const handleCancel = () => {
      window.location.reload();
    }


    return (
        <Container className="mt-4">
          <Form>
            <Row className="mb-3">
              <Col md={6}>
                <Form.Group controlId="formStreet">
                  <Form.Label>Calle</Form.Label>
                  <Form.Control type="text" />
                </Form.Group>
              </Col>
              <Col md={6}>
                <Form.Group controlId="formNumber">
                  <Form.Label>Numero</Form.Label>
                  <Form.Control type="text" />
                </Form.Group>
              </Col>
            </Row>

            <Row className="mb-4 align-items-end">
              <Col md={10}>
                <Form.Group  controlId="formProvince">
                  <Form.Label>Provincia</Form.Label>
                  <Form.Select>
                    <option value="">Seleccione una provincia</option>
                    <option value="buenosaires">Buenos Aires</option>
                    <option value="cordoba">Córdoba</option>
                    <option value="santafe">Santa Fe</option>
                  </Form.Select>
                </Form.Group>
              </Col>
    
              <Col md={2}>
                  <Button 
                  variant="primary" 
                  onClick={handleClickProvincia}
                  className="w-20 mt-3"> + </Button>
              </Col>
            </Row>

            <Row className="mb-5 align-items-end">
              <Col md={10}>
                  <Form.Group controlId="formLocation">
                    <Form.Label>Localidad</Form.Label>
                    <Form.Select>
                      <option value="">Seleccione una localidad</option>
                      <option value="loc1">Localidad 1</option>
                      <option value="loc2">Localidad 2</option>
                      <option value="loc3">Localidad 3</option>
                    </Form.Select>
                  </Form.Group>
              </Col>
    
              <Col md={2}>
                  <Button 
                  variant="primary" 
                  onClick={handleClickLocalidad}
                  className="w-20 mt-3"> + </Button>
              </Col>
            </Row>

            <div className="d-flex justify-content-end gap-2">
              <GuardarBtn/>
              <CancelarBtn onClick={handleCancel}/>
            </div>
          </Form>
        </Container>
    )
    
}

export default Domicilio;