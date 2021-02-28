import React from 'react';
import { Button, Container, Menu } from 'semantic-ui-react';

export default function NavBar(){
    return (
        <Menu inverted fixed='top'>
            <Container>
                <Menu.Item header>
                    <img src="/assets/food.png" alt="logo" style={{marginRight: '10px'}}/>
                    RKalkyl
                </Menu.Item>
                <Menu.Item name='Meals' />
                <Menu.Item>
                    <Button positive content='Create meal' />
                </Menu.Item>

            </Container>
        </Menu>
    )
}
