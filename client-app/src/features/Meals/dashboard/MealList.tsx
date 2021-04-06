import { observer } from 'mobx-react-lite';
import React from 'react';
import { Button, Item, Label, Segment } from 'semantic-ui-react';
import { Meal } from '../../../app/models/meal';
import { useStore } from '../../../app/stores/store';


export default observer(function MealList() {
    const {mealStore} = useStore();
    
    function HandleDeleteMeal(mealId: string) {
        mealStore.deleteMeal(mealId);
        if (mealStore.selectedMeal?.mealId === mealId) {
            mealStore.cancelSelectedMeal();
        }
    }

    return (
        <Segment>
            <Item.Group divided>
                {mealStore.meals.map(meal => (
                    
                    <Item key={meal.mealId}>
                        {console.log('meal.id')}
                        {console.log(meal.mealId)}
                        <Item.Content>
                            <Item.Header as='a'>{meal.name}</Item.Header>
                            <Item.Meta>not impl</Item.Meta>
                            <Item.Description>
                                <div>Not impl</div>
                                <div>Not impl</div>
                            </Item.Description>
                            <Item.Extra>
                                <Button floated='right' content='View' color='blue' onClick={() => mealStore.selectMeal(meal.mealId)} />
                                <Button 
                                    floated='right'
                                    content='Delete'
                                    color='red'
                                    onClick={() => HandleDeleteMeal(meal.mealId)}
                                />
                                <Label basic content="Not impl"/>
                            </Item.Extra>
                        </Item.Content>
                    </Item>
                ))}
            </Item.Group>
        </Segment>
    )
})