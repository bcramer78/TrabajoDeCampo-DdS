import React, {useState} from 'react';
import { useNavigate } from 'react-router-dom'; 

const BtnAltaCine = ({ children }) => {

    const [isActive, setIsActive] = useState(false);
    const navigate = useNavigate(); 
    const handleMouseDown = () => setIsActive(true);
    const handleMouseUp = () => setIsActive(false);

    const handleClick = () => {
        console.log('Redirecting to /altaCine');
        navigate('/altaCine');  // Redirige a la ruta de altaCine
    };


    return (
        <div className='d-flex justify-content-center'>
            <button 
                onClick={handleClick} 
                className={`rounded d-flex justify-content-center align-items-center mx-auto text-center w-100`} 
                onMouseDown={handleMouseDown} 
                onMouseUp={handleMouseUp}> {children}
            </button>
        </div>
    );
};

export default BtnAltaCine;