import { observer } from 'mobx-react-lite';
import React, { useState } from 'react';
import Calendar from 'react-calendar';
import { date } from 'yup';
import { useStore } from '../../../app/stores/store';


export default observer(function MealCalendar() {

    const { mealStore } = useStore();


    function HandleClickDay(date: Date){
        mealStore.setSelectedDate(date);
    }   
    function HandleMoveOnedayForward() {
        let date = new Date(mealStore.selectedDate);
        date.setDate(date.getDate()+ 1);
        mealStore.setSelectedDate(date);
    }
    function HandleMoveOnedaBack() {
        let date = new Date(mealStore.selectedDate);
        date.setDate(date.getDate()- 1);
        mealStore.setSelectedDate(date);
    }
    const date = new Date(mealStore.selectedDate);
    console.log(mealStore.selectedDate);
    return (
        <>
            <div className='dateSelector'>
                <button onClick={HandleMoveOnedaBack} className='leftDateButton'>{'<'}</button>
                 <span className='dateSpan'>  
                      {date.toLocaleString('default', { month: 'long' })+ ' ' + date.getDate() + ', ' + date.getFullYear()}
                </span>
                <button onClick={HandleMoveOnedayForward} className='rightDateButton'>{'>'}</button>
            </div>
            <Calendar
                onClickDay={HandleClickDay}
               value={mealStore.selectedDate}
             />
        </>
    )
})