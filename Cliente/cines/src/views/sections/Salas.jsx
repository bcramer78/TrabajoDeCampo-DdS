import React, { useState } from 'react'
import { Form, Container, Row, Col, Table, Button } from 'react-bootstrap'
import { Trash2 } from 'lucide-react'
import CancelarBtn from '../../components/buttons/CancelarBtn';
import GuardarBtn from '../../components/buttons/GuardarBtn';


const Salas = () => {
    const [selectedSala, setSelectedSala] = useState('')
    const [selectedTipo, setSelectedTipo] = useState('')
    const [items, setItems] = useState([])
  
    const handleAdd = () => {
      if (selectedSala && selectedTipo) {
        setItems([
          ...items,
          {
            sala: selectedSala,
            tipo: selectedTipo
          }
        ])
        // Reset selections
        setSelectedSala('')
        setSelectedTipo('')
      }
    }
  
    const handleDelete = (id) => {
      setItems(items.filter(item => item.id !== id))
    }
  
    return (
      <Container className="mt-4">
        <Row className="mb-4 align-items-end">
            <Col md={5}>
                <Form.Group controlId="formSala">
                <Form.Label>Sala</Form.Label>
                <Form.Select 
                    value={selectedSala}
                    onChange={(e) => setSelectedSala(e.target.value)}
                >
                    <option value="">Seleccione una sala</option>
                    <option value="sala1">Sala 1</option>
                    <option value="sala2">Sala 2</option>
                    <option value="sala3">Sala 3</option>
                </Form.Select>
                </Form.Group>
            </Col>
            <Col md={5}>
                <Form.Group controlId="formTipo">
                <Form.Label>Tipo</Form.Label>
                <Form.Select
                    value={selectedTipo}
                    onChange={(e) => setSelectedTipo(e.target.value)}
                >
                    <option value="">Seleccione un tipo</option>
                    <option value="tipo1">Tipo 1</option>
                    <option value="tipo2">Tipo 2</option>
                    <option value="tipo3">Tipo 3</option>
                </Form.Select>
                </Form.Group>
            </Col>
            <Col md={2}>
                <Button 
                variant="primary" 
                onClick={handleAdd}
                disabled={!selectedSala || !selectedTipo}
                className="w-20"> + </Button>
            </Col>
            </Row>
    
            <Table bordered hover>
            <thead className="bg-light">
                <tr>
                <th>Sala</th>
                <th>Tipo</th>
                <th>Acción</th>
                </tr>
            </thead>
            <tbody>
                {items.map((item) => (
                <tr key={item.id}>
                    <td>{item.sala}</td>
                    <td>{item.tipo}</td>
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
            <GuardarBtn/>
            <CancelarBtn/>
        </div>
      </Container>
    )
}

export default Salas;