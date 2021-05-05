import { createContext, useContext } from "react";
import CommonStore from "./commonStore";
import MealStore from "./mealStore";

interface Store {
    mealStore: MealStore;
    commonStore: CommonStore;
}

export const store: Store = {
    mealStore: new MealStore(),
    commonStore: new CommonStore()
}

export const StoreContext = createContext(store);

export function useStore() {
    return useContext(StoreContext);
}