import React from 'react';
import { Button, Item, Label, Segment } from 'semantic-ui-react';
import { Recepie } from '../../../app/models/recepie';

interface Props {
    recepies: Recepie[];
}

export default function RecepieList({recepies}: Props)
{
    return (
        <Segment>
            <Item.Group divided>
                {recepies.map(recepie => (
                    <Item key={recepie.id}>
                        <Item.Content>
                            <Item.Header as='a'>{recepie.name}</Item.Header>
                            <Item.Meta>not impl</Item.Meta>
                            <Item.Description>
                                <div>Not impl</div>
                                <div>Not impl</div>
                            </Item.Description>
                            <Item.Extra>
                                <Button floated='right' content='View' color='blue' />
                                <Label basic content="Not impl"/>
                            </Item.Extra>
                        </Item.Content>
                    </Item>
                ))}
            </Item.Group>
        </Segment>
    )
}