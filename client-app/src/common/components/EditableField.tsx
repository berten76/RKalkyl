import React, { useState } from 'react'
import { Form, FormField, Input, InputOnChangeData, Label } from 'semantic-ui-react';
import * as Yup from 'yup';

interface Props {
    mealName: string;
    NewMealNameEvent: (newMealName: string) => void;
}

export default function EditableField({ mealName, NewMealNameEvent }: Props) {
    const [editMode, setEditMode] = useState<boolean>(false);
    const [isValid, setIsValid] = useState<boolean>(true);
    const [newMealName, setNewMealName] = useState<string>(mealName);

    const validationSchema = Yup.object().shape({
        title: Yup.string().required('Title is required')
    });

    return (
        <>
            {!editMode && <h1 onClick={() => setEditMode(true)} >{newMealName}</h1>}
            {editMode &&
                <Form>
                    <FormField>
                        <Input
                            defaultValue={mealName}
                            onKeyDown={(e: any) => onKeyPress(e)}
                            onChange={HandleOnChange}
                        />
                        {!isValid && <Label basic color='red' pointing>
                            Please enter a value
                </Label>}
                    </FormField>
                </Form>

            }
        </>
    )

    function onKeyPress(e: any) {
        if (e.key === 'Enter') {
            NewMealNameEvent(newMealName);
            setEditMode(false);
        }
    }

    async function HandleOnChange(event: React.ChangeEvent<HTMLInputElement>, data: InputOnChangeData) {
        validationSchema.isValid({ title: data.value }).then(function (value) {
            setIsValid(value);
        })
            .catch(function (err) {
                console.log('err');
            });

        setNewMealName(data.value);

    }
}