import React, { Fragment, useEffect, useState } from 'react';
import axios from 'axios';
import { Container } from 'semantic-ui-react'
import { Recepie } from '../models/recepie';
import NavBar from './navbar';
import RecepieDashBoard from '../../features/Recepies/dashboard/RecepieDashBoard';

function App() {
  const [recepies, setRecepies] = useState<Recepie[]>([]);
  const [foodNames, setFoodNames] = useState<string[]>([]);

  useEffect(() => {
    axios.get<Recepie[]>('http://localhost:5000/api/Recepies').then(response => {
      setRecepies(response.data);
    })
  }, [])
  useEffect(() => {
    axios.get<string[]>('http://localhost:5000/api/FoodNames').then(response => {
      setFoodNames(response.data);
    })
  }, [])
  return (
    <Fragment>
      <NavBar/>
        <Container style={{marginTop: '7em'}}>
          <RecepieDashBoard recepies={recepies} foodNames={foodNames} />
        </Container>

    </Fragment>
  );
}

export default App;
