using Caliburn.Micro;
using MealPlanner.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using System.Windows;
using System.Windows.Controls;
using System.Xml.Serialization;

namespace MealPlanner.ViewModels
{

    public class ShellViewModel : Conductor<object>
    {
        PersonModel UserPerson = new PersonModel();
        private int calorieCalculatorAge;
        private string calorieCalculatorGender;
        private int calorieCalculatorHeight;
        private int calorieCalculatorWeight;
        private string calorieCalculatorActivity;
        private bool calorieCalculatorMale;
        private bool calorieCalculatorFemale;
        private BindableCollection<string> activities = new BindableCollection<string>();
        private int calorieCalculatorMaintainWeight;
        private int calorieCalculatorMildWeightLoss;
        private int calorieCalculatorWeightLoss;
        private int calorieCalculatorExtremeWeightLoss;

        private bool dietPlansHalfLbAWeek;
        private bool dietPlansOneLbAWeek;
        private bool dietPlansTwoLbsAWeek;

        private bool dietPlansZigzagPlanOne;
        private bool dietPlansZigzagPlanTwo;
        private bool dietPlansNoZigzagPlan;

        private int dietPlansZigzagOneSunday = 0;
        private int dietPlansZigzagOneMonday = 0;
        private int dietPlansZigzagOneTuesday = 0;
        private int dietPlansZigzagOneWednesday = 0;
        private int dietPlansZigzagOneThursday = 0;
        private int dietPlansZigzagOneFriday = 0;
        private int dietPlansZigzagOneSaturday = 0;

        private int dietPlansZigzagTwoSunday = 0;
        private int dietPlansZigzagTwoMonday = 0;
        private int dietPlansZigzagTwoTuesday = 0;
        private int dietPlansZigzagTwoWednesday = 0;
        private int dietPlansZigzagTwoThursday = 0;
        private int dietPlansZigzagTwoFriday = 0;
        private int dietPlansZigzagTwoSaturday = 0;

        private int dietPlansNoZigzagSunday = 0;
        private int dietPlansNoZigzagMonday = 0;
        private int dietPlansNoZigzagTuesday = 0;
        private int dietPlansNoZigzagWednesday = 0;
        private int dietPlansNoZigzagThursday = 0;
        private int dietPlansNoZigzagFriday = 0;
        private int dietPlansNoZigzagSaturday = 0;

        private string dietPlansTwoLbsAWeekIsVisible = "Visible";
        private List<int> personDailyCalories;
        private int mainTabControl = 0;

        private ObservableCollection<IngredientModel> ingredientDatabase = new ObservableCollection<IngredientModel>();
        private int selectedIngredient;

        private BindableCollection<string> units = new BindableCollection<string>();
        private string addIngredientUnit;
        private string addIngredientName;
        private int addIngredientCalories;
        private double addIngredientAmount;

        private string editIngredientName;
        private int editIngredientCalories;
        private double editIngredientAmount;
        private string editIngredientUnit;
        private BindableCollection<string> unitsEdit = new BindableCollection<string>();

        private ObservableCollection<MealModel> mealDatabase = new ObservableCollection<MealModel>();
        private int selectedMeal;

        private ObservableCollection<IngredientModel> addMealIngredients = new ObservableCollection<IngredientModel>();

        private BindableCollection<string> addMealIngredientDatabase = new BindableCollection<string>();
        private int addMealSelectedIngredient;
        private int selectedMealIngredient;
        private int addMealTotalCalories;
        private string addMealName;

        private int mealPlannerSundayTotalCalories;
        private int mealPlannerMondayTotalCalories;
        private int mealPlannerTuesdayTotalCalories;
        private int mealPlannerWednesdayTotalCalories;
        private int mealPlannerThursdayTotalCalories;
        private int mealPlannerFridayTotalCalories;
        private int mealPlannerSaturdayTotalCalories;

        private int mealPlannerSundayCurrentCalories;
        private int mealPlannerMondayCurrentCalories;
        private int mealPlannerTuesdayCurrentCalories;
        private int mealPlannerWednesdayCurrentCalories;
        private int mealPlannerThursdayCurrentCalories;
        private int mealPlannerFridayCurrentCalories;
        private int mealPlannerSaturdayCurrentCalories;

        private BindableCollection<string> sundayBreakfastOne = new BindableCollection<string>();
        private BindableCollection<string> sundayBreakfastTwo = new BindableCollection<string>();
        private BindableCollection<string> sundayLunchOne = new BindableCollection<string>();
        private BindableCollection<string> sundayLunchTwo = new BindableCollection<string>();
        private BindableCollection<string> sundayDinnerOne = new BindableCollection<string>();
        private BindableCollection<string> sundayDinnerTwo = new BindableCollection<string>();
        private BindableCollection<string> sundayBeverageOne = new BindableCollection<string>();
        private BindableCollection<string> sundayBeverageTwo = new BindableCollection<string>();
        private BindableCollection<string> sundayBeverageThree = new BindableCollection<string>();
        private BindableCollection<string> sundayBeverageFour = new BindableCollection<string>();
        private BindableCollection<string> sundaySnackOne = new BindableCollection<string>();
        private BindableCollection<string> sundaySnackTwo = new BindableCollection<string>();
        private BindableCollection<string> sundaySnackThree = new BindableCollection<string>();
        private BindableCollection<string> sundaySnackFour = new BindableCollection<string>();

        private int sundayBreakfastOneSelectedMeal = -1;
        private int sundayBreakfastTwoSelectedMeal = -1;
        private int sundayLunchOneSelectedMeal = -1;
        private int sundayLunchTwoSelectedMeal = -1;
        private int sundayDinnerOneSelectedMeal = -1;
        private int sundayDinnerTwoSelectedMeal = -1;
        private int sundayBeverageOneSelectedBeverage = -1;
        private int sundayBeverageTwoSelectedBeverage = -1;
        private int sundayBeverageThreeSelectedBeverage = -1;
        private int sundayBeverageFourSelectedBeverage = -1;
        private int sundaySnackOneSelectedSnack = -1;
        private int sundaySnackTwoSelectedSnack = -1;
        private int sundaySnackThreeSelectedSnack = -1;
        private int sundaySnackFourSelectedSnack = -1;

        private string sundayCurrentCaloriesColor = "White";

        private BindableCollection<string> mondayBreakfastOne = new BindableCollection<string>();
        private BindableCollection<string> mondayBreakfastTwo = new BindableCollection<string>();
        private BindableCollection<string> mondayLunchOne = new BindableCollection<string>();
        private BindableCollection<string> mondayLunchTwo = new BindableCollection<string>();
        private BindableCollection<string> mondayDinnerOne = new BindableCollection<string>();
        private BindableCollection<string> mondayDinnerTwo = new BindableCollection<string>();
        private BindableCollection<string> mondayBeverageOne = new BindableCollection<string>();
        private BindableCollection<string> mondayBeverageTwo = new BindableCollection<string>();
        private BindableCollection<string> mondayBeverageThree = new BindableCollection<string>();
        private BindableCollection<string> mondayBeverageFour = new BindableCollection<string>();
        private BindableCollection<string> mondaySnackOne = new BindableCollection<string>();
        private BindableCollection<string> mondaySnackTwo = new BindableCollection<string>();
        private BindableCollection<string> mondaySnackThree = new BindableCollection<string>();
        private BindableCollection<string> mondaySnackFour = new BindableCollection<string>();

        private int mondayBreakfastOneSelectedMeal = -1;
        private int mondayBreakfastTwoSelectedMeal = -1;
        private int mondayLunchOneSelectedMeal = -1;
        private int mondayLunchTwoSelectedMeal = -1;
        private int mondayDinnerOneSelectedMeal = -1;
        private int mondayDinnerTwoSelectedMeal = -1;
        private int mondayBeverageOneSelectedBeverage = -1;
        private int mondayBeverageTwoSelectedBeverage = -1;
        private int mondayBeverageThreeSelectedBeverage = -1;
        private int mondayBeverageFourSelectedBeverage = -1;
        private int mondaySnackOneSelectedSnack = -1;
        private int mondaySnackTwoSelectedSnack = -1;
        private int mondaySnackThreeSelectedSnack = -1;
        private int mondaySnackFourSelectedSnack = -1;

        private string mondayCurrentCaloriesColor = "White";

        private BindableCollection<string> tuesdayBreakfastOne = new BindableCollection<string>();
        private BindableCollection<string> tuesdayBreakfastTwo = new BindableCollection<string>();
        private BindableCollection<string> tuesdayLunchOne = new BindableCollection<string>();
        private BindableCollection<string> tuesdayLunchTwo = new BindableCollection<string>();
        private BindableCollection<string> tuesdayDinnerOne = new BindableCollection<string>();
        private BindableCollection<string> tuesdayDinnerTwo = new BindableCollection<string>();
        private BindableCollection<string> tuesdayBeverageOne = new BindableCollection<string>();
        private BindableCollection<string> tuesdayBeverageTwo = new BindableCollection<string>();
        private BindableCollection<string> tuesdayBeverageThree = new BindableCollection<string>();
        private BindableCollection<string> tuesdayBeverageFour = new BindableCollection<string>();
        private BindableCollection<string> tuesdaySnackOne = new BindableCollection<string>();
        private BindableCollection<string> tuesdaySnackTwo = new BindableCollection<string>();
        private BindableCollection<string> tuesdaySnackThree = new BindableCollection<string>();
        private BindableCollection<string> tuesdaySnackFour = new BindableCollection<string>();

        private int tuesdayBreakfastOneSelectedMeal = -1;
        private int tuesdayBreakfastTwoSelectedMeal = -1;
        private int tuesdayLunchOneSelectedMeal = -1;
        private int tuesdayLunchTwoSelectedMeal = -1;
        private int tuesdayDinnerOneSelectedMeal = -1;
        private int tuesdayDinnerTwoSelectedMeal = -1;
        private int tuesdayBeverageOneSelectedBeverage = -1;
        private int tuesdayBeverageTwoSelectedBeverage = -1;
        private int tuesdayBeverageThreeSelectedBeverage = -1;
        private int tuesdayBeverageFourSelectedBeverage = -1;
        private int tuesdaySnackOneSelectedSnack = -1;
        private int tuesdaySnackTwoSelectedSnack = -1;
        private int tuesdaySnackThreeSelectedSnack = -1;
        private int tuesdaySnackFourSelectedSnack = -1;

        private string tuesdayCurrentCaloriesColor = "White";

        private BindableCollection<string> wednesdayBreakfastOne = new BindableCollection<string>();
        private BindableCollection<string> wednesdayBreakfastTwo = new BindableCollection<string>();
        private BindableCollection<string> wednesdayLunchOne = new BindableCollection<string>();
        private BindableCollection<string> wednesdayLunchTwo = new BindableCollection<string>();
        private BindableCollection<string> wednesdayDinnerOne = new BindableCollection<string>();
        private BindableCollection<string> wednesdayDinnerTwo = new BindableCollection<string>();
        private BindableCollection<string> wednesdayBeverageOne = new BindableCollection<string>();
        private BindableCollection<string> wednesdayBeverageTwo = new BindableCollection<string>();
        private BindableCollection<string> wednesdayBeverageThree = new BindableCollection<string>();
        private BindableCollection<string> wednesdayBeverageFour = new BindableCollection<string>();
        private BindableCollection<string> wednesdaySnackOne = new BindableCollection<string>();
        private BindableCollection<string> wednesdaySnackTwo = new BindableCollection<string>();
        private BindableCollection<string> wednesdaySnackThree = new BindableCollection<string>();
        private BindableCollection<string> wednesdaySnackFour = new BindableCollection<string>();

        private int wednesdayBreakfastOneSelectedMeal = -1;
        private int wednesdayBreakfastTwoSelectedMeal = -1;
        private int wednesdayLunchOneSelectedMeal = -1;
        private int wednesdayLunchTwoSelectedMeal = -1;
        private int wednesdayDinnerOneSelectedMeal = -1;
        private int wednesdayDinnerTwoSelectedMeal = -1;
        private int wednesdayBeverageOneSelectedBeverage = -1;
        private int wednesdayBeverageTwoSelectedBeverage = -1;
        private int wednesdayBeverageThreeSelectedBeverage = -1;
        private int wednesdayBeverageFourSelectedBeverage = -1;
        private int wednesdaySnackOneSelectedSnack = -1;
        private int wednesdaySnackTwoSelectedSnack = -1;
        private int wednesdaySnackThreeSelectedSnack = -1;
        private int wednesdaySnackFourSelectedSnack = -1;

        private string wednesdayCurrentCaloriesColor = "White";

        private BindableCollection<string> thursdayBreakfastOne = new BindableCollection<string>();
        private BindableCollection<string> thursdayBreakfastTwo = new BindableCollection<string>();
        private BindableCollection<string> thursdayLunchOne = new BindableCollection<string>();
        private BindableCollection<string> thursdayLunchTwo = new BindableCollection<string>();
        private BindableCollection<string> thursdayDinnerOne = new BindableCollection<string>();
        private BindableCollection<string> thursdayDinnerTwo = new BindableCollection<string>();
        private BindableCollection<string> thursdayBeverageOne = new BindableCollection<string>();
        private BindableCollection<string> thursdayBeverageTwo = new BindableCollection<string>();
        private BindableCollection<string> thursdayBeverageThree = new BindableCollection<string>();
        private BindableCollection<string> thursdayBeverageFour = new BindableCollection<string>();
        private BindableCollection<string> thursdaySnackOne = new BindableCollection<string>();
        private BindableCollection<string> thursdaySnackTwo = new BindableCollection<string>();
        private BindableCollection<string> thursdaySnackThree = new BindableCollection<string>();
        private BindableCollection<string> thursdaySnackFour = new BindableCollection<string>();

        private int thursdayBreakfastOneSelectedMeal = -1;
        private int thursdayBreakfastTwoSelectedMeal = -1;
        private int thursdayLunchOneSelectedMeal = -1;
        private int thursdayLunchTwoSelectedMeal = -1;
        private int thursdayDinnerOneSelectedMeal = -1;
        private int thursdayDinnerTwoSelectedMeal = -1;
        private int thursdayBeverageOneSelectedBeverage = -1;
        private int thursdayBeverageTwoSelectedBeverage = -1;
        private int thursdayBeverageThreeSelectedBeverage = -1;
        private int thursdayBeverageFourSelectedBeverage = -1;
        private int thursdaySnackOneSelectedSnack = -1;
        private int thursdaySnackTwoSelectedSnack = -1;
        private int thursdaySnackThreeSelectedSnack = -1;
        private int thursdaySnackFourSelectedSnack = -1;

        private string thursdayCurrentCaloriesColor = "White";

        private BindableCollection<string> fridayBreakfastOne = new BindableCollection<string>();
        private BindableCollection<string> fridayBreakfastTwo = new BindableCollection<string>();
        private BindableCollection<string> fridayLunchOne = new BindableCollection<string>();
        private BindableCollection<string> fridayLunchTwo = new BindableCollection<string>();
        private BindableCollection<string> fridayDinnerOne = new BindableCollection<string>();
        private BindableCollection<string> fridayDinnerTwo = new BindableCollection<string>();
        private BindableCollection<string> fridayBeverageOne = new BindableCollection<string>();
        private BindableCollection<string> fridayBeverageTwo = new BindableCollection<string>();
        private BindableCollection<string> fridayBeverageThree = new BindableCollection<string>();
        private BindableCollection<string> fridayBeverageFour = new BindableCollection<string>();
        private BindableCollection<string> fridaySnackOne = new BindableCollection<string>();
        private BindableCollection<string> fridaySnackTwo = new BindableCollection<string>();
        private BindableCollection<string> fridaySnackThree = new BindableCollection<string>();
        private BindableCollection<string> fridaySnackFour = new BindableCollection<string>();

        private int fridayBreakfastOneSelectedMeal = -1;
        private int fridayBreakfastTwoSelectedMeal = -1;
        private int fridayLunchOneSelectedMeal = -1;
        private int fridayLunchTwoSelectedMeal = -1;
        private int fridayDinnerOneSelectedMeal = -1;
        private int fridayDinnerTwoSelectedMeal = -1;
        private int fridayBeverageOneSelectedBeverage = -1;
        private int fridayBeverageTwoSelectedBeverage = -1;
        private int fridayBeverageThreeSelectedBeverage = -1;
        private int fridayBeverageFourSelectedBeverage = -1;
        private int fridaySnackOneSelectedSnack = -1;
        private int fridaySnackTwoSelectedSnack = -1;
        private int fridaySnackThreeSelectedSnack = -1;
        private int fridaySnackFourSelectedSnack = -1;

        private string fridayCurrentCaloriesColor = "White";

        private BindableCollection<string> saturdayBreakfastOne = new BindableCollection<string>();
        private BindableCollection<string> saturdayBreakfastTwo = new BindableCollection<string>();
        private BindableCollection<string> saturdayLunchOne = new BindableCollection<string>();
        private BindableCollection<string> saturdayLunchTwo = new BindableCollection<string>();
        private BindableCollection<string> saturdayDinnerOne = new BindableCollection<string>();
        private BindableCollection<string> saturdayDinnerTwo = new BindableCollection<string>();
        private BindableCollection<string> saturdayBeverageOne = new BindableCollection<string>();
        private BindableCollection<string> saturdayBeverageTwo = new BindableCollection<string>();
        private BindableCollection<string> saturdayBeverageThree = new BindableCollection<string>();
        private BindableCollection<string> saturdayBeverageFour = new BindableCollection<string>();
        private BindableCollection<string> saturdaySnackOne = new BindableCollection<string>();
        private BindableCollection<string> saturdaySnackTwo = new BindableCollection<string>();
        private BindableCollection<string> saturdaySnackThree = new BindableCollection<string>();
        private BindableCollection<string> saturdaySnackFour = new BindableCollection<string>();

        private int saturdayBreakfastOneSelectedMeal = -1;
        private int saturdayBreakfastTwoSelectedMeal = -1;
        private int saturdayLunchOneSelectedMeal = -1;
        private int saturdayLunchTwoSelectedMeal = -1;
        private int saturdayDinnerOneSelectedMeal = -1;
        private int saturdayDinnerTwoSelectedMeal = -1;
        private int saturdayBeverageOneSelectedBeverage = -1;
        private int saturdayBeverageTwoSelectedBeverage = -1;
        private int saturdayBeverageThreeSelectedBeverage = -1;
        private int saturdayBeverageFourSelectedBeverage = -1;
        private int saturdaySnackOneSelectedSnack = -1;
        private int saturdaySnackTwoSelectedSnack = -1;
        private int saturdaySnackThreeSelectedSnack = -1;
        private int saturdaySnackFourSelectedSnack = -1;

        private string saturdayCurrentCaloriesColor = "White";

        /// CONSTRUCTOR
        public ShellViewModel()
        {
            PopulateCalorieCalculatorActivities();
            PopulateMealPlannerUnits();
            LoadDataOnStartup();


            IngredientModel banana = new IngredientModel() { Name = "Banana", Calories = 89, Amount = 1, Unit = "piece" };
            IngredientModel salmon = new IngredientModel() { Name = "Salmon fillet", Calories = 412, Amount = 0.5, Unit = "lbs." };

            if (IngredientDatabase.Count == 0)
            {


                IngredientDatabase.Add(banana);
                IngredientDatabase.Add(salmon);
                IngredientDatabase.Add(banana);
                IngredientDatabase.Add(salmon);
                IngredientDatabase.Add(banana);
                IngredientDatabase.Add(salmon);
            }

            if (MealDatabase.Count == 0)
            {

                List<IngredientModel> ingredients = new List<IngredientModel>();

                ingredients.Add(banana);
                ingredients.Add(salmon);
                ingredients.Add(banana);
                ingredients.Add(salmon);
                ingredients.Add(banana);
                ingredients.Add(salmon);

                MealModel sampleMeal = new MealModel() { Name = "Sample Meal", Ingredients = ingredients, TotalCalories = AddCaloriesOfIngredients(ingredients) };

                MealDatabase.Add(sampleMeal);
            }

            //AddMealIngredients.Add(salmon);

            PopulateMealAndIngredientDatabase();

        }

        public int CalorieCalculatorAge
        {
            get => calorieCalculatorAge;
            set
            {
                calorieCalculatorAge = value;
                NotifyOfPropertyChange(() => CalorieCalculatorAge);
            }

        }
        public string CalorieCalculatorGender
        {
            get => calorieCalculatorGender;
            set
            {
                calorieCalculatorGender = value;
                NotifyOfPropertyChange(() => CalorieCalculatorGender);
            }

        }
        public int CalorieCalculatorHeight
        {
            get => calorieCalculatorHeight;
            set
            {
                calorieCalculatorHeight = value;
                NotifyOfPropertyChange(() => CalorieCalculatorHeight);
            }
        }
        public int CalorieCalculatorWeight
        {
            get => calorieCalculatorWeight;
            set
            {
                calorieCalculatorWeight = value;
                NotifyOfPropertyChange(() => CalorieCalculatorWeight);
            }
        }
        public string CalorieCalculatorActivity
        {
            get => calorieCalculatorActivity;
            set
            {
                calorieCalculatorActivity = value;
                NotifyOfPropertyChange(() => CalorieCalculatorActivity);
            }
        }
        public bool CalorieCalculatorMale
        {
            get => calorieCalculatorMale;
            set
            {
                calorieCalculatorMale = value;
                NotifyOfPropertyChange(() => CalorieCalculatorMale);
            }

        }
        public bool CalorieCalculatorFemale
        {
            get => calorieCalculatorFemale;
            set
            {
                calorieCalculatorFemale = value;
                NotifyOfPropertyChange(() => CalorieCalculatorFemale);
            }
        }
        public BindableCollection<string> Activities { get => activities; set => activities = value; }

        public int CalorieCalculatorMaintainWeight
        {
            get => calorieCalculatorMaintainWeight;
            set
            {
                calorieCalculatorMaintainWeight = value;
                NotifyOfPropertyChange(() => CalorieCalculatorMaintainWeight);
            }
        }
        public int CalorieCalculatorMildWeightLoss
        {
            get => calorieCalculatorMildWeightLoss;
            set
            {
                calorieCalculatorMildWeightLoss = value;
                NotifyOfPropertyChange(() => CalorieCalculatorMildWeightLoss);
            }
        }
        public int CalorieCalculatorWeightLoss
        {
            get => calorieCalculatorWeightLoss;
            set
            {
                calorieCalculatorWeightLoss = value;
                NotifyOfPropertyChange(() => CalorieCalculatorWeightLoss);
            }
        }
        public int CalorieCalculatorExtremeWeightLoss
        {
            get => calorieCalculatorExtremeWeightLoss;
            set
            {
                calorieCalculatorExtremeWeightLoss = value;
                NotifyOfPropertyChange(() => CalorieCalculatorExtremeWeightLoss);
            }
        }

        public bool DietPlansHalfLbAWeek
        {
            get => dietPlansHalfLbAWeek;
            set
            {
                dietPlansHalfLbAWeek = value;
                NotifyOfPropertyChange(() => DietPlansHalfLbAWeek);

                if (dietPlansHalfLbAWeek)
                {
                    UserPerson.LbsPerWeek = 0.5;
                    DisplayZigzagPlanTables(UserPerson);
                }
            }
        }
        public bool DietPlansOneLbAWeek
        {
            get => dietPlansOneLbAWeek;
            set
            {
                dietPlansOneLbAWeek = value;
                NotifyOfPropertyChange(() => DietPlansOneLbAWeek);


                if (dietPlansOneLbAWeek)
                {
                    UserPerson.LbsPerWeek = 1.0;
                    DisplayZigzagPlanTables(UserPerson);
                }
            }
        }
        public bool DietPlansTwoLbsAWeek
        {
            get => dietPlansTwoLbsAWeek;
            set
            {
                dietPlansTwoLbsAWeek = value;
                NotifyOfPropertyChange(() => DietPlansTwoLbsAWeek);

                if (dietPlansTwoLbsAWeek)
                {
                    UserPerson.LbsPerWeek = 2.0;
                    DisplayZigzagPlanTables(UserPerson);
                }
            }
        }

        public bool DietPlansZigzagPlanOne
        {
            get => dietPlansZigzagPlanOne;
            set
            {
                if (CheckIfPoundsPerWeekSelected())
                {
                    dietPlansZigzagPlanOne = value;
                    NotifyOfPropertyChange(() => DietPlansZigzagPlanOne);
                    if (dietPlansZigzagPlanOne)
                    {
                        UserPerson.ZigzagPlan = 0;
                        AppendZigzagPlanCaloriesToPerson(UserPerson);
                    }
                }
                else
                {
                    MessageBox.Show("Please select how many pound you want to lose first.");
                }

            }
        }
        public bool DietPlansZigzagPlanTwo
        {
            get => dietPlansZigzagPlanTwo;
            set
            {
                if (CheckIfPoundsPerWeekSelected())
                {
                    dietPlansZigzagPlanTwo = value;
                    NotifyOfPropertyChange(() => DietPlansZigzagPlanTwo);
                    if (dietPlansZigzagPlanTwo)
                    {
                        UserPerson.ZigzagPlan = 1;
                        AppendZigzagPlanCaloriesToPerson(UserPerson);
                    }
                }
                else
                {
                    MessageBox.Show("Please select how many pound you want to lose first.");
                }
            }
        }
        public bool DietPlansNoZigzagPlan
        {
            get => dietPlansNoZigzagPlan;
            set
            {
                if (CheckIfPoundsPerWeekSelected())
                {
                    dietPlansNoZigzagPlan = value;
                    NotifyOfPropertyChange(() => DietPlansNoZigzagPlan);
                    if (dietPlansNoZigzagPlan)
                    {
                        UserPerson.ZigzagPlan = 2;
                        AppendZigzagPlanCaloriesToPerson(UserPerson);
                    }
                }
                else
                {
                    MessageBox.Show("Please select how many pound you want to lose first.");
                }
            }
        }

