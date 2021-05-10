import React from 'react';
import { useState } from 'react';
import { Button, Card, TextArea, TextAreaProps } from 'semantic-ui-react';
import { useStore } from '../../../app/stores/store';

export default function PasteDialog() {
    const { mealStore } = useStore();
    const [recepieString, setRecepieString] = useState<any>('');

    return (
        <Card fluid>
            <Card.Content>

                <Card.Description>
                    <TextArea
                        placeholder='Paste recepie here'
                        onChange={HandleOnInputChange}
                        style={{ minHeight: 200, minWidth: 400 }}
                    />
                </Card.Description>
            </Card.Content>
            <Card.Content extra>
                <Button onClick={() => HandleOnClick()} positive content='Parse recepie' />
            </Card.Content>
        </Card>
    )

    function HandleOnInputChange(event: React.ChangeEvent<HTMLTextAreaElement>, data: TextAreaProps) {

        const value = data.value;
        if (value) {
            setRecepieString(value);

        }
    }

    function HandleOnClick() {
        mealStore.ParseRecepie(recepieString);
        mealStore.setPasteMode(false)
    }
}