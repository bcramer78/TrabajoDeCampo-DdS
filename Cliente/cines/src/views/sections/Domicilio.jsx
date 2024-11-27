import { Form, Container, Row, Col, Button } from 'react-bootstrap'
import React from 'react';

const Domicilio = () => {
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
    
            <Form.Group className="mb-3" controlId="formProvince">
              <Form.Label>Provincia</Form.Label>
              <Form.Select>
                <option value="">Seleccione una provincia</option>
                <option value="buenosaires">Buenos Aires</option>
                <option value="cordoba">Córdoba</option>
                <option value="santafe">Santa Fe</option>
              </Form.Select>
            </Form.Group>
    
            <Form.Group className="mb-3" controlId="formLocation">
              <Form.Label>Localidad</Form.Label>
              <Form.Select>
                <option value="">Seleccione una localidad</option>
                <option value="loc1">Localidad 1</option>
                <option value="loc2">Localidad 2</option>
                <option value="loc3">Localidad 3</option>
              </Form.Select>
            </Form.Group>

            <div className="d-flex justify-content-end gap-2">
                <Button variant="primary" type="submit">
                    Guardar
                </Button>
                <Button variant="secondary" type="button">
                    Cancelar
                </Button>
            </div>
          </Form>
        </Container>
    )
    
}

export default Domicilio;