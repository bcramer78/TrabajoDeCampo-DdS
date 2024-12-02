import {useState, useEffect} from 'react';
import { Form, Container, Row, Col, Button } from 'react-bootstrap'
import React from 'react';
import CancelarBtn from '../../components/buttons/CancelarBtn';
import GuardarBtn from '../../components/buttons/GuardarBtn';
import { useNavigate, useLocation } from 'react-router-dom';
import { getProvincias } from '../../helpers/provincia/provinciaService'
import { getLocalidades } from '../../helpers/localidad/localidadService'
import { createDomicilio } from '../../helpers/domicilio/domicilioService'
import { useForm } from "react-hook-form";

const Domicilio = ({ cineData }) => {
    const location = useLocation();
    const { nombre, numero, telefono } = location.state || {};
    const [provincias, setProvincias] = useState([]);
    const [localidades, setLocalidades] = useState([]);
    const [filteredLocalidades, setFilteredLocalidades] = useState([]);
    const [selectedProvincia, setSelectedProvincia] = useState("");
    const [error, setError] = useState('');
    const { register, handleSubmit, reset, setValue, formState: { errors } } = useForm();
    const navigate = useNavigate();

    console.log("Datos recibidos en Domicilio:", cineData);

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

    useEffect(() => {

      async function ObtenerLocalidades() {
          try {
              const response = await getLocalidades(); 
              setLocalidades(response.data.datos);
          } catch (error) {
              console.error("Error al obtener las localidades:", error);
              setError("Error al obtener los datos.");
          }
      }
  
      ObtenerLocalidades();
    }, []);

    const handleProvinciaChange = (e) => {

      const provinciaId = e.target.value;
      setSelectedProvincia(provinciaId);
  
      const filtradas = localidades.filter(localidad => String(localidad.provinciaId) === provinciaId);
      setFilteredLocalidades(filtradas);

    };

    const handleClickProvincia = () => {
      navigate('/altaProvincia', { state: { from: 'domicilio' } });  
    };

    const handleClickLocalidad = () => {
      navigate('/altaLocalidad', { state: { from: 'domicilio' } })
    }

    const handleCancel = () => {
      window.location.reload();
    }

    const onSubmit = async (data) => {
      try {
          const response = await createDomicilio(data); 
          console.log('Domicilio creado exitosamente:', response.data);
          navigate('/'); // Navega a la página principal o muestra un mensaje de éxito
      } catch (error) {
          console.error('Error al crear el domicilio:', error);
          setError('Error al crear el domicilio.');
      }
    };


    return (
        <Container className="mt-4">
          <Form>
            <Row className="mb-3">
              <Col md={6}>
                <Form.Group controlId="formStreet">
                  <Form.Label>Calle</Form.Label>
                  <Form.Control 
                    type="text"
                    {...register('calle', { required: 'La calle es requerida' })}
                   />
                </Form.Group>
              </Col>
              <Col md={6}>
                <Form.Group controlId="formNumber">
                  <Form.Label>Numero</Form.Label>
                  <Form.Control 
                    type="text"
                    {...register('numero', { required: 'El número es requerido' })}
                  />
                </Form.Group>
              </Col>
            </Row>

            <Row className="mb-4 align-items-end">
              <Col md={10}>
                <Form.Group controlId="provinciaId" className="mb-3">
                <Form.Label>Provincia</Form.Label>
                <Form.Select
                    {...register('provinciaId', { required: 'La provincia es requerida' })}
                    onChange={handleProvinciaChange}
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
    
              <Col md={2}>
                  <Button 
                  variant="primary" 
                  onClick={handleClickProvincia}
                  className="w-20 mt-3"> + </Button>
              </Col>
            </Row>

            <Row className="mb-5 align-items-end">
              <Col md={10}>
              <Form.Group controlId="localidadId">
                <Form.Label>Localidad</Form.Label>
                <Form.Select
                  {...register('localidadId', { required: 'La localidad es requerida' })}
                >
                  <option value="">Seleccione una localidad</option>
                  {filteredLocalidades.map((localidad) => (
                    <option key={localidad.id} value={localidad.id}>
                      {localidad.nombre}
                    </option>
                  ))}
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