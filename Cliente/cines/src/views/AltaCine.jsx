import Tab from 'react-bootstrap/Tab';
import Tabs from 'react-bootstrap/Tabs';
import React, {useState} from 'react';
import Cine from './sections/Cine.jsx';
import Domicilio from './sections/Domicilio';
import Salas from './sections/Salas';
import Turnos from './sections/Turnos';

function AltaCine() {
  const [activeTab, setActiveTab] = useState("home");
  const [domicilioId, setDomicilioId] = useState(null);
  const [cineId, setCineId] = useState(null);
  const [cineData, setCineData] = useState({
    nombre: '',
    numero: '',
    telefono: '',
  });

  const handleGuardarCine = (data) => {
    setCineData(data); 
    setActiveTab("salas"); 
  };

  const handleGuardarDomicilio = () => {
    setActiveTab("home"); 
  };

    return (
        <Tabs
          activeKey={activeTab}
          onSelect={(k) => setActiveTab(k)} 
          id="noanim-tab-example"
          className="mb-3"
        >
            <Tab eventKey="home" title="Cine">
              <Cine onGuardar={handleGuardarCine} cineData={cineData} setCineData={setCineData} domicilioId={domicilioId} setCineId={setCineId}/>
            </Tab>
            <Tab eventKey="domicilio" title="Domicilio">
              <Domicilio onGuardar={handleGuardarDomicilio} setDomicilioId={setDomicilioId}/>
            </Tab>
            <Tab eventKey="salas" title="Salas">
            <Salas cineId={cineId}/>
            </Tab>
            <Tab eventKey="turnos" title="Turnos">
              <Turnos cineId={cineId}/>
            </Tab>
        </Tabs>
    );
}

export default AltaCine;