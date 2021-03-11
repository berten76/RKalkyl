import React, { useState } from 'react';
import { Button, Dropdown, DropdownProps, FeedLike, Input, InputOnChangeData, Table } from 'semantic-ui-react';
import { FoodItem } from '../../../app/models/foodItem';
import { FoodName } from '../../../app/models/foodName';
import { Ingredient } from '../../../app/models/ingredient';

interface Props {
    ingredient: Ingredient | undefined;
    foodNames: FoodName[];
    filterOptions: (options:any[], query: string) => any[];
    deleteIngredient: ((ingredientId: string) => void) | undefined;
    addOrEditIngredient: ((ingredient: Ingredient) => void) | undefined;
}

export default function FoodTableCellsInput({ingredient, foodNames, filterOptions, deleteIngredient, addOrEditIngredient}: Props){
  
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
  
    let initialState = ingredient ?? zeroState;

    console.log('input initialState');
    console.log(initialState);
  
  const [ingredientState, setIngredient] = useState<Ingredient>(initialState)

    function HandleOnInputChange(event: React.ChangeEvent<HTMLInputElement>, data: InputOnChangeData) {

        let newIngredient = {...ingredientState, amountInGram: Number(data.value)};
        setIngredient(newIngredient);
        // if(addOrEditIngredient && newIngredient.foodItem.name !== '' && newIngredient.amountInGram !== 0){
      
        //      addOrEditIngredient(newIngredient);
        // }
    }

    function HandleOnChange(event: React.SyntheticEvent<HTMLElement, Event>, data: DropdownProps){   
        if(!data) return;
console.log('HandleOnChange');
console.log(data);
console.log(foodNames[0]);
        let selectedItem = foodNames.find(i => i.value === data.value);
        if(selectedItem)
        {
            let newFoodItem = selectedItem.value2;
            let newIngredient = {...ingredientState, foodItem: newFoodItem};
            if(addOrEditIngredient && newIngredient.foodItem.name !== '' && newIngredient.amountInGram !== 0){

                     addOrEditIngredient(newIngredient);
            }
            setIngredient(newIngredient);
        }
       // const newFoodItem = {...ingredientState.foodItem, name:data.value as string};
        // let newIngredient = data.v//{...ingredientState, foodItem: newFoodItem};

        // if(addOrEditIngredient && newIngredient.foodItem.name !== '' && newIngredient.amountInGram !== 0){

        //      addOrEditIngredient(newIngredient);
        // }
        // setIngredient(newIngredient);
    }
    function HandleOnAdd() {
        if(addOrEditIngredient) addOrEditIngredient(ingredientState)
        setIngredient(zeroState);
    }

    function onKeyPress(e: any)  {
        console.log('press');
        console.log(e.key);
        
         if(e.key === 'Enter'){
            console.log('Enter');
            console.log(ingredientState);
            setIngredient(ingredientState);
            if(addOrEditIngredient) addOrEditIngredient(ingredientState);
         }
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
                {deleteIngredient && <Button onClick={() => deleteIngredient(ingredientState.id)}>Delete</Button>}
                {addOrEditIngredient && !deleteIngredient && <Button onClick={() => HandleOnAdd()}>Add</Button>}
            </Table.Cell> 
            </>
    )
}
// {addIngredient && <Button onClick={() => HandleAddIngredient(ingredientState)}>Add</Button>}