        public int DietPlansZigzagOneSunday
        {
            get => dietPlansZigzagOneSunday;
            set
            {
                dietPlansZigzagOneSunday = value;
                NotifyOfPropertyChange(() => DietPlansZigzagOneSunday);
            }
        }
        public int DietPlansZigzagOneMonday
        {
            get => dietPlansZigzagOneMonday;
            set
            {
                dietPlansZigzagOneMonday = value;
                NotifyOfPropertyChange(() => DietPlansZigzagOneMonday);
            }
        }
        public int DietPlansZigzagOneTuesday
        {
            get => dietPlansZigzagOneTuesday;
            set
            {
                dietPlansZigzagOneTuesday = value;
                NotifyOfPropertyChange(() => DietPlansZigzagOneTuesday);
            }

        }
        public int DietPlansZigzagOneWednesday
        {
            get => dietPlansZigzagOneWednesday;
            set
            {
                dietPlansZigzagOneWednesday = value;
                NotifyOfPropertyChange(() => DietPlansZigzagOneWednesday);
            }

        }
        public int DietPlansZigzagOneThursday
        {
            get => dietPlansZigzagOneThursday;
            set
            {
                dietPlansZigzagOneThursday = value;
                NotifyOfPropertyChange(() => DietPlansZigzagOneThursday);
            }

        }
        public int DietPlansZigzagOneFriday
        {
            get => dietPlansZigzagOneFriday;
            set
            {
                dietPlansZigzagOneFriday = value;
                NotifyOfPropertyChange(() => DietPlansZigzagOneFriday);
            }
        }
        public int DietPlansZigzagOneSaturday
        {
            get => dietPlansZigzagOneSaturday;
            set
            {
                dietPlansZigzagOneSaturday = value;
                NotifyOfPropertyChange(() => DietPlansZigzagOneSaturday);
            }
        }

        public int DietPlansZigzagTwoSunday
        {
            get => dietPlansZigzagTwoSunday;
            set
            {
                dietPlansZigzagTwoSunday = value;
                NotifyOfPropertyChange(() => DietPlansZigzagTwoSunday);
            }
        }
        public int DietPlansZigzagTwoMonday
        {
            get => dietPlansZigzagTwoMonday;
            set
            {
                dietPlansZigzagTwoMonday = value;
                NotifyOfPropertyChange(() => DietPlansZigzagTwoMonday);
            }
        }
        public int DietPlansZigzagTwoTuesday
        {
            get => dietPlansZigzagTwoTuesday;
            set
            {
                dietPlansZigzagTwoTuesday = value;
                NotifyOfPropertyChange(() => DietPlansZigzagTwoTuesday);
            }
        }
        public int DietPlansZigzagTwoWednesday
        {
            get => dietPlansZigzagTwoWednesday;
            set
            {
                dietPlansZigzagTwoWednesday = value;
                NotifyOfPropertyChange(() => DietPlansZigzagTwoWednesday);
            }
        }
        public int DietPlansZigzagTwoThursday
        {
            get => dietPlansZigzagTwoThursday; set
            {
                dietPlansZigzagTwoThursday = value;
                NotifyOfPropertyChange(() => DietPlansZigzagTwoThursday);
            }
        }
        public int DietPlansZigzagTwoFriday
        {
            get => dietPlansZigzagTwoFriday;
            set
            {
                dietPlansZigzagTwoFriday = value;
                NotifyOfPropertyChange(() => DietPlansZigzagTwoFriday);
            }

        }
        public int DietPlansZigzagTwoSaturday
        {
            get => dietPlansZigzagTwoSaturday;
            set
            {
                dietPlansZigzagTwoSaturday = value;
                NotifyOfPropertyChange(() => DietPlansZigzagTwoSaturday);
            }
        }

        public int DietPlansNoZigzagSunday
        {
            get => dietPlansNoZigzagSunday;
            set
            {
                dietPlansNoZigzagSunday = value;
                NotifyOfPropertyChange(() => DietPlansNoZigzagSunday);
            }
        }
        public int DietPlansNoZigzagMonday
        {
            get => dietPlansNoZigzagMonday;
            set
            {
                dietPlansNoZigzagMonday = value;
                NotifyOfPropertyChange(() => DietPlansNoZigzagMonday);
            }
        }
        public int DietPlansNoZigzagTuesday
        {
            get => dietPlansNoZigzagTuesday;
            set
            {
                dietPlansNoZigzagTuesday = value;
                NotifyOfPropertyChange(() => DietPlansNoZigzagTuesday);
            }
        }
        public int DietPlansNoZigzagWednesday
        {
            get => dietPlansNoZigzagWednesday;
            set
            {
                dietPlansNoZigzagWednesday = value;
                NotifyOfPropertyChange(() => DietPlansNoZigzagWednesday);
            }
        }
        public int DietPlansNoZigzagThursday
        {
            get => dietPlansNoZigzagThursday;
            set
            {
                dietPlansNoZigzagThursday = value;
                NotifyOfPropertyChange(() => DietPlansNoZigzagThursday);
            }
        }
        public int DietPlansNoZigzagFriday
        {
            get => dietPlansNoZigzagFriday;
            set
            {
                dietPlansNoZigzagFriday = value;
                NotifyOfPropertyChange(() => DietPlansNoZigzagFriday);
            }
        }
        public int DietPlansNoZigzagSaturday
        {
            get => dietPlansNoZigzagSaturday;
            set
            {
                dietPlansNoZigzagSaturday = value;
                NotifyOfPropertyChange(() => DietPlansNoZigzagSaturday);
            }
        }

        public int MainTabControl
        {
            get => mainTabControl;
            set
            {
                mainTabControl = value;
                NotifyOfPropertyChange(() => MainTabControl);
            }
        }
        public List<int> PersonDailyCalories
        {
            get => personDailyCalories; set => personDailyCalories = value; }
        public string DietPlansTwoLbsAWeekIsVisible
        {
            get => dietPlansTwoLbsAWeekIsVisible;
            set
            {
                dietPlansTwoLbsAWeekIsVisible = value;
                NotifyOfPropertyChange(() => DietPlansTwoLbsAWeekIsVisible);
            }
        }

        public ObservableCollection<IngredientModel> IngredientDatabase
        {
            get => ingredientDatabase;
            set
            {
                ingredientDatabase = value;
                NotifyOfPropertyChange(() => IngredientDatabase);
            }
        }
        public int SelectedIngredient
        {
            get => selectedIngredient;
            set
            {
                selectedIngredient = value;
                NotifyOfPropertyChange(() => SelectedIngredient);

                if (SelectedIngredient > -1 && SelectedIngredient <= IngredientDatabase.Count - 1)
                {
                    EditIngredientName = IngredientDatabase[SelectedIngredient].Name;
                    EditIngredientCalories = IngredientDatabase[SelectedIngredient].Calories;
                    EditIngredientAmount = IngredientDatabase[SelectedIngredient].Amount;
                    EditIngredientUnit = IngredientDatabase[SelectedIngredient].Unit;
                }
            }
        }
        public BindableCollection<string> Units { get => units; set => units = value; }
        public string AddIngredientUnit
        {
            get => addIngredientUnit;
            set
            {
                addIngredientUnit = value;
                NotifyOfPropertyChange(() => AddIngredientUnit);
            }
        }
        public string AddIngredientName
        {
            get => addIngredientName;
            set
            {
                addIngredientName = value;
                NotifyOfPropertyChange(() => AddIngredientName);
            }
        }
        public int AddIngredientCalories
        {
            get => addIngredientCalories;
            set
            {
                addIngredientCalories = value;
                NotifyOfPropertyChange(() => AddIngredientCalories);
            }
        }
        public double AddIngredientAmount
        {
            get => addIngredientAmount;
            set
            {
                addIngredientAmount = value;
                NotifyOfPropertyChange(() => AddIngredientAmount);
            }
        }
        public BindableCollection<string> UnitsEdit { get => unitsEdit; set => unitsEdit = value; }
        public string EditIngredientName
        {
            get => editIngredientName;
            set
            {
                editIngredientName = value;
                NotifyOfPropertyChange(() => EditIngredientName);
            }
        }
        public int EditIngredientCalories
        {
            get => editIngredientCalories;
            set
            {
                editIngredientCalories = value;
                NotifyOfPropertyChange(() => EditIngredientCalories);
            }
        }
        public double EditIngredientAmount
        {
            get => editIngredientAmount;
            set
            {
                editIngredientAmount = value;
                NotifyOfPropertyChange(() => EditIngredientAmount);
            }
        }
        public string EditIngredientUnit
        {
            get => editIngredientUnit;
            set
            {
                editIngredientUnit = value;
                NotifyOfPropertyChange(() => EditIngredientUnit);
            }
        }
        public ObservableCollection<MealModel> MealDatabase
        {
            get => mealDatabase;
            set
            {
                mealDatabase = value;
                NotifyOfPropertyChange(() => MealDatabase);
            }
        }
        public int SelectedMeal
        {
            get => selectedMeal;
            set
            {
                selectedMeal = value;
                NotifyOfPropertyChange(() => SelectedMeal);
                //if (SelectedMeal > -1 && SelectedMeal <= MealDatabase.Count - 1)
                //{
                //    EditIngredientName = IngredientDatabase[SelectedIngredient].Name;
                //    EditIngredientCalories = IngredientDatabase[SelectedIngredient].Calories;
                //    EditIngredientAmount = IngredientDatabase[SelectedIngredient].Amount;
                //    EditIngredientUnit = IngredientDatabase[SelectedIngredient].Unit;
                //}
            }
        }
        public ObservableCollection<IngredientModel> AddMealIngredients
        {
            get => addMealIngredients;
            set
            {
                addMealIngredients = value;
                NotifyOfPropertyChange(() => AddMealIngredients);
            }
        }
        public BindableCollection<string> AddMealIngredientDatabase
        {
            get => addMealIngredientDatabase;
            set
            {
                addMealIngredientDatabase = value;
                NotifyOfPropertyChange(() => AddMealIngredientDatabase);

            }
        }
        public int AddMealSelectedIngredient
        {
            get => addMealSelectedIngredient;
            set
            {
                addMealSelectedIngredient = value;
                NotifyOfPropertyChange(() => AddMealSelectedIngredient);
            }
        }
        public int SelectedMealIngredient
        {
            get => selectedMealIngredient;
            set
            {
                selectedMealIngredient = value;
                NotifyOfPropertyChange(() => AddMealSelectedIngredient);
            }
        }
        public int AddMealTotalCalories
        {
            get => addMealTotalCalories;
            set
            {
                addMealTotalCalories = value;
                NotifyOfPropertyChange(() => AddMealTotalCalories);
            }
        }
        public string AddMealName
        {
            get => addMealName;
            set
            {
                addMealName = value;
                NotifyOfPropertyChange(() => AddMealName);
            }
        }

        public int MealPlannerSundayTotalCalories
        {
            get => mealPlannerSundayTotalCalories;
            set
            {
                mealPlannerSundayTotalCalories = value;
                NotifyOfPropertyChange(() => MealPlannerSundayTotalCalories);
            }
        }
        public int MealPlannerMondayTotalCalories
        {
            get => mealPlannerMondayTotalCalories;
            set
            {
                mealPlannerMondayTotalCalories = value;
                NotifyOfPropertyChange(() => MealPlannerMondayTotalCalories);
            }
        }
        public int MealPlannerTuesdayTotalCalories
        {
            get => mealPlannerTuesdayTotalCalories;
            set
            {
                mealPlannerTuesdayTotalCalories = value;
                NotifyOfPropertyChange(() => MealPlannerTuesdayTotalCalories);
            }
        }
        public int MealPlannerWednesdayTotalCalories
        {
            get => mealPlannerWednesdayTotalCalories;
            set
            {
                mealPlannerWednesdayTotalCalories = value;
                NotifyOfPropertyChange(() => MealPlannerWednesdayTotalCalories);
            }
        }
        public int MealPlannerThursdayTotalCalories
        {
            get => mealPlannerThursdayTotalCalories;
            set
            {
                mealPlannerThursdayTotalCalories = value;
                NotifyOfPropertyChange(() => MealPlannerThursdayTotalCalories);
            }
        }
        public int MealPlannerFridayTotalCalories
        {
            get => mealPlannerFridayTotalCalories;
            set
            {
                mealPlannerFridayTotalCalories = value;
                NotifyOfPropertyChange(() => MealPlannerFridayTotalCalories);
            }
        }
        public int MealPlannerSaturdayTotalCalories
        {
            get => mealPlannerSaturdayTotalCalories;
            set
            {
                mealPlannerSaturdayTotalCalories = value;
                NotifyOfPropertyChange(() => MealPlannerSaturdayTotalCalories);
            }
        }

        public int MealPlannerSundayCurrentCalories
        {
            get => mealPlannerSundayCurrentCalories;
            set
            {
                mealPlannerSundayCurrentCalories = value;
                NotifyOfPropertyChange(() => MealPlannerSundayCurrentCalories);
            }
        }
        public int MealPlannerMondayCurrentCalories
        {
            get => mealPlannerMondayCurrentCalories;
            set
            {
                mealPlannerMondayCurrentCalories = value;
                NotifyOfPropertyChange(() => MealPlannerMondayCurrentCalories);
            }
        }
        public int MealPlannerTuesdayCurrentCalories
        {
            get => mealPlannerTuesdayCurrentCalories;
            set
            {
                mealPlannerTuesdayCurrentCalories = value;
                NotifyOfPropertyChange(() => MealPlannerTuesdayCurrentCalories);
            }
        }
        public int MealPlannerWednesdayCurrentCalories
        {
            get => mealPlannerWednesdayCurrentCalories;
            set
            {
                mealPlannerWednesdayCurrentCalories = value;
                NotifyOfPropertyChange(() => MealPlannerWednesdayCurrentCalories);
            }
        }
        public int MealPlannerThursdayCurrentCalories
        {
            get => mealPlannerThursdayCurrentCalories;
            set
            {
                mealPlannerThursdayCurrentCalories = value;
                NotifyOfPropertyChange(() => MealPlannerThursdayCurrentCalories);
            }
        }
        public int MealPlannerFridayCurrentCalories
        {
            get => mealPlannerFridayCurrentCalories;
            set
            {
                mealPlannerFridayCurrentCalories = value;
                NotifyOfPropertyChange(() => MealPlannerFridayCurrentCalories);
            }
        }
        public int MealPlannerSaturdayCurrentCalories
        {
            get => mealPlannerSaturdayCurrentCalories;
            set
            {
                mealPlannerSaturdayCurrentCalories = value;
                NotifyOfPropertyChange(() => MealPlannerSaturdayCurrentCalories);
            }
        }

        public BindableCollection<string> SundayBreakfastOne { get => sundayBreakfastOne; set { sundayBreakfastOne = value; NotifyOfPropertyChange(() => SundayBreakfastOne); } }
        public BindableCollection<string> SundayBreakfastTwo { get => sundayBreakfastTwo; set { sundayBreakfastTwo = value; NotifyOfPropertyChange(() => SundayBreakfastTwo); } }
        public BindableCollection<string> SundayLunchOne { get => sundayLunchOne; set { sundayLunchOne = value; NotifyOfPropertyChange(() => SundayLunchOne); } }
        public BindableCollection<string> SundayLunchTwo { get => sundayLunchTwo; set { sundayLunchTwo = value; NotifyOfPropertyChange(() => SundayLunchTwo); } }
        public BindableCollection<string> SundayDinnerOne { get => sundayDinnerOne; set { sundayDinnerOne = value; NotifyOfPropertyChange(() => SundayDinnerOne); } }
        public BindableCollection<string> SundayDinnerTwo { get => sundayDinnerTwo; set { sundayDinnerTwo = value; NotifyOfPropertyChange(() => SundayDinnerTwo); } }
        public BindableCollection<string> SundayBeverageOne { get => sundayBeverageOne; set { sundayBeverageOne = value; NotifyOfPropertyChange(() => SundayBeverageOne); } }
        public BindableCollection<string> SundayBeverageTwo { get => sundayBeverageTwo; set { sundayBeverageTwo = value; NotifyOfPropertyChange(() => SundayBeverageTwo); } }
        public BindableCollection<string> SundayBeverageThree { get => sundayBeverageThree; set { sundayBeverageThree = value; NotifyOfPropertyChange(() => SundayBeverageThree); } }
        public BindableCollection<string> SundayBeverageFour { get => sundayBeverageFour; set { sundayBeverageFour = value; NotifyOfPropertyChange(() => SundayBeverageFour); } }
        public BindableCollection<string> SundaySnackOne { get => sundaySnackOne; set { sundaySnackOne = value; NotifyOfPropertyChange(() => SundaySnackOne); } }
        public BindableCollection<string> SundaySnackTwo { get => sundaySnackTwo; set { sundaySnackTwo = value; NotifyOfPropertyChange(() => SundaySnackTwo); } }
        public BindableCollection<string> SundaySnackThree { get => sundaySnackThree; set { sundaySnackThree = value; NotifyOfPropertyChange(() => SundaySnackThree); } }
        public BindableCollection<string> SundaySnackFour { get => sundaySnackFour; set { sundaySnackFour = value; NotifyOfPropertyChange(() => SundaySnackFour); } }

        public int SundayBreakfastOneSelectedMeal { get => sundayBreakfastOneSelectedMeal;
            set {
                sundayBreakfastOneSelectedMeal = value;
                NotifyOfPropertyChange(() => SundayBreakfastOneSelectedMeal);
                if (SundayBreakfastOneSelectedMeal != -1)
                {
                    UpdateSundayCurrentCalories();
                }
            } }
        public int SundayBreakfastTwoSelectedMeal { get => sundayBreakfastTwoSelectedMeal;
            set {
                sundayBreakfastTwoSelectedMeal = value;
                NotifyOfPropertyChange(() => SundayBreakfastTwoSelectedMeal);
                if (SundayBreakfastTwoSelectedMeal != -1)
                {
                    UpdateSundayCurrentCalories();
                }
            } }
        public int SundayLunchOneSelectedMeal { get => sundayLunchOneSelectedMeal;
            set {
                sundayLunchOneSelectedMeal = value;
                NotifyOfPropertyChange(() => SundayLunchOneSelectedMeal);
                if (SundayLunchOneSelectedMeal != -1)
                {
                    UpdateSundayCurrentCalories();
                }
            } }
        public int SundayLunchTwoSelectedMeal { get => sundayLunchTwoSelectedMeal;
            set {
                sundayLunchTwoSelectedMeal = value;
                NotifyOfPropertyChange(() => SundayLunchTwoSelectedMeal);
                if (SundayLunchTwoSelectedMeal != -1)
                {
                    UpdateSundayCurrentCalories();
                }

            } }
        public int SundayDinnerOneSelectedMeal { get => sundayDinnerOneSelectedMeal;
            set {
                sundayDinnerOneSelectedMeal = value;
                NotifyOfPropertyChange(() => SundayDinnerOneSelectedMeal);
                if (SundayDinnerOneSelectedMeal != -1)
                {
                    UpdateSundayCurrentCalories();
                }
            } }
        public int SundayDinnerTwoSelectedMeal { get => sundayDinnerTwoSelectedMeal;
            set {
                sundayDinnerTwoSelectedMeal = value;
                NotifyOfPropertyChange(() => SundayDinnerTwoSelectedMeal);
                if (SundayDinnerTwoSelectedMeal != -1)
                {
                    UpdateSundayCurrentCalories();
                }
            } }
        public int SundayBeverageOneSelectedBeverage { get => sundayBeverageOneSelectedBeverage;
            set {
                sundayBeverageOneSelectedBeverage = value;
                NotifyOfPropertyChange(() => SundayBeverageOneSelectedBeverage);
                if (SundayBeverageOneSelectedBeverage != -1)
                {
                    UpdateSundayCurrentCalories();
                }
            } }
        public int SundayBeverageTwoSelectedBeverage { get => sundayBeverageTwoSelectedBeverage;
            set {
                sundayBeverageTwoSelectedBeverage = value;
                NotifyOfPropertyChange(() => SundayBeverageTwoSelectedBeverage);
                if (SundayBeverageTwoSelectedBeverage != -1)
                {
                    UpdateSundayCurrentCalories();
                }
            } }
        public int SundayBeverageThreeSelectedBeverage { get => sundayBeverageThreeSelectedBeverage;
            set {
                sundayBeverageThreeSelectedBeverage = value;
                NotifyOfPropertyChange(() => SundayBeverageThreeSelectedBeverage);
                if (SundayBeverageThreeSelectedBeverage != -1)
                {
                    UpdateSundayCurrentCalories();
                }
            } }
        public int SundayBeverageFourSelectedBeverage { get => sundayBeverageFourSelectedBeverage;
            set {
                sundayBeverageFourSelectedBeverage = value;
                NotifyOfPropertyChange(() => SundayBeverageFourSelectedBeverage);
                if (SundayBeverageFourSelectedBeverage != -1)
                {
                    UpdateSundayCurrentCalories();
                }
            } }
        public int SundaySnackOneSelectedSnack { get => sundaySnackOneSelectedSnack;
            set {
                sundaySnackOneSelectedSnack = value;
                NotifyOfPropertyChange(() => SundaySnackOneSelectedSnack);
                if (SundaySnackOneSelectedSnack != -1)
                {
                    UpdateSundayCurrentCalories();
                }
            } }
        public int SundaySnackTwoSelectedSnack { get => sundaySnackTwoSelectedSnack;
            set {
                sundaySnackTwoSelectedSnack = value;
                NotifyOfPropertyChange(() => SundaySnackTwoSelectedSnack);
                if (SundaySnackTwoSelectedSnack != -1)
                {
                    UpdateSundayCurrentCalories();
                }
            } }
        public int SundaySnackThreeSelectedSnack { get => sundaySnackThreeSelectedSnack;
            set {
                sundaySnackThreeSelectedSnack = value;
                NotifyOfPropertyChange(() => SundaySnackThreeSelectedSnack);
                if (SundaySnackThreeSelectedSnack != -1)
                {
                    UpdateSundayCurrentCalories();
                }
            } }
        public int SundaySnackFourSelectedSnack { get => sundaySnackFourSelectedSnack;
            set {
                sundaySnackFourSelectedSnack = value;
                NotifyOfPropertyChange(() => SundaySnackFourSelectedSnack);
                if (SundaySnackFourSelectedSnack != -1)
                {
                    UpdateSundayCurrentCalories();
                }
            } }

        public string SundayCurrentCaloriesColor
        {
            get => sundayCurrentCaloriesColor;
            set
            {
                sundayCurrentCaloriesColor = value;
                NotifyOfPropertyChange(() => SundayCurrentCaloriesColor);
            }
        }

        public BindableCollection<string> MondayBreakfastOne { get => mondayBreakfastOne; set { mondayBreakfastOne = value; NotifyOfPropertyChange(() => MondayBreakfastOne); } }
        public BindableCollection<string> MondayBreakfastTwo { get => mondayBreakfastTwo; set { mondayBreakfastTwo = value; NotifyOfPropertyChange(() => MondayBreakfastTwo); } }
        public BindableCollection<string> MondayLunchOne { get => mondayLunchOne; set { mondayLunchOne = value; NotifyOfPropertyChange(() => MondayLunchOne); } }
        public BindableCollection<string> MondayLunchTwo { get => mondayLunchTwo; set { mondayLunchTwo = value; NotifyOfPropertyChange(() => MondayLunchTwo); } }
        public BindableCollection<string> MondayDinnerOne { get => mondayDinnerOne; set { mondayDinnerOne = value; NotifyOfPropertyChange(() => MondayDinnerOne); } }
        public BindableCollection<string> MondayDinnerTwo { get => mondayDinnerTwo; set { mondayDinnerTwo = value; NotifyOfPropertyChange(() => MondayDinnerTwo); } }
        public BindableCollection<string> MondayBeverageOne { get => mondayBeverageOne; set { mondayBeverageOne = value; NotifyOfPropertyChange(() => MondayBeverageOne); } }
        public BindableCollection<string> MondayBeverageTwo { get => mondayBeverageTwo; set { mondayBeverageTwo = value; NotifyOfPropertyChange(() => MondayBeverageTwo); } }
        public BindableCollection<string> MondayBeverageThree { get => mondayBeverageThree; set { mondayBeverageThree = value; NotifyOfPropertyChange(() => MondayBeverageThree); } }
        public BindableCollection<string> MondayBeverageFour { get => mondayBeverageFour; set { mondayBeverageFour = value; NotifyOfPropertyChange(() => MondayBeverageFour); } }
        public BindableCollection<string> MondaySnackOne { get => mondaySnackOne; set { mondaySnackOne = value; NotifyOfPropertyChange(() => MondaySnackOne); } }
        public BindableCollection<string> MondaySnackTwo { get => mondaySnackTwo; set { mondaySnackTwo = value; NotifyOfPropertyChange(() => MondaySnackTwo); } }
        public BindableCollection<string> MondaySnackThree { get => mondaySnackThree; set { mondaySnackThree = value; NotifyOfPropertyChange(() => MondaySnackThree); } }
        public BindableCollection<string> MondaySnackFour { get => mondaySnackFour; set { mondaySnackFour = value; NotifyOfPropertyChange(() => MondaySnackFour); } }

