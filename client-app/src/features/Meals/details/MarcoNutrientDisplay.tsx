import { observer } from 'mobx-react-lite';
import React from 'react';
import { PieChart } from 'react-minimal-pie-chart';
import { Header, Table } from 'semantic-ui-react'
import { Meal } from '../../../app/models/meal';

interface Props {
    meals: Meal[];
}

export default observer(function MarcoNutrientDisplay({ meals }: Props) {

    let energy = 0;
    let protein = 0;
    let carbs = 0;
    let fat = 0;

    meals?.forEach(m => {
        m.ingredients.forEach(i => {

            protein = protein + i.foodItem.protein * i.amountInGram / 100.0;
            carbs = carbs + i.foodItem.carbs * i.amountInGram / 100.0;
            fat = fat + i.foodItem.fat * i.amountInGram / 100.0;
        });

    });
    const eProtein = protein * 4;
    const eCarbs = carbs * 4;
    const eFat = fat * 9;
    energy = energy + eProtein + eCarbs + eFat;

    return (
        <>
            <div className='macro'>
                <Table striped collapsing>
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
                                <Header as='h4' image color='green'>
                                    <Header.Content>
                                        Protein
              <Header.Subheader>g</Header.Subheader>
                                    </Header.Content>
                                </Header>
                            </Table.HeaderCell>
                            <Table.HeaderCell>
                                <Header as='h4' image color='blue'>
                                    <Header.Content>
                                        Carbs
              <Header.Subheader>g</Header.Subheader>
                                    </Header.Content>
                                </Header>
                            </Table.HeaderCell>
                            <Table.HeaderCell>
                                <Header as='h4' image color='red'>
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
            </div>
            <PieChart className='chart'
                data={[

                    { title: getToolTip('Protein', eProtein, energy) , value: eProtein, color: 'green' },
                    { title: getToolTip('Carbs', eCarbs, energy), value: eCarbs, color: 'blue' },
                    { title: getToolTip('Fat', eFat, energy), value: eFat, color: 'red' },
                ]}
            />
        </>
    )

    function getToolTip(macroN: string, value: number, totalEnergy: number){

        return macroN + ': ' + Math.round(value) + ' kcal, (' +   Math.round(100 * value / totalEnergy) +'%)';
    }
})