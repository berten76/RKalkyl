import React from 'react';
import { NavLink, useHistory } from 'react-router-dom';
import { Button, Container, Menu } from 'semantic-ui-react';
import { useStore } from '../stores/store';


export default function NavBar(){
    const {mealStore} = useStore();
    const history = useHistory();

    async function  HandleCreateMeal() {
        await mealStore.createMeal();
        if(mealStore.selectedMeal){
            const id = mealStore.selectedMeal.mealId;
            history.push(`/meals/${id}`);
        }
    }

    return (
        <Menu inverted fixed='top'>
            <Container>
                <Menu.Item as={NavLink} to='/' exact header>
                    <img src="/assets/food.png" alt="logo" style={{marginRight: '10px'}}/>
                    RKalkyl
                </Menu.Item>
                <Menu.Item as={NavLink} to='/meals' name='Meals' />
                <Menu.Item as={NavLink} to='/errors' name='Errors' />
                <Menu.Item>
                    <Button positive content='Create meal' 
                        onClick={() => HandleCreateMeal()}
                    />
                </Menu.Item>

            </Container>
        </Menu>
    )
}
