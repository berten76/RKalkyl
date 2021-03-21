import React from 'react';
import { useState } from 'react';
import { Button, Card, Table } from 'semantic-ui-react';
import { Meal} from '../../../app/models/meal';
//import SelectSearch from 'react-select-search';
//import Select from 'react-select';
//import { FoodItem } from '../../../app/models/foodItem';
import { Ingredient } from '../../../app/models/ingredient';
import FoodTableCells from './FoodTableCells';
import { FoodName } from '../../../app/models/foodName';
import FoodTableCellsInput from './FoodTableCellsInput';
import { FoodItem } from '../../../app/models/foodItem';

interface Props {
    meal: Meal;
    foodItems: FoodItem[]
    cancelSelectMeal: () => void;
    deleteIngredient: (MealId: string, ingredientId: string) => void;
    addOrEditIngredient: (meald: string, ingredient: Ingredient) => void;
}
// interface op {
//     value: string;
//     text: string;
// }

export default function MealDetails({meal, foodItems, cancelSelectMeal, deleteIngredient, addOrEditIngredient}: Props){
    
   // const [searchQuery, SetsearchQuery] = useState<string>('');
   // const [selectedOption, SetSelectedOption] = useState<any>(null);
    const [selectedIngredientId, setSelectedIngredientId] = useState<string>('');
    
    //const [ingredients, Setingredients] = useState<Ingredient[]>(recepie.ingredients);
   // let ingredients = recepie.ingredients;
   // if(recepie){
    let ingredients = (meal.ingredients.map(i => {
        
        if(i.id === selectedIngredientId){
            i.selected = true;
        }
        else{
            i.selected = false;
        }
        return i;
    })) ;
//}

      function FilterOptions(options:any[], query: string) {
          return options.filter((f: FoodName)=> f.value.toLowerCase()?.startsWith(query.toLowerCase()));
      };
      function HandleOnFocus(id: string) {

          setSelectedIngredientId(id);
      };

      function HandleDeleteIngredient(ingredientId: string) {
            deleteIngredient(meal.mealId, ingredientId);
      }
      function HandleAddOrEditIngredient(ingredient: Ingredient) {
        addOrEditIngredient(meal.mealId, ingredient);
      }

      let ddd= foodItems.map((fName) =>{
        return { value: fName.name, text: fName.name, value2: fName}
    });

    return (
        <Card fluid>
            <Card.Content>
            <Card.Header>{meal.name}</Card.Header>
            <Card.Meta>
                <span className='date'>Joined in 2015</span>
            </Card.Meta>
            <Card.Description>
            <Table basic='very' celled selectable>
    <Table.Header>
      <Table.Row>
        <Table.HeaderCell width={6}>Description</Table.HeaderCell>
        <Table.HeaderCell width={1} >Amount</Table.HeaderCell>
        <Table.HeaderCell  width={1} >Unit</Table.HeaderCell>
        <Table.HeaderCell  width={1} ></Table.HeaderCell>
      </Table.Row>
    </Table.Header>

    <Table.Body>
    {ingredients.map(i => (
      
         <Table.Row key={i.foodItem.name}  onClick={()=> {HandleOnFocus(i.id)}} >

            {i.selected &&  <FoodTableCellsInput 
                                ingredient={i}
                                foodNames={ddd}
                                filterOptions={FilterOptions}
                                deleteIngredient={HandleDeleteIngredient}
                                addOrEditIngredient={HandleAddOrEditIngredient}
                            />
     
           
            }
            {!i.selected && 
                <FoodTableCells ingredient={i} deleteIngredient={HandleDeleteIngredient}/>
            }
       </Table.Row>
    ))}

     <Table.Row>
     <FoodTableCellsInput 
            ingredient={undefined}
            foodNames={ddd}
            filterOptions={FilterOptions}
            deleteIngredient={undefined}
            addOrEditIngredient={HandleAddOrEditIngredient}
            />
       </Table.Row>
    </Table.Body>
  </Table>

            </Card.Description>
            </Card.Content>
            <Card.Content extra>
                <Button onClick={() => cancelSelectMeal()} basic color='grey' content='Close'/>
            </Card.Content>
        </Card>
    )
}


 //{{foodItem: {name : '', id : '', protein: 0, fat:0, carbs:0}, id:'', amountInGram:0, protein: 0, fat:0, carbs:0, selected:false}}