        public int MondayBreakfastOneSelectedMeal
        {
            get => mondayBreakfastOneSelectedMeal;
            set
            {
                mondayBreakfastOneSelectedMeal = value;
                NotifyOfPropertyChange(() => MondayBreakfastOneSelectedMeal);
                if (MondayBreakfastOneSelectedMeal != -1)
                {
                    UpdateMondayCurrentCalories();
                }
            }
        }
        public int MondayBreakfastTwoSelectedMeal
        {
            get => mondayBreakfastTwoSelectedMeal;
            set
            {
                mondayBreakfastTwoSelectedMeal = value;
                NotifyOfPropertyChange(() => MondayBreakfastTwoSelectedMeal);
                if (MondayBreakfastTwoSelectedMeal != -1)
                {
                    UpdateMondayCurrentCalories();
                }
            }
        }
        public int MondayLunchOneSelectedMeal
        {
            get => mondayLunchOneSelectedMeal;
            set
            {
                mondayLunchOneSelectedMeal = value;
                NotifyOfPropertyChange(() => MondayLunchOneSelectedMeal);
                if (MondayLunchOneSelectedMeal != -1)
                {
                    UpdateMondayCurrentCalories();
                }
            }
        }
        public int MondayLunchTwoSelectedMeal
        {
            get => mondayLunchTwoSelectedMeal;
            set
            {
                mondayLunchTwoSelectedMeal = value;
                NotifyOfPropertyChange(() => MondayLunchTwoSelectedMeal);
                if (MondayLunchTwoSelectedMeal != -1)
                {
                    UpdateMondayCurrentCalories();
                }

            }
        }
        public int MondayDinnerOneSelectedMeal
        {
            get => mondayDinnerOneSelectedMeal;
            set
            {
                mondayDinnerOneSelectedMeal = value;
                NotifyOfPropertyChange(() => MondayDinnerOneSelectedMeal);
                if (MondayDinnerOneSelectedMeal != -1)
                {
                    UpdateMondayCurrentCalories();
                }
            }
        }
        public int MondayDinnerTwoSelectedMeal
        {
            get => mondayDinnerTwoSelectedMeal;
            set
            {
                mondayDinnerTwoSelectedMeal = value;
                NotifyOfPropertyChange(() => MondayDinnerTwoSelectedMeal);
                if (MondayDinnerTwoSelectedMeal != -1)
                {
                    UpdateMondayCurrentCalories();
                }
            }
        }
        public int MondayBeverageOneSelectedBeverage
        {
            get => mondayBeverageOneSelectedBeverage;
            set
            {
                mondayBeverageOneSelectedBeverage = value;
                NotifyOfPropertyChange(() => MondayBeverageOneSelectedBeverage);
                if (MondayBeverageOneSelectedBeverage != -1)
                {
                    UpdateMondayCurrentCalories();
                }
            }
        }
        public int MondayBeverageTwoSelectedBeverage
        {
            get => mondayBeverageTwoSelectedBeverage;
            set
            {
                mondayBeverageTwoSelectedBeverage = value;
                NotifyOfPropertyChange(() => MondayBeverageTwoSelectedBeverage);
                if (MondayBeverageTwoSelectedBeverage != -1)
                {
                    UpdateMondayCurrentCalories();
                }
            }
        }
        public int MondayBeverageThreeSelectedBeverage
        {
            get => mondayBeverageThreeSelectedBeverage;
            set
            {
                mondayBeverageThreeSelectedBeverage = value;
                NotifyOfPropertyChange(() => MondayBeverageThreeSelectedBeverage);
                if (MondayBeverageThreeSelectedBeverage != -1)
                {
                    UpdateMondayCurrentCalories();
                }
            }
        }
        public int MondayBeverageFourSelectedBeverage
        {
            get => mondayBeverageFourSelectedBeverage;
            set
            {
                mondayBeverageFourSelectedBeverage = value;
                NotifyOfPropertyChange(() => MondayBeverageFourSelectedBeverage);
                if (MondayBeverageFourSelectedBeverage != -1)
                {
                    UpdateMondayCurrentCalories();
                }
            }
        }
        public int MondaySnackOneSelectedSnack
        {
            get => mondaySnackOneSelectedSnack;
            set
            {
                mondaySnackOneSelectedSnack = value;
                NotifyOfPropertyChange(() => MondaySnackOneSelectedSnack);
                if (MondaySnackOneSelectedSnack != -1)
                {
                    UpdateMondayCurrentCalories();
                }
            }
        }
        public int MondaySnackTwoSelectedSnack
        {
            get => mondaySnackTwoSelectedSnack;
            set
            {
                mondaySnackTwoSelectedSnack = value;
                NotifyOfPropertyChange(() => MondaySnackTwoSelectedSnack);
                if (MondaySnackTwoSelectedSnack != -1)
                {
                    UpdateMondayCurrentCalories();
                }
            }
        }
        public int MondaySnackThreeSelectedSnack
        {
            get => mondaySnackThreeSelectedSnack;
            set
            {
                mondaySnackThreeSelectedSnack = value;
                NotifyOfPropertyChange(() => MondaySnackThreeSelectedSnack);
                if (MondaySnackThreeSelectedSnack != -1)
                {
                    UpdateMondayCurrentCalories();
                }
            }
        }
        public int MondaySnackFourSelectedSnack
        {
            get => mondaySnackFourSelectedSnack;
            set
            {
                mondaySnackFourSelectedSnack = value;
                NotifyOfPropertyChange(() => MondaySnackFourSelectedSnack);
                if (MondaySnackFourSelectedSnack != -1)
                {
                    UpdateMondayCurrentCalories();
                }
            }
        }

        public string MondayCurrentCaloriesColor
        {
            get => mondayCurrentCaloriesColor;
            set
            {
                mondayCurrentCaloriesColor = value;
                NotifyOfPropertyChange(() => MondayCurrentCaloriesColor);
            }
        }

        public BindableCollection<string> TuesdayBreakfastOne { get => tuesdayBreakfastOne; set { tuesdayBreakfastOne = value; NotifyOfPropertyChange(() => TuesdayBreakfastOne); } }
        public BindableCollection<string> TuesdayBreakfastTwo { get => tuesdayBreakfastTwo; set { tuesdayBreakfastTwo = value; NotifyOfPropertyChange(() => TuesdayBreakfastTwo); } }
        public BindableCollection<string> TuesdayLunchOne { get => tuesdayLunchOne; set { tuesdayLunchOne = value; NotifyOfPropertyChange(() => TuesdayLunchOne); } }
        public BindableCollection<string> TuesdayLunchTwo { get => tuesdayLunchTwo; set { tuesdayLunchTwo = value; NotifyOfPropertyChange(() => TuesdayLunchTwo); } }
        public BindableCollection<string> TuesdayDinnerOne { get => tuesdayDinnerOne; set { tuesdayDinnerOne = value; NotifyOfPropertyChange(() => TuesdayDinnerOne); } }
        public BindableCollection<string> TuesdayDinnerTwo { get => tuesdayDinnerTwo; set { tuesdayDinnerTwo = value; NotifyOfPropertyChange(() => TuesdayDinnerTwo); } }
        public BindableCollection<string> TuesdayBeverageOne { get => tuesdayBeverageOne; set { tuesdayBeverageOne = value; NotifyOfPropertyChange(() => TuesdayBeverageOne); } }
        public BindableCollection<string> TuesdayBeverageTwo { get => tuesdayBeverageTwo; set { tuesdayBeverageTwo = value; NotifyOfPropertyChange(() => TuesdayBeverageTwo); } }
        public BindableCollection<string> TuesdayBeverageThree { get => tuesdayBeverageThree; set { tuesdayBeverageThree = value; NotifyOfPropertyChange(() => TuesdayBeverageThree); } }
        public BindableCollection<string> TuesdayBeverageFour { get => tuesdayBeverageFour; set { tuesdayBeverageFour = value; NotifyOfPropertyChange(() => TuesdayBeverageFour); } }
        public BindableCollection<string> TuesdaySnackOne { get => tuesdaySnackOne; set { tuesdaySnackOne = value; NotifyOfPropertyChange(() => TuesdaySnackOne); } }
        public BindableCollection<string> TuesdaySnackTwo { get => tuesdaySnackTwo; set { tuesdaySnackTwo = value; NotifyOfPropertyChange(() => TuesdaySnackTwo); } }
        public BindableCollection<string> TuesdaySnackThree { get => tuesdaySnackThree; set { tuesdaySnackThree = value; NotifyOfPropertyChange(() => TuesdaySnackThree); } }
        public BindableCollection<string> TuesdaySnackFour { get => tuesdaySnackFour; set { tuesdaySnackFour = value; NotifyOfPropertyChange(() => TuesdaySnackFour); } }

        public int TuesdayBreakfastOneSelectedMeal
        {
            get => tuesdayBreakfastOneSelectedMeal;
            set
            {
                tuesdayBreakfastOneSelectedMeal = value;
                NotifyOfPropertyChange(() => TuesdayBreakfastOneSelectedMeal);
                if (TuesdayBreakfastOneSelectedMeal != -1)
                {
                    UpdateTuesdayCurrentCalories();
                }
            }
        }
        public int TuesdayBreakfastTwoSelectedMeal
        {
            get => tuesdayBreakfastTwoSelectedMeal;
            set
            {
                tuesdayBreakfastTwoSelectedMeal = value;
                NotifyOfPropertyChange(() => TuesdayBreakfastTwoSelectedMeal);
                if (TuesdayBreakfastTwoSelectedMeal != -1)
                {
                    UpdateTuesdayCurrentCalories();
                }
            }
        }
        public int TuesdayLunchOneSelectedMeal
        {
            get => tuesdayLunchOneSelectedMeal;
            set
            {
                tuesdayLunchOneSelectedMeal = value;
                NotifyOfPropertyChange(() => TuesdayLunchOneSelectedMeal);
                if (TuesdayLunchOneSelectedMeal != -1)
                {
                    UpdateTuesdayCurrentCalories();
                }
            }
        }
        public int TuesdayLunchTwoSelectedMeal
        {
            get => tuesdayLunchTwoSelectedMeal;
            set
            {
                tuesdayLunchTwoSelectedMeal = value;
                NotifyOfPropertyChange(() => TuesdayLunchTwoSelectedMeal);
                if (TuesdayLunchTwoSelectedMeal != -1)
                {
                    UpdateTuesdayCurrentCalories();
                }

            }
        }
        public int TuesdayDinnerOneSelectedMeal
        {
            get => tuesdayDinnerOneSelectedMeal;
            set
            {
                tuesdayDinnerOneSelectedMeal = value;
                NotifyOfPropertyChange(() => TuesdayDinnerOneSelectedMeal);
                if (TuesdayDinnerOneSelectedMeal != -1)
                {
                    UpdateTuesdayCurrentCalories();
                }
            }
        }
        public int TuesdayDinnerTwoSelectedMeal
        {
            get => tuesdayDinnerTwoSelectedMeal;
            set
            {
                tuesdayDinnerTwoSelectedMeal = value;
                NotifyOfPropertyChange(() => TuesdayDinnerTwoSelectedMeal);
                if (TuesdayDinnerTwoSelectedMeal != -1)
                {
                    UpdateTuesdayCurrentCalories();
                }
            }
        }
        public int TuesdayBeverageOneSelectedBeverage
        {
            get => tuesdayBeverageOneSelectedBeverage;
            set
            {
                tuesdayBeverageOneSelectedBeverage = value;
                NotifyOfPropertyChange(() => TuesdayBeverageOneSelectedBeverage);
                if (TuesdayBeverageOneSelectedBeverage != -1)
                {
                    UpdateTuesdayCurrentCalories();
                }
            }
        }
        public int TuesdayBeverageTwoSelectedBeverage
        {
            get => tuesdayBeverageTwoSelectedBeverage;
            set
            {
                tuesdayBeverageTwoSelectedBeverage = value;
                NotifyOfPropertyChange(() => TuesdayBeverageTwoSelectedBeverage);
                if (TuesdayBeverageTwoSelectedBeverage != -1)
                {
                    UpdateTuesdayCurrentCalories();
                }
            }
        }
        public int TuesdayBeverageThreeSelectedBeverage
        {
            get => tuesdayBeverageThreeSelectedBeverage;
            set
            {
                tuesdayBeverageThreeSelectedBeverage = value;
                NotifyOfPropertyChange(() => TuesdayBeverageThreeSelectedBeverage);
                if (TuesdayBeverageThreeSelectedBeverage != -1)
                {
                    UpdateTuesdayCurrentCalories();
                }
            }
        }
        public int TuesdayBeverageFourSelectedBeverage
        {
            get => tuesdayBeverageFourSelectedBeverage;
            set
            {
                tuesdayBeverageFourSelectedBeverage = value;
                NotifyOfPropertyChange(() => TuesdayBeverageFourSelectedBeverage);
                if (TuesdayBeverageFourSelectedBeverage != -1)
                {
                    UpdateTuesdayCurrentCalories();
                }
            }
        }
        public int TuesdaySnackOneSelectedSnack
        {
            get => tuesdaySnackOneSelectedSnack;
            set
            {
                tuesdaySnackOneSelectedSnack = value;
                NotifyOfPropertyChange(() => TuesdaySnackOneSelectedSnack);
                if (TuesdaySnackOneSelectedSnack != -1)
                {
                    UpdateTuesdayCurrentCalories();
                }
            }
        }
        public int TuesdaySnackTwoSelectedSnack
        {
            get => tuesdaySnackTwoSelectedSnack;
            set
            {
                tuesdaySnackTwoSelectedSnack = value;
                NotifyOfPropertyChange(() => TuesdaySnackTwoSelectedSnack);
                if (TuesdaySnackTwoSelectedSnack != -1)
                {
                    UpdateTuesdayCurrentCalories();
                }
            }
        }
        public int TuesdaySnackThreeSelectedSnack
        {
            get => tuesdaySnackThreeSelectedSnack;
            set
            {
                tuesdaySnackThreeSelectedSnack = value;
                NotifyOfPropertyChange(() => TuesdaySnackThreeSelectedSnack);
                if (TuesdaySnackThreeSelectedSnack != -1)
                {
                    UpdateTuesdayCurrentCalories();
                }
            }
        }
        public int TuesdaySnackFourSelectedSnack
        {
            get => tuesdaySnackFourSelectedSnack;
            set
            {
                tuesdaySnackFourSelectedSnack = value;
                NotifyOfPropertyChange(() => TuesdaySnackFourSelectedSnack);
                if (TuesdaySnackFourSelectedSnack != -1)
                {
                    UpdateTuesdayCurrentCalories();
                }
            }
        }

        public string TuesdayCurrentCaloriesColor
        {
            get => tuesdayCurrentCaloriesColor;
            set
            {
                tuesdayCurrentCaloriesColor = value;
                NotifyOfPropertyChange(() => TuesdayCurrentCaloriesColor);
            }
        }

        public BindableCollection<string> WednesdayBreakfastOne { get => wednesdayBreakfastOne; set { wednesdayBreakfastOne = value; NotifyOfPropertyChange(() => WednesdayBreakfastOne); } }
        public BindableCollection<string> WednesdayBreakfastTwo { get => wednesdayBreakfastTwo; set { wednesdayBreakfastTwo = value; NotifyOfPropertyChange(() => WednesdayBreakfastTwo); } }
        public BindableCollection<string> WednesdayLunchOne { get => wednesdayLunchOne; set { wednesdayLunchOne = value; NotifyOfPropertyChange(() => WednesdayLunchOne); } }
        public BindableCollection<string> WednesdayLunchTwo { get => wednesdayLunchTwo; set { wednesdayLunchTwo = value; NotifyOfPropertyChange(() => WednesdayLunchTwo); } }
        public BindableCollection<string> WednesdayDinnerOne { get => wednesdayDinnerOne; set { wednesdayDinnerOne = value; NotifyOfPropertyChange(() => WednesdayDinnerOne); } }
        public BindableCollection<string> WednesdayDinnerTwo { get => wednesdayDinnerTwo; set { wednesdayDinnerTwo = value; NotifyOfPropertyChange(() => WednesdayDinnerTwo); } }
        public BindableCollection<string> WednesdayBeverageOne { get => wednesdayBeverageOne; set { wednesdayBeverageOne = value; NotifyOfPropertyChange(() => WednesdayBeverageOne); } }
        public BindableCollection<string> WednesdayBeverageTwo { get => wednesdayBeverageTwo; set { wednesdayBeverageTwo = value; NotifyOfPropertyChange(() => WednesdayBeverageTwo); } }
        public BindableCollection<string> WednesdayBeverageThree { get => wednesdayBeverageThree; set { wednesdayBeverageThree = value; NotifyOfPropertyChange(() => WednesdayBeverageThree); } }
        public BindableCollection<string> WednesdayBeverageFour { get => wednesdayBeverageFour; set { wednesdayBeverageFour = value; NotifyOfPropertyChange(() => WednesdayBeverageFour); } }
        public BindableCollection<string> WednesdaySnackOne { get => wednesdaySnackOne; set { wednesdaySnackOne = value; NotifyOfPropertyChange(() => WednesdaySnackOne); } }
        public BindableCollection<string> WednesdaySnackTwo { get => wednesdaySnackTwo; set { wednesdaySnackTwo = value; NotifyOfPropertyChange(() => WednesdaySnackTwo); } }
        public BindableCollection<string> WednesdaySnackThree { get => wednesdaySnackThree; set { wednesdaySnackThree = value; NotifyOfPropertyChange(() => WednesdaySnackThree); } }
        public BindableCollection<string> WednesdaySnackFour { get => wednesdaySnackFour; set { wednesdaySnackFour = value; NotifyOfPropertyChange(() => WednesdaySnackFour); } }

        public int WednesdayBreakfastOneSelectedMeal
        {
            get => wednesdayBreakfastOneSelectedMeal;
            set
            {
                wednesdayBreakfastOneSelectedMeal = value;
                NotifyOfPropertyChange(() => WednesdayBreakfastOneSelectedMeal);
                if (WednesdayBreakfastOneSelectedMeal != -1)
                {
                    UpdateWednesdayCurrentCalories();
                }
            }
        }
        public int WednesdayBreakfastTwoSelectedMeal
        {
            get => wednesdayBreakfastTwoSelectedMeal;
            set
            {
                wednesdayBreakfastTwoSelectedMeal = value;
                NotifyOfPropertyChange(() => WednesdayBreakfastTwoSelectedMeal);
                if (WednesdayBreakfastTwoSelectedMeal != -1)
                {
                    UpdateWednesdayCurrentCalories();
                }
            }
        }
        public int WednesdayLunchOneSelectedMeal
        {
            get => wednesdayLunchOneSelectedMeal;
            set
            {
                wednesdayLunchOneSelectedMeal = value;
                NotifyOfPropertyChange(() => WednesdayLunchOneSelectedMeal);
                if (WednesdayLunchOneSelectedMeal != -1)
                {
                    UpdateWednesdayCurrentCalories();
                }
            }
        }
        public int WednesdayLunchTwoSelectedMeal
        {
            get => wednesdayLunchTwoSelectedMeal;
            set
            {
                wednesdayLunchTwoSelectedMeal = value;
                NotifyOfPropertyChange(() => WednesdayLunchTwoSelectedMeal);
                if (WednesdayLunchTwoSelectedMeal != -1)
                {
                    UpdateWednesdayCurrentCalories();
                }

            }
        }
        public int WednesdayDinnerOneSelectedMeal
        {
            get => wednesdayDinnerOneSelectedMeal;
            set
            {
                wednesdayDinnerOneSelectedMeal = value;
                NotifyOfPropertyChange(() => WednesdayDinnerOneSelectedMeal);
                if (WednesdayDinnerOneSelectedMeal != -1)
                {
                    UpdateWednesdayCurrentCalories();
                }
            }
        }
        public int WednesdayDinnerTwoSelectedMeal
        {
            get => wednesdayDinnerTwoSelectedMeal;
            set
            {
                wednesdayDinnerTwoSelectedMeal = value;
                NotifyOfPropertyChange(() => WednesdayDinnerTwoSelectedMeal);
                if (WednesdayDinnerTwoSelectedMeal != -1)
                {
                    UpdateWednesdayCurrentCalories();
                }
            }
        }
        public int WednesdayBeverageOneSelectedBeverage
        {
            get => wednesdayBeverageOneSelectedBeverage;
            set
            {
                wednesdayBeverageOneSelectedBeverage = value;
                NotifyOfPropertyChange(() => WednesdayBeverageOneSelectedBeverage);
                if (WednesdayBeverageOneSelectedBeverage != -1)
                {
                    UpdateWednesdayCurrentCalories();
                }
            }
        }
        public int WednesdayBeverageTwoSelectedBeverage
        {
            get => wednesdayBeverageTwoSelectedBeverage;
            set
            {
                wednesdayBeverageTwoSelectedBeverage = value;
                NotifyOfPropertyChange(() => WednesdayBeverageTwoSelectedBeverage);
                if (WednesdayBeverageTwoSelectedBeverage != -1)
                {
                    UpdateWednesdayCurrentCalories();
                }
            }
        }
        public int WednesdayBeverageThreeSelectedBeverage
        {
            get => wednesdayBeverageThreeSelectedBeverage;
            set
            {
                wednesdayBeverageThreeSelectedBeverage = value;
                NotifyOfPropertyChange(() => WednesdayBeverageThreeSelectedBeverage);
                if (WednesdayBeverageThreeSelectedBeverage != -1)
                {
                    UpdateWednesdayCurrentCalories();
                }
            }
        }
        public int WednesdayBeverageFourSelectedBeverage
        {
            get => wednesdayBeverageFourSelectedBeverage;
            set
            {
                wednesdayBeverageFourSelectedBeverage = value;
                NotifyOfPropertyChange(() => WednesdayBeverageFourSelectedBeverage);
                if (WednesdayBeverageFourSelectedBeverage != -1)
                {
                    UpdateWednesdayCurrentCalories();
                }
            }
        }
        public int WednesdaySnackOneSelectedSnack
        {
            get => wednesdaySnackOneSelectedSnack;
            set
            {
                wednesdaySnackOneSelectedSnack = value;
                NotifyOfPropertyChange(() => WednesdaySnackOneSelectedSnack);
                if (WednesdaySnackOneSelectedSnack != -1)
                {
                    UpdateWednesdayCurrentCalories();
                }
            }
        }
        public int WednesdaySnackTwoSelectedSnack
        {
            get => wednesdaySnackTwoSelectedSnack;
            set
            {
                wednesdaySnackTwoSelectedSnack = value;
                NotifyOfPropertyChange(() => WednesdaySnackTwoSelectedSnack);
                if (WednesdaySnackTwoSelectedSnack != -1)
                {
                    UpdateWednesdayCurrentCalories();
                }
            }
        }
        public int WednesdaySnackThreeSelectedSnack
        {
            get => wednesdaySnackThreeSelectedSnack;
            set
            {
                wednesdaySnackThreeSelectedSnack = value;
                NotifyOfPropertyChange(() => WednesdaySnackThreeSelectedSnack);
                if (WednesdaySnackThreeSelectedSnack != -1)
                {
                    UpdateWednesdayCurrentCalories();
                }
            }
        }
        public int WednesdaySnackFourSelectedSnack
        {
            get => wednesdaySnackFourSelectedSnack;
            set
            {
                wednesdaySnackFourSelectedSnack = value;
                NotifyOfPropertyChange(() => WednesdaySnackFourSelectedSnack);
                if (WednesdaySnackFourSelectedSnack != -1)
                {
                    UpdateWednesdayCurrentCalories();
                }
            }
        }

        public string WednesdayCurrentCaloriesColor
        {
            get => wednesdayCurrentCaloriesColor;
            set
            {
                wednesdayCurrentCaloriesColor = value;
                NotifyOfPropertyChange(() => WednesdayCurrentCaloriesColor);
            }
        }

        public BindableCollection<string> ThursdayBreakfastOne { get => thursdayBreakfastOne; set { thursdayBreakfastOne = value; NotifyOfPropertyChange(() => ThursdayBreakfastOne); } }
        public BindableCollection<string> ThursdayBreakfastTwo { get => thursdayBreakfastTwo; set { thursdayBreakfastTwo = value; NotifyOfPropertyChange(() => ThursdayBreakfastTwo); } }
        public BindableCollection<string> ThursdayLunchOne { get => thursdayLunchOne; set { thursdayLunchOne = value; NotifyOfPropertyChange(() => ThursdayLunchOne); } }
        public BindableCollection<string> ThursdayLunchTwo { get => thursdayLunchTwo; set { thursdayLunchTwo = value; NotifyOfPropertyChange(() => ThursdayLunchTwo); } }
        public BindableCollection<string> ThursdayDinnerOne { get => thursdayDinnerOne; set { thursdayDinnerOne = value; NotifyOfPropertyChange(() => ThursdayDinnerOne); } }
        public BindableCollection<string> ThursdayDinnerTwo { get => thursdayDinnerTwo; set { thursdayDinnerTwo = value; NotifyOfPropertyChange(() => ThursdayDinnerTwo); } }
        public BindableCollection<string> ThursdayBeverageOne { get => thursdayBeverageOne; set { thursdayBeverageOne = value; NotifyOfPropertyChange(() => ThursdayBeverageOne); } }
        public BindableCollection<string> ThursdayBeverageTwo { get => thursdayBeverageTwo; set { thursdayBeverageTwo = value; NotifyOfPropertyChange(() => ThursdayBeverageTwo); } }
        public BindableCollection<string> ThursdayBeverageThree { get => thursdayBeverageThree; set { thursdayBeverageThree = value; NotifyOfPropertyChange(() => ThursdayBeverageThree); } }
        public BindableCollection<string> ThursdayBeverageFour { get => thursdayBeverageFour; set { thursdayBeverageFour = value; NotifyOfPropertyChange(() => ThursdayBeverageFour); } }
        public BindableCollection<string> ThursdaySnackOne { get => thursdaySnackOne; set { thursdaySnackOne = value; NotifyOfPropertyChange(() => ThursdaySnackOne); } }
        public BindableCollection<string> ThursdaySnackTwo { get => thursdaySnackTwo; set { thursdaySnackTwo = value; NotifyOfPropertyChange(() => ThursdaySnackTwo); } }
        public BindableCollection<string> ThursdaySnackThree { get => thursdaySnackThree; set { thursdaySnackThree = value; NotifyOfPropertyChange(() => ThursdaySnackThree); } }
        public BindableCollection<string> ThursdaySnackFour { get => thursdaySnackFour; set { thursdaySnackFour = value; NotifyOfPropertyChange(() => ThursdaySnackFour); } }

