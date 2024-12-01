import React, { useState, useEffect } from 'react'
import { Form, Container, Row, Col, Table, Button } from 'react-bootstrap'
import { Trash2 } from 'lucide-react'
import CancelarBtn from '../../components/buttons/CancelarBtn';
import GuardarBtn from '../../components/buttons/GuardarBtn';
import { useNavigate} from 'react-router-dom';
import { getTurnos } from '../../helpers/turno/turnoService'
import { useForm } from "react-hook-form";

const Turnos = () => {
    const [turnos, setTurnos] = useState([]);
    const [error, setError] = useState('');
    const [selectedTurno, setSelectedTurno] = useState('')
    const [precio, setPrecio] = useState('')
    const [items, setItems] = useState([])
    const { register, handleSubmit, reset, setValue, formState: { errors } } = useForm();

    useEffect(() => {

      async function ObtenerTurnos() {
          try {
              const response = await getTurnos(); 
              setTurnos(response.data.datos);
          } catch (error) {
              console.error("Error al obtener los turnos:", error);
              setError("Error al obtener los datos.");
          }
      }
  
      ObtenerTurnos();
    }, []);
  
    const handleAdd = () => {
      if (selectedTurno && precio) {
        const turnoSeleccionado = turnos.find(turno => String(turno.id) === selectedTurno);
        setItems([
          ...items,
          {
            id: turnoSeleccionado.id,
            turno: turnoSeleccionado.tipo,
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

    
    const navigate = useNavigate();

    const handleClickTurno = () => {
      navigate('/altaTurno', { state: { from: 'turnos' } });  
    };

    const handleCancel = () => {
      window.location.reload();
    }

    return (
        <Container className="mt-4">
          <Row className="mb-4 align-items-end">
            <Col md={4}>
              <Form.Group controlId="turnoId">
                <Form.Label>Turno</Form.Label>
                <Form.Select 
                  {...register("turnoId")}
                  value={selectedTurno}
                  onChange={(e) => setSelectedTurno(e.target.value)}
                >
                  <option value="">Selecciona un turno</option>
                  {turnos.map((turno) => (
                      <option key={turno.id} value={turno.id}>
                      {turno.tipo} 
                      </option>
                  ))}
                </Form.Select>
              </Form.Group>
            </Col>

            <Col md={2}>
                <Button 
                variant="primary" 
                onClick={handleClickTurno}
                className="w-20 mt-3"> + </Button>
            </Col>

            <Col md={4}>
              <Form.Group className="mt-3" controlId="formPrecio">
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
                className="w-20 mt-3"
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
            <GuardarBtn/>
            <CancelarBtn onClick={handleCancel}/>
          </div>
        </Container>
    )

};

export default Turnos;
