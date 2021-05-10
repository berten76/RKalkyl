import { observer } from 'mobx-react-lite'
import React from 'react'
import { Button, Grid, Segment } from 'semantic-ui-react'
import { useStore } from '../../../app/stores/store'
import MarcoNutrientDisplay from '../details/MarcoNutrientDisplay'
import MealCalendar from './MealCalendar'
import MealList from './MealList'
import { useHistory } from 'react-router-dom';

export default observer(function MealDashBoard() {
    const { mealStore } = useStore();
    const history = useHistory();

    return (
        <Grid>
            <Grid.Column width='6'>
                <MealCalendar />
            </Grid.Column>
            <Grid.Column width='10'>
                <Segment >
                    <h1>Total:</h1>
                    <MarcoNutrientDisplay meals={mealStore.getMealsSelectedDay()} />
                </Segment>
                <MealList />
                <Button positive content='Create meal' onClick={HandleCreateMeal} />
            </Grid.Column>
        </Grid>
    )

    async function  HandleCreateMeal() {
        await mealStore.createMeal();
        if(mealStore.selectedMeal){
            const id = mealStore.selectedMeal.mealId;
            history.push(`/meals/${id}`);
        }
    }
})