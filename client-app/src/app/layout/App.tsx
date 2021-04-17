import React, { Fragment, useEffect, useState } from 'react';
import { Container } from 'semantic-ui-react'
import NavBar from './navbar';
import MealDashBoard from '../../features/Meals/dashboard/MealDashBoard';
//import agent from '../api/agent';
//import { FoodItem } from '../models/foodItem';
import { useStore } from '../stores/store';
import { observer } from 'mobx-react-lite';
import LoadingComponent from './LoadingComponent';
import { Route } from 'react-router';
import HomePage from '../../features/home/HomePage';
import MealDetails from '../../features/Meals/details/MealDetails';

function App() {
  const {mealStore} = useStore();
  //const [foodItems, setFoodItems] = useState<FoodItem[]>([]);

  useEffect(() => {
     mealStore.loadMeals();
     mealStore.loadFoodItems();
  }, [mealStore])
 /* useEffect(() => {
    mealStore.loadFoodItems();
      //agent.FoodItems.list().then(response => {
      //  setFoodItems(response);
    })
  }, [mealStore])*/


  if (mealStore.lodingInitial) return <LoadingComponent content='Loading...' />
  return (
    <Fragment> 
      <NavBar />
        <Container style={{marginTop: '7em'}}>
          <Route exact path='/' component={HomePage} />
          <Route exact path='/meals' component={MealDashBoard} />
          <Route path='/meals/:id' component={MealDetails} />
        {/*  <MealDashBoard />*/}
          
        </Container>
    </Fragment>
  );
}

export default observer(App);
