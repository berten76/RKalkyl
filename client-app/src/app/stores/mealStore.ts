import { makeAutoObservable, runInAction } from "mobx";
import agent from "../api/agent";
import { Meal } from "../models/meal";
import { v4 as uuid } from 'uuid';
import { Ingredient } from "../models/ingredient";
import { FoodItem } from "../models/foodItem";
export default class MealStore {

    meals: Meal[] = [];
    foodItems: FoodItem[] = [];
    selectedMeal: Meal | undefined = undefined;
    editMode = false;
    loading = false;
    lodingInitial = false;
    pasteMode = false;

    constructor() {
        makeAutoObservable(this)
    }

    loadMeals = async () => {
        this.setLoadingInitial(true);
        try {
            const meals = await agent.Meals.list();
            runInAction(() => {
                this.meals = [];
                meals.forEach(meal => {
                    this.meals.push(meal);
                })
                this.setLoadingInitial(false);
            })
        } catch (error) {
            console.log(error);
            runInAction(() => {
                this.setLoadingInitial(false);
            });
        }
    }

    loadFoodItems = async () => {
        this.setLoadingInitial(true);
        try {
            const foodItems = await agent.FoodItems.list();
            runInAction(() => {
                foodItems.forEach(foodItem => {
                    this.foodItems.push(foodItem);
                })
                this.setLoadingInitial(false);
            })

        } catch (error) {
            console.log(error);
            runInAction(() => {
                this.setLoadingInitial(false);
            })
        }
    }

    loadMeal = async (id: string) => {
        let meal = this.getMeal(id);
        if (meal) {
            this.selectedMeal = meal;
            return meal;
        } else {
            this.loading = true;
            try {
                meal = await agent.Meals.details(id);
                runInAction(() => {
                    this.selectedMeal = meal;
                    if (meal) {
                        if (!this.meals.find(m => m.mealId === meal?.mealId)) {
                            this.meals.push(meal);
                        }

                    }
                    this.setLoadingInitial(false);
                })
                return meal;
            } catch (error) {
                console.log(error);
                runInAction(() => {
                    this.setLoadingInitial(false);
                })
            }
        }
    }

    get mealsByDate() {
        return Array.from(this.meals).sort((a, b) =>
            a.date!.getTime() - b.date!.getTime());
    }

    /* get groupedMeals() {
         return Object.entries(
             this.meals.reduce((meals, meal) => {
                 const
             })
         )
     }*/

    private getMeal = (id: string) => {
        return this.meals.find(m => m.mealId === id);
    }

    setPasteMode = (mode: boolean) => {
        this.pasteMode = mode;
    }

    setLoadingInitial = (state: boolean) => {
        this.lodingInitial = state;
    }

    selectMeal = (id: string) => {
        this.selectedMeal = undefined;
        const temp = this.meals.find(m => m.mealId === id);
        this.selectedMeal = temp;
    }

    cancelSelectedMeal = () => {
        this.selectedMeal = undefined;
    }

    getSelectedMeal = (id: string) => {
        if (id === '') {
            return undefined;
        }
        return this.meals.find(r => r.mealId === id);
    }

    createMeal = async () => {
        this.loading = true;
        let newMeal = {
            mealId: uuid(),
            name: 'New meal',
            date: new Date(Date.now()),
            ingredients: []
        };
        try {
            await agent.Meals.create(newMeal);
            runInAction(() => {
                this.meals.push(newMeal);
                this.selectedMeal = newMeal;
                this.editMode = false;
                this.loading = false;

            })
        } catch (error) {
            console.log(error);
            runInAction(() => {
                this.loading = false;
            })
        }
    }

    addIngredient = async (ingredient: Ingredient) => {
        
        let mealId = this.selectedMeal?.mealId;
        if (!mealId) {
            console.log('could not add ingredient,no meal selected')
        }
        if (ingredient.id) {
            console.log('could not add ingredient, id is defined')
            return;
        }

        this.loading = true;

        try {
            ingredient.id = uuid();
            await agent.Ingredients.create(ingredient);
            runInAction(() => {
                let meal = this.meals.find(r => r.mealId === mealId);
                meal?.ingredients.push(ingredient);
            })
        } catch (error) {
            console.log(error);
        }
        console.log('add')

    }

    editMeal = async (meal: Meal) => {
        if(!this.selectedMeal) {
            console.log('could not edit ingredient,no meal selected');
            return;
        }

        this.loading = true;

        try {
            await agent.Meals.update(this.selectedMeal);
        } catch (error) {
            console.log(error);
        }
        runInAction(() => {
            this.loading = false;
        })
 
    }

    editIngredient = async (ingredient: Ingredient) => {
        console.log('edit')
        let mealId = this.selectedMeal?.mealId;
        if (!mealId) {
            console.log('could not edit ingredient,no meal selected')
            return
        }
        if (!ingredient.id) {
            console.log('could not edit ingredient, id not defined')
            return;
        }
        this.loading = true;


        try {
            await agent.Ingredients.update(ingredient);
            runInAction(() => {
                let updatedIngredients = new Array<Ingredient>();
                let meal = this.meals.find(r => r.mealId === mealId);
                if (!meal) {
                    console.log('could not edit ingredient,could not find meal')
                    this.loading = false;
                    return;
                }
                meal.ingredients.forEach(i => {
                    if (i.id !== ingredient.id) {
                        updatedIngredients.push(i);
                    }
                    else {
                        updatedIngredients.push(ingredient);
                    }
                });
                meal.ingredients = updatedIngredients;
            })
        } catch (error) {
            console.log(error);
        }
        this.loading = false;
    }

    deleteIngredient = async (ingredientId: string) => {
        try {
            await agent.Ingredients.delete(ingredientId);
            runInAction(() => {
                if (!this.selectedMeal) return;
                this.selectedMeal.ingredients = [...this.selectedMeal.ingredients.filter(i => i.id !== ingredientId)];
            });

        } catch (error) {
            console.log(error);
        }
    }

    deleteMeal = async (mealId: string) => {
        this.loading = true
        try {
            await agent.Meals.delete(mealId);
            runInAction(() => {
                this.meals = [...this.meals.filter(m => m.mealId !== mealId)];
            });

        } catch (error) {
            console.log(error);
        }
        finally {
            runInAction(() => {
                this.loading = false;
            })
        }
    }

    ParseRecepie = async (recepie: string) => {
        console.log('parse')
        let mealId = this.selectedMeal?.mealId;
        let recepieCsv = recepie.split(/\r|\n/).join(';');

        let rec = {
            res: recepieCsv,
        };

        this.loading = true;

        try {
            if (!mealId) mealId = 'notSet';
            let result = await agent.ParseRecepie.parse(mealId, rec);

            runInAction(() => {
                let ingredients = result.data;

                /* ingredients.map(i => {
                     if(this.selectedMeal) {
                         i.mealId = this.selectedMeal.mealId
                     }
                 });*/
                if (this.selectedMeal) {
                    this.selectedMeal.ingredients = ingredients;
                }
            })
        } catch (error) {
            console.log(error);
        }
    }

}