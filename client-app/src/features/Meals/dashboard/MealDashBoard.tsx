import { observer } from 'mobx-react-lite'
import React from 'react'
import { Grid } from 'semantic-ui-react'
import { FoodItem } from '../../../app/models/foodItem'
import { useStore } from '../../../app/stores/store'
import MealDetails from '../details/MealDetails'
import PasteDialog from '../details/PasteDialog'
import MealList from './MealList'



export default observer(function MealDashBoard(){
    const {mealStore} = useStore();
    const {foodItems} = mealStore;
    return (
        <>
      
            {!mealStore.selectedMeal &&
                <Grid>
                    <Grid.Column width='8'>
                        <MealList />
                    </Grid.Column>

                </Grid>
            }
  
            {mealStore.selectedMeal &&
                <Grid>
                    
                    <Grid.Column width='4'>
                        <MealList />
                    </Grid.Column>
                   
                    <Grid.Column width='12'>
                
                        {mealStore.selectedMeal && !mealStore.pasteMode &&
                        <MealDetails 
                            foodItems={foodItems} 
                        />}
                        {mealStore.selectedMeal && mealStore.pasteMode &&
                        <PasteDialog />
                        }
                    </Grid.Column>
                </Grid>
            }

        </>
    )
})