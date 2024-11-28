import React, {useState} from 'react';
import { useNavigate } from 'react-router-dom'; 
import { Form, Button, Container, Row, Col } from 'react-bootstrap';

const CancelarBtn = () => {

    const [isActive, setIsActive] = useState(false);
    const navigate = useNavigate(); 
    const handleMouseDown = () => setIsActive(true);
    const handleMouseUp = () => setIsActive(false);

    const handleClick = () => {
        navigate('/');  
    };

    return (
        <div className='d-flex justify-content-center'>
            <Button 
                onClick={handleClick} 
                onMouseDown={handleMouseDown} 
                onMouseUp={handleMouseUp}
                variant="secondary" 
                type="button"> Cancelar
            </Button>
        </div>
    );
};

export default CancelarBtn;