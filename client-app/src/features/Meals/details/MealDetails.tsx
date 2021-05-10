import React, { useEffect } from 'react';
import { useState } from 'react';
import { Button, Card, Label, Table } from 'semantic-ui-react';
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
import { runInAction } from 'mobx';
import { Ingredient } from '../../../app/models/ingredient';
import EditableField from '../../../common/components/EditableField';


export default observer(function MealDetails() {

    console.log('details-------------------------------')
    const history = useHistory();
    const { mealStore } = useStore();
    const { loadMeal, lodingInitial } = mealStore;
    const [selectedIngredientId, setSelectedIngredientId] = useState<string>('');
    const [pasteMode, setPasteMode] = useState<Boolean>(false);
    const { id } = useParams<{ id: string }>();

    useEffect(() => {
        if (id) loadMeal(id);
    }, [id, loadMeal]);

    // let ingredients : Ingredient[] | undefined;
    // runInAction(() => {
    let meal = mealStore.meals.find(m => m.mealId === id);
    let ingredients = (meal?.ingredients.map(i => {
        runInAction(() => {
            if (i.id === selectedIngredientId) {
                i.selected = true;
            }
            else {
                i.selected = false;
            }
        })
        return i;
    }));

    //})

    if (!meal) return (<div>could not find meal</div>)

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


    function HandleNewMealName(newMealName: string) {
        runInAction(() => {
            if (mealStore.selectedMeal) {
                mealStore.selectedMeal.name = newMealName;
                mealStore.editMeal(mealStore.selectedMeal);
            }
        })
    }
    function HandleDeleteMeal(mealId: string) {
        mealStore.deleteMeal(mealId);
        if (mealStore.selectedMeal?.mealId === mealId) {
            mealStore.cancelSelectedMeal();
        }
    }

    let ddd = mealStore.foodItems.map((fName) => {
        return { value: fName.name, text: fName.name, value2: fName }
    });

    //if (!mealStore.selectedMeal) return <h2>Error</h2>

    if (lodingInitial || !meal) return <LoadingComponent />

    let aa = [meal];

    console.log('details222222222222222222-------------------------------')
    console.log(aa)
    
    return (
        <Card fluid className='border' onClick={() => mealStore.selectMeal(id)}>
            <Card.Content>
                <Card.Header>
                    <EditableField mealName={meal.name} NewMealNameEvent={HandleNewMealName} />
                </Card.Header>
                <Card.Meta>
                    <span className='date'>{meal.name}</span>
                </Card.Meta>
                <Card.Description>
                    <MarcoNutrientDisplay meals={[meal]} />
                </Card.Description>
                <Table striped selectable >
                    <Table.Header>
                        <Table.Row>
                            <Table.HeaderCell width={5}>Description</Table.HeaderCell>
                            <Table.HeaderCell width={1} >Amount</Table.HeaderCell>
                            <Table.HeaderCell width={1} >Unit</Table.HeaderCell>
                            <Table.HeaderCell width={1} >Carbs</Table.HeaderCell>
                            <Table.HeaderCell width={1} ></Table.HeaderCell>
                        </Table.Row>
                    </Table.Header>
                    <Table.Body>
                        {ingredients && ingredients.map(i => (

                            <Table.Row key={i.id} onClick={() => { HandleOnFocus(i.id) }} >

                                {i.selected && <FoodTableCellsInput
                                    ingredient={i}
                                    foodNames={ddd}
                                    filterOptions={FilterOptions}
                                    deleteIngredient={true}
                                    onBlur={() => setSelectedIngredientId('')}
                                />
                                }
                                {!i.selected &&
                                    <FoodTableCells ingredient={i} showButton={true} />
                                }

                            </Table.Row>

                        ))}
                        {(meal.mealId === mealStore.selectedMeal?.mealId) && <Table.Row >
                            <FoodTableCellsInput
                                ingredient={undefined}
                                foodNames={ddd}
                                filterOptions={FilterOptions}
                                deleteIngredient={false}
                                onBlur={() => { }}
                            />
                        </Table.Row>}
                    </Table.Body>
                </Table>
            </Card.Content>
            <Card.Content extra>
                <Button className='buttonRK'
                    floated='right'
                    content='Delete'
                    color='red'
                    onClick={() => HandleDeleteMeal(id)}
                />
                <Button floated='right' onClick={() => setPasteMode(true)} basic color='grey' content='Paste a recepie' />
                <Button floated='right' onClick={() => HandleClose()} basic color='grey' content='Close' />

            </Card.Content>
            {pasteMode && <PasteDialog />}
        </Card>
    )
});

/*<Card fluid className='border' onClick={() => mealStore.selectMeal(id)}>
            <Card.Content >
                <Card.Header>
                 <EditableField mealName={meal.name} NewMealNameEvent={ HandleNewMealName}/>

                </Card.Header>
                <Card.Meta>
                    <span className='date'>{meal}</span>
                </Card.Meta>
                <Card.Description>
                    <MarcoNutrientDisplay meal={meal} />

                            <Table  striped  selectable >
                                <Table.Header>
                                    <Table.Row>
                                        <Table.HeaderCell width={5}>Description</Table.HeaderCell>
                                        <Table.HeaderCell width={1} >Amount</Table.HeaderCell>
                                        <Table.HeaderCell width={1} >Unit</Table.HeaderCell>
                                        <Table.HeaderCell width={1} >Carbs</Table.HeaderCell>
                                        <Table.HeaderCell width={1} ></Table.HeaderCell>
                                    </Table.Row>
                                </Table.Header>

                                <Table.Body>

                                    {ingredients && ingredients.map(i => (

                                        <Table.Row key={i.id} onClick={() => { HandleOnFocus(i.id) }} >

                                            {i.selected && <FoodTableCellsInput
                                                ingredient={i}
                                                foodNames={ddd}
                                                filterOptions={FilterOptions}
                                                deleteIngredient={true}
                                                onBlur={() =>setSelectedIngredientId('')}
                                            />
                                            }
                                            {!i.selected &&
                                                <FoodTableCells ingredient={i} />
                                            }
                                        </Table.Row>
                                    ))}

                            {(meal.mealId === mealStore.selectedMeal?.mealId) &&<Table.Row >
                                        <FoodTableCellsInput
                                            ingredient={undefined}
                                            foodNames={ddd}
                                            filterOptions={FilterOptions}
                                            deleteIngredient={false}
                                            onBlur={() => {}}
                                        />
                                    </Table.Row>}
                                </Table.Body>
                            </Table>

                </Card.Description>
            </Card.Content>
            <Card.Content extra>
                <Button onClick={() => setPasteMode(true)} basic color='grey' content='Paste a recepie' />
                <Button onClick={() => HandleClose()} basic color='grey' content='Close' />
                <Button className='buttonRK'
                    floated='right'
                    content='Delete'
                    color='red'
                    onClick={() => HandleDeleteMeal(id)}
                />
            </Card.Content>
            {pasteMode && <PasteDialog />}
        </Card>*/