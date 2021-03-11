import axios, { AxiosResponse } from 'axios';
import { request } from 'node:http';
import { FoodItem } from '../models/foodItem';
import { Recepie } from '../models/recepie';

axios.defaults.baseURL = 'http://localhost:5000/api';

const responseBody = <T> (response: AxiosResponse<T>) => response.data;

const requests = {
    get: <T> (url: string) => axios.get<T>(url).then(responseBody),
    post: <T> (url: string, body: {}) => axios.post<T>(url).then(responseBody),
    put: <T> (url: string, body: {}) => axios.put<T>(url).then(responseBody),
    del: <T> (url: string) => axios.delete<T>(url).then(responseBody),
}

const Recepies = {
    list: () => requests.get<Recepie[]>('/recepies'),
    details: (id: string) => requests.get<Recepie>(`/recepies/${id}`),
    create: (recepie: Recepie) => axios.post('/recepies', recepie),
    update: (recepie: Recepie) => axios.put(`/recepies/${recepie.id}`, recepie),
    delete: (id: string) => axios.delete(`/recepies/${id}`)
}

const FoodItems = {
    list: () => requests.get<FoodItem[]>('/FoodItems')
}

const agent = {
    Recepies,
    FoodItems
}

export default agent;

