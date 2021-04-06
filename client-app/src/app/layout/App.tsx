import React, { Fragment, useEffect, useState } from 'react';
import { Container } from 'semantic-ui-react'
import NavBar from './navbar';
import MealDashBoard from '../../features/Meals/dashboard/MealDashBoard';
import agent from '../api/agent';
import { FoodItem } from '../models/foodItem';
import { useStore } from '../stores/store';
import { observer } from 'mobx-react-lite';
import LoadingComponent from './LoadingComponent';

function App() {
  const {mealStore} = useStore();
  const [foodItems, setFoodItems] = useState<FoodItem[]>([]);

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
          
          
            
          <MealDashBoard />
          
        </Container>
    </Fragment>
  );
}

export default observer(App);
