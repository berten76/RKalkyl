import React, { useEffect } from 'react';
import { useState } from 'react';
import { Button, Card, Table } from 'semantic-ui-react';
import FoodTableCells from './FoodTableCells';
import { FoodName } from '../../../app/models/foodName';
import FoodTableCellsInput from './FoodTableCellsInput';
import { useStore } from '../../../app/stores/store';
import { observer } from 'mobx-react-lite';
import { useParams } from 'react-router';
import LoadingComponent from '../../../app/layout/LoadingComponent';
import PasteDialog from './PasteDialog';
import { useHistory } from 'react-router-dom';
import MarcoNutrientDisplay from './MarcoNutrientDisplay';



export default observer(function MealDetails() {
    const history = useHistory();
    const { mealStore } = useStore();
    const { selectedMeal, loadMeal, lodingInitial } = mealStore;
    const [selectedIngredientId, setSelectedIngredientId] = useState<string>('');
    const [pasteMode, setPasteMode] = useState<Boolean>(false);
    const { id } = useParams<{ id: string }>();

    useEffect(() => {
        if (id) loadMeal(id);
    }, [id, loadMeal]);

    let ingredients = (selectedMeal?.ingredients.map(i => {

        if (i.id === selectedIngredientId) {
            i.selected = true;
        }
        else {
            i.selected = false;
        }
        return i;
    }));

    function FilterOptions(options: any[], query: string) {
        return options.filter((f: FoodName) => f.value.toLowerCase()?.startsWith(query.toLowerCase()));
    };
    function HandleOnFocus(id: string) {

        setSelectedIngredientId(id);
    };

    function HandleClose() {
        mealStore.cancelSelectedMeal();
        history.push('/meals/');
    }


    let ddd = mealStore.foodItems.map((fName) => {
        return { value: fName.name, text: fName.name, value2: fName }
    });

    if (!mealStore.selectedMeal) return <h2>Error</h2>

    if (lodingInitial || !selectedMeal) return <LoadingComponent />

    return (
        <Card fluid>
            <Card.Content>
                <Card.Header>{mealStore.selectedMeal.name}</Card.Header>
                <Card.Meta>
                    <span className='date'>{mealStore.selectedMeal.date}</span>
                </Card.Meta>
                <Card.Description>
                    <MarcoNutrientDisplay meal={mealStore.selectedMeal} />
                    <Card fluid>
                        <Card.Content>
                            <Table basic='very' celled selectable>
                                <Table.Header>
                                    <Table.Row>
                                        <Table.HeaderCell width={6}>Description</Table.HeaderCell>
                                        <Table.HeaderCell width={1} >Amount</Table.HeaderCell>
                                        <Table.HeaderCell width={1} >Unit</Table.HeaderCell>
                                        <Table.HeaderCell width={1} ></Table.HeaderCell>
                                    </Table.Row>
                                </Table.Header>

                                <Table.Body>

                                    {ingredients && ingredients.map(i => (

                                        <Table.Row key={i.foodItem.name} onClick={() => { HandleOnFocus(i.id) }} >

                                            {i.selected && <FoodTableCellsInput
                                                ingredient={i}
                                                foodNames={ddd}
                                                filterOptions={FilterOptions}
                                                deleteIngredient={true}
                                            />
                                            }
                                            {!i.selected &&
                                                <FoodTableCells ingredient={i} />
                                            }
                                        </Table.Row>
                                    ))}

                                    <Table.Row >
                                        <FoodTableCellsInput
                                            ingredient={undefined}
                                            foodNames={ddd}
                                            filterOptions={FilterOptions}
                                            deleteIngredient={false}
                                        />
                                    </Table.Row>
                                </Table.Body>
                            </Table>
                        </Card.Content>
                    </Card>

                </Card.Description>
            </Card.Content>
            <Card.Content extra>
                <Button onClick={() => setPasteMode(true)} basic color='grey' content='Paste a recepie' />
                <Button onClick={() => HandleClose()} basic color='grey' content='Close' />
            </Card.Content>
            {pasteMode && <PasteDialog />}
        </Card>
    )
});
