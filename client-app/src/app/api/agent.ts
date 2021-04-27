import axios, { AxiosError, AxiosResponse } from 'axios';
import { FoodItem } from '../models/foodItem';
import { Meal } from '../models/meal';
import { Ingredient } from '../models/ingredient';
import { Recepie } from '../models/recepie';
import { toast } from 'react-toastify';
import { history } from '../..';

axios.defaults.baseURL = 'http://localhost:5000/api';

axios.interceptors.response.use(async response => {
    return response
}, (error: AxiosError) => {
    const {data, status} = error.response!;
    switch (status) {
        case 400:
            console.log('itt');
            console.log(data.errors);
            if (data.errors) {
                const modelStateErrors = [];
                for ( const key in data.errors) {
                    if (data.errors[key]) {
                        console.log('push');
                        console.log(key);
                        console.log(data.errors[key]);
                        modelStateErrors.push(data.errors[key])
                    }
                }
                throw modelStateErrors.flat();
            } else {
                toast.error(data);
            }
            
            break;
        case 401:
            toast.error('unauthorised');
            break;
        case 404:
            history.push('/not-found');
            break;
        case 500:
            toast.error('server error');
            break;
    }
    return Promise.reject(error);
})

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