        public int ThursdayBreakfastOneSelectedMeal
        {
            get => thursdayBreakfastOneSelectedMeal;
            set
            {
                thursdayBreakfastOneSelectedMeal = value;
                NotifyOfPropertyChange(() => ThursdayBreakfastOneSelectedMeal);
                if (ThursdayBreakfastOneSelectedMeal != -1)
                {
                    UpdateThursdayCurrentCalories();
                }
            }
        }
        public int ThursdayBreakfastTwoSelectedMeal
        {
            get => thursdayBreakfastTwoSelectedMeal;
            set
            {
                thursdayBreakfastTwoSelectedMeal = value;
                NotifyOfPropertyChange(() => ThursdayBreakfastTwoSelectedMeal);
                if (ThursdayBreakfastTwoSelectedMeal != -1)
                {
                    UpdateThursdayCurrentCalories();
                }
            }
        }
        public int ThursdayLunchOneSelectedMeal
        {
            get => thursdayLunchOneSelectedMeal;
            set
            {
                thursdayLunchOneSelectedMeal = value;
                NotifyOfPropertyChange(() => ThursdayLunchOneSelectedMeal);
                if (ThursdayLunchOneSelectedMeal != -1)
                {
                    UpdateThursdayCurrentCalories();
                }
            }
        }
        public int ThursdayLunchTwoSelectedMeal
        {
            get => thursdayLunchTwoSelectedMeal;
            set
            {
                thursdayLunchTwoSelectedMeal = value;
                NotifyOfPropertyChange(() => ThursdayLunchTwoSelectedMeal);
                if (ThursdayLunchTwoSelectedMeal != -1)
                {
                    UpdateThursdayCurrentCalories();
                }

            }
        }
        public int ThursdayDinnerOneSelectedMeal
        {
            get => thursdayDinnerOneSelectedMeal;
            set
            {
                thursdayDinnerOneSelectedMeal = value;
                NotifyOfPropertyChange(() => ThursdayDinnerOneSelectedMeal);
                if (ThursdayDinnerOneSelectedMeal != -1)
                {
                    UpdateThursdayCurrentCalories();
                }
            }
        }
        public int ThursdayDinnerTwoSelectedMeal
        {
            get => thursdayDinnerTwoSelectedMeal;
            set
            {
                thursdayDinnerTwoSelectedMeal = value;
                NotifyOfPropertyChange(() => ThursdayDinnerTwoSelectedMeal);
                if (ThursdayDinnerTwoSelectedMeal != -1)
                {
                    UpdateThursdayCurrentCalories();
                }
            }
        }
        public int ThursdayBeverageOneSelectedBeverage
        {
            get => thursdayBeverageOneSelectedBeverage;
            set
            {
                thursdayBeverageOneSelectedBeverage = value;
                NotifyOfPropertyChange(() => ThursdayBeverageOneSelectedBeverage);
                if (ThursdayBeverageOneSelectedBeverage != -1)
                {
                    UpdateThursdayCurrentCalories();
                }
            }
        }
        public int ThursdayBeverageTwoSelectedBeverage
        {
            get => thursdayBeverageTwoSelectedBeverage;
            set
            {
                thursdayBeverageTwoSelectedBeverage = value;
                NotifyOfPropertyChange(() => ThursdayBeverageTwoSelectedBeverage);
                if (ThursdayBeverageTwoSelectedBeverage != -1)
                {
                    UpdateThursdayCurrentCalories();
                }
            }
        }
        public int ThursdayBeverageThreeSelectedBeverage
        {
            get => thursdayBeverageThreeSelectedBeverage;
            set
            {
                thursdayBeverageThreeSelectedBeverage = value;
                NotifyOfPropertyChange(() => ThursdayBeverageThreeSelectedBeverage);
                if (ThursdayBeverageThreeSelectedBeverage != -1)
                {
                    UpdateThursdayCurrentCalories();
                }
            }
        }
        public int ThursdayBeverageFourSelectedBeverage
        {
            get => thursdayBeverageFourSelectedBeverage;
            set
            {
                thursdayBeverageFourSelectedBeverage = value;
                NotifyOfPropertyChange(() => ThursdayBeverageFourSelectedBeverage);
                if (ThursdayBeverageFourSelectedBeverage != -1)
                {
                    UpdateThursdayCurrentCalories();
                }
            }
        }
        public int ThursdaySnackOneSelectedSnack
        {
            get => thursdaySnackOneSelectedSnack;
            set
            {
                thursdaySnackOneSelectedSnack = value;
                NotifyOfPropertyChange(() => ThursdaySnackOneSelectedSnack);
                if (ThursdaySnackOneSelectedSnack != -1)
                {
                    UpdateThursdayCurrentCalories();
                }
            }
        }
        public int ThursdaySnackTwoSelectedSnack
        {
            get => thursdaySnackTwoSelectedSnack;
            set
            {
                thursdaySnackTwoSelectedSnack = value;
                NotifyOfPropertyChange(() => ThursdaySnackTwoSelectedSnack);
                if (ThursdaySnackTwoSelectedSnack != -1)
                {
                    UpdateThursdayCurrentCalories();
                }
            }
        }
        public int ThursdaySnackThreeSelectedSnack
        {
            get => thursdaySnackThreeSelectedSnack;
            set
            {
                thursdaySnackThreeSelectedSnack = value;
                NotifyOfPropertyChange(() => ThursdaySnackThreeSelectedSnack);
                if (ThursdaySnackThreeSelectedSnack != -1)
                {
                    UpdateThursdayCurrentCalories();
                }
            }
        }
        public int ThursdaySnackFourSelectedSnack
        {
            get => thursdaySnackFourSelectedSnack;
            set
            {
                thursdaySnackFourSelectedSnack = value;
                NotifyOfPropertyChange(() => ThursdaySnackFourSelectedSnack);
                if (ThursdaySnackFourSelectedSnack != -1)
                {
                    UpdateThursdayCurrentCalories();
                }
            }
        }

        public string ThursdayCurrentCaloriesColor
        {
            get => thursdayCurrentCaloriesColor;
            set
            {
                thursdayCurrentCaloriesColor = value;
                NotifyOfPropertyChange(() => ThursdayCurrentCaloriesColor);
            }
        }

        public BindableCollection<string> FridayBreakfastOne { get => fridayBreakfastOne; set { fridayBreakfastOne = value; NotifyOfPropertyChange(() => FridayBreakfastOne); } }
        public BindableCollection<string> FridayBreakfastTwo { get => fridayBreakfastTwo; set { fridayBreakfastTwo = value; NotifyOfPropertyChange(() => FridayBreakfastTwo); } }
        public BindableCollection<string> FridayLunchOne { get => fridayLunchOne; set { fridayLunchOne = value; NotifyOfPropertyChange(() => FridayLunchOne); } }
        public BindableCollection<string> FridayLunchTwo { get => fridayLunchTwo; set { fridayLunchTwo = value; NotifyOfPropertyChange(() => FridayLunchTwo); } }
        public BindableCollection<string> FridayDinnerOne { get => fridayDinnerOne; set { fridayDinnerOne = value; NotifyOfPropertyChange(() => FridayDinnerOne); } }
        public BindableCollection<string> FridayDinnerTwo { get => fridayDinnerTwo; set { fridayDinnerTwo = value; NotifyOfPropertyChange(() => FridayDinnerTwo); } }
        public BindableCollection<string> FridayBeverageOne { get => fridayBeverageOne; set { fridayBeverageOne = value; NotifyOfPropertyChange(() => FridayBeverageOne); } }
        public BindableCollection<string> FridayBeverageTwo { get => fridayBeverageTwo; set { fridayBeverageTwo = value; NotifyOfPropertyChange(() => FridayBeverageTwo); } }
        public BindableCollection<string> FridayBeverageThree { get => fridayBeverageThree; set { fridayBeverageThree = value; NotifyOfPropertyChange(() => FridayBeverageThree); } }
        public BindableCollection<string> FridayBeverageFour { get => fridayBeverageFour; set { fridayBeverageFour = value; NotifyOfPropertyChange(() => FridayBeverageFour); } }
        public BindableCollection<string> FridaySnackOne { get => fridaySnackOne; set { fridaySnackOne = value; NotifyOfPropertyChange(() => FridaySnackOne); } }
        public BindableCollection<string> FridaySnackTwo { get => fridaySnackTwo; set { fridaySnackTwo = value; NotifyOfPropertyChange(() => FridaySnackTwo); } }
        public BindableCollection<string> FridaySnackThree { get => fridaySnackThree; set { fridaySnackThree = value; NotifyOfPropertyChange(() => FridaySnackThree); } }
        public BindableCollection<string> FridaySnackFour { get => fridaySnackFour; set { fridaySnackFour = value; NotifyOfPropertyChange(() => FridaySnackFour); } }

        public int FridayBreakfastOneSelectedMeal
        {
            get => fridayBreakfastOneSelectedMeal;
            set
            {
                fridayBreakfastOneSelectedMeal = value;
                NotifyOfPropertyChange(() => FridayBreakfastOneSelectedMeal);
                if (FridayBreakfastOneSelectedMeal != -1)
                {
                    UpdateFridayCurrentCalories();
                }
            }
        }
        public int FridayBreakfastTwoSelectedMeal
        {
            get => fridayBreakfastTwoSelectedMeal;
            set
            {
                fridayBreakfastTwoSelectedMeal = value;
                NotifyOfPropertyChange(() => FridayBreakfastTwoSelectedMeal);
                if (FridayBreakfastTwoSelectedMeal != -1)
                {
                    UpdateFridayCurrentCalories();
                }
            }
        }
        public int FridayLunchOneSelectedMeal
        {
            get => fridayLunchOneSelectedMeal;
            set
            {
                fridayLunchOneSelectedMeal = value;
                NotifyOfPropertyChange(() => FridayLunchOneSelectedMeal);
                if (FridayLunchOneSelectedMeal != -1)
                {
                    UpdateFridayCurrentCalories();
                }
            }
        }
        public int FridayLunchTwoSelectedMeal
        {
            get => fridayLunchTwoSelectedMeal;
            set
            {
                fridayLunchTwoSelectedMeal = value;
                NotifyOfPropertyChange(() => FridayLunchTwoSelectedMeal);
                if (FridayLunchTwoSelectedMeal != -1)
                {
                    UpdateFridayCurrentCalories();
                }

            }
        }
        public int FridayDinnerOneSelectedMeal
        {
            get => fridayDinnerOneSelectedMeal;
            set
            {
                fridayDinnerOneSelectedMeal = value;
                NotifyOfPropertyChange(() => FridayDinnerOneSelectedMeal);
                if (FridayDinnerOneSelectedMeal != -1)
                {
                    UpdateFridayCurrentCalories();
                }
            }
        }
        public int FridayDinnerTwoSelectedMeal
        {
            get => fridayDinnerTwoSelectedMeal;
            set
            {
                fridayDinnerTwoSelectedMeal = value;
                NotifyOfPropertyChange(() => FridayDinnerTwoSelectedMeal);
                if (FridayDinnerTwoSelectedMeal != -1)
                {
                    UpdateFridayCurrentCalories();
                }
            }
        }
        public int FridayBeverageOneSelectedBeverage
        {
            get => fridayBeverageOneSelectedBeverage;
            set
            {
                fridayBeverageOneSelectedBeverage = value;
                NotifyOfPropertyChange(() => FridayBeverageOneSelectedBeverage);
                if (FridayBeverageOneSelectedBeverage != -1)
                {
                    UpdateFridayCurrentCalories();
                }
            }
        }
        public int FridayBeverageTwoSelectedBeverage
        {
            get => fridayBeverageTwoSelectedBeverage;
            set
            {
                fridayBeverageTwoSelectedBeverage = value;
                NotifyOfPropertyChange(() => FridayBeverageTwoSelectedBeverage);
                if (FridayBeverageTwoSelectedBeverage != -1)
                {
                    UpdateFridayCurrentCalories();
                }
            }
        }
        public int FridayBeverageThreeSelectedBeverage
        {
            get => fridayBeverageThreeSelectedBeverage;
            set
            {
                fridayBeverageThreeSelectedBeverage = value;
                NotifyOfPropertyChange(() => FridayBeverageThreeSelectedBeverage);
                if (FridayBeverageThreeSelectedBeverage != -1)
                {
                    UpdateFridayCurrentCalories();
                }
            }
        }
        public int FridayBeverageFourSelectedBeverage
        {
            get => fridayBeverageFourSelectedBeverage;
            set
            {
                fridayBeverageFourSelectedBeverage = value;
                NotifyOfPropertyChange(() => FridayBeverageFourSelectedBeverage);
                if (FridayBeverageFourSelectedBeverage != -1)
                {
                    UpdateFridayCurrentCalories();
                }
            }
        }
        public int FridaySnackOneSelectedSnack
        {
            get => fridaySnackOneSelectedSnack;
            set
            {
                fridaySnackOneSelectedSnack = value;
                NotifyOfPropertyChange(() => FridaySnackOneSelectedSnack);
                if (FridaySnackOneSelectedSnack != -1)
                {
                    UpdateFridayCurrentCalories();
                }
            }
        }
        public int FridaySnackTwoSelectedSnack
        {
            get => fridaySnackTwoSelectedSnack;
            set
            {
                fridaySnackTwoSelectedSnack = value;
                NotifyOfPropertyChange(() => FridaySnackTwoSelectedSnack);
                if (FridaySnackTwoSelectedSnack != -1)
                {
                    UpdateFridayCurrentCalories();
                }
            }
        }
        public int FridaySnackThreeSelectedSnack
        {
            get => fridaySnackThreeSelectedSnack;
            set
            {
                fridaySnackThreeSelectedSnack = value;
                NotifyOfPropertyChange(() => FridaySnackThreeSelectedSnack);
                if (FridaySnackThreeSelectedSnack != -1)
                {
                    UpdateFridayCurrentCalories();
                }
            }
        }
        public int FridaySnackFourSelectedSnack
        {
            get => fridaySnackFourSelectedSnack;
            set
            {
                fridaySnackFourSelectedSnack = value;
                NotifyOfPropertyChange(() => FridaySnackFourSelectedSnack);
                if (FridaySnackFourSelectedSnack != -1)
                {
                    UpdateFridayCurrentCalories();
                }
            }
        }

        public string FridayCurrentCaloriesColor
        {
            get => fridayCurrentCaloriesColor;
            set
            {
                fridayCurrentCaloriesColor = value;
                NotifyOfPropertyChange(() => FridayCurrentCaloriesColor);
            }
        }

        public BindableCollection<string> SaturdayBreakfastOne { get => saturdayBreakfastOne; set { saturdayBreakfastOne = value; NotifyOfPropertyChange(() => SaturdayBreakfastOne); } }
        public BindableCollection<string> SaturdayBreakfastTwo { get => saturdayBreakfastTwo; set { saturdayBreakfastTwo = value; NotifyOfPropertyChange(() => SaturdayBreakfastTwo); } }
        public BindableCollection<string> SaturdayLunchOne { get => saturdayLunchOne; set { saturdayLunchOne = value; NotifyOfPropertyChange(() => SaturdayLunchOne); } }
        public BindableCollection<string> SaturdayLunchTwo { get => saturdayLunchTwo; set { saturdayLunchTwo = value; NotifyOfPropertyChange(() => SaturdayLunchTwo); } }
        public BindableCollection<string> SaturdayDinnerOne { get => saturdayDinnerOne; set { saturdayDinnerOne = value; NotifyOfPropertyChange(() => SaturdayDinnerOne); } }
        public BindableCollection<string> SaturdayDinnerTwo { get => saturdayDinnerTwo; set { saturdayDinnerTwo = value; NotifyOfPropertyChange(() => SaturdayDinnerTwo); } }
        public BindableCollection<string> SaturdayBeverageOne { get => saturdayBeverageOne; set { saturdayBeverageOne = value; NotifyOfPropertyChange(() => SaturdayBeverageOne); } }
        public BindableCollection<string> SaturdayBeverageTwo { get => saturdayBeverageTwo; set { saturdayBeverageTwo = value; NotifyOfPropertyChange(() => SaturdayBeverageTwo); } }
        public BindableCollection<string> SaturdayBeverageThree { get => saturdayBeverageThree; set { saturdayBeverageThree = value; NotifyOfPropertyChange(() => SaturdayBeverageThree); } }
        public BindableCollection<string> SaturdayBeverageFour { get => saturdayBeverageFour; set { saturdayBeverageFour = value; NotifyOfPropertyChange(() => SaturdayBeverageFour); } }
        public BindableCollection<string> SaturdaySnackOne { get => saturdaySnackOne; set { saturdaySnackOne = value; NotifyOfPropertyChange(() => SaturdaySnackOne); } }
        public BindableCollection<string> SaturdaySnackTwo { get => saturdaySnackTwo; set { saturdaySnackTwo = value; NotifyOfPropertyChange(() => SaturdaySnackTwo); } }
        public BindableCollection<string> SaturdaySnackThree { get => saturdaySnackThree; set { saturdaySnackThree = value; NotifyOfPropertyChange(() => SaturdaySnackThree); } }
        public BindableCollection<string> SaturdaySnackFour { get => saturdaySnackFour; set { saturdaySnackFour = value; NotifyOfPropertyChange(() => SaturdaySnackFour); } }

        public int SaturdayBreakfastOneSelectedMeal
        {
            get => saturdayBreakfastOneSelectedMeal;
            set
            {
                saturdayBreakfastOneSelectedMeal = value;
                NotifyOfPropertyChange(() => SaturdayBreakfastOneSelectedMeal);
                if (SaturdayBreakfastOneSelectedMeal != -1)
                {
                    UpdateSaturdayCurrentCalories();
                }
            }
        }
        public int SaturdayBreakfastTwoSelectedMeal
        {
            get => saturdayBreakfastTwoSelectedMeal;
            set
            {
                saturdayBreakfastTwoSelectedMeal = value;
                NotifyOfPropertyChange(() => SaturdayBreakfastTwoSelectedMeal);
                if (SaturdayBreakfastTwoSelectedMeal != -1)
                {
                    UpdateSaturdayCurrentCalories();
                }
            }
        }
        public int SaturdayLunchOneSelectedMeal
        {
            get => saturdayLunchOneSelectedMeal;
            set
            {
                saturdayLunchOneSelectedMeal = value;
                NotifyOfPropertyChange(() => SaturdayLunchOneSelectedMeal);
                if (SaturdayLunchOneSelectedMeal != -1)
                {
                    UpdateSaturdayCurrentCalories();
                }
            }
        }
        public int SaturdayLunchTwoSelectedMeal
        {
            get => saturdayLunchTwoSelectedMeal;
            set
            {
                saturdayLunchTwoSelectedMeal = value;
                NotifyOfPropertyChange(() => SaturdayLunchTwoSelectedMeal);
                if (SaturdayLunchTwoSelectedMeal != -1)
                {
                    UpdateSaturdayCurrentCalories();
                }

            }
        }
        public int SaturdayDinnerOneSelectedMeal
        {
            get => saturdayDinnerOneSelectedMeal;
            set
            {
                saturdayDinnerOneSelectedMeal = value;
                NotifyOfPropertyChange(() => SaturdayDinnerOneSelectedMeal);
                if (SaturdayDinnerOneSelectedMeal != -1)
                {
                    UpdateSaturdayCurrentCalories();
                }
            }
        }
        public int SaturdayDinnerTwoSelectedMeal
        {
            get => saturdayDinnerTwoSelectedMeal;
            set
            {
                saturdayDinnerTwoSelectedMeal = value;
                NotifyOfPropertyChange(() => SaturdayDinnerTwoSelectedMeal);
                if (SaturdayDinnerTwoSelectedMeal != -1)
                {
                    UpdateSaturdayCurrentCalories();
                }
            }
        }
        public int SaturdayBeverageOneSelectedBeverage
        {
            get => saturdayBeverageOneSelectedBeverage;
            set
            {
                saturdayBeverageOneSelectedBeverage = value;
                NotifyOfPropertyChange(() => SaturdayBeverageOneSelectedBeverage);
                if (SaturdayBeverageOneSelectedBeverage != -1)
                {
                    UpdateSaturdayCurrentCalories();
                }
            }
        }
        public int SaturdayBeverageTwoSelectedBeverage
        {
            get => saturdayBeverageTwoSelectedBeverage;
            set
            {
                saturdayBeverageTwoSelectedBeverage = value;
                NotifyOfPropertyChange(() => SaturdayBeverageTwoSelectedBeverage);
                if (SaturdayBeverageTwoSelectedBeverage != -1)
                {
                    UpdateSaturdayCurrentCalories();
                }
            }
        }
        public int SaturdayBeverageThreeSelectedBeverage
        {
            get => saturdayBeverageThreeSelectedBeverage;
            set
            {
                saturdayBeverageThreeSelectedBeverage = value;
                NotifyOfPropertyChange(() => SaturdayBeverageThreeSelectedBeverage);
                if (SaturdayBeverageThreeSelectedBeverage != -1)
                {
                    UpdateSaturdayCurrentCalories();
                }
            }
        }
        public int SaturdayBeverageFourSelectedBeverage
        {
            get => saturdayBeverageFourSelectedBeverage;
            set
            {
                saturdayBeverageFourSelectedBeverage = value;
                NotifyOfPropertyChange(() => SaturdayBeverageFourSelectedBeverage);
                if (SaturdayBeverageFourSelectedBeverage != -1)
                {
                    UpdateSaturdayCurrentCalories();
                }
            }
        }
        public int SaturdaySnackOneSelectedSnack
        {
            get => saturdaySnackOneSelectedSnack;
            set
            {
                saturdaySnackOneSelectedSnack = value;
                NotifyOfPropertyChange(() => SaturdaySnackOneSelectedSnack);
                if (SaturdaySnackOneSelectedSnack != -1)
                {
                    UpdateSaturdayCurrentCalories();
                }
            }
        }
        public int SaturdaySnackTwoSelectedSnack
        {
            get => saturdaySnackTwoSelectedSnack;
            set
            {
                saturdaySnackTwoSelectedSnack = value;
                NotifyOfPropertyChange(() => SaturdaySnackTwoSelectedSnack);
                if (SaturdaySnackTwoSelectedSnack != -1)
                {
                    UpdateSaturdayCurrentCalories();
                }
            }
        }
        public int SaturdaySnackThreeSelectedSnack
        {
            get => saturdaySnackThreeSelectedSnack;
            set
            {
                saturdaySnackThreeSelectedSnack = value;
                NotifyOfPropertyChange(() => SaturdaySnackThreeSelectedSnack);
                if (SaturdaySnackThreeSelectedSnack != -1)
                {
                    UpdateSaturdayCurrentCalories();
                }
            }
        }
        public int SaturdaySnackFourSelectedSnack
        {
            get => saturdaySnackFourSelectedSnack;
            set
            {
                saturdaySnackFourSelectedSnack = value;
                NotifyOfPropertyChange(() => SaturdaySnackFourSelectedSnack);
                if (SaturdaySnackFourSelectedSnack != -1)
                {
                    UpdateSaturdayCurrentCalories();
                }
            }
        }

        public string SaturdayCurrentCaloriesColor
        {
            get => saturdayCurrentCaloriesColor;
            set
            {
                saturdayCurrentCaloriesColor = value;
                NotifyOfPropertyChange(() => SaturdayCurrentCaloriesColor);
            }
        }

        //////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
        // TODO: 3. Duplicate Meal Planner for Monday, Tuesday, Wednesday, Thursday, Friday, Saturday
        //       4. Meal Planner Overview
        //////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////

        // SATURDAY SECTION
        public void UpdateSaturdayCurrentCaloriesColor()
        {
            if (MealPlannerSaturdayCurrentCalories > MealPlannerSaturdayTotalCalories && MealPlannerSaturdayTotalCalories != 0)
            {
                SaturdayCurrentCaloriesColor = "Red";
            }
            else
            {
                SaturdayCurrentCaloriesColor = "White";
            }
        }

        public void UpdateSaturdayCurrentCalories()
        {
            MealPlannerSaturdayCurrentCalories = 0;
            if (SaturdayBreakfastOneSelectedMeal != -1)
            {
                MealPlannerSaturdayCurrentCalories += MealDatabase[SaturdayBreakfastOneSelectedMeal].TotalCalories;
            }
            if (SaturdayBreakfastTwoSelectedMeal != -1)
            {
                MealPlannerSaturdayCurrentCalories += MealDatabase[SaturdayBreakfastTwoSelectedMeal].TotalCalories;
            }
            if (SaturdayLunchOneSelectedMeal != -1)
            {
                MealPlannerSaturdayCurrentCalories += MealDatabase[SaturdayLunchOneSelectedMeal].TotalCalories;
            }
            if (SaturdayLunchTwoSelectedMeal != -1)
            {
                MealPlannerSaturdayCurrentCalories += MealDatabase[SaturdayLunchTwoSelectedMeal].TotalCalories;
            }
            if (SaturdayDinnerOneSelectedMeal != -1)
            {
                MealPlannerSaturdayCurrentCalories += MealDatabase[SaturdayDinnerOneSelectedMeal].TotalCalories;
            }
            if (SaturdayDinnerTwoSelectedMeal != -1)
            {
                MealPlannerSaturdayCurrentCalories += MealDatabase[SaturdayDinnerTwoSelectedMeal].TotalCalories;
            }
            if (SaturdayBeverageOneSelectedBeverage != -1)
            {
                MealPlannerSaturdayCurrentCalories += IngredientDatabase[SaturdayBeverageOneSelectedBeverage].Calories;
            }
            if (SaturdayBeverageTwoSelectedBeverage != -1)
            {
                MealPlannerSaturdayCurrentCalories += IngredientDatabase[SaturdayBeverageTwoSelectedBeverage].Calories;
            }
            if (SaturdayBeverageThreeSelectedBeverage != -1)
            {
                MealPlannerSaturdayCurrentCalories += IngredientDatabase[SaturdayBeverageThreeSelectedBeverage].Calories;
            }
            if (SaturdayBeverageFourSelectedBeverage != -1)
            {
                MealPlannerSaturdayCurrentCalories += IngredientDatabase[SaturdayBeverageFourSelectedBeverage].Calories;
            }
            if (SaturdaySnackOneSelectedSnack != -1)
            {
                MealPlannerSaturdayCurrentCalories += IngredientDatabase[SaturdaySnackOneSelectedSnack].Calories;
            }
            if (SaturdaySnackTwoSelectedSnack != -1)
            {
                MealPlannerSaturdayCurrentCalories += IngredientDatabase[SaturdaySnackTwoSelectedSnack].Calories;
            }
            if (SaturdaySnackThreeSelectedSnack != -1)
            {
                MealPlannerSaturdayCurrentCalories += IngredientDatabase[SaturdaySnackThreeSelectedSnack].Calories;
            }
            if (SaturdaySnackFourSelectedSnack != -1)
            {
                MealPlannerSaturdayCurrentCalories += IngredientDatabase[SaturdaySnackFourSelectedSnack].Calories;
            }

            UpdateSaturdayCurrentCaloriesColor();
        }

