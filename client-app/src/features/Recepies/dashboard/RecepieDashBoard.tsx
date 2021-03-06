import React from 'react'
import { Grid } from 'semantic-ui-react'
import { Recepie } from '../../../app/models/recepie'
import MealDetails from '../details/MealDetails'
import RecepieList from './RecepieList'

interface Props {
    recepies: Recepie[];
    foodNames: string[];
}

export default function RecepieDashBoard({recepies, foodNames} : Props){
    return (
        <Grid>
            <Grid.Column width='10'>
                <RecepieList recepies={recepies}/>
            </Grid.Column>
            <Grid.Column width='6'>
                {recepies[0] &&
                <MealDetails recepie={recepies[0]} foodNames={foodNames}/>}
            </Grid.Column>
        </Grid>
    )
}