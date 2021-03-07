import React, { ChangeEvent, SyntheticEvent } from 'react';
import { useState } from 'react';
import { Button, Card, Dropdown, DropdownItemProps, Icon, Image, Input, List, Table } from 'semantic-ui-react';
import { Recepie} from '../../../app/models/recepie';
//import SelectSearch from 'react-select-search';
import Select from 'react-select';
import { FoodItem } from '../../../app/models/foodItem';
import { Ingredient } from '../../../app/models/ingredient';
import FoodTableCells from './FoodTableCells';
import { FoodName } from '../../../app/models/foodName';
import FoodTableCellsInput from './FoodTableCellsInput';

interface Props {
    recepie: Recepie;
    foodNames: string[]
    cancelSelectRecepie: () => void;
    deleteIngredient: (recepieId: string, ingredientId: string) => void;
    addIngredient: (recepieId: string, ingredient: Ingredient) => void;
}
// interface op {
//     value: string;
//     text: string;
// }

export default function MealDetails({recepie, foodNames, cancelSelectRecepie, deleteIngredient, addIngredient}: Props){
    
    {console.log('render MealDetails')}
    {console.log(recepie)}
    const [searchQuery, SetsearchQuery] = useState<string>('');
    const [selectedOption, SetSelectedOption] = useState<any>(null);
    const [selectedIngredientId, setSelectedIngredientId] = useState<string>('');
    //const [ingredients, Setingredients] = useState<Ingredient[]>(recepie.ingredients);
    let ingredients = recepie.ingredients;
    if(recepie){
    const ingredients = recepie.ingredients.map(i => {
        if(i.id === selectedIngredientId){
            i.selected = true;
        }
        else{
            i.selected = false;
        }
    });
}

      function FilterOptions(options:any[], query: string) {
          return options.filter((f: FoodName)=> f.value.toLowerCase()?.startsWith(query.toLowerCase()));
      };
      function HandleOnFocus(id: string) {

          setSelectedIngredientId(id);
      };

      function HandleDeleteIngredient(ingredientId: string) {
            deleteIngredient(recepie.id, ingredientId);
      }
      function HandleAddIngredient(ingredient: Ingredient) {
        addIngredient(recepie.id, ingredient);
      }

      let ddd= foodNames.map((fName) =>{
        return { value: fName, text: fName}
    });

    return (
        <Card fluid>
            <Card.Content>
            <Card.Header>{recepie.name}</Card.Header>
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
{console.log('render')}
    <Table.Body>
    {ingredients.map(i => (
         <Table.Row key={i.foodItem.name}  onClick={()=> {HandleOnFocus(i.id)}} >
            {i.selected &&  <FoodTableCellsInput 
                                ingredient={i}
                                foodNames={ddd}
                                filterOptions={FilterOptions}
                                deleteIngredient={HandleDeleteIngredient}
                                addIngredient={undefined}
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
            addIngredient={HandleAddIngredient}
            />
       </Table.Row>
    </Table.Body>
  </Table>

            </Card.Description>
            </Card.Content>
            <Card.Content extra>
                <Button onClick={() => cancelSelectRecepie()} basic color='grey' content='Close'/>
            </Card.Content>
        </Card>
    )
}


 //{{foodItem: {name : '', id : '', protein: 0, fat:0, carbs:0}, id:'', amountInGram:0, protein: 0, fat:0, carbs:0, selected:false}}