import React, { Fragment, useEffect, useState } from 'react';
import { Container } from 'semantic-ui-react'
import { Meal } from '../models/meal';
import NavBar from './navbar';
import MealDashBoard from '../../features/Meals/dashboard/MealDashBoard';
import { Ingredient } from '../models/ingredient';
import {v4 as uuid} from 'uuid';
import agent from '../api/agent';
import { FoodItem } from '../models/foodItem';

function App() {
  const [meals, setMeals] = useState<Meal[]>([]);
  const [foodItems, setFoodItems] = useState<FoodItem[]>([]);
  const [selectedMeal, setSelectedMeal] = useState<string>('');
  const [submitting, setSubmitting] = useState(false);

  useEffect(() => {
      agent.Meals.list().then(response => {
      setMeals(response);
    })
  }, [])
  useEffect(() => {
      agent.FoodItems.list().then(response => {
        setFoodItems(response);
    })
  }, [])

  function handleCreateMeal(){
    let newMeal = {
      mealId: uuid(),
      name: 'New meal',
      ingredients: []
    };
    
    setMeals([...meals, newMeal])
  }
  function handleSelectMeal(id: string) {
    setSelectedMeal(id);
  }

  function handleCanceledMeal() {
    setSelectedMeal('');
  }

  function getSelectedMeal(id: string) {
    if(id === ''){
      return undefined;
    }
    return meals.find(r => r.mealId === id);
  }
  function HandleAddOrEditIngredient(mealId: string, ingredient: Ingredient){
   setSubmitting(true);
console.log('HandleAddOrEditIngredient');
console.log(ingredient);
    let meal = meals.find(r => r.mealId === mealId);
    console.log(meal)
    if(meal !== undefined)
    {
      //let updatedIngredients : Ingredient[];
      let updatedIngredients = new Array<Ingredient>();
      console.log('ff');
      

      if(ingredient.id) {
        meal.ingredients.forEach(i => {
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
        updatedIngredients =  [...meal.ingredients, {...ingredient, id: uuid()}];
      }
      console.log('updatedIngredients');
      console.log(updatedIngredients);

      let updatedMeal = {...meal, ingredients: updatedIngredients};

     console.log('update');
     console.log(updatedMeal);
     if(ingredient.id !== ''){
      agent.Ingredients.update(ingredient).then(() => {
        setMeals(meals.map(r => {
          if(r.mealId ===mealId ){
             return updatedMeal;
          }
          else{
            return r;
          }
        }));
        setSubmitting(false);
      })
    }
    else{
      console.log('jjjjjjjjjjjjjjjjjjjj');
      console.log(ingredient);
      ingredient.id = 'new';
      ingredient.mealId = mealId;
      agent.Ingredients.create(ingredient).then(() => {
       /* console.log('inide');
        setMeals(meals.map(r => {
          if(r.mealId ===mealId ){
             return updatedMeal;
          }
          else{
            return r;
          }
        }));*/
        setSubmitting(false);
      })
    }
      

    }
    else{
      setSubmitting(false);
    }
    //setRecepies(recepies);
  }


  function HandleDeleteIngredient(mealId: string, ingredientId: string){
   
    let meal = meals.find(r => r.mealId === mealId);
    if(meal !== undefined)
    {
      let ingredientList = [...meal.ingredients.filter(i => i.id !== ingredientId)]
      const meal2 = {...meal,  ingredients: ingredientList};
    
      setMeals(meals.map(r => {
        if(r.mealId ===mealId ){
           return meal2;
        }
        else{
          return r;
        }
      }));
     
      handleSelectMeal(mealId);
     // setRecepies(tmp);
    }
  }
  return (

    <Fragment> 
      <NavBar createMeal={handleCreateMeal}/>
        <Container style={{marginTop: '7em'}}>
          <MealDashBoard 
            meals={meals} 
            foodItems={foodItems}
            selectedMeal={getSelectedMeal(selectedMeal)}
            selectMeal={handleSelectMeal} 
            cancelSelectMeal={handleCanceledMeal}
            deleteIngredient={HandleDeleteIngredient}
            addOrEditIngredient={HandleAddOrEditIngredient}
            />
        </Container>
      
    </Fragment>
  );
}

export default App;
