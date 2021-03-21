import React from 'react'
import { Grid } from 'semantic-ui-react'
import { FoodItem } from '../../../app/models/foodItem'
import { Ingredient } from '../../../app/models/ingredient'
import { Meal } from '../../../app/models/meal'
import MealDetails from '../details/MealDetails'
import MealList from './MealList'

interface Props {
    meals: Meal[];
    foodItems: FoodItem[];
    selectedMeal: Meal | undefined;
    selectMeal: (id: string) => void; 
    cancelSelectMeal: () => void;
    deleteIngredient: (mealId: string, ingredientId: string) => void;
    addOrEditIngredient: (mealId: string, ingredient: Ingredient) => void;
}

export default function MealDashBoard({meals, 
                                          foodItems, 
                                          selectedMeal, 
                                          selectMeal, 
                                          cancelSelectMeal, 
                                          deleteIngredient, 
                                          addOrEditIngredient} : Props){
    return (
<>


{!selectedMeal &&
        <Grid>
            <Grid.Column width='8'>
                <MealList meals={meals} selectMeal={selectMeal}/>
            </Grid.Column>

        </Grid>}
        {selectedMeal &&
        <Grid>
            <Grid.Column width='4'>
                <MealList meals={meals} selectMeal={selectMeal}/>
            </Grid.Column>
            <Grid.Column width='12'>
                {selectedMeal &&
                <MealDetails 
                    meal={selectedMeal} 
                    foodItems={foodItems} 
                    cancelSelectMeal={cancelSelectMeal}
                    deleteIngredient={deleteIngredient}
                    addOrEditIngredient={addOrEditIngredient}
                />}
            </Grid.Column>
        </Grid>}
        </>
    )
}