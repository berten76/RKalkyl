import React from 'react'
import { Grid } from 'semantic-ui-react'
import { Recepie } from '../../../app/models/recepie'
import RecepieList from './RecepieList'

interface Props {
    recepies: Recepie[];
}

export default function RecepieDashBoard({recepies} : Props){
    return (
        <Grid>
            <Grid.Column width='10'>
                <RecepieList recepies={recepies}/>
            </Grid.Column>
        </Grid>
    )
}