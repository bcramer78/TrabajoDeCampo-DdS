import React, {useState, useEffect} from 'react';
import { Form, Button, Container, Row, Col } from 'react-bootstrap'
import GuardarBtn from '../components/buttons/GuardarBtn';
import CancelarBtn from '../components/buttons/CancelarBtn';
import { useNavigate, useLocation } from 'react-router-dom';
import { getCines } from '../helpers/cine/cineService'
import { useForm } from "react-hook-form";

const AltaSala = () => {
    const [mostrarComponente, setMostrarComponente] = useState(true);
    const [cines, setCines] = useState([]);
    const [error, setError] = useState('');
    const navigate = useNavigate(); 
    const location = useLocation(); 
    const { register, handleSubmit, reset, setValue, formState: { errors } } = useForm();

    const handleCancel = () => {
        if (location.state?.from === 'salas') {
            navigate('/altaCine'); 
        } else {
            navigate('/'); 
        }
    };

    useEffect(() => {
        if (location.state?.from === 'salas') {
            setMostrarComponente(false); 
        } else {
            setMostrarComponente(true); 
        }
    }, [location.state]); 

    useEffect(() => {

        async function ObtenerCines() {
            try {
                const response = await getCines(); 
                setCines(response.data.datos);
            } catch (error) {
                console.error("Error al obtener los cines:", error);
                setError("Error al obtener los datos.");
            }
        }
    
        ObtenerCines();
      }, []);


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

                        <Form.Group className="mb-3" controlId="formProvince">
                            <Form.Label>Tipo</Form.Label>
                            <Form.Select>
                                <option value="">Seleccione un tipo</option>
                                <option value="hd">HD</option>
                                <option value="3d">3D</option>
                                <option value="4d">4D</option>
                            </Form.Select>
                        </Form.Group>

                        {mostrarComponente ?
                            <Form.Group controlId="cineId" className="mb-3">
                            <Form.Label>Cine</Form.Label>
                            <Form.Select
                                {...register("cineId")}
                            >
                            <option value="">Selecciona un cine</option>
                                {cines.map((cine) => (
                                    <option key={cine.id} value={cine.id}>
                                    {cine.nombre} 
                                    </option>
                                ))}
                            </Form.Select>
                            </Form.Group>
                        : null}

                        <div className="d-flex justify-content-end gap-2">
                            <GuardarBtn/>
                            <CancelarBtn onClick={handleCancel}/>
                        </div>
    
                    </Form>
                </Container>
            </div>
        </div>
    )
}

export default AltaSala;