using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MealPlanner.Models
{
    public class MealModel
    {
        public string Name { get; set; }
        public List<IngredientModel> Ingredients { get; set; }
        public int TotalCalories { get; set; }
    }
}
