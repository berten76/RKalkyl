import React from 'react'
import { Link } from 'react-router-dom'
import { Button, Grid, Segment, Table } from 'semantic-ui-react'
import { Meal } from '../../../app/models/meal'
import { useStore } from '../../../app/stores/store'
import DeleteModal from '../../../common/components/DeleteModa'
import FoodTableCells from '../details/FoodTableCells'
import MarcoNutrientDisplay from '../details/MarcoNutrientDisplay'

interface Props {
    meal: Meal
}
export default function MealListItem({ meal }: Props) {
    const { mealStore } = useStore();

    return (
        <Segment key={meal.mealId}>
            <h2>{meal.name}</h2>
            <div>Not impl</div>
            <MarcoNutrientDisplay meals={[meal]} />
            <Table striped>
                <Table.Header>
                    <Table.Row>
                        <Table.HeaderCell width={5}>Description</Table.HeaderCell>
                        <Table.HeaderCell width={1} >Amount</Table.HeaderCell>
                        <Table.HeaderCell width={1} >Unit</Table.HeaderCell>
                        <Table.HeaderCell width={1} >Carbs</Table.HeaderCell>
                    </Table.Row>
                </Table.Header>
                <Table.Body>
                    {meal.ingredients && meal.ingredients.map(i => (
                        <Table.Row key={i.id}>
                            <FoodTableCells ingredient={i} showButton={false} />
                        </Table.Row>

                    ))}
                </Table.Body>
            </Table>
            <Grid>
                <Grid.Row style={{ padding: '0.5em' }}></Grid.Row>
                <Grid.Column width='10'>

                </Grid.Column>
                <Grid.Column width='6'>
                    <div className='floatedRight'>
                        <DeleteModal setResponse={(deleteMeal) => HandleResponseFromModal(deleteMeal, meal.mealId)} />
                    </div>
                    <Button as={Link} to={`/meals/${meal.mealId}`} floated='right' content='Edit' color='blue' />
                </Grid.Column>
            </Grid>

        </Segment>
    )

    function HandleDeleteMeal(mealId: string) {
        mealStore.deleteMeal(mealId);
        if (mealStore.selectedMeal?.mealId === mealId) {
            mealStore.cancelSelectedMeal();
        }
    }

    function HandleResponseFromModal(deleteMeal: boolean, mealId: string) {
        if (deleteMeal) {
            HandleDeleteMeal(mealId);
        }
    }
}

