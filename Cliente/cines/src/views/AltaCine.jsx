import Tab from 'react-bootstrap/Tab';
import Tabs from 'react-bootstrap/Tabs';
import React, {useState} from 'react';
import Cine from './sections/Cine.jsx';
import Domicilio from './sections/Domicilio';
import Salas from './sections/Salas';
import Turnos from './sections/Turnos';

function AltaCine() {
  const [activeTab, setActiveTab] = useState("domicilio");
  const [domicilioId, setDomicilioId] = useState(null);
  const [cineId, setCineId] = useState(null);
  const [domicilioGuardado, setDomicilioGuardado] = useState(false);
  const [cineGuardado, setCineGuardado] = useState(false);
  const [cineData, setCineData] = useState({
    nombre: '',
    numero: '',
    telefono: '',
  });

  const handleGuardarCine = (data) => {
    setCineGuardado(true);
    setCineData(data); 
    setActiveTab("salas"); 
  };

  const handleGuardarDomicilio = () => {
    setDomicilioGuardado(true); 
    setActiveTab("home"); 
  };

    return (
        <Tabs
          activeKey={activeTab}
          onSelect={(k) => setActiveTab(k)} 
          id="noanim-tab-example"
          className="mb-3"
        >
            <Tab eventKey="home" title="Cine" disabled={!domicilioGuardado}>
              <Cine onGuardar={handleGuardarCine} cineData={cineData} setCineData={setCineData} domicilioId={domicilioId} setCineId={setCineId}/>
            </Tab>
            <Tab eventKey="domicilio" title="Domicilio">
              <Domicilio onGuardar={handleGuardarDomicilio} setDomicilioId={setDomicilioId}/>
            </Tab>
            <Tab eventKey="salas" title="Salas" disabled={!cineGuardado} >
            <Salas cineId={cineId}/>
            </Tab>
            <Tab eventKey="turnos" title="Turnos" disabled={!cineGuardado} >
              <Turnos cineId={cineId}/>
            </Tab>
        </Tabs>
    );
}

export default AltaCine;