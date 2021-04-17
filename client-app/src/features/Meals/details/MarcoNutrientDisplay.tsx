import { observer } from 'mobx-react-lite';
import React, { useEffect } from 'react';
import { Card, Header, Image, Table } from 'semantic-ui-react'
import { Meal } from '../../../app/models/meal';
import { useStore } from '../../../app/stores/store';

interface Props {
    meal: Meal;
}

export default observer(function MarcoNutrientDisplay({ meal }: Props) {

    const { mealStore } = useStore();

    let energy = 0;
    let protein = 0;
    let carbs = 0;
    let fat = 0;
    meal?.ingredients.forEach(i => {

        protein = protein + i.foodItem.protein * i.amountInGram / 100.0;
        carbs = carbs + i.foodItem.carbs * i.amountInGram / 100.0;
        fat = fat + i.foodItem.fat * i.amountInGram / 100.0;
    });
    energy = protein * 4 + carbs * 4 + fat * 9;
    return (
        <Card fluid>
            <Card.Content>
                <Card.Description>
                    <Table basic='very' celled collapsing>
                        <Table.Header>
                            <Table.Row>

                                <Table.HeaderCell>
                                    <Header as='h4' image>
                                        <Header.Content>
                                            Energy
              <Header.Subheader>kcal</Header.Subheader>
                                        </Header.Content>
                                    </Header>
                                </Table.HeaderCell>
                                <Table.HeaderCell>
                                    <Header as='h4' image>
                                        <Header.Content>
                                            Protein
              <Header.Subheader>g</Header.Subheader>
                                        </Header.Content>
                                    </Header>
                                </Table.HeaderCell>
                                <Table.HeaderCell>
                                    <Header as='h4' image>
                                        <Header.Content>
                                            Carbs
              <Header.Subheader>g</Header.Subheader>
                                        </Header.Content>
                                    </Header>
                                </Table.HeaderCell>
                                <Table.HeaderCell>
                                    <Header as='h4' image>
                                        <Header.Content>
                                            Fat
              <Header.Subheader>g</Header.Subheader>
                                        </Header.Content>
                                    </Header>
                                </Table.HeaderCell>
                            </Table.Row>
                        </Table.Header>

                        <Table.Body>
                            <Table.Row>
                                <Table.Cell>{Math.round(energy)}</Table.Cell>
                                <Table.Cell>{Math.round(protein)}</Table.Cell>
                                <Table.Cell>{Math.round(carbs)}</Table.Cell>
                                <Table.Cell>{Math.round(fat)}</Table.Cell>
                            </Table.Row>
                        </Table.Body>
                    </Table>
                </Card.Description>
            </Card.Content>
        </Card>
    )
})
