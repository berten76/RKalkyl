import axios, { AxiosResponse } from 'axios';
import { request } from 'node:http';
import { FoodItem } from '../models/foodItem';
import { Meal } from '../models/meal';
import { Ingredient } from '../models/ingredient';
import { Recepie } from '../models/recepie';

axios.defaults.baseURL = 'http://localhost:5000/api';

const responseBody = <T> (response: AxiosResponse<T>) => response.data;

const requests = {
    get: <T> (url: string) => axios.get<T>(url).then(responseBody),
    post: <T> (url: string, body: {}) => axios.post<T>(url).then(responseBody),
    put: <T> (url: string, body: {}) => axios.put<T>(url).then(responseBody),
    del: <T> (url: string) => axios.delete<T>(url).then(responseBody),
}

const Meals = {
    list: () => requests.get<Meal[]>('/meals'),
    details: (id: string) => requests.get<Meal>(`/meals/${id}`),
    create: (meal: Meal) => axios.post('/meals', meal),
    update: (meal: Meal) => axios.put(`/meals/${meal.mealId}`, meal),
    delete: (id: string) => axios.delete(`/meals/${id}`)
}

const Ingredients = {
    list: () => requests.get<Ingredient[]>('/ingredients'),
    details: (id: string) => requests.get<Ingredient>(`/ingredients/${id}`),
    create: (ingredient: Ingredient) => axios.post('/ingredients', ingredient),
    update: (ingredient: Ingredient) => axios.put(`/ingredients/${ingredient.id}`, ingredient),
    delete: (id: string) => axios.delete(`/ingredients/${id}`)
}

const FoodItems = {
    list: () => requests.get<FoodItem[]>('/FoodItems')
}

const ParseRecepie = {
    parse: (mealId: string, recepie: Recepie) => axios.post<Ingredient[]>(`/mealParser/${mealId}`, recepie)
   // parse: (recepie: string) => axios.put(`/mealParser/${'tt'}`, recepie)
    //parse: (recepie: string) => axios.get<string>(`/mealParser/${recepie}`)
}
const agent = {
    Meals,
    Ingredients,
    FoodItems,
    ParseRecepie
}

export default agent;

