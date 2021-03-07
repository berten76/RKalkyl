import React, { ChangeEvent, SyntheticEvent } from 'react';
import { Button, Table } from 'semantic-ui-react';
import { Ingredient } from '../../../app/models/ingredient';

interface Props {
    ingredient: Ingredient;
    deleteIngredient: (ingredientId: string) => void;
}

export default function FoodTableCells({ingredient, deleteIngredient}: Props){
    
    return (
        <>
            <Table.Cell >
                {ingredient.foodItem.name}
            </Table.Cell>
            <Table.Cell>
                {ingredient.amountInGram}
            </Table.Cell>
            <Table.Cell>g</Table.Cell>
            <Table.Cell>
                <Button onClick={() => deleteIngredient(ingredient.id)}>Delete</Button>
            </Table.Cell>
        </>
    )
}