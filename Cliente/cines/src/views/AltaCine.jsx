import Tab from 'react-bootstrap/Tab';
import Tabs from 'react-bootstrap/Tabs';
import React, {useState} from 'react';
import Cine from './sections/Cine.jsx';
import Domicilio from './sections/Domicilio';
import Salas from './sections/Salas';
import Turnos from './sections/Turnos';

function AltaCine() {
    console.log('Rendering AltaCine');
    return (
        <Tabs
          defaultActiveKey="home"
          transition={false}
          id="noanim-tab-example"
          className="mb-3"
        >
            <Tab eventKey="home" title="Cine">
              <Cine/>
            </Tab>
            <Tab eventKey="domicilio" title="Domicilio">
              <Domicilio/>
            </Tab>
            <Tab eventKey="salas" title="Salas">
            <Salas/>
            </Tab>
            <Tab eventKey="turnos" title="Turnos">
              <Turnos/>>
            </Tab>
        </Tabs>
    );
}

export default AltaCine;