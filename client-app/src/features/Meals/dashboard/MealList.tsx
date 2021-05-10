import { observer } from 'mobx-react-lite';
import React, { Fragment } from 'react';
import { useStore } from '../../../app/stores/store';
import MealListItem from './MealListItem';


export default observer(function MealList() {
    const { mealStore } = useStore();

    return (
        <>
            {mealStore.getMealsSelectedDay().map(meal => (
                <Fragment key={meal.mealId}>
                    <MealListItem key={meal.mealId} meal={meal} />
                </Fragment>
            ))}
        </>
    )
})