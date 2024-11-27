import React, { useState } from 'react'
import { Form, Container, Row, Col, Table, Button } from 'react-bootstrap'
import { Trash2 } from 'lucide-react'

const Turnos = () => {
    const [selectedTurno, setSelectedTurno] = useState('')
    const [precio, setPrecio] = useState('')
    const [items, setItems] = useState([])
  
    const handleAdd = () => {
      if (selectedTurno && precio) {
        setItems([
          ...items,
          {
            turno: selectedTurno,
            precio: precio
          }
        ])
        setSelectedTurno('')
        setPrecio('')
      }
    }
  
    const handleDelete = (id) => {
      setItems(items.filter(item => item.id !== id))
    }

    return (
        <Container className="mt-4">
          <Row className="mb-4 align-items-end">
            <Col md={5}>
              <Form.Group controlId="formTurno">
                <Form.Label>Turno</Form.Label>
                <Form.Select 
                  value={selectedTurno}
                  onChange={(e) => setSelectedTurno(e.target.value)}
                >
                  <option value="">Seleccione un turno</option>
                  <option value="mañana">Mañana</option>
                  <option value="tarde">Tarde</option>
                  <option value="noche">Noche</option>
                </Form.Select>
              </Form.Group>
            </Col>
            <Col md={5}>
              <Form.Group controlId="formPrecio">
                <Form.Label>Precio</Form.Label>
                <Form.Control
                  type="number"
                  value={precio}
                  onChange={(e) => setPrecio(e.target.value)}
                  placeholder="Ingrese el precio"
                />
              </Form.Group>
            </Col>
            <Col md={2}>
              <Button 
                variant="primary" 
                onClick={handleAdd}
                disabled={!selectedTurno || !precio}
                className="w-20"
              > + </Button>
            </Col>
          </Row>
    
          <Table bordered hover>
            <thead className="bg-light">
              <tr>
                <th>Turno</th>
                <th>Precio</th>
                <th>Acción</th>
              </tr>
            </thead>
            <tbody>
              {items.map((item) => (
                <tr key={item.id}>
                  <td>{item.turno}</td>
                  <td>${item.precio}</td>
                  <td className="text-center">
                    <Button 
                      variant="link" 
                      className="text-danger p-0" 
                      onClick={() => handleDelete(item.id)}
                    >
                      <Trash2 size={20} />
                    </Button>
                  </td>
                </tr>
              ))}
            </tbody>
          </Table>

          <div className="d-flex justify-content-end gap-2">
                <Button variant="primary" type="submit">
                    Guardar
                </Button>
                <Button variant="secondary" type="button">
                    Cancelar
                </Button>
            </div>
        </Container>
    )
}

export default Turnos;
