import { FoodItem } from "./foodItem";

export interface Ingredient {
    id: string;
    foodItem: FoodItem;
    amountInGram: number;
    protein: number;
    carbs: number;
    fat: number;
  }