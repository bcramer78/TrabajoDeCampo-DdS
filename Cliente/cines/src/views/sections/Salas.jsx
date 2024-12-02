import React, { useState, useEffect } from 'react'
import { Form, Container, Row, Col, Table, Button } from 'react-bootstrap'
import { Trash2 } from 'lucide-react'
import CancelarBtn from '../../components/buttons/CancelarBtn';
import GuardarBtn from '../../components/buttons/GuardarBtn';
import { useNavigate } from 'react-router-dom';
import { getSalas } from '../../helpers/sala/salaService'
import { useForm } from "react-hook-form";

const Salas = () => {
    const [salas, setSalas] = useState([]);
    const [error, setError] = useState('');
    const [selectedTipo, setSelectedTipo] = useState('')
    const [items, setItems] = useState([])
    const { register, handleSubmit, reset, setValue, formState: { errors } } = useForm();

    useEffect(() => {

      async function ObtenerSalas() {
          try {
            const response = await getSalas(); 
            setSalas(response.data.datos);
          } catch (error) {
            console.error("Error al obtener las salas:", error);
            setError("Error al obtener los datos.");
          }
      }
  
      ObtenerSalas();
    }, []);
  
    const handleAdd = () => {
      if (selectedTipo) {
        const lastSalaNumber = Math.max(...salas.map(sala => sala.numero), 0);
        const newSalaNumber = lastSalaNumber + 1;
        setItems([
          ...items,
          {
            id: newSalaNumber,
            sala: newSalaNumber,
            tipo: selectedTipo
          }
        ])
        setSelectedTipo('');
      }
    }
  
    const handleDelete = (id) => {
      setItems(items.filter(item => item.id !== id))
    }

    const handleCancel = () => {
      window.location.reload();
    }
  
    return (
      <Container className="mt-4">
        <Row className="mb-4 align-items-end">
            <Col md={4}>
                <Form.Group className="mt-3" controlId="formTipo">
                <Form.Label>Tipo</Form.Label>
                <Form.Select
                    value={selectedTipo}
                    onChange={(e) => setSelectedTipo(e.target.value)}
                >
                    <option value="">Seleccione un tipo</option>
                    <option value="2D">2D</option>
                    <option value="3D">3D</option>
                    <option value="HD">HD</option>
                </Form.Select>
                </Form.Group>
            </Col>
            <Col md={2}>
                <Button 
                variant="primary" 
                onClick={handleAdd}
                disabled={!selectedTipo}
                className="w-20 mt-3"> + </Button>
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
            <CancelarBtn onClick={handleCancel}/>
        </div>
      </Container>
    )
}

export default Salas;