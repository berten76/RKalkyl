import React from 'react';
import { Button, Table } from 'semantic-ui-react';
import { Ingredient } from '../../../app/models/ingredient';
import { useStore } from '../../../app/stores/store';

interface Props {
    ingredient: Ingredient;
    showButton: boolean;
}

export default function FoodTableCells({ ingredient, showButton }: Props) {
    const { mealStore } = useStore();
    let carbs = Math.round(ingredient.foodItem.carbs * ingredient.amountInGram / 100.0);

    return (
        <>
            <Table.Cell >
                {ingredient.foodItem.name}
            </Table.Cell>
            <Table.Cell>
                {ingredient.amountInGram}
            </Table.Cell>
            <Table.Cell>g</Table.Cell>
            <Table.Cell>{carbs}</Table.Cell>
            {showButton && <Table.Cell style={{ padding: '0' }} textAlign='center'>
                <Button floated='right' onClick={() => HandleDelete(ingredient.id)} color='red'>Delete</Button>
            </Table.Cell>}
        </>
    )
    function HandleDelete(ingredientId: string) {
        mealStore.deleteIngredient(ingredientId);
    }
}