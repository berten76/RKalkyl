import { Ingredient } from "./ingredient";

export interface Recepie {
    id: string;
    name: string;
    ingredients: Ingredient[];
  }
