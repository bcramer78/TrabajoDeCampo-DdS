import React, {useState} from 'react';
import BtnAltaCine from '../components/buttons/AltaCineBtn.jsx';
import MenuTitulo from '../components/titles/MenuTtl.jsx';

const MenuPrincipal = () => {
    console.log('Rendering MenuPrincipal');
    return (
        <div className='d-flex justify-content-center align-items-center w-100' style={{ height: '100vh' }}>
            <div className='d-flex flex-column align-items-center'>
                <MenuTitulo />
                <BtnAltaCine>Alta Cine</BtnAltaCine>
            </div>
        </div>
    );
    
}

export default MenuPrincipal;