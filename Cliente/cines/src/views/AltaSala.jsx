import React, {useState, useEffect} from 'react';
import { Form, Button, Container, Row, Col } from 'react-bootstrap'
import GuardarBtn from '../components/buttons/GuardarBtn';
import CancelarBtn from '../components/buttons/CancelarBtn';
import { useNavigate, useLocation } from 'react-router-dom';

const AltaSala = () => {
    const navigate = useNavigate(); 
    const location = useLocation(); 
    const handleCancel = () => {
        if (location.state?.from === 'salas') {
            navigate('/altaCine'); 
        } else {
            navigate('/'); 
        }
    };

    const [mostrarComponente, setMostrarComponente] = useState(true);

    useEffect(() => {
        if (location.state?.from === 'salas') {
            setMostrarComponente(false); 
        } else {
            setMostrarComponente(true); 
        }
    }, [location.state]); 

    const [cines, setCines] = useState([]);

    useEffect(() => {

        async function ObtenerCines() {
            try {
                const response = await getCines(); 
                setCines(response.data.datos);
            } catch (error) {
                console.error("Error al obtener los salones:", error);
                setError("Error al obtener los datos.");
            }
        }
    
        ObtenerSalones();
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
                            <Form.Group className="mb-5" controlId="formProvince">
                                <Form.Label>Cine</Form.Label>
                                <Form.Select>
                                    <option value="">Seleccione el cine</option>
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