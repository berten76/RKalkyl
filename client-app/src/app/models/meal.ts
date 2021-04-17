import { Ingredient } from "./ingredient";

export interface Meal {
    mealId: string;
    name: string;
    ingredients: Ingredient[];
    date: Date | null;
  }
