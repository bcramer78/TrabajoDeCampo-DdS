import React, {useState} from 'react';
import BtnAltaCine from '../components/buttons/AltaCineBtn.jsx';
import MenuTitulo from '../components/titles/MenuTtl.jsx';
import AltaProvinciaBtn from '../components/buttons/AltaProvinciaBtn.jsx';
import AltaSalaBtn from '../components/buttons/AltaSalaBtn.jsx';
import AltaTurnoBtn from '../components/buttons/AltaTurnoBtn.jsx';
import AltaLocalidadBtn from '../components/buttons/AltaLocalidadBtn.jsx';
import AltaTurnoPrecioBtn from '../components/buttons/AltaTurnoPrecioBtn.jsx';

const MenuPrincipal = () => {
    console.log('Rendering MenuPrincipal');
    return (
        <div className='d-flex justify-content-center align-items-center w-100' style={{ height: '100vh' }}>
            <div className='d-flex flex-column align-items-center'>
                <MenuTitulo />
                <BtnAltaCine>Alta Cine</BtnAltaCine>
                <AltaSalaBtn>Alta Sala</AltaSalaBtn>
                <AltaTurnoBtn>Alta Turno</AltaTurnoBtn>
                <AltaLocalidadBtn>Alta Localidad</AltaLocalidadBtn>
                <AltaProvinciaBtn>Alta Provincia</AltaProvinciaBtn>
                <AltaTurnoPrecioBtn>Alta Turno Precio</AltaTurnoPrecioBtn>
            </div>
        </div>
    );
    
}

export default MenuPrincipal;