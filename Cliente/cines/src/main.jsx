import { createRoot } from 'react-dom/client'
import './index.css'
import React from 'react';
import { BrowserRouter as Router } from 'react-router-dom';
import AppRoutes from '../src/routes/Routes.jsx';
import 'bootstrap/dist/css/bootstrap.min.css'; 

createRoot(document.getElementById('root')).render(
  <Router>
    <AppRoutes/>
  </Router>
);
