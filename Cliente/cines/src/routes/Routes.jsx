import React from 'react'
import { Routes, Route } from 'react-router-dom'
import AltaCine from '../views/AltaCine.jsx';
import MenuPrincipal from '../views/MenuPrincipal.jsx';
import AltaLocalidad from '../views/AltaLocalidad.jsx';
import AltaProvincia from '../views/AltaProvincia.jsx';
import AltaSala from '../views/AltaSala.jsx';
import AltaTurno from '../views/AltaTurno.jsx';

const AppRoutes = () => {
    return (
        <Routes>
            <Route path='/' element={<MenuPrincipal/>} />
            <Route path='/altaCine' element={<AltaCine/>} />
            <Route path='/altaLocalidad' element={<AltaLocalidad/>} />
            <Route path='/altaProvincia' element={<AltaProvincia/>} />
            <Route path='/altaSala' element={<AltaSala/>} />
            <Route path='/altaTurno' element={<AltaTurno/>} />
        </Routes>
    )
}

export default AppRoutes;