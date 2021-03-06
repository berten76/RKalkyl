import React, { ChangeEvent, SyntheticEvent } from 'react';
import { useState } from 'react';
import { Card, Dropdown, DropdownItemProps, Icon, Image, List } from 'semantic-ui-react';
import { Recepie } from '../../../app/models/recepie';
//import SelectSearch from 'react-select-search';
import Select from 'react-select';

interface Props {
    recepie: Recepie;
    foodNames: string[]
}
interface op {
    value: string;
    text: string;
}
const options = [
    { value: 'chocolate', label: 'Chocolate' },
    { value: 'strawberry', label: 'Strawberry' },
    { value: 'vanilla', label: 'Vanilla' },
  ];

export default function MealDetails({recepie, foodNames}: Props){
    

    const [searchQuery, SetsearchQuery] = useState<string>('');
    const [selectedOption, SetSelectedOption] = useState<any>(null);

    function handleChange(selectedOption: any) {

        //console.log(`Option selected:`, selectedOption);
      };
 
      function handleInputChange(value: any) {
        // console.log('hande input change');
         //console.log(value);
      };
      function caseSensitiveSearch(options:any[], query: string) {

        return options.filter((f: op)=> f.value.toLowerCase()?.startsWith(query.toLowerCase()));
        return options;
       // return options.filter(word => word.value.startsWith(query))
      };
      function filterOptions(candidate: any, input: string) {
          if(!input || input.length < 3)
          {
              console.log('false');
              return false;
          }
          if(input)
          {
            console.log('true');
              return candidate.value.startsWith(input);
          }
         // return candidate.startsWith(input);
          
        //if (input) {
        //  return candidate.value === customOptions[0].value;
        //}
        return true;
      };

    let ddd= foodNames.map(fName =>{
        return { value: fName, text: fName}
    });

    console.log(ddd.filter(m=> m.value.startsWith('Pot')));

    console.log('start');
    return (
        <Card fluid>
            <Card.Content>
            <Card.Header>{recepie.name}</Card.Header>
            <Card.Meta>
                <span className='date'>Joined in 2015</span>
            </Card.Meta>
            <Card.Description>
            <List>
                {recepie.ingredients.map(i => (
                    <List.Item key={i.foodItem.name}>
                        <Dropdown
                           
                            fluid
                            search={caseSensitiveSearch}
                            selection
                            options={ddd}
                            defaultValue={i.foodItem.name}
                        />
                    </List.Item>
                ))}

                <List.Item>
                <Select
                    value={selectedOption}
                    onChange={handleChange}
                    options={ddd}
                    onInputChange={handleInputChange}
                   
      />
                </List.Item>
            </List>
            </Card.Description>
            </Card.Content>
            <Card.Content extra>
            <a>
                <Icon name='user' />
                22 Friends
            </a>
            </Card.Content>
        </Card>
    )
}