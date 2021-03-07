import React, { ChangeEvent, SyntheticEvent, useState } from 'react';
import { Button, ButtonProps, Dropdown, DropdownProps, Input, InputOnChangeData, Table } from 'semantic-ui-react';
import { FoodName } from '../../../app/models/foodName';
import { Ingredient } from '../../../app/models/ingredient';

interface Props {
    ingredient: Ingredient | undefined;
    foodNames: FoodName[];
    filterOptions: (options:any[], query: string) => any[];
    deleteIngredient: ((ingredientId: string) => void) | undefined;
    addIngredient: ((ingredient: Ingredient) => void) | undefined;
}

export default function FoodTableCellsInput({ingredient, foodNames, filterOptions, deleteIngredient, addIngredient}: Props){
  
    const zeroState = {
        id: '',
        foodItem: {
            id: '',
            name: '',
            protein: 0,
            carbs:0,
            fat: 0,
        },
        amountInGram: 0,
        protein: 0,
        carbs: 0,
        fat: 0,
        selected: false,
      };
  
    const initialState = ingredient ?? zeroState;
  
  const [ingredientState, setIngredient] = useState<Ingredient>(initialState)

    function HandleOnInputChange(event: React.ChangeEvent<HTMLInputElement>, data: InputOnChangeData) {
        let newIngredient = {...ingredientState, amountInGram: Number(data.value)};
        setIngredient(newIngredient);
    }
    function HandleOnChange(event: React.SyntheticEvent<HTMLElement, Event>, data: DropdownProps){   
        if(!data) return;
        const newFoodItem = {...ingredientState.foodItem, name:data.value as string};
        let newIngredient = {...ingredientState, foodItem: newFoodItem};
        setIngredient(newIngredient);
    }
    function HandleOnAdd() {
        if(addIngredient) addIngredient(ingredientState)
        setIngredient(zeroState);
    }
    
    console.log('render cell')
    console.log(ingredientState)
    return (
        <>
             <Table.Cell >
                    <Dropdown
                        floating
                        fluid
                        search={filterOptions}
                        selection
                        options={foodNames}
                        defaultValue={ingredientState.foodItem.name}
                        onChange={HandleOnChange}
                    />
            </Table.Cell>
            <Table.Cell>
                <Input
                    defaultValue={ingredientState.amountInGram} 
                    onChange={HandleOnInputChange}
                  />
            </Table.Cell>
            <Table.Cell>g</Table.Cell>
            <Table.Cell>
                {deleteIngredient && <Button onClick={() => deleteIngredient(ingredientState.id)}>Delete</Button>}
                {addIngredient && <Button onClick={() => HandleOnAdd()}>Add</Button>}
            </Table.Cell> 
            </>
    )
}
// {addIngredient && <Button onClick={() => HandleAddIngredient(ingredientState)}>Add</Button>}

