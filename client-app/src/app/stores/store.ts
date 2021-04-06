import { createContext, useContext } from "react";
import MealStore from "./mealStore";

interface Store {
    mealStore: MealStore
}

export const store: Store = {
    mealStore: new MealStore()
}

export const StoreContext = createContext(store);

export function useStore() {
    return useContext(StoreContext);
}