        public void ClearSaturdayBreakfast()
        {
            if (SaturdayBreakfastOneSelectedMeal != -1)
            {
                MealPlannerSaturdayCurrentCalories -= MealDatabase[SaturdayBreakfastOneSelectedMeal].TotalCalories;
            }
            if (SaturdayBreakfastTwoSelectedMeal != -1)
            {
                MealPlannerSaturdayCurrentCalories -= MealDatabase[SaturdayBreakfastTwoSelectedMeal].TotalCalories;
            }
            UpdateSaturdayCurrentCaloriesColor();

            SaturdayBreakfastOneSelectedMeal = -1;
            SaturdayBreakfastTwoSelectedMeal = -1;
        }
        public void ClearSaturdayLunch()
        {
            if (SaturdayLunchOneSelectedMeal != -1)
            {
                MealPlannerSaturdayCurrentCalories -= MealDatabase[SaturdayLunchOneSelectedMeal].TotalCalories;
            }
            if (SaturdayLunchTwoSelectedMeal != -1)
            {
                MealPlannerSaturdayCurrentCalories -= MealDatabase[SaturdayLunchTwoSelectedMeal].TotalCalories;
            }
            UpdateSaturdayCurrentCaloriesColor();

            SaturdayLunchOneSelectedMeal = -1;
            SaturdayLunchTwoSelectedMeal = -1;
        }
        public void ClearSaturdayDinner()
        {
            if (SaturdayDinnerOneSelectedMeal != -1)
            {
                MealPlannerSaturdayCurrentCalories -= MealDatabase[SaturdayDinnerOneSelectedMeal].TotalCalories;
            }
            if (SaturdayDinnerTwoSelectedMeal != -1)
            {
                MealPlannerSaturdayCurrentCalories -= MealDatabase[SaturdayDinnerTwoSelectedMeal].TotalCalories;
            }
            UpdateSaturdayCurrentCaloriesColor();

            SaturdayDinnerOneSelectedMeal = -1;
            SaturdayDinnerTwoSelectedMeal = -1;
        }
        public void ClearSaturdayBeverages()
        {
            if (SaturdayBeverageOneSelectedBeverage != -1)
            {
                MealPlannerSaturdayCurrentCalories -= IngredientDatabase[SaturdayBeverageOneSelectedBeverage].Calories;
            }
            if (SaturdayBeverageTwoSelectedBeverage != -1)
            {
                MealPlannerSaturdayCurrentCalories -= IngredientDatabase[SaturdayBeverageTwoSelectedBeverage].Calories;
            }
            if (SaturdayBeverageThreeSelectedBeverage != -1)
            {
                MealPlannerSaturdayCurrentCalories -= IngredientDatabase[SaturdayBeverageThreeSelectedBeverage].Calories;
            }
            if (SaturdayBeverageFourSelectedBeverage != -1)
            {
                MealPlannerSaturdayCurrentCalories -= IngredientDatabase[SaturdayBeverageFourSelectedBeverage].Calories;
            }
            UpdateSaturdayCurrentCaloriesColor();

            SaturdayBeverageOneSelectedBeverage = -1;
            SaturdayBeverageTwoSelectedBeverage = -1;
            SaturdayBeverageThreeSelectedBeverage = -1;
            SaturdayBeverageFourSelectedBeverage = -1;
        }
        public void ClearSaturdaySnacks()
        {
            if (SaturdaySnackOneSelectedSnack != -1)
            {
                MealPlannerSaturdayCurrentCalories -= IngredientDatabase[SaturdaySnackOneSelectedSnack].Calories;
            }
            if (SaturdaySnackTwoSelectedSnack != -1)
            {
                MealPlannerSaturdayCurrentCalories -= IngredientDatabase[SaturdaySnackTwoSelectedSnack].Calories;
            }
            if (SaturdaySnackThreeSelectedSnack != -1)
            {
                MealPlannerSaturdayCurrentCalories -= IngredientDatabase[SaturdaySnackThreeSelectedSnack].Calories;
            }
            if (SaturdaySnackFourSelectedSnack != -1)
            {
                MealPlannerSaturdayCurrentCalories -= IngredientDatabase[SaturdaySnackFourSelectedSnack].Calories;
            }
            UpdateSaturdayCurrentCaloriesColor();

            SaturdaySnackOneSelectedSnack = -1;
            SaturdaySnackTwoSelectedSnack = -1;
            SaturdaySnackThreeSelectedSnack = -1;
            SaturdaySnackFourSelectedSnack = -1;
        }

        // FRIDAY SECTION
        public void UpdateFridayCurrentCaloriesColor()
        {
            if (MealPlannerFridayCurrentCalories > MealPlannerFridayTotalCalories && MealPlannerFridayTotalCalories != 0)
            {
                FridayCurrentCaloriesColor = "Red";
            }
            else
            {
                FridayCurrentCaloriesColor = "White";
            }
        }

        public void UpdateFridayCurrentCalories()
        {
            MealPlannerFridayCurrentCalories = 0;
            if (FridayBreakfastOneSelectedMeal != -1)
            {
                MealPlannerFridayCurrentCalories += MealDatabase[FridayBreakfastOneSelectedMeal].TotalCalories;
            }
            if (FridayBreakfastTwoSelectedMeal != -1)
            {
                MealPlannerFridayCurrentCalories += MealDatabase[FridayBreakfastTwoSelectedMeal].TotalCalories;
            }
            if (FridayLunchOneSelectedMeal != -1)
            {
                MealPlannerFridayCurrentCalories += MealDatabase[FridayLunchOneSelectedMeal].TotalCalories;
            }
            if (FridayLunchTwoSelectedMeal != -1)
            {
                MealPlannerFridayCurrentCalories += MealDatabase[FridayLunchTwoSelectedMeal].TotalCalories;
            }
            if (FridayDinnerOneSelectedMeal != -1)
            {
                MealPlannerFridayCurrentCalories += MealDatabase[FridayDinnerOneSelectedMeal].TotalCalories;
            }
            if (FridayDinnerTwoSelectedMeal != -1)
            {
                MealPlannerFridayCurrentCalories += MealDatabase[FridayDinnerTwoSelectedMeal].TotalCalories;
            }
            if (FridayBeverageOneSelectedBeverage != -1)
            {
                MealPlannerFridayCurrentCalories += IngredientDatabase[FridayBeverageOneSelectedBeverage].Calories;
            }
            if (FridayBeverageTwoSelectedBeverage != -1)
            {
                MealPlannerFridayCurrentCalories += IngredientDatabase[FridayBeverageTwoSelectedBeverage].Calories;
            }
            if (FridayBeverageThreeSelectedBeverage != -1)
            {
                MealPlannerFridayCurrentCalories += IngredientDatabase[FridayBeverageThreeSelectedBeverage].Calories;
            }
            if (FridayBeverageFourSelectedBeverage != -1)
            {
                MealPlannerFridayCurrentCalories += IngredientDatabase[FridayBeverageFourSelectedBeverage].Calories;
            }
            if (FridaySnackOneSelectedSnack != -1)
            {
                MealPlannerFridayCurrentCalories += IngredientDatabase[FridaySnackOneSelectedSnack].Calories;
            }
            if (FridaySnackTwoSelectedSnack != -1)
            {
                MealPlannerFridayCurrentCalories += IngredientDatabase[FridaySnackTwoSelectedSnack].Calories;
            }
            if (FridaySnackThreeSelectedSnack != -1)
            {
                MealPlannerFridayCurrentCalories += IngredientDatabase[FridaySnackThreeSelectedSnack].Calories;
            }
            if (FridaySnackFourSelectedSnack != -1)
            {
                MealPlannerFridayCurrentCalories += IngredientDatabase[FridaySnackFourSelectedSnack].Calories;
            }

            UpdateFridayCurrentCaloriesColor();
        }

        public void ClearFridayBreakfast()
        {
            if (FridayBreakfastOneSelectedMeal != -1)
            {
                MealPlannerFridayCurrentCalories -= MealDatabase[FridayBreakfastOneSelectedMeal].TotalCalories;
            }
            if (FridayBreakfastTwoSelectedMeal != -1)
            {
                MealPlannerFridayCurrentCalories -= MealDatabase[FridayBreakfastTwoSelectedMeal].TotalCalories;
            }
            UpdateFridayCurrentCaloriesColor();

            FridayBreakfastOneSelectedMeal = -1;
            FridayBreakfastTwoSelectedMeal = -1;
        }
        public void ClearFridayLunch()
        {
            if (FridayLunchOneSelectedMeal != -1)
            {
                MealPlannerFridayCurrentCalories -= MealDatabase[FridayLunchOneSelectedMeal].TotalCalories;
            }
            if (FridayLunchTwoSelectedMeal != -1)
            {
                MealPlannerFridayCurrentCalories -= MealDatabase[FridayLunchTwoSelectedMeal].TotalCalories;
            }
            UpdateFridayCurrentCaloriesColor();

            FridayLunchOneSelectedMeal = -1;
            FridayLunchTwoSelectedMeal = -1;
        }
        public void ClearFridayDinner()
        {
            if (FridayDinnerOneSelectedMeal != -1)
            {
                MealPlannerFridayCurrentCalories -= MealDatabase[FridayDinnerOneSelectedMeal].TotalCalories;
            }
            if (FridayDinnerTwoSelectedMeal != -1)
            {
                MealPlannerFridayCurrentCalories -= MealDatabase[FridayDinnerTwoSelectedMeal].TotalCalories;
            }
            UpdateFridayCurrentCaloriesColor();

            FridayDinnerOneSelectedMeal = -1;
            FridayDinnerTwoSelectedMeal = -1;
        }
        public void ClearFridayBeverages()
        {
            if (FridayBeverageOneSelectedBeverage != -1)
            {
                MealPlannerFridayCurrentCalories -= IngredientDatabase[FridayBeverageOneSelectedBeverage].Calories;
            }
            if (FridayBeverageTwoSelectedBeverage != -1)
            {
                MealPlannerFridayCurrentCalories -= IngredientDatabase[FridayBeverageTwoSelectedBeverage].Calories;
            }
            if (FridayBeverageThreeSelectedBeverage != -1)
            {
                MealPlannerFridayCurrentCalories -= IngredientDatabase[FridayBeverageThreeSelectedBeverage].Calories;
            }
            if (FridayBeverageFourSelectedBeverage != -1)
            {
                MealPlannerFridayCurrentCalories -= IngredientDatabase[FridayBeverageFourSelectedBeverage].Calories;
            }
            UpdateFridayCurrentCaloriesColor();

            FridayBeverageOneSelectedBeverage = -1;
            FridayBeverageTwoSelectedBeverage = -1;
            FridayBeverageThreeSelectedBeverage = -1;
            FridayBeverageFourSelectedBeverage = -1;
        }
        public void ClearFridaySnacks()
        {
            if (FridaySnackOneSelectedSnack != -1)
            {
                MealPlannerFridayCurrentCalories -= IngredientDatabase[FridaySnackOneSelectedSnack].Calories;
            }
            if (FridaySnackTwoSelectedSnack != -1)
            {
                MealPlannerFridayCurrentCalories -= IngredientDatabase[FridaySnackTwoSelectedSnack].Calories;
            }
            if (FridaySnackThreeSelectedSnack != -1)
            {
                MealPlannerFridayCurrentCalories -= IngredientDatabase[FridaySnackThreeSelectedSnack].Calories;
            }
            if (FridaySnackFourSelectedSnack != -1)
            {
                MealPlannerFridayCurrentCalories -= IngredientDatabase[FridaySnackFourSelectedSnack].Calories;
            }
            UpdateFridayCurrentCaloriesColor();

            FridaySnackOneSelectedSnack = -1;
            FridaySnackTwoSelectedSnack = -1;
            FridaySnackThreeSelectedSnack = -1;
            FridaySnackFourSelectedSnack = -1;
        }

        // THURSDAY SECTION
        public void UpdateThursdayCurrentCaloriesColor()
        {
            if (MealPlannerThursdayCurrentCalories > MealPlannerThursdayTotalCalories && MealPlannerThursdayTotalCalories != 0)
            {
                ThursdayCurrentCaloriesColor = "Red";
            }
            else
            {
                ThursdayCurrentCaloriesColor = "White";
            }
        }

        public void UpdateThursdayCurrentCalories()
        {
            MealPlannerThursdayCurrentCalories = 0;
            if (ThursdayBreakfastOneSelectedMeal != -1)
            {
                MealPlannerThursdayCurrentCalories += MealDatabase[ThursdayBreakfastOneSelectedMeal].TotalCalories;
            }
            if (ThursdayBreakfastTwoSelectedMeal != -1)
            {
                MealPlannerThursdayCurrentCalories += MealDatabase[ThursdayBreakfastTwoSelectedMeal].TotalCalories;
            }
            if (ThursdayLunchOneSelectedMeal != -1)
            {
                MealPlannerThursdayCurrentCalories += MealDatabase[ThursdayLunchOneSelectedMeal].TotalCalories;
            }
            if (ThursdayLunchTwoSelectedMeal != -1)
            {
                MealPlannerThursdayCurrentCalories += MealDatabase[ThursdayLunchTwoSelectedMeal].TotalCalories;
            }
            if (ThursdayDinnerOneSelectedMeal != -1)
            {
                MealPlannerThursdayCurrentCalories += MealDatabase[ThursdayDinnerOneSelectedMeal].TotalCalories;
            }
            if (ThursdayDinnerTwoSelectedMeal != -1)
            {
                MealPlannerThursdayCurrentCalories += MealDatabase[ThursdayDinnerTwoSelectedMeal].TotalCalories;
            }
            if (ThursdayBeverageOneSelectedBeverage != -1)
            {
                MealPlannerThursdayCurrentCalories += IngredientDatabase[ThursdayBeverageOneSelectedBeverage].Calories;
            }
            if (ThursdayBeverageTwoSelectedBeverage != -1)
            {
                MealPlannerThursdayCurrentCalories += IngredientDatabase[ThursdayBeverageTwoSelectedBeverage].Calories;
            }
            if (ThursdayBeverageThreeSelectedBeverage != -1)
            {
                MealPlannerThursdayCurrentCalories += IngredientDatabase[ThursdayBeverageThreeSelectedBeverage].Calories;
            }
            if (ThursdayBeverageFourSelectedBeverage != -1)
            {
                MealPlannerThursdayCurrentCalories += IngredientDatabase[ThursdayBeverageFourSelectedBeverage].Calories;
            }
            if (ThursdaySnackOneSelectedSnack != -1)
            {
                MealPlannerThursdayCurrentCalories += IngredientDatabase[ThursdaySnackOneSelectedSnack].Calories;
            }
            if (ThursdaySnackTwoSelectedSnack != -1)
            {
                MealPlannerThursdayCurrentCalories += IngredientDatabase[ThursdaySnackTwoSelectedSnack].Calories;
            }
            if (ThursdaySnackThreeSelectedSnack != -1)
            {
                MealPlannerThursdayCurrentCalories += IngredientDatabase[ThursdaySnackThreeSelectedSnack].Calories;
            }
            if (ThursdaySnackFourSelectedSnack != -1)
            {
                MealPlannerThursdayCurrentCalories += IngredientDatabase[ThursdaySnackFourSelectedSnack].Calories;
            }

            UpdateThursdayCurrentCaloriesColor();
        }

        public void ClearThursdayBreakfast()
        {
            if (ThursdayBreakfastOneSelectedMeal != -1)
            {
                MealPlannerThursdayCurrentCalories -= MealDatabase[ThursdayBreakfastOneSelectedMeal].TotalCalories;
            }
            if (ThursdayBreakfastTwoSelectedMeal != -1)
            {
                MealPlannerThursdayCurrentCalories -= MealDatabase[ThursdayBreakfastTwoSelectedMeal].TotalCalories;
            }
            UpdateThursdayCurrentCaloriesColor();

            ThursdayBreakfastOneSelectedMeal = -1;
            ThursdayBreakfastTwoSelectedMeal = -1;
        }
        public void ClearThursdayLunch()
        {
            if (ThursdayLunchOneSelectedMeal != -1)
            {
                MealPlannerThursdayCurrentCalories -= MealDatabase[ThursdayLunchOneSelectedMeal].TotalCalories;
            }
            if (ThursdayLunchTwoSelectedMeal != -1)
            {
                MealPlannerThursdayCurrentCalories -= MealDatabase[ThursdayLunchTwoSelectedMeal].TotalCalories;
            }
            UpdateThursdayCurrentCaloriesColor();

            ThursdayLunchOneSelectedMeal = -1;
            ThursdayLunchTwoSelectedMeal = -1;
        }
        public void ClearThursdayDinner()
        {
            if (ThursdayDinnerOneSelectedMeal != -1)
            {
                MealPlannerThursdayCurrentCalories -= MealDatabase[ThursdayDinnerOneSelectedMeal].TotalCalories;
            }
            if (ThursdayDinnerTwoSelectedMeal != -1)
            {
                MealPlannerThursdayCurrentCalories -= MealDatabase[ThursdayDinnerTwoSelectedMeal].TotalCalories;
            }
            UpdateThursdayCurrentCaloriesColor();

            ThursdayDinnerOneSelectedMeal = -1;
            ThursdayDinnerTwoSelectedMeal = -1;
        }
        public void ClearThursdayBeverages()
        {
            if (ThursdayBeverageOneSelectedBeverage != -1)
            {
                MealPlannerThursdayCurrentCalories -= IngredientDatabase[ThursdayBeverageOneSelectedBeverage].Calories;
            }
            if (ThursdayBeverageTwoSelectedBeverage != -1)
            {
                MealPlannerThursdayCurrentCalories -= IngredientDatabase[ThursdayBeverageTwoSelectedBeverage].Calories;
            }
            if (ThursdayBeverageThreeSelectedBeverage != -1)
            {
                MealPlannerThursdayCurrentCalories -= IngredientDatabase[ThursdayBeverageThreeSelectedBeverage].Calories;
            }
            if (ThursdayBeverageFourSelectedBeverage != -1)
            {
                MealPlannerThursdayCurrentCalories -= IngredientDatabase[ThursdayBeverageFourSelectedBeverage].Calories;
            }
            UpdateThursdayCurrentCaloriesColor();

            ThursdayBeverageOneSelectedBeverage = -1;
            ThursdayBeverageTwoSelectedBeverage = -1;
            ThursdayBeverageThreeSelectedBeverage = -1;
            ThursdayBeverageFourSelectedBeverage = -1;
        }
        public void ClearThursdaySnacks()
        {
            if (ThursdaySnackOneSelectedSnack != -1)
            {
                MealPlannerThursdayCurrentCalories -= IngredientDatabase[ThursdaySnackOneSelectedSnack].Calories;
            }
            if (ThursdaySnackTwoSelectedSnack != -1)
            {
                MealPlannerThursdayCurrentCalories -= IngredientDatabase[ThursdaySnackTwoSelectedSnack].Calories;
            }
            if (ThursdaySnackThreeSelectedSnack != -1)
            {
                MealPlannerThursdayCurrentCalories -= IngredientDatabase[ThursdaySnackThreeSelectedSnack].Calories;
            }
            if (ThursdaySnackFourSelectedSnack != -1)
            {
                MealPlannerThursdayCurrentCalories -= IngredientDatabase[ThursdaySnackFourSelectedSnack].Calories;
            }
            UpdateThursdayCurrentCaloriesColor();

            ThursdaySnackOneSelectedSnack = -1;
            ThursdaySnackTwoSelectedSnack = -1;
            ThursdaySnackThreeSelectedSnack = -1;
            ThursdaySnackFourSelectedSnack = -1;
        }

        // WEDNESDAY SECTION
        public void UpdateWednesdayCurrentCaloriesColor()
        {
            if (MealPlannerWednesdayCurrentCalories > MealPlannerWednesdayTotalCalories && MealPlannerWednesdayTotalCalories != 0)
            {
                WednesdayCurrentCaloriesColor = "Red";
            }
            else
            {
                WednesdayCurrentCaloriesColor = "White";
            }
        }

        public void UpdateWednesdayCurrentCalories()
        {
            MealPlannerWednesdayCurrentCalories = 0;
            if (WednesdayBreakfastOneSelectedMeal != -1)
            {
                MealPlannerWednesdayCurrentCalories += MealDatabase[WednesdayBreakfastOneSelectedMeal].TotalCalories;
            }
            if (WednesdayBreakfastTwoSelectedMeal != -1)
            {
                MealPlannerWednesdayCurrentCalories += MealDatabase[WednesdayBreakfastTwoSelectedMeal].TotalCalories;
            }
            if (WednesdayLunchOneSelectedMeal != -1)
            {
                MealPlannerWednesdayCurrentCalories += MealDatabase[WednesdayLunchOneSelectedMeal].TotalCalories;
            }
            if (WednesdayLunchTwoSelectedMeal != -1)
            {
                MealPlannerWednesdayCurrentCalories += MealDatabase[WednesdayLunchTwoSelectedMeal].TotalCalories;
            }
            if (WednesdayDinnerOneSelectedMeal != -1)
            {
                MealPlannerWednesdayCurrentCalories += MealDatabase[WednesdayDinnerOneSelectedMeal].TotalCalories;
            }
            if (WednesdayDinnerTwoSelectedMeal != -1)
            {
                MealPlannerWednesdayCurrentCalories += MealDatabase[WednesdayDinnerTwoSelectedMeal].TotalCalories;
            }
            if (WednesdayBeverageOneSelectedBeverage != -1)
            {
                MealPlannerWednesdayCurrentCalories += IngredientDatabase[WednesdayBeverageOneSelectedBeverage].Calories;
            }
            if (WednesdayBeverageTwoSelectedBeverage != -1)
            {
                MealPlannerWednesdayCurrentCalories += IngredientDatabase[WednesdayBeverageTwoSelectedBeverage].Calories;
            }
            if (WednesdayBeverageThreeSelectedBeverage != -1)
            {
                MealPlannerWednesdayCurrentCalories += IngredientDatabase[WednesdayBeverageThreeSelectedBeverage].Calories;
            }
            if (WednesdayBeverageFourSelectedBeverage != -1)
            {
                MealPlannerWednesdayCurrentCalories += IngredientDatabase[WednesdayBeverageFourSelectedBeverage].Calories;
            }
            if (WednesdaySnackOneSelectedSnack != -1)
            {
                MealPlannerWednesdayCurrentCalories += IngredientDatabase[WednesdaySnackOneSelectedSnack].Calories;
            }
            if (WednesdaySnackTwoSelectedSnack != -1)
            {
                MealPlannerWednesdayCurrentCalories += IngredientDatabase[WednesdaySnackTwoSelectedSnack].Calories;
            }
            if (WednesdaySnackThreeSelectedSnack != -1)
            {
                MealPlannerWednesdayCurrentCalories += IngredientDatabase[WednesdaySnackThreeSelectedSnack].Calories;
            }
            if (WednesdaySnackFourSelectedSnack != -1)
            {
                MealPlannerWednesdayCurrentCalories += IngredientDatabase[WednesdaySnackFourSelectedSnack].Calories;
            }

            UpdateWednesdayCurrentCaloriesColor();
        }

        public void ClearWednesdayBreakfast()
        {
            if (WednesdayBreakfastOneSelectedMeal != -1)
            {
                MealPlannerWednesdayCurrentCalories -= MealDatabase[WednesdayBreakfastOneSelectedMeal].TotalCalories;
            }
            if (WednesdayBreakfastTwoSelectedMeal != -1)
            {
                MealPlannerWednesdayCurrentCalories -= MealDatabase[WednesdayBreakfastTwoSelectedMeal].TotalCalories;
            }
            UpdateWednesdayCurrentCaloriesColor();

            WednesdayBreakfastOneSelectedMeal = -1;
            WednesdayBreakfastTwoSelectedMeal = -1;
        }
        public void ClearWednesdayLunch()
        {
            if (WednesdayLunchOneSelectedMeal != -1)
            {
                MealPlannerWednesdayCurrentCalories -= MealDatabase[WednesdayLunchOneSelectedMeal].TotalCalories;
            }
            if (WednesdayLunchTwoSelectedMeal != -1)
            {
                MealPlannerWednesdayCurrentCalories -= MealDatabase[WednesdayLunchTwoSelectedMeal].TotalCalories;
            }
            UpdateWednesdayCurrentCaloriesColor();

            WednesdayLunchOneSelectedMeal = -1;
            WednesdayLunchTwoSelectedMeal = -1;
        }
        public void ClearWednesdayDinner()
        {
            if (WednesdayDinnerOneSelectedMeal != -1)
            {
                MealPlannerWednesdayCurrentCalories -= MealDatabase[WednesdayDinnerOneSelectedMeal].TotalCalories;
            }
            if (WednesdayDinnerTwoSelectedMeal != -1)
            {
                MealPlannerWednesdayCurrentCalories -= MealDatabase[WednesdayDinnerTwoSelectedMeal].TotalCalories;
            }
            UpdateWednesdayCurrentCaloriesColor();

            WednesdayDinnerOneSelectedMeal = -1;
            WednesdayDinnerTwoSelectedMeal = -1;
        }
        public void ClearWednesdayBeverages()
        {
            if (WednesdayBeverageOneSelectedBeverage != -1)
            {
                MealPlannerWednesdayCurrentCalories -= IngredientDatabase[WednesdayBeverageOneSelectedBeverage].Calories;
            }
            if (WednesdayBeverageTwoSelectedBeverage != -1)
            {
                MealPlannerWednesdayCurrentCalories -= IngredientDatabase[WednesdayBeverageTwoSelectedBeverage].Calories;
            }
            if (WednesdayBeverageThreeSelectedBeverage != -1)
            {
                MealPlannerWednesdayCurrentCalories -= IngredientDatabase[WednesdayBeverageThreeSelectedBeverage].Calories;
            }
            if (WednesdayBeverageFourSelectedBeverage != -1)
            {
                MealPlannerWednesdayCurrentCalories -= IngredientDatabase[WednesdayBeverageFourSelectedBeverage].Calories;
            }
            UpdateWednesdayCurrentCaloriesColor();

            WednesdayBeverageOneSelectedBeverage = -1;
            WednesdayBeverageTwoSelectedBeverage = -1;
            WednesdayBeverageThreeSelectedBeverage = -1;
            WednesdayBeverageFourSelectedBeverage = -1;
        }
        public void ClearWednesdaySnacks()
        {
            if (WednesdaySnackOneSelectedSnack != -1)
            {
                MealPlannerWednesdayCurrentCalories -= IngredientDatabase[WednesdaySnackOneSelectedSnack].Calories;
            }
            if (WednesdaySnackTwoSelectedSnack != -1)
            {
                MealPlannerWednesdayCurrentCalories -= IngredientDatabase[WednesdaySnackTwoSelectedSnack].Calories;
            }
            if (WednesdaySnackThreeSelectedSnack != -1)
            {
                MealPlannerWednesdayCurrentCalories -= IngredientDatabase[WednesdaySnackThreeSelectedSnack].Calories;
            }
            if (WednesdaySnackFourSelectedSnack != -1)
            {
                MealPlannerWednesdayCurrentCalories -= IngredientDatabase[WednesdaySnackFourSelectedSnack].Calories;
            }
            UpdateWednesdayCurrentCaloriesColor();

            WednesdaySnackOneSelectedSnack = -1;
            WednesdaySnackTwoSelectedSnack = -1;
            WednesdaySnackThreeSelectedSnack = -1;
            WednesdaySnackFourSelectedSnack = -1;
        }

        // TUESDAY SECTION
        public void UpdateTuesdayCurrentCaloriesColor()
        {
            if (MealPlannerTuesdayCurrentCalories > MealPlannerTuesdayTotalCalories && MealPlannerTuesdayTotalCalories != 0)
            {
                TuesdayCurrentCaloriesColor = "Red";
            }
            else
            {
                TuesdayCurrentCaloriesColor = "White";
            }
        }

