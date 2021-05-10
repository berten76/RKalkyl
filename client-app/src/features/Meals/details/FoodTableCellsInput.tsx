import React, { useState } from 'react';
import { Button, Dropdown, DropdownProps,  InputOnChangeData, Table } from 'semantic-ui-react';
import { FoodName } from '../../../app/models/foodName';
import { Ingredient } from '../../../app/models/ingredient';
import { useStore } from '../../../app/stores/store';
import TextInputWithValidation from '../../../common/form/TextInputWithValidation';
import * as Yup from 'yup';
import { Formik } from 'formik'

interface Props {
    ingredient: Ingredient | undefined;
    foodNames: FoodName[];
    filterOptions: (options: any[], query: string) => any[];
    deleteIngredient: boolean;
    onBlur: () => void;
}
interface Erro {
    amountInGram: string;
}
export default function FoodTableCellsInput({ ingredient, foodNames, filterOptions, deleteIngredient, onBlur }: Props) {
    const { mealStore } = useStore();

    const zeroState = {
        id: '',
        foodItem: {
            foodItemId: '',
            name: '',
            protein: 0,
            carbs: 0,
            fat: 0,
        },
        mealId: '',
        amountInGram: 0,
        protein: 0,
        carbs: 0,
        fat: 0,
        selected: false,
    };

    const validationSchema = Yup.object({
        amountInGram: Yup.number().required(),
    })

    let initialState = ingredient ?? zeroState;

    const [ingredientState, setIngredient] = useState<Ingredient>(initialState);
    const [validationError, setValidationError] = useState<boolean>(false);
    const [error, setError] = useState<Erro>({ amountInGram: '' });

    let carbs = Math.round(ingredientState.foodItem.carbs * ingredientState.amountInGram / 100.0);

    return (
        <>
            <Table.Cell style={{ padding: '0' }}>
                <Dropdown
                    value={ingredientState.foodItem.name}
                    floating
                    fluid
                    search={filterOptions}
                    selection
                    options={foodNames}

                    onChange={HandleOnChange}
                />
            </Table.Cell>
            <Table.Cell style={{ padding: '0' }}>
                <Formik
                    validationSchema={validationSchema}
                    enableReinitialize
                    initialValues={validationError ? error : ingredientState}
                    onSubmit={values => console.log(values)}>

                    <TextInputWithValidation onBlur={handleOnBlur} onKeyPress={onKeyPress} onChange={HandleOnInputChange} name='amountInGram' placeholder='Amount' />
                </Formik>
            </Table.Cell>
            <Table.Cell>g</Table.Cell>
            <Table.Cell>{carbs}</Table.Cell>
            <Table.Cell style={{ padding: '0' }} textAlign='center' >

                {deleteIngredient && <Button floated='right' onClick={() => HandleDelete(ingredientState.id)} color='red'>Delete</Button>}
                {!deleteIngredient && <Button floated='right' style={{ width: "6em" }} color='green' onClick={() => HandleOnAdd()} >Add</Button>}
            </Table.Cell>
        </>
    )

    function HandleOnInputChange(event: React.ChangeEvent<HTMLInputElement>, data: InputOnChangeData) {
        if (!isNaN(Number(data.value))) {
            setValidationError(false);
            let newIngredient = { ...ingredientState, amountInGram: Number(data.value) };
            setIngredient(newIngredient);
        }
        else {
            setValidationError(true);
            setError({ amountInGram: data.value });
        }
    }

    function HandleOnChange(event: React.SyntheticEvent<HTMLElement, Event>, data: DropdownProps) {
        if (!data) return;
        let selectedItem = foodNames.find(i => i.value === data.value);
        if (selectedItem) {
            let newFoodItem = selectedItem.value2;
            let mealId = mealStore?.selectedMeal ? mealStore?.selectedMeal.mealId : '';
            let newIngredient = { ...ingredientState, foodItem: newFoodItem, mealId: mealId };
            if (newIngredient.foodItem.name !== '' && newIngredient.amountInGram !== 0 && mealStore?.selectedMeal) {
                mealStore.editIngredient(newIngredient);
            }

            setIngredient(newIngredient);
        }
    }

    function HandleOnAdd() {
        mealStore.addIngredient(ingredientState)
        setIngredient(zeroState);
    }

    function onKeyPress(e: any) {
        if (e.key === 'Enter') {
            setIngredient(ingredientState);
            mealStore.editIngredient(ingredientState);
            onBlur();
        }
    }
    function handleOnBlur() {
        setIngredient(ingredientState);
        mealStore.editIngredient(ingredientState);
        onBlur();
    }

    function HandleDelete(ingredientId: string) {
        mealStore.deleteIngredient(ingredientId);
    }
}
