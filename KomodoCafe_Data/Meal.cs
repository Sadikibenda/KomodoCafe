using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace KomodoCafe_Data
{
    public class Meal
    {
        public string MealName;
        public string Decription;
        public List<Meal> Ingredients;
        public double price;

        public Meal( string mealName, string decription, List<Meal> ingredients,  double price)
        {
            
            this.MealName = mealName;;
            this.Decription = decription;
            this.Ingredients = Ingredients;
            this.price = price; 
        }
    }
}