        public void UpdateTuesdayCurrentCalories()
        {
            MealPlannerTuesdayCurrentCalories = 0;
            if (TuesdayBreakfastOneSelectedMeal != -1)
            {
                MealPlannerTuesdayCurrentCalories += MealDatabase[TuesdayBreakfastOneSelectedMeal].TotalCalories;
            }
            if (TuesdayBreakfastTwoSelectedMeal != -1)
            {
                MealPlannerTuesdayCurrentCalories += MealDatabase[TuesdayBreakfastTwoSelectedMeal].TotalCalories;
            }
            if (TuesdayLunchOneSelectedMeal != -1)
            {
                MealPlannerTuesdayCurrentCalories += MealDatabase[TuesdayLunchOneSelectedMeal].TotalCalories;
            }
            if (TuesdayLunchTwoSelectedMeal != -1)
            {
                MealPlannerTuesdayCurrentCalories += MealDatabase[TuesdayLunchTwoSelectedMeal].TotalCalories;
            }
            if (TuesdayDinnerOneSelectedMeal != -1)
            {
                MealPlannerTuesdayCurrentCalories += MealDatabase[TuesdayDinnerOneSelectedMeal].TotalCalories;
            }
            if (TuesdayDinnerTwoSelectedMeal != -1)
            {
                MealPlannerTuesdayCurrentCalories += MealDatabase[TuesdayDinnerTwoSelectedMeal].TotalCalories;
            }
            if (TuesdayBeverageOneSelectedBeverage != -1)
            {
                MealPlannerTuesdayCurrentCalories += IngredientDatabase[TuesdayBeverageOneSelectedBeverage].Calories;
            }
            if (TuesdayBeverageTwoSelectedBeverage != -1)
            {
                MealPlannerTuesdayCurrentCalories += IngredientDatabase[TuesdayBeverageTwoSelectedBeverage].Calories;
            }
            if (TuesdayBeverageThreeSelectedBeverage != -1)
            {
                MealPlannerTuesdayCurrentCalories += IngredientDatabase[TuesdayBeverageThreeSelectedBeverage].Calories;
            }
            if (TuesdayBeverageFourSelectedBeverage != -1)
            {
                MealPlannerTuesdayCurrentCalories += IngredientDatabase[TuesdayBeverageFourSelectedBeverage].Calories;
            }
            if (TuesdaySnackOneSelectedSnack != -1)
            {
                MealPlannerTuesdayCurrentCalories += IngredientDatabase[TuesdaySnackOneSelectedSnack].Calories;
            }
            if (TuesdaySnackTwoSelectedSnack != -1)
            {
                MealPlannerTuesdayCurrentCalories += IngredientDatabase[TuesdaySnackTwoSelectedSnack].Calories;
            }
            if (TuesdaySnackThreeSelectedSnack != -1)
            {
                MealPlannerTuesdayCurrentCalories += IngredientDatabase[TuesdaySnackThreeSelectedSnack].Calories;
            }
            if (TuesdaySnackFourSelectedSnack != -1)
            {
                MealPlannerTuesdayCurrentCalories += IngredientDatabase[TuesdaySnackFourSelectedSnack].Calories;
            }

            UpdateTuesdayCurrentCaloriesColor();
        }

        public void ClearTuesdayBreakfast()
        {
            if (TuesdayBreakfastOneSelectedMeal != -1)
            {
                MealPlannerTuesdayCurrentCalories -= MealDatabase[TuesdayBreakfastOneSelectedMeal].TotalCalories;
            }
            if (TuesdayBreakfastTwoSelectedMeal != -1)
            {
                MealPlannerTuesdayCurrentCalories -= MealDatabase[TuesdayBreakfastTwoSelectedMeal].TotalCalories;
            }
            UpdateTuesdayCurrentCaloriesColor();

            TuesdayBreakfastOneSelectedMeal = -1;
            TuesdayBreakfastTwoSelectedMeal = -1;
        }
        public void ClearTuesdayLunch()
        {
            if (TuesdayLunchOneSelectedMeal != -1)
            {
                MealPlannerTuesdayCurrentCalories -= MealDatabase[TuesdayLunchOneSelectedMeal].TotalCalories;
            }
            if (TuesdayLunchTwoSelectedMeal != -1)
            {
                MealPlannerTuesdayCurrentCalories -= MealDatabase[TuesdayLunchTwoSelectedMeal].TotalCalories;
            }
            UpdateTuesdayCurrentCaloriesColor();

            TuesdayLunchOneSelectedMeal = -1;
            TuesdayLunchTwoSelectedMeal = -1;
        }
        public void ClearTuesdayDinner()
        {
            if (TuesdayDinnerOneSelectedMeal != -1)
            {
                MealPlannerTuesdayCurrentCalories -= MealDatabase[TuesdayDinnerOneSelectedMeal].TotalCalories;
            }
            if (TuesdayDinnerTwoSelectedMeal != -1)
            {
                MealPlannerTuesdayCurrentCalories -= MealDatabase[TuesdayDinnerTwoSelectedMeal].TotalCalories;
            }
            UpdateTuesdayCurrentCaloriesColor();

            TuesdayDinnerOneSelectedMeal = -1;
            TuesdayDinnerTwoSelectedMeal = -1;
        }
        public void ClearTuesdayBeverages()
        {
            if (TuesdayBeverageOneSelectedBeverage != -1)
            {
                MealPlannerTuesdayCurrentCalories -= IngredientDatabase[TuesdayBeverageOneSelectedBeverage].Calories;
            }
            if (TuesdayBeverageTwoSelectedBeverage != -1)
            {
                MealPlannerTuesdayCurrentCalories -= IngredientDatabase[TuesdayBeverageTwoSelectedBeverage].Calories;
            }
            if (TuesdayBeverageThreeSelectedBeverage != -1)
            {
                MealPlannerTuesdayCurrentCalories -= IngredientDatabase[TuesdayBeverageThreeSelectedBeverage].Calories;
            }
            if (TuesdayBeverageFourSelectedBeverage != -1)
            {
                MealPlannerTuesdayCurrentCalories -= IngredientDatabase[TuesdayBeverageFourSelectedBeverage].Calories;
            }
            UpdateTuesdayCurrentCaloriesColor();

            TuesdayBeverageOneSelectedBeverage = -1;
            TuesdayBeverageTwoSelectedBeverage = -1;
            TuesdayBeverageThreeSelectedBeverage = -1;
            TuesdayBeverageFourSelectedBeverage = -1;
        }
        public void ClearTuesdaySnacks()
        {
            if (TuesdaySnackOneSelectedSnack != -1)
            {
                MealPlannerTuesdayCurrentCalories -= IngredientDatabase[TuesdaySnackOneSelectedSnack].Calories;
            }
            if (TuesdaySnackTwoSelectedSnack != -1)
            {
                MealPlannerTuesdayCurrentCalories -= IngredientDatabase[TuesdaySnackTwoSelectedSnack].Calories;
            }
            if (TuesdaySnackThreeSelectedSnack != -1)
            {
                MealPlannerTuesdayCurrentCalories -= IngredientDatabase[TuesdaySnackThreeSelectedSnack].Calories;
            }
            if (TuesdaySnackFourSelectedSnack != -1)
            {
                MealPlannerTuesdayCurrentCalories -= IngredientDatabase[TuesdaySnackFourSelectedSnack].Calories;
            }
            UpdateTuesdayCurrentCaloriesColor();

            TuesdaySnackOneSelectedSnack = -1;
            TuesdaySnackTwoSelectedSnack = -1;
            TuesdaySnackThreeSelectedSnack = -1;
            TuesdaySnackFourSelectedSnack = -1;
        }

        // MONDAY SECTION
        public void UpdateMondayCurrentCaloriesColor()
        {
            if (MealPlannerMondayCurrentCalories > MealPlannerMondayTotalCalories && MealPlannerMondayTotalCalories != 0)
            {
                MondayCurrentCaloriesColor = "Red";
            }
            else
            {
                MondayCurrentCaloriesColor = "White";
            }
        }

        public void UpdateMondayCurrentCalories()
        {
            MealPlannerMondayCurrentCalories = 0;
            if (MondayBreakfastOneSelectedMeal != -1)
            {
                MealPlannerMondayCurrentCalories += MealDatabase[MondayBreakfastOneSelectedMeal].TotalCalories;
            }
            if (MondayBreakfastTwoSelectedMeal != -1)
            {
                MealPlannerMondayCurrentCalories += MealDatabase[MondayBreakfastTwoSelectedMeal].TotalCalories;
            }
            if (MondayLunchOneSelectedMeal != -1)
            {
                MealPlannerMondayCurrentCalories += MealDatabase[MondayLunchOneSelectedMeal].TotalCalories;
            }
            if (MondayLunchTwoSelectedMeal != -1)
            {
                MealPlannerMondayCurrentCalories += MealDatabase[MondayLunchTwoSelectedMeal].TotalCalories;
            }
            if (MondayDinnerOneSelectedMeal != -1)
            {
                MealPlannerMondayCurrentCalories += MealDatabase[MondayDinnerOneSelectedMeal].TotalCalories;
            }
            if (MondayDinnerTwoSelectedMeal != -1)
            {
                MealPlannerMondayCurrentCalories += MealDatabase[MondayDinnerTwoSelectedMeal].TotalCalories;
            }
            if (MondayBeverageOneSelectedBeverage != -1)
            {
                MealPlannerMondayCurrentCalories += IngredientDatabase[MondayBeverageOneSelectedBeverage].Calories;
            }
            if (MondayBeverageTwoSelectedBeverage != -1)
            {
                MealPlannerMondayCurrentCalories += IngredientDatabase[MondayBeverageTwoSelectedBeverage].Calories;
            }
            if (MondayBeverageThreeSelectedBeverage != -1)
            {
                MealPlannerMondayCurrentCalories += IngredientDatabase[MondayBeverageThreeSelectedBeverage].Calories;
            }
            if (MondayBeverageFourSelectedBeverage != -1)
            {
                MealPlannerMondayCurrentCalories += IngredientDatabase[MondayBeverageFourSelectedBeverage].Calories;
            }
            if (MondaySnackOneSelectedSnack != -1)
            {
                MealPlannerMondayCurrentCalories += IngredientDatabase[MondaySnackOneSelectedSnack].Calories;
            }
            if (MondaySnackTwoSelectedSnack != -1)
            {
                MealPlannerMondayCurrentCalories += IngredientDatabase[MondaySnackTwoSelectedSnack].Calories;
            }
            if (MondaySnackThreeSelectedSnack != -1)
            {
                MealPlannerMondayCurrentCalories += IngredientDatabase[MondaySnackThreeSelectedSnack].Calories;
            }
            if (MondaySnackFourSelectedSnack != -1)
            {
                MealPlannerMondayCurrentCalories += IngredientDatabase[MondaySnackFourSelectedSnack].Calories;
            }

            UpdateMondayCurrentCaloriesColor();
        }

        public void ClearMondayBreakfast()
        {
            if (MondayBreakfastOneSelectedMeal != -1)
            {
                MealPlannerMondayCurrentCalories -= MealDatabase[MondayBreakfastOneSelectedMeal].TotalCalories;
            }
            if (MondayBreakfastTwoSelectedMeal != -1)
            {
                MealPlannerMondayCurrentCalories -= MealDatabase[MondayBreakfastTwoSelectedMeal].TotalCalories;
            }
            UpdateMondayCurrentCaloriesColor();

            MondayBreakfastOneSelectedMeal = -1;
            MondayBreakfastTwoSelectedMeal = -1;
        }
        public void ClearMondayLunch()
        {
            if (MondayLunchOneSelectedMeal != -1)
            {
                MealPlannerMondayCurrentCalories -= MealDatabase[MondayLunchOneSelectedMeal].TotalCalories;
            }
            if (MondayLunchTwoSelectedMeal != -1)
            {
                MealPlannerMondayCurrentCalories -= MealDatabase[MondayLunchTwoSelectedMeal].TotalCalories;
            }
            UpdateMondayCurrentCaloriesColor();

            MondayLunchOneSelectedMeal = -1;
            MondayLunchTwoSelectedMeal = -1;
        }
        public void ClearMondayDinner()
        {
            if (MondayDinnerOneSelectedMeal != -1)
            {
                MealPlannerMondayCurrentCalories -= MealDatabase[MondayDinnerOneSelectedMeal].TotalCalories;
            }
            if (MondayDinnerTwoSelectedMeal != -1)
            {
                MealPlannerMondayCurrentCalories -= MealDatabase[MondayDinnerTwoSelectedMeal].TotalCalories;
            }
            UpdateMondayCurrentCaloriesColor();

            MondayDinnerOneSelectedMeal = -1;
            MondayDinnerTwoSelectedMeal = -1;
        }
        public void ClearMondayBeverages()
        {
            if (MondayBeverageOneSelectedBeverage != -1)
            {
                MealPlannerMondayCurrentCalories -= IngredientDatabase[MondayBeverageOneSelectedBeverage].Calories;
            }
            if (MondayBeverageTwoSelectedBeverage != -1)
            {
                MealPlannerMondayCurrentCalories -= IngredientDatabase[MondayBeverageTwoSelectedBeverage].Calories;
            }
            if (MondayBeverageThreeSelectedBeverage != -1)
            {
                MealPlannerMondayCurrentCalories -= IngredientDatabase[MondayBeverageThreeSelectedBeverage].Calories;
            }
            if (MondayBeverageFourSelectedBeverage != -1)
            {
                MealPlannerMondayCurrentCalories -= IngredientDatabase[MondayBeverageFourSelectedBeverage].Calories;
            }
            UpdateMondayCurrentCaloriesColor();

            MondayBeverageOneSelectedBeverage = -1;
            MondayBeverageTwoSelectedBeverage = -1;
            MondayBeverageThreeSelectedBeverage = -1;
            MondayBeverageFourSelectedBeverage = -1;
        }
        public void ClearMondaySnacks()
        {
            if (MondaySnackOneSelectedSnack != -1)
            {
                MealPlannerMondayCurrentCalories -= IngredientDatabase[MondaySnackOneSelectedSnack].Calories;
            }
            if (MondaySnackTwoSelectedSnack != -1)
            {
                MealPlannerMondayCurrentCalories -= IngredientDatabase[MondaySnackTwoSelectedSnack].Calories;
            }
            if (MondaySnackThreeSelectedSnack != -1)
            {
                MealPlannerMondayCurrentCalories -= IngredientDatabase[MondaySnackThreeSelectedSnack].Calories;
            }
            if (MondaySnackFourSelectedSnack != -1)
            {
                MealPlannerMondayCurrentCalories -= IngredientDatabase[MondaySnackFourSelectedSnack].Calories;
            }
            UpdateMondayCurrentCaloriesColor();

            MondaySnackOneSelectedSnack = -1;
            MondaySnackTwoSelectedSnack = -1;
            MondaySnackThreeSelectedSnack = -1;
            MondaySnackFourSelectedSnack = -1;
        }

        // SUNDAY SECTION
        public void UpdateSundayCurrentCaloriesColor()
        {
            if (MealPlannerSundayCurrentCalories > MealPlannerSundayTotalCalories && MealPlannerSundayTotalCalories != 0)
            {
                SundayCurrentCaloriesColor = "Red";
            }
            else 
            {
                SundayCurrentCaloriesColor = "White";
            }
        }

        public void UpdateSundayCurrentCalories() 
        {
            MealPlannerSundayCurrentCalories = 0;
            if (SundayBreakfastOneSelectedMeal != -1)
            {
                MealPlannerSundayCurrentCalories += MealDatabase[SundayBreakfastOneSelectedMeal].TotalCalories;
            }
            if (SundayBreakfastTwoSelectedMeal != -1)
            {
                MealPlannerSundayCurrentCalories += MealDatabase[SundayBreakfastTwoSelectedMeal].TotalCalories;
            }
            if (SundayLunchOneSelectedMeal != -1)
            {
                MealPlannerSundayCurrentCalories += MealDatabase[SundayLunchOneSelectedMeal].TotalCalories;
            }
            if (SundayLunchTwoSelectedMeal != -1)
            {
                MealPlannerSundayCurrentCalories += MealDatabase[SundayLunchTwoSelectedMeal].TotalCalories;
            }
            if (SundayDinnerOneSelectedMeal != -1)
            {
                MealPlannerSundayCurrentCalories += MealDatabase[SundayDinnerOneSelectedMeal].TotalCalories;
            }
            if (SundayDinnerTwoSelectedMeal != -1)
            {
                MealPlannerSundayCurrentCalories += MealDatabase[SundayDinnerTwoSelectedMeal].TotalCalories;
            }
            if (SundayBeverageOneSelectedBeverage != -1)
            {
                MealPlannerSundayCurrentCalories += IngredientDatabase[SundayBeverageOneSelectedBeverage].Calories;
            }
            if (SundayBeverageTwoSelectedBeverage != -1)
            {
                MealPlannerSundayCurrentCalories += IngredientDatabase[SundayBeverageTwoSelectedBeverage].Calories;
            }
            if (SundayBeverageThreeSelectedBeverage != -1)
            {
                MealPlannerSundayCurrentCalories += IngredientDatabase[SundayBeverageThreeSelectedBeverage].Calories;
            }
            if (SundayBeverageFourSelectedBeverage != -1)
            {
                MealPlannerSundayCurrentCalories += IngredientDatabase[SundayBeverageFourSelectedBeverage].Calories;
            }
            if (SundaySnackOneSelectedSnack != -1)
            {
                MealPlannerSundayCurrentCalories += IngredientDatabase[SundaySnackOneSelectedSnack].Calories;
            }
            if (SundaySnackTwoSelectedSnack != -1)
            {
                MealPlannerSundayCurrentCalories += IngredientDatabase[SundaySnackTwoSelectedSnack].Calories;
            }
            if (SundaySnackThreeSelectedSnack != -1)
            {
                MealPlannerSundayCurrentCalories += IngredientDatabase[SundaySnackThreeSelectedSnack].Calories;
            }
            if (SundaySnackFourSelectedSnack != -1)
            {
                MealPlannerSundayCurrentCalories += IngredientDatabase[SundaySnackFourSelectedSnack].Calories;
            }

            UpdateSundayCurrentCaloriesColor();
        }

        public void ClearSundayBreakfast()
        {
            if (SundayBreakfastOneSelectedMeal != -1)
            {
                MealPlannerSundayCurrentCalories -= MealDatabase[SundayBreakfastOneSelectedMeal].TotalCalories;
            }
            if (SundayBreakfastTwoSelectedMeal != -1)
            {
                MealPlannerSundayCurrentCalories -= MealDatabase[SundayBreakfastTwoSelectedMeal].TotalCalories;
            }
            UpdateSundayCurrentCaloriesColor();

            SundayBreakfastOneSelectedMeal = -1;
            SundayBreakfastTwoSelectedMeal = -1;
        }
        public void ClearSundayLunch()
        {
            if (SundayLunchOneSelectedMeal != -1)
            {
                MealPlannerSundayCurrentCalories -= MealDatabase[SundayLunchOneSelectedMeal].TotalCalories;
            }
            if (SundayLunchTwoSelectedMeal != -1)
            {
                MealPlannerSundayCurrentCalories -= MealDatabase[SundayLunchTwoSelectedMeal].TotalCalories;
            }
            UpdateSundayCurrentCaloriesColor();

            SundayLunchOneSelectedMeal = -1;
            SundayLunchTwoSelectedMeal = -1;
        }
        public void ClearSundayDinner()
        {
            if (SundayDinnerOneSelectedMeal != -1)
            {
                MealPlannerSundayCurrentCalories -= MealDatabase[SundayDinnerOneSelectedMeal].TotalCalories;
            }
            if (SundayDinnerTwoSelectedMeal != -1)
            {
                MealPlannerSundayCurrentCalories -= MealDatabase[SundayDinnerTwoSelectedMeal].TotalCalories;
            }
            UpdateSundayCurrentCaloriesColor();

            SundayDinnerOneSelectedMeal = -1;
            SundayDinnerTwoSelectedMeal = -1;
        }
        public void ClearSundayBeverages()
        {
            if (SundayBeverageOneSelectedBeverage != -1)
            {
                MealPlannerSundayCurrentCalories -= IngredientDatabase[SundayBeverageOneSelectedBeverage].Calories;
            }
            if (SundayBeverageTwoSelectedBeverage != -1)
            {
                MealPlannerSundayCurrentCalories -= IngredientDatabase[SundayBeverageTwoSelectedBeverage].Calories;
            }
            if (SundayBeverageThreeSelectedBeverage != -1)
            {
                MealPlannerSundayCurrentCalories -= IngredientDatabase[SundayBeverageThreeSelectedBeverage].Calories;
            }
            if (SundayBeverageFourSelectedBeverage != -1)
            {
                MealPlannerSundayCurrentCalories -= IngredientDatabase[SundayBeverageFourSelectedBeverage].Calories;
            }
            UpdateSundayCurrentCaloriesColor();

            SundayBeverageOneSelectedBeverage = -1;
            SundayBeverageTwoSelectedBeverage = -1;
            SundayBeverageThreeSelectedBeverage = -1;
            SundayBeverageFourSelectedBeverage = -1;
        }
        public void ClearSundaySnacks()
        {
            if (SundaySnackOneSelectedSnack != -1)
            {
                MealPlannerSundayCurrentCalories -= IngredientDatabase[SundaySnackOneSelectedSnack].Calories;
            }
            if (SundaySnackTwoSelectedSnack != -1)
            {
                MealPlannerSundayCurrentCalories -= IngredientDatabase[SundaySnackTwoSelectedSnack].Calories;
            }
            if (SundaySnackThreeSelectedSnack != -1)
            {
                MealPlannerSundayCurrentCalories -= IngredientDatabase[SundaySnackThreeSelectedSnack].Calories;
            }
            if (SundaySnackFourSelectedSnack != -1)
            {
                MealPlannerSundayCurrentCalories -= IngredientDatabase[SundaySnackFourSelectedSnack].Calories;
            }
            UpdateSundayCurrentCaloriesColor();

            SundaySnackOneSelectedSnack = -1;
            SundaySnackTwoSelectedSnack = -1;
            SundaySnackThreeSelectedSnack = -1;
            SundaySnackFourSelectedSnack = -1;
        }


        public void SaveWeeklyMealsToPerson()
        {
            List<int> weeklyMeals = new List<int>();
            weeklyMeals.Add(SundayBreakfastOneSelectedMeal);
            weeklyMeals.Add(SundayBreakfastTwoSelectedMeal);
            weeklyMeals.Add(SundayLunchOneSelectedMeal);
            weeklyMeals.Add(SundayLunchTwoSelectedMeal);
            weeklyMeals.Add(SundayDinnerOneSelectedMeal);
            weeklyMeals.Add(SundayDinnerTwoSelectedMeal);
            weeklyMeals.Add(SundayBeverageOneSelectedBeverage);
            weeklyMeals.Add(SundayBeverageTwoSelectedBeverage);
            weeklyMeals.Add(SundayBeverageThreeSelectedBeverage);
            weeklyMeals.Add(SundayBeverageFourSelectedBeverage);
            weeklyMeals.Add(SundaySnackOneSelectedSnack);
            weeklyMeals.Add(SundaySnackTwoSelectedSnack);
            weeklyMeals.Add(SundaySnackThreeSelectedSnack);
            weeklyMeals.Add(SundaySnackFourSelectedSnack);

            weeklyMeals.Add(MondayBreakfastOneSelectedMeal);
            weeklyMeals.Add(MondayBreakfastTwoSelectedMeal);
            weeklyMeals.Add(MondayLunchOneSelectedMeal);
            weeklyMeals.Add(MondayLunchTwoSelectedMeal);
            weeklyMeals.Add(MondayDinnerOneSelectedMeal);
            weeklyMeals.Add(MondayDinnerTwoSelectedMeal);
            weeklyMeals.Add(MondayBeverageOneSelectedBeverage);
            weeklyMeals.Add(MondayBeverageTwoSelectedBeverage);
            weeklyMeals.Add(MondayBeverageThreeSelectedBeverage);
            weeklyMeals.Add(MondayBeverageFourSelectedBeverage);
            weeklyMeals.Add(MondaySnackOneSelectedSnack);
            weeklyMeals.Add(MondaySnackTwoSelectedSnack);
            weeklyMeals.Add(MondaySnackThreeSelectedSnack);
            weeklyMeals.Add(MondaySnackFourSelectedSnack);

            weeklyMeals.Add(TuesdayBreakfastOneSelectedMeal);
            weeklyMeals.Add(TuesdayBreakfastTwoSelectedMeal);
            weeklyMeals.Add(TuesdayLunchOneSelectedMeal);
            weeklyMeals.Add(TuesdayLunchTwoSelectedMeal);
            weeklyMeals.Add(TuesdayDinnerOneSelectedMeal);
            weeklyMeals.Add(TuesdayDinnerTwoSelectedMeal);
            weeklyMeals.Add(TuesdayBeverageOneSelectedBeverage);
            weeklyMeals.Add(TuesdayBeverageTwoSelectedBeverage);
            weeklyMeals.Add(TuesdayBeverageThreeSelectedBeverage);
            weeklyMeals.Add(TuesdayBeverageFourSelectedBeverage);
            weeklyMeals.Add(TuesdaySnackOneSelectedSnack);
            weeklyMeals.Add(TuesdaySnackTwoSelectedSnack);
            weeklyMeals.Add(TuesdaySnackThreeSelectedSnack);
            weeklyMeals.Add(TuesdaySnackFourSelectedSnack);

            weeklyMeals.Add(WednesdayBreakfastOneSelectedMeal);
            weeklyMeals.Add(WednesdayBreakfastTwoSelectedMeal);
            weeklyMeals.Add(WednesdayLunchOneSelectedMeal);
            weeklyMeals.Add(WednesdayLunchTwoSelectedMeal);
            weeklyMeals.Add(WednesdayDinnerOneSelectedMeal);
            weeklyMeals.Add(WednesdayDinnerTwoSelectedMeal);
            weeklyMeals.Add(WednesdayBeverageOneSelectedBeverage);
            weeklyMeals.Add(WednesdayBeverageTwoSelectedBeverage);
            weeklyMeals.Add(WednesdayBeverageThreeSelectedBeverage);
            weeklyMeals.Add(WednesdayBeverageFourSelectedBeverage);
            weeklyMeals.Add(WednesdaySnackOneSelectedSnack);
            weeklyMeals.Add(WednesdaySnackTwoSelectedSnack);
            weeklyMeals.Add(WednesdaySnackThreeSelectedSnack);
            weeklyMeals.Add(WednesdaySnackFourSelectedSnack);

            weeklyMeals.Add(ThursdayBreakfastOneSelectedMeal);
            weeklyMeals.Add(ThursdayBreakfastTwoSelectedMeal);
            weeklyMeals.Add(ThursdayLunchOneSelectedMeal);
            weeklyMeals.Add(ThursdayLunchTwoSelectedMeal);
            weeklyMeals.Add(ThursdayDinnerOneSelectedMeal);
            weeklyMeals.Add(ThursdayDinnerTwoSelectedMeal);
            weeklyMeals.Add(ThursdayBeverageOneSelectedBeverage);
            weeklyMeals.Add(ThursdayBeverageTwoSelectedBeverage);
            weeklyMeals.Add(ThursdayBeverageThreeSelectedBeverage);
            weeklyMeals.Add(ThursdayBeverageFourSelectedBeverage);
            weeklyMeals.Add(ThursdaySnackOneSelectedSnack);
            weeklyMeals.Add(ThursdaySnackTwoSelectedSnack);
            weeklyMeals.Add(ThursdaySnackThreeSelectedSnack);
            weeklyMeals.Add(ThursdaySnackFourSelectedSnack);

            weeklyMeals.Add(FridayBreakfastOneSelectedMeal);
            weeklyMeals.Add(FridayBreakfastTwoSelectedMeal);
            weeklyMeals.Add(FridayLunchOneSelectedMeal);
            weeklyMeals.Add(FridayLunchTwoSelectedMeal);
            weeklyMeals.Add(FridayDinnerOneSelectedMeal);
            weeklyMeals.Add(FridayDinnerTwoSelectedMeal);
            weeklyMeals.Add(FridayBeverageOneSelectedBeverage);
            weeklyMeals.Add(FridayBeverageTwoSelectedBeverage);
            weeklyMeals.Add(FridayBeverageThreeSelectedBeverage);
            weeklyMeals.Add(FridayBeverageFourSelectedBeverage);
            weeklyMeals.Add(FridaySnackOneSelectedSnack);
            weeklyMeals.Add(FridaySnackTwoSelectedSnack);
            weeklyMeals.Add(FridaySnackThreeSelectedSnack);
            weeklyMeals.Add(FridaySnackFourSelectedSnack);

            weeklyMeals.Add(SaturdayBreakfastOneSelectedMeal);
            weeklyMeals.Add(SaturdayBreakfastTwoSelectedMeal);
            weeklyMeals.Add(SaturdayLunchOneSelectedMeal);
            weeklyMeals.Add(SaturdayLunchTwoSelectedMeal);
            weeklyMeals.Add(SaturdayDinnerOneSelectedMeal);
            weeklyMeals.Add(SaturdayDinnerTwoSelectedMeal);
            weeklyMeals.Add(SaturdayBeverageOneSelectedBeverage);
            weeklyMeals.Add(SaturdayBeverageTwoSelectedBeverage);
            weeklyMeals.Add(SaturdayBeverageThreeSelectedBeverage);
            weeklyMeals.Add(SaturdayBeverageFourSelectedBeverage);
            weeklyMeals.Add(SaturdaySnackOneSelectedSnack);
            weeklyMeals.Add(SaturdaySnackTwoSelectedSnack);
            weeklyMeals.Add(SaturdaySnackThreeSelectedSnack);
            weeklyMeals.Add(SaturdaySnackFourSelectedSnack);

            UserPerson.WeeklyMeals = new List<int>();
            foreach (int meal in weeklyMeals)
            {
                UserPerson.WeeklyMeals.Add(meal);
            }
            
        }

