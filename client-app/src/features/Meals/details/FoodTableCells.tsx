import React from 'react';
import { Button, Table } from 'semantic-ui-react';
import { Ingredient } from '../../../app/models/ingredient';
import { useStore } from '../../../app/stores/store';

interface Props {
    ingredient: Ingredient;
}

export default function FoodTableCells({ ingredient }: Props) {
    const { mealStore } = useStore();

    function HandleDelete(ingredientId: string) {
        mealStore.deleteIngredient(ingredientId);
    }

    return (
        <>
            <Table.Cell >
                {ingredient.foodItem.name}
            </Table.Cell>
            <Table.Cell>
                {ingredient.amountInGram}
            </Table.Cell>
            <Table.Cell>g</Table.Cell>
            <Table.Cell style={{ padding: '0' }} textAlign='center'>
                <Button onClick={() => HandleDelete(ingredient.id)} color='red'>Delete</Button>
            </Table.Cell>
        </>
    )
}