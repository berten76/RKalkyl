import React, { Fragment, useEffect, useState } from 'react';
import axios from 'axios';
import { Container } from 'semantic-ui-react'
import { Recepie } from '../models/recepie';
import NavBar from './navbar';
import RecepieDashBoard from '../../features/Recepies/dashboard/RecepieDashBoard';
import { Ingredient } from '../models/ingredient';
import {v4 as uuid} from 'uuid';
function App() {
  const [recepies, setRecepies] = useState<Recepie[]>([]);
  const [foodNames, setFoodNames] = useState<string[]>([]);
  const [selectedRecepie, setSelectedRecepie] = useState<string>('');

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

  function handleCreateMeal(){
    let newMeal = {
      id: uuid(),
      name: 'New meal',
      ingredients: []
    };
    
    setRecepies([...recepies, newMeal])
  }
  function handleSelectRecepie(id: string) {
    setSelectedRecepie(id);
  }

  function handleCanceledRecepie() {
    setSelectedRecepie('');
  }

  function getSelectedRecepie(id: string) {
    if(id === ''){
      return undefined;
    }
    return recepies.find(r => r.id === id);
  }
  function HandleAddOrEditIngredient(recepieId: string, ingredient: Ingredient){
   
    let recepie = recepies.find(r => r.id === recepieId);
    if(recepie !== undefined)
    {
      let updatedIngredients = ingredient.id
        ?  [...recepie.ingredients.filter(i => i.id !== ingredient.id), ingredient]
        :  [...recepie.ingredients, {...ingredient, id: uuid()}];
      let updatedRecepie = {...recepie, ingredients: updatedIngredients};
     
      setRecepies(recepies.map(r => {
        if(r.id ===recepieId ){
           return updatedRecepie;
        }
        else{
          return r;
        }
      }));
    }
    //setRecepies(recepies);
  }

  // function handleAddOrEditRecepie(recepieId: string, ingredient: Ingredient) {
  //   if(ingredient.id) {
  //     let recepie = recepies.find(r => r.id == recepieId);
  //     if(recepie !== undefined){
  //         let recepie2 = [...recepies.filter(x=> x.id !== )]
  //     }
  //   }
   
  // }
  function HandleDeleteIngredient(recepieId: string, ingredientId: string){
   
    let recepie = recepies.find(r => r.id === recepieId);
    if(recepie !== undefined)
    {
      let ingredientList = [...recepie.ingredients.filter(i => i.id !== ingredientId)]
      const recepie2 = {...recepie,  ingredients: ingredientList};
    
      setRecepies(recepies.map(r => {
        if(r.id ===recepieId ){
           return recepie2;
        }
        else{
          return r;
        }
      }));
     
      handleSelectRecepie(recepieId);
     // setRecepies(tmp);
    }
  }
  return (

    <Fragment> 
      <NavBar createMeal={handleCreateMeal}/>
        <Container style={{marginTop: '7em'}}>
          <RecepieDashBoard 
            recepies={recepies} 
            foodNames={foodNames}
            selectedRecepie={getSelectedRecepie(selectedRecepie)}
            selectRecepie={handleSelectRecepie} 
            cancelSelectRecepie={handleCanceledRecepie}
            deleteIngredient={HandleDeleteIngredient}
            addOrEditIngredient={HandleAddOrEditIngredient}
            />
        </Container>
      
    </Fragment>
  );
}

export default App;