        public void ReadWeeklyMeals()
        {
            SundayBreakfastOneSelectedMeal = UserPerson.WeeklyMeals[0];
            SundayBreakfastTwoSelectedMeal = UserPerson.WeeklyMeals[1];
            SundayLunchOneSelectedMeal = UserPerson.WeeklyMeals[2];
            SundayLunchTwoSelectedMeal = UserPerson.WeeklyMeals[3];
            SundayDinnerOneSelectedMeal = UserPerson.WeeklyMeals[4];
            SundayDinnerTwoSelectedMeal = UserPerson.WeeklyMeals[5];
            SundayBeverageOneSelectedBeverage = UserPerson.WeeklyMeals[6];
            SundayBeverageTwoSelectedBeverage = UserPerson.WeeklyMeals[7];
            SundayBeverageThreeSelectedBeverage = UserPerson.WeeklyMeals[8];
            SundayBeverageFourSelectedBeverage = UserPerson.WeeklyMeals[9];
            SundaySnackOneSelectedSnack = UserPerson.WeeklyMeals[10];
            SundaySnackTwoSelectedSnack = UserPerson.WeeklyMeals[11];
            SundaySnackThreeSelectedSnack = UserPerson.WeeklyMeals[12];
            SundaySnackFourSelectedSnack = UserPerson.WeeklyMeals[13];

            MondayBreakfastOneSelectedMeal = UserPerson.WeeklyMeals[14];
            MondayBreakfastTwoSelectedMeal = UserPerson.WeeklyMeals[15];
            MondayLunchOneSelectedMeal = UserPerson.WeeklyMeals[16];
            MondayLunchTwoSelectedMeal = UserPerson.WeeklyMeals[17];
            MondayDinnerOneSelectedMeal = UserPerson.WeeklyMeals[18];
            MondayDinnerTwoSelectedMeal = UserPerson.WeeklyMeals[19];
            MondayBeverageOneSelectedBeverage = UserPerson.WeeklyMeals[20];
            MondayBeverageTwoSelectedBeverage = UserPerson.WeeklyMeals[21];
            MondayBeverageThreeSelectedBeverage = UserPerson.WeeklyMeals[22];
            MondayBeverageFourSelectedBeverage = UserPerson.WeeklyMeals[23];
            MondaySnackOneSelectedSnack = UserPerson.WeeklyMeals[24];
            MondaySnackTwoSelectedSnack = UserPerson.WeeklyMeals[25];
            MondaySnackThreeSelectedSnack = UserPerson.WeeklyMeals[26];
            MondaySnackFourSelectedSnack = UserPerson.WeeklyMeals[27];

            TuesdayBreakfastOneSelectedMeal = UserPerson.WeeklyMeals[28];
            TuesdayBreakfastTwoSelectedMeal = UserPerson.WeeklyMeals[29];
            TuesdayLunchOneSelectedMeal = UserPerson.WeeklyMeals[30];
            TuesdayLunchTwoSelectedMeal = UserPerson.WeeklyMeals[31];
            TuesdayDinnerOneSelectedMeal = UserPerson.WeeklyMeals[32];
            TuesdayDinnerTwoSelectedMeal = UserPerson.WeeklyMeals[33];
            TuesdayBeverageOneSelectedBeverage = UserPerson.WeeklyMeals[34];
            TuesdayBeverageTwoSelectedBeverage = UserPerson.WeeklyMeals[35];
            TuesdayBeverageThreeSelectedBeverage = UserPerson.WeeklyMeals[36];
            TuesdayBeverageFourSelectedBeverage = UserPerson.WeeklyMeals[37];
            TuesdaySnackOneSelectedSnack = UserPerson.WeeklyMeals[38];
            TuesdaySnackTwoSelectedSnack = UserPerson.WeeklyMeals[39];
            TuesdaySnackThreeSelectedSnack = UserPerson.WeeklyMeals[40];
            TuesdaySnackFourSelectedSnack = UserPerson.WeeklyMeals[41];

            WednesdayBreakfastOneSelectedMeal = UserPerson.WeeklyMeals[42];
            WednesdayBreakfastTwoSelectedMeal = UserPerson.WeeklyMeals[43];
            WednesdayLunchOneSelectedMeal = UserPerson.WeeklyMeals[44];
            WednesdayLunchTwoSelectedMeal = UserPerson.WeeklyMeals[45];
            WednesdayDinnerOneSelectedMeal = UserPerson.WeeklyMeals[46];
            WednesdayDinnerTwoSelectedMeal = UserPerson.WeeklyMeals[47];
            WednesdayBeverageOneSelectedBeverage = UserPerson.WeeklyMeals[48];
            WednesdayBeverageTwoSelectedBeverage = UserPerson.WeeklyMeals[49];
            WednesdayBeverageThreeSelectedBeverage = UserPerson.WeeklyMeals[50];
            WednesdayBeverageFourSelectedBeverage = UserPerson.WeeklyMeals[51];
            WednesdaySnackOneSelectedSnack = UserPerson.WeeklyMeals[52];
            WednesdaySnackTwoSelectedSnack = UserPerson.WeeklyMeals[53];
            WednesdaySnackThreeSelectedSnack = UserPerson.WeeklyMeals[54];
            WednesdaySnackFourSelectedSnack = UserPerson.WeeklyMeals[55];

            ThursdayBreakfastOneSelectedMeal = UserPerson.WeeklyMeals[56];
            ThursdayBreakfastTwoSelectedMeal = UserPerson.WeeklyMeals[57];
            ThursdayLunchOneSelectedMeal = UserPerson.WeeklyMeals[58];
            ThursdayLunchTwoSelectedMeal = UserPerson.WeeklyMeals[59];
            ThursdayDinnerOneSelectedMeal = UserPerson.WeeklyMeals[60];
            ThursdayDinnerTwoSelectedMeal = UserPerson.WeeklyMeals[61];
            ThursdayBeverageOneSelectedBeverage = UserPerson.WeeklyMeals[62];
            ThursdayBeverageTwoSelectedBeverage = UserPerson.WeeklyMeals[63];
            ThursdayBeverageThreeSelectedBeverage = UserPerson.WeeklyMeals[64];
            ThursdayBeverageFourSelectedBeverage = UserPerson.WeeklyMeals[65];
            ThursdaySnackOneSelectedSnack = UserPerson.WeeklyMeals[66];
            ThursdaySnackTwoSelectedSnack = UserPerson.WeeklyMeals[67];
            ThursdaySnackThreeSelectedSnack = UserPerson.WeeklyMeals[68];
            ThursdaySnackFourSelectedSnack = UserPerson.WeeklyMeals[69];

            FridayBreakfastOneSelectedMeal = UserPerson.WeeklyMeals[70];
            FridayBreakfastTwoSelectedMeal = UserPerson.WeeklyMeals[71];
            FridayLunchOneSelectedMeal = UserPerson.WeeklyMeals[72];
            FridayLunchTwoSelectedMeal = UserPerson.WeeklyMeals[73];
            FridayDinnerOneSelectedMeal = UserPerson.WeeklyMeals[74];
            FridayDinnerTwoSelectedMeal = UserPerson.WeeklyMeals[75];
            FridayBeverageOneSelectedBeverage = UserPerson.WeeklyMeals[76];
            FridayBeverageTwoSelectedBeverage = UserPerson.WeeklyMeals[77];
            FridayBeverageThreeSelectedBeverage = UserPerson.WeeklyMeals[78];
            FridayBeverageFourSelectedBeverage = UserPerson.WeeklyMeals[79];
            FridaySnackOneSelectedSnack = UserPerson.WeeklyMeals[80];
            FridaySnackTwoSelectedSnack = UserPerson.WeeklyMeals[81];
            FridaySnackThreeSelectedSnack = UserPerson.WeeklyMeals[82];
            FridaySnackFourSelectedSnack = UserPerson.WeeklyMeals[83];

            SaturdayBreakfastOneSelectedMeal = UserPerson.WeeklyMeals[84];
            SaturdayBreakfastTwoSelectedMeal = UserPerson.WeeklyMeals[85];
            SaturdayLunchOneSelectedMeal = UserPerson.WeeklyMeals[86];
            SaturdayLunchTwoSelectedMeal = UserPerson.WeeklyMeals[87];
            SaturdayDinnerOneSelectedMeal = UserPerson.WeeklyMeals[88];
            SaturdayDinnerTwoSelectedMeal = UserPerson.WeeklyMeals[89];
            SaturdayBeverageOneSelectedBeverage = UserPerson.WeeklyMeals[90];
            SaturdayBeverageTwoSelectedBeverage = UserPerson.WeeklyMeals[91];
            SaturdayBeverageThreeSelectedBeverage = UserPerson.WeeklyMeals[92];
            SaturdayBeverageFourSelectedBeverage = UserPerson.WeeklyMeals[93];
            SaturdaySnackOneSelectedSnack = UserPerson.WeeklyMeals[94];
            SaturdaySnackTwoSelectedSnack = UserPerson.WeeklyMeals[95];
            SaturdaySnackThreeSelectedSnack = UserPerson.WeeklyMeals[96];
            SaturdaySnackFourSelectedSnack = UserPerson.WeeklyMeals[97];
        }

        public void DeleteMeal()
        {
            if (SelectedMeal != -1)
            {
                MealDatabase.RemoveAt(SelectedMeal);
            }
            else
            {
                MessageBox.Show("Please select a meal to delete.");
            }
        }

        public bool CheckIfCanAddMeal()
        {
            if (string.IsNullOrWhiteSpace(AddMealName) || AddMealIngredients.Count < 1)
            {
                return false;
            }
            return true;
        }

        public void AddMeal()
        {
            if (CheckIfCanAddMeal())
            {
                MealModel newMeal = new MealModel();
                List<IngredientModel> mealIngredients = new List<IngredientModel>();

                foreach (IngredientModel ingredient in AddMealIngredients)
                {
                    mealIngredients.Add(ingredient);
                }

                newMeal.Name = AddMealName;
                newMeal.Ingredients = mealIngredients;
                newMeal.TotalCalories = AddMealTotalCalories;

                MealDatabase.Add(newMeal);
                PopulateMealAndIngredientDatabase();

                AddMealName = "";
                AddMealTotalCalories = 0;
                AddMealIngredients = new ObservableCollection<IngredientModel>();
            }
            else
            {
                MessageBox.Show("Please fill out all fields.");
            }
        }

        public void DeleteMealIngredient()
        {
            if (SelectedMealIngredient != -1)
            {
                AddMealTotalCalories -= AddMealIngredients[SelectedMealIngredient].Calories;
                AddMealIngredients.RemoveAt(SelectedMealIngredient);
            }
            else
            {
                MessageBox.Show("Please select an ingredient to delete.");
            }
        }

        public bool CheckIfCanAddMealIngredient()
        {
            if (AddMealSelectedIngredient > -1)
            {
                return true;
            }
            return false;
        }

        public void AddIngredientToMeal()
        {
            if (CheckIfCanAddMealIngredient())
            {
                IngredientModel selectedIngredient = IngredientDatabase[AddMealSelectedIngredient];
                AddMealIngredients.Add(selectedIngredient);
                AddMealTotalCalories += selectedIngredient.Calories;
            }
            else
            {
                MessageBox.Show("Please select an ingredient in the Combo Box.");
            }

        }

        // For combo boxes using the meal or ingredient databases
        public void PopulateMealAndIngredientDatabase()
        {
            AddMealIngredientDatabase.Clear();
            SundayBreakfastOne.Clear();
            SundayBreakfastTwo.Clear();
            SundayLunchOne.Clear();
            SundayLunchTwo.Clear();
            SundayDinnerOne.Clear();
            SundayDinnerTwo.Clear();
            SundayBeverageOne.Clear();
            SundayBeverageTwo.Clear();
            SundayBeverageThree.Clear();
            SundayBeverageFour.Clear();
            SundaySnackOne.Clear();
            SundaySnackTwo.Clear();
            SundaySnackThree.Clear();
            SundaySnackFour.Clear();

            MondayBreakfastOne.Clear();
            MondayBreakfastTwo.Clear();
            MondayLunchOne.Clear();
            MondayLunchTwo.Clear();
            MondayDinnerOne.Clear();
            MondayDinnerTwo.Clear();
            MondayBeverageOne.Clear();
            MondayBeverageTwo.Clear();
            MondayBeverageThree.Clear();
            MondayBeverageFour.Clear();
            MondaySnackOne.Clear();
            MondaySnackTwo.Clear();
            MondaySnackThree.Clear();
            MondaySnackFour.Clear();

            TuesdayBreakfastOne.Clear();
            TuesdayBreakfastTwo.Clear();
            TuesdayLunchOne.Clear();
            TuesdayLunchTwo.Clear();
            TuesdayDinnerOne.Clear();
            TuesdayDinnerTwo.Clear();
            TuesdayBeverageOne.Clear();
            TuesdayBeverageTwo.Clear();
            TuesdayBeverageThree.Clear();
            TuesdayBeverageFour.Clear();
            TuesdaySnackOne.Clear();
            TuesdaySnackTwo.Clear();
            TuesdaySnackThree.Clear();
            TuesdaySnackFour.Clear();

            WednesdayBreakfastOne.Clear();
            WednesdayBreakfastTwo.Clear();
            WednesdayLunchOne.Clear();
            WednesdayLunchTwo.Clear();
            WednesdayDinnerOne.Clear();
            WednesdayDinnerTwo.Clear();
            WednesdayBeverageOne.Clear();
            WednesdayBeverageTwo.Clear();
            WednesdayBeverageThree.Clear();
            WednesdayBeverageFour.Clear();
            WednesdaySnackOne.Clear();
            WednesdaySnackTwo.Clear();
            WednesdaySnackThree.Clear();
            WednesdaySnackFour.Clear();

            ThursdayBreakfastOne.Clear();
            ThursdayBreakfastTwo.Clear();
            ThursdayLunchOne.Clear();
            ThursdayLunchTwo.Clear();
            ThursdayDinnerOne.Clear();
            ThursdayDinnerTwo.Clear();
            ThursdayBeverageOne.Clear();
            ThursdayBeverageTwo.Clear();
            ThursdayBeverageThree.Clear();
            ThursdayBeverageFour.Clear();
            ThursdaySnackOne.Clear();
            ThursdaySnackTwo.Clear();
            ThursdaySnackThree.Clear();
            ThursdaySnackFour.Clear();

            FridayBreakfastOne.Clear();
            FridayBreakfastTwo.Clear();
            FridayLunchOne.Clear();
            FridayLunchTwo.Clear();
            FridayDinnerOne.Clear();
            FridayDinnerTwo.Clear();
            FridayBeverageOne.Clear();
            FridayBeverageTwo.Clear();
            FridayBeverageThree.Clear();
            FridayBeverageFour.Clear();
            FridaySnackOne.Clear();
            FridaySnackTwo.Clear();
            FridaySnackThree.Clear();
            FridaySnackFour.Clear();

            SaturdayBreakfastOne.Clear();
            SaturdayBreakfastTwo.Clear();
            SaturdayLunchOne.Clear();
            SaturdayLunchTwo.Clear();
            SaturdayDinnerOne.Clear();
            SaturdayDinnerTwo.Clear();
            SaturdayBeverageOne.Clear();
            SaturdayBeverageTwo.Clear();
            SaturdayBeverageThree.Clear();
            SaturdayBeverageFour.Clear();
            SaturdaySnackOne.Clear();
            SaturdaySnackTwo.Clear();
            SaturdaySnackThree.Clear();
            SaturdaySnackFour.Clear();

            foreach (MealModel meal in MealDatabase)
            {
                SundayBreakfastOne.Add(meal.Name + ", " + meal.TotalCalories + " cal.");
                SundayBreakfastTwo.Add(meal.Name + ", " + meal.TotalCalories + " cal.");
                SundayLunchOne.Add(meal.Name + ", " + meal.TotalCalories + " cal.");
                SundayLunchTwo.Add(meal.Name + ", " + meal.TotalCalories + " cal.");
                SundayDinnerOne.Add(meal.Name + ", " + meal.TotalCalories + " cal.");
                SundayDinnerTwo.Add(meal.Name + ", " + meal.TotalCalories + " cal.");

                MondayBreakfastOne.Add(meal.Name + ", " + meal.TotalCalories + " cal.");
                MondayBreakfastTwo.Add(meal.Name + ", " + meal.TotalCalories + " cal.");
                MondayLunchOne.Add(meal.Name + ", " + meal.TotalCalories + " cal.");
                MondayLunchTwo.Add(meal.Name + ", " + meal.TotalCalories + " cal.");
                MondayDinnerOne.Add(meal.Name + ", " + meal.TotalCalories + " cal.");
                MondayDinnerTwo.Add(meal.Name + ", " + meal.TotalCalories + " cal.");

                TuesdayBreakfastOne.Add(meal.Name + ", " + meal.TotalCalories + " cal.");
                TuesdayBreakfastTwo.Add(meal.Name + ", " + meal.TotalCalories + " cal.");
                TuesdayLunchOne.Add(meal.Name + ", " + meal.TotalCalories + " cal.");
                TuesdayLunchTwo.Add(meal.Name + ", " + meal.TotalCalories + " cal.");
                TuesdayDinnerOne.Add(meal.Name + ", " + meal.TotalCalories + " cal.");
                TuesdayDinnerTwo.Add(meal.Name + ", " + meal.TotalCalories + " cal.");

                WednesdayBreakfastOne.Add(meal.Name + ", " + meal.TotalCalories + " cal.");
                WednesdayBreakfastTwo.Add(meal.Name + ", " + meal.TotalCalories + " cal.");
                WednesdayLunchOne.Add(meal.Name + ", " + meal.TotalCalories + " cal.");
                WednesdayLunchTwo.Add(meal.Name + ", " + meal.TotalCalories + " cal.");
                WednesdayDinnerOne.Add(meal.Name + ", " + meal.TotalCalories + " cal.");
                WednesdayDinnerTwo.Add(meal.Name + ", " + meal.TotalCalories + " cal.");

                ThursdayBreakfastOne.Add(meal.Name + ", " + meal.TotalCalories + " cal.");
                ThursdayBreakfastTwo.Add(meal.Name + ", " + meal.TotalCalories + " cal.");
                ThursdayLunchOne.Add(meal.Name + ", " + meal.TotalCalories + " cal.");
                ThursdayLunchTwo.Add(meal.Name + ", " + meal.TotalCalories + " cal.");
                ThursdayDinnerOne.Add(meal.Name + ", " + meal.TotalCalories + " cal.");
                ThursdayDinnerTwo.Add(meal.Name + ", " + meal.TotalCalories + " cal.");

                FridayBreakfastOne.Add(meal.Name + ", " + meal.TotalCalories + " cal.");
                FridayBreakfastTwo.Add(meal.Name + ", " + meal.TotalCalories + " cal.");
                FridayLunchOne.Add(meal.Name + ", " + meal.TotalCalories + " cal.");
                FridayLunchTwo.Add(meal.Name + ", " + meal.TotalCalories + " cal.");
                FridayDinnerOne.Add(meal.Name + ", " + meal.TotalCalories + " cal.");
                FridayDinnerTwo.Add(meal.Name + ", " + meal.TotalCalories + " cal.");

                SaturdayBreakfastOne.Add(meal.Name + ", " + meal.TotalCalories + " cal.");
                SaturdayBreakfastTwo.Add(meal.Name + ", " + meal.TotalCalories + " cal.");
                SaturdayLunchOne.Add(meal.Name + ", " + meal.TotalCalories + " cal.");
                SaturdayLunchTwo.Add(meal.Name + ", " + meal.TotalCalories + " cal.");
                SaturdayDinnerOne.Add(meal.Name + ", " + meal.TotalCalories + " cal.");
                SaturdayDinnerTwo.Add(meal.Name + ", " + meal.TotalCalories + " cal.");
            }

            foreach (IngredientModel ingredient in IngredientDatabase)
            {
                AddMealIngredientDatabase.Add(ingredient.Name);

                SundaySnackOne.Add(ingredient.Amount + " " + ingredient.Unit + " " + ingredient.Name + ", " + ingredient.Calories + " cal.");
                SundaySnackTwo.Add(ingredient.Amount + " " + ingredient.Unit + " " + ingredient.Name + ", " + ingredient.Calories + " cal.");
                SundaySnackThree.Add(ingredient.Amount + " " + ingredient.Unit + " " + ingredient.Name + ", " + ingredient.Calories + " cal.");
                SundaySnackFour.Add(ingredient.Amount + " " + ingredient.Unit + " " + ingredient.Name + ", " + ingredient.Calories + " cal.");

                SundayBeverageOne.Add(ingredient.Amount + " " + ingredient.Unit + " " + ingredient.Name + ", " + ingredient.Calories + " cal.");
                SundayBeverageTwo.Add(ingredient.Amount + " " + ingredient.Unit + " " + ingredient.Name + ", " + ingredient.Calories + " cal.");
                SundayBeverageThree.Add(ingredient.Amount + " " + ingredient.Unit + " " + ingredient.Name + ", " + ingredient.Calories + " cal.");
                SundayBeverageFour.Add(ingredient.Amount + " " + ingredient.Unit + " " + ingredient.Name + ", " + ingredient.Calories + " cal.");

                MondaySnackOne.Add(ingredient.Amount + " " + ingredient.Unit + " " + ingredient.Name + ", " + ingredient.Calories + " cal.");
                MondaySnackTwo.Add(ingredient.Amount + " " + ingredient.Unit + " " + ingredient.Name + ", " + ingredient.Calories + " cal.");
                MondaySnackThree.Add(ingredient.Amount + " " + ingredient.Unit + " " + ingredient.Name + ", " + ingredient.Calories + " cal.");
                MondaySnackFour.Add(ingredient.Amount + " " + ingredient.Unit + " " + ingredient.Name + ", " + ingredient.Calories + " cal.");

                MondayBeverageOne.Add(ingredient.Amount + " " + ingredient.Unit + " " + ingredient.Name + ", " + ingredient.Calories + " cal.");
                MondayBeverageTwo.Add(ingredient.Amount + " " + ingredient.Unit + " " + ingredient.Name + ", " + ingredient.Calories + " cal.");
                MondayBeverageThree.Add(ingredient.Amount + " " + ingredient.Unit + " " + ingredient.Name + ", " + ingredient.Calories + " cal.");
                MondayBeverageFour.Add(ingredient.Amount + " " + ingredient.Unit + " " + ingredient.Name + ", " + ingredient.Calories + " cal.");

                TuesdaySnackOne.Add(ingredient.Amount + " " + ingredient.Unit + " " + ingredient.Name + ", " + ingredient.Calories + " cal.");
                TuesdaySnackTwo.Add(ingredient.Amount + " " + ingredient.Unit + " " + ingredient.Name + ", " + ingredient.Calories + " cal.");
                TuesdaySnackThree.Add(ingredient.Amount + " " + ingredient.Unit + " " + ingredient.Name + ", " + ingredient.Calories + " cal.");
                TuesdaySnackFour.Add(ingredient.Amount + " " + ingredient.Unit + " " + ingredient.Name + ", " + ingredient.Calories + " cal.");

                TuesdayBeverageOne.Add(ingredient.Amount + " " + ingredient.Unit + " " + ingredient.Name + ", " + ingredient.Calories + " cal.");
                TuesdayBeverageTwo.Add(ingredient.Amount + " " + ingredient.Unit + " " + ingredient.Name + ", " + ingredient.Calories + " cal.");
                TuesdayBeverageThree.Add(ingredient.Amount + " " + ingredient.Unit + " " + ingredient.Name + ", " + ingredient.Calories + " cal.");
                TuesdayBeverageFour.Add(ingredient.Amount + " " + ingredient.Unit + " " + ingredient.Name + ", " + ingredient.Calories + " cal.");

                WednesdaySnackOne.Add(ingredient.Amount + " " + ingredient.Unit + " " + ingredient.Name + ", " + ingredient.Calories + " cal.");
                WednesdaySnackTwo.Add(ingredient.Amount + " " + ingredient.Unit + " " + ingredient.Name + ", " + ingredient.Calories + " cal.");
                WednesdaySnackThree.Add(ingredient.Amount + " " + ingredient.Unit + " " + ingredient.Name + ", " + ingredient.Calories + " cal.");
                WednesdaySnackFour.Add(ingredient.Amount + " " + ingredient.Unit + " " + ingredient.Name + ", " + ingredient.Calories + " cal.");

                WednesdayBeverageOne.Add(ingredient.Amount + " " + ingredient.Unit + " " + ingredient.Name + ", " + ingredient.Calories + " cal.");
                WednesdayBeverageTwo.Add(ingredient.Amount + " " + ingredient.Unit + " " + ingredient.Name + ", " + ingredient.Calories + " cal.");
                WednesdayBeverageThree.Add(ingredient.Amount + " " + ingredient.Unit + " " + ingredient.Name + ", " + ingredient.Calories + " cal.");
                WednesdayBeverageFour.Add(ingredient.Amount + " " + ingredient.Unit + " " + ingredient.Name + ", " + ingredient.Calories + " cal.");

                ThursdaySnackOne.Add(ingredient.Amount + " " + ingredient.Unit + " " + ingredient.Name + ", " + ingredient.Calories + " cal.");
                ThursdaySnackTwo.Add(ingredient.Amount + " " + ingredient.Unit + " " + ingredient.Name + ", " + ingredient.Calories + " cal.");
                ThursdaySnackThree.Add(ingredient.Amount + " " + ingredient.Unit + " " + ingredient.Name + ", " + ingredient.Calories + " cal.");
                ThursdaySnackFour.Add(ingredient.Amount + " " + ingredient.Unit + " " + ingredient.Name + ", " + ingredient.Calories + " cal.");

                ThursdayBeverageOne.Add(ingredient.Amount + " " + ingredient.Unit + " " + ingredient.Name + ", " + ingredient.Calories + " cal.");
                ThursdayBeverageTwo.Add(ingredient.Amount + " " + ingredient.Unit + " " + ingredient.Name + ", " + ingredient.Calories + " cal.");
                ThursdayBeverageThree.Add(ingredient.Amount + " " + ingredient.Unit + " " + ingredient.Name + ", " + ingredient.Calories + " cal.");
                ThursdayBeverageFour.Add(ingredient.Amount + " " + ingredient.Unit + " " + ingredient.Name + ", " + ingredient.Calories + " cal.");

                FridaySnackOne.Add(ingredient.Amount + " " + ingredient.Unit + " " + ingredient.Name + ", " + ingredient.Calories + " cal.");
                FridaySnackTwo.Add(ingredient.Amount + " " + ingredient.Unit + " " + ingredient.Name + ", " + ingredient.Calories + " cal.");
                FridaySnackThree.Add(ingredient.Amount + " " + ingredient.Unit + " " + ingredient.Name + ", " + ingredient.Calories + " cal.");
                FridaySnackFour.Add(ingredient.Amount + " " + ingredient.Unit + " " + ingredient.Name + ", " + ingredient.Calories + " cal.");

                FridayBeverageOne.Add(ingredient.Amount + " " + ingredient.Unit + " " + ingredient.Name + ", " + ingredient.Calories + " cal.");
                FridayBeverageTwo.Add(ingredient.Amount + " " + ingredient.Unit + " " + ingredient.Name + ", " + ingredient.Calories + " cal.");
                FridayBeverageThree.Add(ingredient.Amount + " " + ingredient.Unit + " " + ingredient.Name + ", " + ingredient.Calories + " cal.");
                FridayBeverageFour.Add(ingredient.Amount + " " + ingredient.Unit + " " + ingredient.Name + ", " + ingredient.Calories + " cal.");

                SaturdaySnackOne.Add(ingredient.Amount + " " + ingredient.Unit + " " + ingredient.Name + ", " + ingredient.Calories + " cal.");
                SaturdaySnackTwo.Add(ingredient.Amount + " " + ingredient.Unit + " " + ingredient.Name + ", " + ingredient.Calories + " cal.");
                SaturdaySnackThree.Add(ingredient.Amount + " " + ingredient.Unit + " " + ingredient.Name + ", " + ingredient.Calories + " cal.");
                SaturdaySnackFour.Add(ingredient.Amount + " " + ingredient.Unit + " " + ingredient.Name + ", " + ingredient.Calories + " cal.");

                SaturdayBeverageOne.Add(ingredient.Amount + " " + ingredient.Unit + " " + ingredient.Name + ", " + ingredient.Calories + " cal.");
                SaturdayBeverageTwo.Add(ingredient.Amount + " " + ingredient.Unit + " " + ingredient.Name + ", " + ingredient.Calories + " cal.");
                SaturdayBeverageThree.Add(ingredient.Amount + " " + ingredient.Unit + " " + ingredient.Name + ", " + ingredient.Calories + " cal.");
                SaturdayBeverageFour.Add(ingredient.Amount + " " + ingredient.Unit + " " + ingredient.Name + ", " + ingredient.Calories + " cal.");
            }

        }

