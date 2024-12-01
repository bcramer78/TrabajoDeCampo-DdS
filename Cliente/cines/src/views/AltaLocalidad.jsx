import React from 'react';
import {useState, useEffect} from 'react';
import { Form, Container, Row, Col } from 'react-bootstrap';
import GuardarBtn from '../components/buttons/GuardarBtn';
import CancelarBtn from '../components/buttons/CancelarBtn';
import { useNavigate, useLocation } from 'react-router-dom';
import { getProvincias } from '../helpers/provincia/provinciaService'
import { useForm } from "react-hook-form";

const AltaLocalidad = () => {
    const [provincias, setProvincias] = useState([]);
    const [error, setError] = useState('');
    const navigate = useNavigate(); 
    const location = useLocation(); 
    const { register, handleSubmit, reset, setValue, formState: { errors } } = useForm();

    useEffect(() => {

        async function ObtenerProvincias() {
            try {
                const response = await getProvincias(); 
                setProvincias(response.data.datos);
            } catch (error) {
                console.error("Error al obtener las provincias:", error);
                setError("Error al obtener los datos.");
            }
        }
    
        ObtenerProvincias();
      }, []);

    const handleCancel = () => {
        if (location.state?.from === 'domicilio') {
            navigate('/altaCine'); 
        } else {
            navigate('/'); 
        }
    };

    return (
        <div className='d-flex justify-content-center align-items-center w-100' style={{ height: '100vh' }}>
            <div className='d-flex flex-column align-items-center'>
                <Container className="mt-4">
                    <Form>
                        <Row className="mb-3">
                            <Col md={12}>
                                <Form.Group controlId="formName">
                                    <Form.Label>Nombre</Form.Label>
                                    <Form.Control type="text" />
                                </Form.Group>
                            </Col>
                        </Row>
                        <Row className="mb-4">
                            <Col md={12}>
                            <Form.Group controlId="provinciaId" className="mb-3">
                            <Form.Label>Provincia</Form.Label>
                            <Form.Select
                                {...register("provinciaId")}
                            >
                            <option value="">Selecciona una provincia</option>
                                {provincias.map((provincia) => (
                                    <option key={provincia.id} value={provincia.id}>
                                    {provincia.nombre} 
                                    </option>
                                ))}
                            </Form.Select>
                            </Form.Group>
                            </Col>
                        </Row>
                        <div className="d-flex justify-content-end gap-2">
                            <GuardarBtn/>
                            <CancelarBtn onClick={handleCancel} />
                        </div>
                    </Form>
                </Container>
            </div>
        </div>
    )
}

export default AltaLocalidad;