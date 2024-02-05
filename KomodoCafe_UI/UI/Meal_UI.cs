using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using KomodoCafe_Data;



    public class Meal_UI
    {
        MealRepository _MealRepo = new MealRepository();

        public void Run()
        {
            RunApplication();
        }

        public void RunApplication()
        {
            bool isRunning = true;
            while(isRunning)
            {

                Console.ForegroundColor = ConsoleColor.DarkGreen;
                Console.WriteLine(
                    " \t \n"+ 
                    " \t========= Cafe menu ==========\n" +
                    " \t      <==============>                \n"  
                );

                 Console.ForegroundColor = ConsoleColor.Cyan;
                System.Console.WriteLine(
                    " \tThis Application whill help Manager to organize \n" +
                    " \t             Cafe's menu                         \n" 
                );

                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.WriteLine(
                    " \t Please Select from the following: \n"
                    );

                Console.ForegroundColor = ConsoleColor.White;
                Console.WriteLine(
                " \t1. Add Meal\n" +
                " \t2. Get Meal\n" +
                " \t3. Update Meal  \n" +
                " \t4. Delete Meal  \n"
                );

                Console.WriteLine(
                    " \t========== \n" +
                    " \tX. Exit\n" +
                    " \t========== \n"
                );

                string userinput = Console.ReadLine().ToLower();
                switch(userinput)
                {
                    case "x":
                        isRunning = CloseApplication();
                        break;

                    case "1":
                        AddMeal();
                        break;

                    case "2":
                        GetAllMeal();
                        break;

                    case "3":
                        updateMeal();
                        break;

                    case "4":
                        DeleteMeal();
                        break;

                    default:
                    Console.WriteLine("invalid Selection");
                    PressAnyKey();
                    break;
                }
            }


           
        } 

        public void AddMeal()
        {
            Meal newmeal = new Meal("", "", new List<Meal>(), 0.0 );

            Console.WriteLine("Please Enter Meal Name");
            newmeal.MealName = Console.ReadLine();

            Console.WriteLine("Please Enter Meal Description");
            newmeal.Decription = Console.ReadLine();

            Console.WriteLine("Enter ingredients (separated by commas):");
            string ingredientsInput = Console.ReadLine();
            List<string> ingredientNames = new List<string>(ingredientsInput.Split(','));
            List<Meal> ingredientsList = new List<Meal>();
            foreach (string ingredientName in ingredientNames)
            {
                // Create a new meal for each ingredient
                Meal ingredient = new Meal(ingredientName, "Description of " + ingredientName, new List<Meal>(), 0.0);
                ingredientsList.Add(ingredient);
            }

            Console.WriteLine("Please Enter Meal Price");
            newmeal.price = Convert.ToInt32(Console.ReadLine());

            _MealRepo.AddMeal(newmeal);
        }

        public void GetAllMeal()
        {
            Console.WriteLine("Here are your Meal(s)");

            //get List of meals
            List<Meal> meal = _MealRepo.GetAllMeal();
            Console.WriteLine("Meal in list = " + meal.Count);

            //get each meal
            for(int i = 0; i < meal.Count; i++)
            {
                Console.WriteLine("");
                Console.WriteLine(i+ ". " + meal[i].MealName);
                Console.WriteLine("Description: "+ meal[i].Decription);
                Console.WriteLine("Ingrediant: "+ meal[i].Ingredients); // Need help with populating List !!!!
                Console.WriteLine("Price: " + meal[i].price);
            }
        }

        public void updateMeal()      // Need Help with Update !!!!!!
        {
            Console.WriteLine("Please enter Meal number you would like to update");
            List<Meal> meal = _MealRepo.GetAllMeal();

            for(int i = 0; i < meal.Count; i++)
            {
                Console.WriteLine(i+ ". " + meal[i].MealName);
            }

            string updateinput = Console.ReadLine();
            Console.WriteLine(" Meal to update " + updateinput);
            Console.WriteLine(" Enter 1 to update Meal Name");
            Console.WriteLine(" Enter 2 to update Description");
            Console.WriteLine(" Enter 3 to update Ingredients");
            Console.WriteLine(" Enter 4 to update Price");

        
        string updateMeal_input = Console.ReadLine();
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

                default:
                    Console.WriteLine("invalid Selection");
                    break;
            } 

            string updateData = Console.ReadLine();
           _MealRepo.updateMeal(updateinput, updateMeal_input, updateData);
        }

        public void DeleteMeal()
        {
            Console.WriteLine("Please enter Meal number you would like to Delete");
             List<Meal> meal = _MealRepo.GetAllMeal();

            for(int i = 0; i < meal.Count; i++)
            {
                Console.WriteLine(i+ ". " + meal[i].MealName);
            }

            int input = Convert.ToInt32(Console.ReadLine());
            _MealRepo.DeleteMealByMealNumber(input);

        }

         public bool CloseApplication()  
         {    
              Console.WriteLine("\"Have a good day.\"");
              PressAnyKey();
             return false;
             }

             public void PressAnyKey() 
             {
              Console.ForegroundColor = ConsoleColor.DarkYellow;
              System.Console.WriteLine("\tPress Any Key to Continue...");
              Console.ResetColor();
               Console.ReadKey();
             }
            
    }
