import React, {useState} from 'react';
import { useNavigate } from 'react-router-dom'; 

const AltaTurnoBtn = ({ children }) => {

    const [isActive, setIsActive] = useState(false);
    const navigate = useNavigate(); 
    const handleMouseDown = () => setIsActive(true);
    const handleMouseUp = () => setIsActive(false);

    const handleClick = () => {
        navigate('/altaTurno');  
    };

    return (
        <div className='d-flex justify-content-center mb-1'>
            <button 
                onClick={handleClick} 
                className={`rounded d-flex justify-content-center align-items-center mx-auto text-center w-100`} 
                onMouseDown={handleMouseDown} 
                onMouseUp={handleMouseUp}> {children}
            </button>
        </div>
    );
};

export default AltaTurnoBtn;