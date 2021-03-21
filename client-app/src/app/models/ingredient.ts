import { FoodItem } from "./foodItem";

export interface Ingredient {
    id: string;
    foodItem: FoodItem;
    mealId: string;
    amountInGram: number;
    protein: number;
    carbs: number;
    fat: number;
    selected: boolean;
  }