        public int AddCaloriesOfIngredients(List<IngredientModel> ingredients)
        {
            int totalCalories = 0;

            foreach (IngredientModel ingredient in ingredients)
            {
                totalCalories += ingredient.Calories;
            }

            return totalCalories;
        }

        public bool CheckIfCanAddIngredient()
        {
            if (string.IsNullOrWhiteSpace(AddIngredientName) || string.IsNullOrWhiteSpace(AddIngredientUnit))
            {
                return false;
            }
            return true;
        }

        public void AddIngredient()
        {
            if (CheckIfCanAddIngredient())
            {
                IngredientModel newIngredient = new IngredientModel();
                newIngredient.Name = AddIngredientName;
                newIngredient.Calories = AddIngredientCalories;
                newIngredient.Amount = AddIngredientAmount;
                newIngredient.Unit = AddIngredientUnit;

                IngredientDatabase.Add(newIngredient);
                PopulateMealAndIngredientDatabase();
                //MessageBox.Show(IngredientDatabase[IngredientDatabase.Count - 1].Name + " successfully added!");

                AddIngredientName = "";
                AddIngredientCalories = new int();
                AddIngredientAmount = 0;
            }
            else
            {
                MessageBox.Show("Please fill out all fields.");
            }

        }

        public bool CheckIfCanEditIngredient()
        {
            if (string.IsNullOrWhiteSpace(EditIngredientName) || string.IsNullOrWhiteSpace(EditIngredientUnit))
            {
                return false;
            }
            return true;
        }

        public void EditIngredient()
        {
            if (CheckIfCanEditIngredient())
            {
                IngredientModel ingredient = new IngredientModel
                {
                    Name = EditIngredientName,
                    Calories = EditIngredientCalories,
                    Amount = EditIngredientAmount,
                    Unit = EditIngredientUnit
                };

                IngredientDatabase[SelectedIngredient] = ingredient;
                PopulateMealAndIngredientDatabase();
            }
            else
            {
                MessageBox.Show("Please fill out all fields.");
            }
        }

        public void DeleteIngredient()
        {
            if (SelectedIngredient != -1)
            {
                IngredientDatabase.RemoveAt(SelectedIngredient);
                PopulateMealAndIngredientDatabase();
            }
            else
            {
                MessageBox.Show("Please select an ingredient to delete.");
            }
        }

        // Prevents people with a BMR of less than 1750 to select losing 2 lbs. a week due to extreme fasting
        public void DisplayTwoLbsAWeekRadioButton(PersonModel person)
        {
            if (person.Bmr <= 1750)
            {
                DietPlansTwoLbsAWeekIsVisible = "Hidden";
            }
            else
            {
                DietPlansTwoLbsAWeekIsVisible = "Visible";
            }
        }

        public void AppendZigzagPlanCaloriesToPerson(PersonModel person)
        {
            PersonDailyCalories = new List<int>();
            UserPerson.DailyCalories = new List<int>();

            if (UserPerson.ZigzagPlan == 0)
            {
                PersonDailyCalories.Add(DietPlansZigzagOneSunday);
                PersonDailyCalories.Add(DietPlansZigzagOneMonday);
                PersonDailyCalories.Add(DietPlansZigzagOneTuesday);
                PersonDailyCalories.Add(DietPlansZigzagOneWednesday);
                PersonDailyCalories.Add(DietPlansZigzagOneThursday);
                PersonDailyCalories.Add(DietPlansZigzagOneFriday);
                PersonDailyCalories.Add(DietPlansZigzagOneSaturday);
            }
            else if (UserPerson.ZigzagPlan == 1)
            {
                PersonDailyCalories.Add(DietPlansZigzagTwoSunday);
                PersonDailyCalories.Add(DietPlansZigzagTwoMonday);
                PersonDailyCalories.Add(DietPlansZigzagTwoTuesday);
                PersonDailyCalories.Add(DietPlansZigzagTwoWednesday);
                PersonDailyCalories.Add(DietPlansZigzagTwoThursday);
                PersonDailyCalories.Add(DietPlansZigzagTwoFriday);
                PersonDailyCalories.Add(DietPlansZigzagTwoSaturday);
            }
            else if (UserPerson.ZigzagPlan == 2)
            {
                PersonDailyCalories.Add(DietPlansNoZigzagSunday);
                PersonDailyCalories.Add(DietPlansNoZigzagMonday);
                PersonDailyCalories.Add(DietPlansNoZigzagTuesday);
                PersonDailyCalories.Add(DietPlansNoZigzagWednesday);
                PersonDailyCalories.Add(DietPlansNoZigzagThursday);
                PersonDailyCalories.Add(DietPlansNoZigzagFriday);
                PersonDailyCalories.Add(DietPlansNoZigzagSaturday);
            }

            foreach (int calories in PersonDailyCalories)
            {
                UserPerson.DailyCalories.Add(calories);
            }

            DisplayMealPlannerDailyTotalCalories();
        }

        public void DisplayMealPlannerDailyTotalCalories()
        {
            MealPlannerSundayTotalCalories = UserPerson.DailyCalories[0];
            MealPlannerMondayTotalCalories = UserPerson.DailyCalories[1];
            MealPlannerTuesdayTotalCalories = UserPerson.DailyCalories[2];
            MealPlannerWednesdayTotalCalories = UserPerson.DailyCalories[3];
            MealPlannerThursdayTotalCalories = UserPerson.DailyCalories[4];
            MealPlannerFridayTotalCalories = UserPerson.DailyCalories[5];
            MealPlannerSaturdayTotalCalories = UserPerson.DailyCalories[6];
        }

        public bool CheckIfPoundsPerWeekSelected()
        {
            if (DietPlansHalfLbAWeek || DietPlansOneLbAWeek || DietPlansTwoLbsAWeek)
            {
                return true;
            }
            else
            {
                return false;
            }

        }

        public bool CheckIfCanCalculate()
        {
            bool genderChecked = false;

            if (CalorieCalculatorMale || CalorieCalculatorFemale)
            {
                genderChecked = true;
            }

            if (CalorieCalculatorAge == 0 || CalorieCalculatorHeight == 0 || CalorieCalculatorWeight == 0 || string.IsNullOrWhiteSpace(CalorieCalculatorActivity) || !genderChecked)
            {
                return false;
            }
            else
            {
                return true;
            }
        }

        public void Calculate()
        {
            if (CheckIfCanCalculate())
            {
                UserPerson.Age = CalorieCalculatorAge;
                //UserPerson.Gender = CalorieCalculatorGender;

                if (CalorieCalculatorMale)
                {
                    UserPerson.Gender = "Male";
                }
                else
                {
                    UserPerson.Gender = "Female";
                }

                UserPerson.Height = CalorieCalculatorHeight;
                UserPerson.Weight = CalorieCalculatorWeight;
                UserPerson.Activity = CalorieCalculatorActivity;

                UserPerson.Bmr = CalculateBMR(UserPerson);

                CalculateCalorieCalculatorWeightLossCalories(UserPerson);
                DisplayZigzagPlanTables(UserPerson);
                DisplayTwoLbsAWeekRadioButton(UserPerson);
            }
            else
            {
                MessageBox.Show("Please fill out all fields and try again.");
            }

        }

        public void CalculateCalorieCalculatorWeightLossCalories(PersonModel person)
        {
            CalorieCalculatorMaintainWeight = person.Bmr;
            CalorieCalculatorMildWeightLoss = person.Bmr - 250;
            CalorieCalculatorWeightLoss = person.Bmr - 500;
            CalorieCalculatorExtremeWeightLoss = person.Bmr - 1000;
        }

        public int CalculateBMR(PersonModel person)
        {
            int bmr = 0;

            if (person.Gender == "Male")
            {
                bmr = (int)Math.Floor(10 * (person.Weight * 0.45359237) + 6.25 * (person.Height / 0.39370) - 5 * person.Age + 5);
            }
            else
            {
                bmr = (int)Math.Floor(10 * (person.Weight * 0.45359237) + 6.25 * (person.Height / 0.39370) - 5 * person.Age - 161);
            }

            switch (person.Activity)
            {
                case "Sedentary: little or no exercise":
                    bmr = (int)Math.Ceiling(bmr * 1.2);
                    break;
                case "Light: exercise 1-3 times a week":
                    bmr = (int)Math.Ceiling(bmr * 1.375);
                    break;
                case "Moderate: exercise 4-5 a week":
                    bmr = (int)Math.Ceiling(bmr * 1.465);
                    break;
                case "Active: daily exercise or intense exercise 3-4 times a week":
                    bmr = (int)Math.Ceiling(bmr * 1.55);
                    break;
                case "Very Active: intense exercise 6-7 times a week":
                    bmr = (int)Math.Ceiling(bmr * 1.725);
                    break;
                case "Extra Active: very intense daily exercise or physical job":
                    bmr = (int)Math.Ceiling(bmr * 1.9);
                    break;
            }

            return bmr;
        }
        
        public void ClearFields(int calorieCalculatorAge, int calorieCalculatorHeight, int calorieCalculatorWeight)
        {
            CalorieCalculatorAge = 0;
            CalorieCalculatorHeight = 0;
            CalorieCalculatorWeight = 0;
            CalorieCalculatorGender = "";
            CalorieCalculatorMale = false;
            CalorieCalculatorFemale = false;

            CalorieCalculatorMaintainWeight = 0;
            CalorieCalculatorMildWeightLoss = 0;
            CalorieCalculatorWeightLoss = 0;
            CalorieCalculatorExtremeWeightLoss = 0;
        }

        public void PopulateCalorieCalculatorActivities()
        {
            Activities.Add("Sedentary: little or no exercise");
            Activities.Add("Light: exercise 1-3 times a week");
            Activities.Add("Moderate: exercise 4-5 a week");
            Activities.Add("Active: daily exercise or intense exercise 3-4 times a week");
            Activities.Add("Very Active: intense exercise 6-7 times a week");
            Activities.Add("Extra Active: very intense daily exercise or physical job");
        }

        public void PopulateMealPlannerUnits()
        {
            Units.Add("piece(s)");
            Units.Add("pinch(es)");
            Units.Add("tspn.");
            Units.Add("tbsp.");
            Units.Add("oz.");
            Units.Add("cup(s)");
            Units.Add("pt.");
            Units.Add("qt.");
            Units.Add("gal.");
            Units.Add("g");
            Units.Add("kg");
            Units.Add("lbs.");

            UnitsEdit.Add("piece(s)");
            UnitsEdit.Add("pinch(es)");
            UnitsEdit.Add("tspn.");
            UnitsEdit.Add("tbsp.");
            UnitsEdit.Add("oz.");
            UnitsEdit.Add("cup(s)");
            UnitsEdit.Add("pt.");
            UnitsEdit.Add("qt.");
            UnitsEdit.Add("gal.");
            UnitsEdit.Add("g");
            UnitsEdit.Add("kg");
            UnitsEdit.Add("lbs.");
        }

        private bool SavePersonData(String inFileName, PersonModel inObject)
        {
            try
            {
                FileStream theStream = File.Open(inFileName, FileMode.Create);
                BinaryFormatter theFormatter = new BinaryFormatter();
                theFormatter.Serialize(theStream, inObject);//add it to the end there
                theStream.Dispose();
                theStream.Close();
            }
            catch
            {
                return false;
            }
            return true;

        }

        private PersonModel ReadPersonData(String inFileName)
        {
            PersonModel theReturn = null;
            try
            {
                FileStream theStream = File.Open(inFileName, FileMode.Open, FileAccess.Read);

                BinaryFormatter theFormatter = new BinaryFormatter();
                theReturn = (PersonModel)theFormatter.Deserialize(theStream);//add it to the end there
                theStream.Dispose();
                theStream.Close();
            }
            catch
            {
                return null;
            }
            return theReturn;
        }

        private bool SaveIngredientData(ObservableCollection<IngredientModel> ingredients)
        {
            try
            {
                XmlSerializer xs = new XmlSerializer(typeof(ObservableCollection<IngredientModel>));
                using (StreamWriter wr = new StreamWriter("ingredients.xml"))
                {
                    xs.Serialize(wr, ingredients);
                }
            }
            catch
            {
                return false;
            }
            return true;
        }

        private ObservableCollection<IngredientModel> ReadIngredientData()
        {
            try
            {
                XmlSerializer xs = new XmlSerializer(typeof(ObservableCollection<IngredientModel>));
                using (StreamReader rd = new StreamReader("ingredients.xml"))
                {
                    ObservableCollection<IngredientModel> ingredients = xs.Deserialize(rd) as ObservableCollection<IngredientModel>;
                    return ingredients;
                }
            }
            catch
            {
                return null;
            }
        }

        private bool SaveMealData(ObservableCollection<MealModel> meals)
        {
            try
            {
                XmlSerializer xs = new XmlSerializer(typeof(ObservableCollection<MealModel>));
                using (StreamWriter wr = new StreamWriter("meals.xml"))
                {
                    xs.Serialize(wr, meals);
                }
            }
            catch
            {
                return false;
            }
            return true;
        }

        private ObservableCollection<MealModel> ReadMealData()
        {
            try
            {
                XmlSerializer xs = new XmlSerializer(typeof(ObservableCollection<MealModel>));
                using (StreamReader rd = new StreamReader("meals.xml"))
                {
                    ObservableCollection<MealModel> meals = xs.Deserialize(rd) as ObservableCollection<MealModel>;
                    return meals;
                }
            }
            catch
            {
                return null;
            }
        }

        public void LoadDataOnStartup()
        {
            if (File.Exists("ingredients.xml"))
            {
                IngredientDatabase = ReadIngredientData();
            }
            if (File.Exists("meals.xml"))
            {
                MealDatabase = ReadMealData();
            }
            if (File.Exists("Person"))
            {
                UserPerson = ReadPersonData("Person");
                ReadWeeklyMeals();
                UpdateSundayCurrentCaloriesColor();
            }
            if (UserPerson.Age != 0)
            {
                CalorieCalculatorAge = UserPerson.Age;
                if (UserPerson.Gender == "Male")
                {
                    CalorieCalculatorMale = true;
                }
                else
                {
                    CalorieCalculatorFemale = true;
                }
                CalorieCalculatorHeight = UserPerson.Height;
                CalorieCalculatorWeight = UserPerson.Weight;
                CalorieCalculatorActivity = UserPerson.Activity;

                CalculateCalorieCalculatorWeightLossCalories(UserPerson);
                DisplayDietPlansSelection(UserPerson);
                DisplayZigzagPlanSelection(UserPerson);
                DisplayZigzagPlanTables(UserPerson);
                DisplayTwoLbsAWeekRadioButton(UserPerson);
                DisplayMealPlannerDailyTotalCalories();
            }
        }

        public void DisplayZigzagPlanTables(PersonModel person)
        {
            int bmr = person.Bmr;

            int caloriesToLose = 0;
            int zzTwoFactor = 1;

            switch (person.LbsPerWeek)
            {
                case 0.5:
                    caloriesToLose = 1750;
                    zzTwoFactor = 500;
                    break;
                case 1.0:
                    caloriesToLose = 3500;
                    zzTwoFactor = 100;
                    break;
                case 2.0:
                    caloriesToLose = 7000;
                    zzTwoFactor = 2000;
                    break;
            }

            // Calculations for Zigzag Plan 1
            // Zigzag Plan 1:
            // Saturday-Sunday = # of calories to maintain weight (aka the BMR)
            // Monday-Friday = Lower # of calories to lose weight
            int zzOneWeekdayCalories = bmr - (caloriesToLose / 5);
            int zzOneMaxCalories = bmr;
            int leftovers = 0;

            // If the calories you'd be eating on weekdays are less than 1500, change your weekend calories to 1500
            // and add those removed weekend calories to the weekday values.
            // Ex.       Calories on weekend days = 2000, and calories on weekdays = 1000.
            // Change to calories on weekend days = 1500, and calories on weekdays = 1200. 
            if (zzOneWeekdayCalories < 1400)
            {
                zzOneMaxCalories = 1500;
                leftovers = (bmr - 1500) * 2;
                zzOneWeekdayCalories = bmr - (caloriesToLose / 5) + (leftovers / 5);
            }

            // Create an array for the calories signifying each day.
            // 0 = Sun., 6 = Sat.
            int[] zzOneDailyCalories = new int[7];

            for (int i = 0; i < zzOneDailyCalories.Length; i++)
            {
                if (i == 0 || i == 6)
                {
                    zzOneDailyCalories[i] = zzOneMaxCalories;
                }
                else
                {
                    zzOneDailyCalories[i] = zzOneWeekdayCalories;
                }
            }

            // Display the values on the Diet Plans screen 
            DietPlansZigzagOneSunday = zzOneDailyCalories[0];
            DietPlansZigzagOneMonday = zzOneDailyCalories[1];
            DietPlansZigzagOneTuesday = zzOneDailyCalories[2];
            DietPlansZigzagOneWednesday = zzOneDailyCalories[3];
            DietPlansZigzagOneThursday = zzOneDailyCalories[4];
            DietPlansZigzagOneFriday = zzOneDailyCalories[5];
            DietPlansZigzagOneSaturday = zzOneDailyCalories[6];

            // Calculations for Zigzag Plan 2
            int[] zzTwoDailyCalories = new int[7];
            int currentCalories = bmr;
            int highestCaloriesForTheWeek = bmr;

            // Sunday
            if (zzTwoFactor == 2000 && (bmr - 2000) < 1500)
            {
                zzTwoDailyCalories[0] = 1500;
                highestCaloriesForTheWeek = bmr - (1500 - (bmr - 2000));
                currentCalories = zzTwoDailyCalories[0];
            }
            else
            {
                zzTwoDailyCalories[0] = bmr - zzTwoFactor;
                currentCalories = zzTwoDailyCalories[0];
            }

            // Monday - Tuesday
            int add = (int)(Math.Ceiling((double)(highestCaloriesForTheWeek - zzTwoDailyCalories[0]) / 3));

            for (int i = 1; i < 3; i++)
            {
                zzTwoDailyCalories[i] = currentCalories + add;
                currentCalories += add;
            }
            // Wednesday
            zzTwoDailyCalories[3] = highestCaloriesForTheWeek;
            currentCalories = highestCaloriesForTheWeek;

            // Thursday - Saturday
            add = (int)(Math.Ceiling((double)(highestCaloriesForTheWeek - zzTwoDailyCalories[0]) / 4));

            for (int i = 4; i < zzTwoDailyCalories.Length; i++)
            {
                zzTwoDailyCalories[i] = currentCalories - add;
                currentCalories -= add;
            }

            // Display the values on the Diet Plans screen 
            DietPlansZigzagTwoSunday = zzTwoDailyCalories[0];
            DietPlansZigzagTwoMonday = zzTwoDailyCalories[1];
            DietPlansZigzagTwoTuesday = zzTwoDailyCalories[2];
            DietPlansZigzagTwoWednesday = zzTwoDailyCalories[3];
            DietPlansZigzagTwoThursday = zzTwoDailyCalories[4];
            DietPlansZigzagTwoFriday = zzTwoDailyCalories[5];
            DietPlansZigzagTwoSaturday = zzTwoDailyCalories[6];

            // Calculations for No Zigzag Plan
            int noZZCalories = bmr - (caloriesToLose / 7);

            // Display the values on the Diet Plans screen 
            DietPlansNoZigzagSunday = noZZCalories;
            DietPlansNoZigzagMonday = noZZCalories;
            DietPlansNoZigzagTuesday = noZZCalories;
            DietPlansNoZigzagWednesday = noZZCalories;
            DietPlansNoZigzagThursday = noZZCalories;
            DietPlansNoZigzagFriday = noZZCalories;
            DietPlansNoZigzagSaturday = noZZCalories;
            /////////////////////////////////////////////////////////////////////////////////////////////////////////////
            // Apply all the calorie numbers to their respective local arrays
            for (int i = 0; i < 7; i++)
            {
                //zzPlanOneCalories[i] = zzOneDailyCalories[i];
                //zzPlanTwoCalories[i] = zzTwoDailyCalories[i];
                //NoZzPlanCalories[i] = noZZCalories;
            }
        }

        public void DisplayDietPlansSelection(PersonModel person)
        {
            switch (person.LbsPerWeek)
            {
                case 0.5:
                    DietPlansHalfLbAWeek = true;
                    break;
                case 1.0:
                    DietPlansOneLbAWeek = true;
                    break;
                case 2.0:
                    DietPlansTwoLbsAWeek = true;
                    break;
            }
        }

        public void DisplayZigzagPlanSelection(PersonModel person)
        {
            switch (person.ZigzagPlan)
            {
                case 0:
                    DietPlansZigzagPlanOne = true;
                    break;
                case 1:
                    DietPlansZigzagPlanTwo = true;
                    break;
                case 2:
                    DietPlansNoZigzagPlan = true;
                    break;
            }
        }

        public void CalorieCalculatorContinue()
        {
            if (UserPerson.Bmr != 0)
            {
                MainTabControl = 1;
            }
            else
            {
                MessageBox.Show("Please calculate your calories before continuing.");
            }
        }

        public void DietPlansContinue()
        {
            if (UserPerson.Bmr != 0)
            {
                MainTabControl = 2;
            }
            else
            {
                MessageBox.Show("Please calculate your calories before continuing.");
            }
        }

        // When the window is closed, save Person data
        protected override void OnDeactivate(bool close)
        {
            SaveWeeklyMealsToPerson();
            SavePersonData("Person", UserPerson);
            SaveIngredientData(IngredientDatabase);
            SaveMealData(MealDatabase);
            base.OnDeactivate(close);
        }

        // Convert a string into an int
        public static int GetNumber(string arg)
        {
            int number = Int32.Parse(arg);
            return number;
        }
    }
}
