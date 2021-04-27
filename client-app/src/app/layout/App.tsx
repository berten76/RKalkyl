import React, { Fragment, useEffect } from 'react';
import { Container } from 'semantic-ui-react'
import NavBar from './navbar';
import MealDashBoard from '../../features/Meals/dashboard/MealDashBoard';
import { useStore } from '../stores/store';
import { observer } from 'mobx-react-lite';
import LoadingComponent from './LoadingComponent';
import { Route, Switch } from 'react-router';
import HomePage from '../../features/home/HomePage';
import MealDetails from '../../features/Meals/details/MealDetails';
import TestErrors from '../../features/errors/TestError';
import { ToastContainer } from 'react-toastify';
import NotFound from '../../features/errors/NotFound';

function App() {
  const {mealStore} = useStore();

  useEffect(() => {
     mealStore.loadMeals();
     mealStore.loadFoodItems();
  }, [mealStore])


  if (mealStore.lodingInitial) return <LoadingComponent content='Loading...' />
  return (
    <Fragment> 
      <ToastContainer position='bottom-right' hideProgressBar/>
      <NavBar />
        <Container style={{marginTop: '7em'}}>
          <Switch>
            <Route exact path='/' component={HomePage} />
            <Route exact path='/meals' component={MealDashBoard} />
            <Route path='/meals/:id' component={MealDetails} />
            <Route path='/errors' component={TestErrors}/>
            <Route component={NotFound} />
          </Switch>
          
        </Container>
    </Fragment>
  );
}

export default observer(App);
