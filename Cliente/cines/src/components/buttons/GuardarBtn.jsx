import React, {useState} from 'react';
import { useNavigate } from 'react-router-dom'; 
import { Form, Button, Container, Row, Col } from 'react-bootstrap';

const GuardarBtn = () => {

    const [isActive, setIsActive] = useState(false);
    const navigate = useNavigate(); 
    const handleMouseDown = () => setIsActive(true);
    const handleMouseUp = () => setIsActive(false);


    return (
        <div className='d-flex justify-content-center'>
            <Button 
                onMouseDown={handleMouseDown} 
                onMouseUp={handleMouseUp}
                variant="primary" 
                type="submit"> Guardar
            </Button>
        </div>
    );
};

export default GuardarBtn;