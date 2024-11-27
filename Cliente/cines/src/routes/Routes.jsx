import React from 'react'
import { Routes, Route } from 'react-router-dom'
import AltaCine from '../views/AltaCine.jsx';
import MenuPrincipal from '../views/MenuPrincipal.jsx';

const AppRoutes = () => {
    console.log('Rendering AppRoutes');
    return (
        <Routes>
            <Route path='/' element={<MenuPrincipal/>} />
            <Route path='/altaCine' element={<AltaCine/>} />
        </Routes>
    )
}

export default AppRoutes;