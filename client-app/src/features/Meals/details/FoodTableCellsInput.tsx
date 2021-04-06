import React, { useState } from 'react';
import { Button, Dropdown, DropdownProps, Input, InputOnChangeData, Table } from 'semantic-ui-react';
//import { FoodItem } from '../../../app/models/foodItem';
import { FoodName } from '../../../app/models/foodName';
import { Ingredient } from '../../../app/models/ingredient';
import { useStore } from '../../../app/stores/store';


interface Props {
    ingredient: Ingredient | undefined;
    foodNames: FoodName[];
    filterOptions: (options:any[], query: string) => any[];
    deleteIngredient: boolean;
}
  
export default function FoodTableCellsInput({ingredient, foodNames, filterOptions, deleteIngredient}: Props){
  
    const {mealStore} = useStore();
    
    const zeroState = {
        id: '',
        foodItem: {
            foodItemId: '',
            name: '',
            protein: 0,
            carbs:0,
            fat: 0,
        },
        mealId: '',
        amountInGram: 0,
        protein: 0,
        carbs: 0,
        fat: 0,
        selected: false,
      };
  
    let initialState = ingredient ?? zeroState;
  
  const [ingredientState, setIngredient] = useState<Ingredient>(initialState)

    function HandleOnInputChange(event: React.ChangeEvent<HTMLInputElement>, data: InputOnChangeData) {

        let newIngredient = {...ingredientState, amountInGram: Number(data.value)};
        setIngredient(newIngredient);
    }

    function HandleOnChange(event: React.SyntheticEvent<HTMLElement, Event>, data: DropdownProps){   
        if(!data) return;

        let selectedItem = foodNames.find(i => i.value === data.value);
        if(selectedItem)
        {
            let newFoodItem = selectedItem.value2;
            let mealId = mealStore?.selectedMeal ?  mealStore?.selectedMeal.mealId : '';
            let newIngredient = {...ingredientState, foodItem: newFoodItem, mealId: mealId };
            if(newIngredient.foodItem.name !== '' && newIngredient.amountInGram !== 0 && mealStore?.selectMeal){
                mealStore.editIngredient(newIngredient);
            }

            setIngredient(newIngredient);
        }
    }

    function HandleOnAdd() {
        mealStore.addIngredient(ingredientState)
        setIngredient(zeroState);
    }

    function onKeyPress(e: any)  {
         if(e.key === 'Enter'){
            setIngredient(ingredientState);
            mealStore.editIngredient(ingredientState);
         }
    }
  
    function HandleDelete(ingredientId: string) {
        mealStore.deleteIngredient(ingredientId);
    }
    
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
                    onKeyDown={(e: any) => onKeyPress(e)}
                    defaultValue={ingredientState.amountInGram} 
                    onChange={HandleOnInputChange}
                />
            </Table.Cell>
            <Table.Cell>g</Table.Cell>
            <Table.Cell>
                {deleteIngredient && <Button onClick={() => HandleDelete(ingredientState.id)}>Delete</Button>}
                {!deleteIngredient && <Button onClick={() => HandleOnAdd()}>Add2</Button>}
            </Table.Cell> 
        </>
    )
}
// {addIngredient && <Button onClick={() => HandleAddIngredient(ingredientState)}>Add</Button>}

