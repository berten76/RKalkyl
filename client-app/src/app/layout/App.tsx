import React, { Fragment, useEffect, useState } from 'react';
import { Container } from 'semantic-ui-react'
import { Recepie } from '../models/recepie';
import NavBar from './navbar';
import RecepieDashBoard from '../../features/Recepies/dashboard/RecepieDashBoard';
import { Ingredient } from '../models/ingredient';
import {v4 as uuid} from 'uuid';
import agent from '../api/agent';
import { FoodItem } from '../models/foodItem';

function App() {
  const [recepies, setRecepies] = useState<Recepie[]>([]);
  const [foodItems, setFoodItems] = useState<FoodItem[]>([]);
  const [selectedRecepie, setSelectedRecepie] = useState<string>('');
  const [submitting, setSubmitting] = useState(false);

  useEffect(() => {
      agent.Recepies.list().then(response => {
      setRecepies(response);
    })
  }, [])
  useEffect(() => {
      agent.FoodItems.list().then(response => {
        setFoodItems(response);
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
   setSubmitting(true);
console.log('HandleAddOrEditIngredient');
console.log(ingredient);
    let recepie = recepies.find(r => r.id === recepieId);
    console.log(recepie)
    if(recepie !== undefined)
    {
      //let updatedIngredients : Ingredient[];
      let updatedIngredients = new Array<Ingredient>();
      console.log('ff');
      

      if(ingredient.id) {
        recepie.ingredients.forEach(i => {
          if(i.id !== ingredient.id){
            updatedIngredients.push(i);
            console.log('push i')
          }
          else{
            updatedIngredients.push(ingredient);
            console.log('push ingredient')
          }
        });
      }
      else {
        updatedIngredients =  [...recepie.ingredients, {...ingredient, id: uuid()}];
      }
      console.log('updatedIngredients');
      console.log(updatedIngredients);
     // let updatedIngredients = ingredient.id
     //   ?  [...recepie.ingredients.filter(i => i.id !== ingredient.id), ingredient]
     //   :  [...recepie.ingredients, {...ingredient, id: uuid()}];
      let updatedRecepie = {...recepie, ingredients: updatedIngredients};

     console.log('update');
     console.log(updatedRecepie);
      agent.Recepies.update(updatedRecepie).then(() => {
        setRecepies(recepies.map(r => {
          if(r.id ===recepieId ){
             return updatedRecepie;
          }
          else{
            return r;
          }
        }));
        setSubmitting(false);
      })
      

    }
    else{
      setSubmitting(false);
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
            foodItems={foodItems}
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
