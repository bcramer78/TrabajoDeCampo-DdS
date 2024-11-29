import React, {useState} from 'react';
import { useNavigate } from 'react-router-dom'; 
import { Form, Button, Container, Row, Col } from 'react-bootstrap';

const CancelarBtn = ({ onClick }) => {

    const [isActive, setIsActive] = useState(false);
    const handleMouseDown = () => setIsActive(true);
    const handleMouseUp = () => setIsActive(false);

    return (
        <div className='d-flex justify-content-center'>
            <Button 
                onClick={onClick} 
                onMouseDown={handleMouseDown} 
                onMouseUp={handleMouseUp}
                variant="secondary" 
                type="button"> Cancelar
            </Button>
        </div>
    );
};

export default CancelarBtn;