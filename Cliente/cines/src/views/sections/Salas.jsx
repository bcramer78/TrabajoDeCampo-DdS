import React, { useState, useEffect } from 'react'
import { Form, Container, Row, Col, Table, Button } from 'react-bootstrap'
import { Trash2 } from 'lucide-react'
import CancelarBtn from '../../components/buttons/CancelarBtn';
import GuardarBtn from '../../components/buttons/GuardarBtn';
import { useNavigate } from 'react-router-dom';
import { useForm } from "react-hook-form";
import { createSala, deleteSala } from '../../helpers/sala/salaService'

const Salas = ({cineId}) => {
    const [error, setError] = useState('');
    const [selectedTipo, setSelectedTipo] = useState('')
    const [items, setItems] = useState([])
    const { register, handleSubmit, reset, setValue, formState: { errors } } = useForm();
    const navigate = useNavigate();
  
    const onSubmit = async (data) => {
    
      const numeroSala = parseInt(data.numeroSala, 10);
      console.log("Datos enviados:", { numeroSala, tipo: data.tipo, cineId });

      const nuevaSala = {
          numero: data.numeroSala, 
          tipo: data.tipo,
          cineId: cineId
      };

      

      try {
          const response = await createSala(nuevaSala); // Llamada a la API para guardar en la base de datos
          setItems(prevItems => [
              ...prevItems,
              {
                  id: nuevaSala.numero, 
                  sala: nuevaSala.numero, 
                  tipo: nuevaSala.tipo
              }
          ]);
          reset(); // Limpia el formulario después de agregar
      } catch (error) {
          setError(error.message);
          console.log(error);
      }
  };
  
  const handleDelete = async (numeroSala) => {
    try {
        console.log("numero sala", numeroSala);
        await deleteSala(numeroSala);

        setItems((prevItems) => prevItems.filter((item) => item.sala !== numeroSala));
    } catch (error) {
        console.error("Error al eliminar la sala:", error);
        setError("No se pudo eliminar la sala. Inténtalo nuevamente.");
    }
};

    const handleCancel = () => {
      navigate('/');
    }
  
    return (
      <Container className="mt-4">
            <Row className="mb-4 align-items-end">
                <Col md={4}>
                    <Form.Group className="mt-3" controlId="formNumeroSala">
                        <Form.Label>Numero de Sala</Form.Label>
                        <Form.Control 
                            type="number"
                            placeholder="número sala"
                            {...register("numeroSala", {
                                required: "Este campo es obligatorio",
                                valueAsNumber: true,
                            })}
                            isInvalid={!!errors.numeroSala}
                        />
                        <Form.Control.Feedback type="invalid">
                            {errors.numeroSala && errors.numeroSala.message}
                        </Form.Control.Feedback>
                    </Form.Group>
                </Col>
                <Col md={4}>
                    <Form.Group className="mt-3" controlId="formTipo">
                        <Form.Label>Tipo</Form.Label>
                        <Form.Select 
                            {...register("tipo", { required: "Este campo es obligatorio" })}
                            isInvalid={!!errors.tipo}
                        >
                            <option value="">Seleccione un tipo</option>
                            <option value="2D">2D</option>
                            <option value="3D">3D</option>
                            <option value="4D">4D</option>
                        </Form.Select>
                        <Form.Control.Feedback type="invalid">
                            {errors.tipo && errors.tipo.message}
                        </Form.Control.Feedback>
                    </Form.Group>
                </Col>
                <Col md={2}>
                    <Button 
                        variant="primary" 
                        onClick={handleSubmit(onSubmit)} // Usa handleSubmit con la función onSubmit
                        disabled={!!errors.tipo || !!errors.numeroSala}
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
                                    onClick={() => handleDelete(item.sala)}
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