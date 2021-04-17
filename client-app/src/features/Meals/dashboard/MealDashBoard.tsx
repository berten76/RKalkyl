import { observer } from 'mobx-react-lite'
import React from 'react'
import { Grid } from 'semantic-ui-react'
import MealCalendar from './MealCalendar'
import MealList from './MealList'



export default observer(function MealDashBoard() {

    return (
        <Grid>
            <Grid.Column width='10'>
                <MealList />
            </Grid.Column>
            <Grid.Column width='6'>
                <MealCalendar />
            </Grid.Column>
        </Grid>
    )
})