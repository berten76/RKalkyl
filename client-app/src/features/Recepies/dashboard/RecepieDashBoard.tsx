import React from 'react'
import { Grid } from 'semantic-ui-react'
import { Ingredient } from '../../../app/models/ingredient'
import { Recepie } from '../../../app/models/recepie'
import MealDetails from '../details/MealDetails'
import RecepieList from './RecepieList'

interface Props {
    recepies: Recepie[];
    foodNames: string[];
    selectedRecepie: Recepie | undefined;
    selectRecepie: (id: string) => void; 
    cancelSelectRecepie: () => void;
    deleteIngredient: (recepieId: string, ingredientId: string) => void;
    addOrEditIngredient: (recepieId: string, ingredient: Ingredient) => void;
}

export default function RecepieDashBoard({recepies, 
                                          foodNames, 
                                          selectedRecepie, 
                                          selectRecepie, 
                                          cancelSelectRecepie, 
                                          deleteIngredient, 
                                          addOrEditIngredient} : Props){
    return (
<>


{!selectedRecepie &&
        <Grid>
            <Grid.Column width='8'>
                <RecepieList recepies={recepies} selectRecepie={selectRecepie}/>
            </Grid.Column>

        </Grid>}
        {selectedRecepie &&
        <Grid>
            <Grid.Column width='4'>
                <RecepieList recepies={recepies} selectRecepie={selectRecepie}/>
            </Grid.Column>
            <Grid.Column width='12'>
                {selectedRecepie &&
                <MealDetails 
                    recepie={selectedRecepie} 
                    foodNames={foodNames} 
                    cancelSelectRecepie={cancelSelectRecepie}
                    deleteIngredient={deleteIngredient}
                    addOrEditIngredient={addOrEditIngredient}
                />}
            </Grid.Column>
        </Grid>}
        </>
    )
}