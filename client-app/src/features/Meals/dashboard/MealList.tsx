import React from 'react';
import { Button, Item, Label, Segment } from 'semantic-ui-react';
import { Meal } from '../../../app/models/meal';

interface Props {
    meals: Meal[];
    selectMeal: (mealId: string) => void; 
}

export default function MealList({meals, selectMeal}: Props)
{
    return (
        <Segment>
            <Item.Group divided>
                {meals.map(meal => (
                    
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
                                <Button floated='right' content='View' color='blue' onClick={() => selectMeal(meal.mealId)} />
                                <Label basic content="Not impl"/>
                            </Item.Extra>
                        </Item.Content>
                    </Item>
                ))}
            </Item.Group>
        </Segment>
    )
}