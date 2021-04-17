import React from 'react'
import { Link } from 'react-router-dom'
import { Button, Item, Label, Segment } from 'semantic-ui-react'
import { Meal } from '../../../app/models/meal'
import { useStore } from '../../../app/stores/store'
import MarcoNutrientDisplay from '../details/MarcoNutrientDisplay'
//import {format} from 'date-fns';

interface Props {
    meal: Meal
}
export default function MealListItem({ meal }: Props) {

    const { mealStore } = useStore();

    function HandleDeleteMeal(mealId: string) {
        mealStore.deleteMeal(mealId);
        if (mealStore.selectedMeal?.mealId === mealId) {
            mealStore.cancelSelectedMeal();
        }
    }
    console.log('meallistItem 1')
    console.log(meal.date)
    //console.log(meal.date?.toLocaleDateString())

  
    return (
        <Segment color='olive'>
        <Item key={meal.mealId}>
            <Item.Content>
                <Item.Header as='a'>{meal.name}</Item.Header>
                <Item.Meta>{/*date*/}</Item.Meta>
                <Item.Description>
                    <div>Not impl</div>
                    <MarcoNutrientDisplay meal={meal} />
                </Item.Description>
                <Item.Extra>
                     {console.log('meallistItem 2')}
                    <Button as={Link} to={`/meals/${meal.mealId}`} floated='right' content='View' color='blue' />
                    <Button
                        floated='right'
                        content='Delete'
                        color='red'
                        onClick={() => HandleDeleteMeal(meal.mealId)}
                    />
                    <Label basic content="Not impl" />
                </Item.Extra>
            </Item.Content>
        </Item>
        </Segment>
    )
}