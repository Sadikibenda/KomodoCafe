using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using KomodoCafe_Data;


    public class MealRepository
    {
       public List<Meal> _mealDirectory = new List<Meal>();

        //Create
        public bool AddMeal(Meal meal)
        {
            _mealDirectory.Add(meal);
            return true;
        }

        //Read 
        public List<Meal> GetAllMeal()
        {
            return _mealDirectory;
        }

        public Meal GetMealbyMealName(string MealName)
        {
            foreach(Meal meal in _mealDirectory)
            {
                if(meal.MealName == MealName)
                {
                    return meal;
                }
                
            }
            return null;
        }   

        //Update
      /*  public void updateMeal(Meal meal)
        {
            Meal mealToUpdate = GetMealbyMealName(meal.MealName);
            if(mealToUpdate != null)
            {
            mealToUpdate.MealName = meal.MealName;
            mealToUpdate.Decription = meal.Decription;
            mealToUpdate.Ingredients = meal.Ingredients;
            mealToUpdate.price = meal.price;
            }
            
        } */

        public void updateMeal(string updateinput, string updateMeal_input, string updateData)
        {
            Meal oldMeal = _mealDirectory[Convert.ToInt32(updateinput)];

            switch (updateMeal_input)
            {
                case "1":
                    Console.WriteLine("update Meal Name");
                    break;

                case "2":
                    Console.WriteLine("update Description");
                    break;

                case "3":
                    Console.WriteLine("update Ingredients");
                    break;

                case "4":
                    Console.WriteLine("update Price");
                    break;

            } 

            _mealDirectory[Convert.ToInt32(updateinput)] = oldMeal;
        }

        //Delete

       public bool DeleteMeal(Meal existingmeal)
        {
            bool deleteResult = _mealDirectory.Remove(existingmeal);
            return deleteResult;
        }
        public void DeleteMealByMealNumber(int input)
        {
            _mealDirectory.RemoveAt(input);
        } 
    }
