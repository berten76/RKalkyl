import { observer } from 'mobx-react-lite';
import React, { Fragment } from 'react';
import { Link } from 'react-router-dom';
import { Button, Item, Label, Segment } from 'semantic-ui-react';
//import { Meal } from '../../../app/models/meal';
import { useStore } from '../../../app/stores/store';
import MarcoNutrientDisplay from '../details/MarcoNutrientDisplay';
import MealListItem from './MealListItem';


export default observer(function MealList() {
    const {mealStore} = useStore();
    
    return (
        <>
            {mealStore.meals.map(meal => (
                <Fragment key={meal.mealId}>
                   <MealListItem key={meal.mealId} meal={meal} />
                   </Fragment>
             ))}
        </>
    )
})