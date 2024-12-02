import Tab from 'react-bootstrap/Tab';
import Tabs from 'react-bootstrap/Tabs';
import React, {useState} from 'react';
import Cine from './sections/Cine.jsx';
import Domicilio from './sections/Domicilio';
import Salas from './sections/Salas';
import Turnos from './sections/Turnos';

function AltaCine() {
  const [activeTab, setActiveTab] = useState("home");
  const [cineData, setCineData] = useState({
    nombre: '',
    numero: '',
    telefono: '',
  });

  const handleGuardarCine = (data) => {
    setCineData(data); // Guarda los datos del cine
    setActiveTab("Domicilio"); // Cambia al tab de domicilio
  };

    return (
        <Tabs
          activeKey={activeTab}
          onSelect={(k) => setActiveTab(k)} // Cambiar el tab activo al seleccionar uno nuevo
          id="noanim-tab-example"
          className="mb-3"
        >
            <Tab eventKey="home" title="Cine">
              <Cine onGuardar={handleGuardarCine} cineData={cineData} setCineData={setCineData}/>
            </Tab>
            <Tab eventKey="domicilio" title="Domicilio">
              <Domicilio cineData={cineData}/>
            </Tab>
            <Tab eventKey="salas" title="Salas">
            <Salas/>
            </Tab>
            <Tab eventKey="turnos" title="Turnos">
              <Turnos/>
            </Tab>
        </Tabs>
    );
}

export default AltaCine;