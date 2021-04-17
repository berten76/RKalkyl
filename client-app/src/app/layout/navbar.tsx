import React from 'react';
import { NavLink, useHistory } from 'react-router-dom';
import { Button, Container, Menu } from 'semantic-ui-react';
import { useStore } from '../stores/store';


export default function NavBar(){
    const {mealStore} = useStore();
    const history = useHistory();

    async function  HandleCreateMeal() {
        console.log("crate meal 1");
        await mealStore.createMeal();
        console.log("crate meal 2");
        if(mealStore.selectedMeal){
            console.log("crate meal 3");
            console.log("crate mea---------------")
            const id = mealStore.selectedMeal.mealId;
            history.push(`/meals/${id}`);
        }
        console.log("crate meal 4");
    }

    return (
        <Menu inverted fixed='top'>
            <Container>
                <Menu.Item as={NavLink} to='/' exact header>
                    <img src="/assets/food.png" alt="logo" style={{marginRight: '10px'}}/>
                    RKalkyl
                </Menu.Item>
                <Menu.Item as={NavLink} to='/meals' name='Meals' />
                <Menu.Item>
                    <Button positive content='Create meal' 
                        onClick={() => HandleCreateMeal()}
                    />
                </Menu.Item>

            </Container>
        </Menu>
    )
}
