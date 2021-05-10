import { observer } from 'mobx-react-lite';
import React, { Fragment } from 'react';
import { useStore } from '../../../app/stores/store';
import MarcoNutrientDisplay from '../details/MarcoNutrientDisplay';
import MealDetails from '../details/MealDetails';
import MealListItem from './MealListItem';


export default observer(function MealList() {
    const { mealStore } = useStore();

    return (
        <>
       {/* <MarcoNutrientDisplay meals={mealStore.getMealsSelectedDay()}/>*/}
            {mealStore.getMealsSelectedDay().map(meal => (
                <Fragment key={meal.mealId}>
                   <MealListItem key={meal.mealId} meal={meal} />
                </Fragment>
            ))}
        </>
    )
})
//getMealsSelectedDay
/* <>
            {mealStore.meals.map(meal => (
                <Fragment key={meal.mealId}>
                   <MealListItem key={meal.mealId} meal={meal} />
                </Fragment>
            ))}
        </>*/