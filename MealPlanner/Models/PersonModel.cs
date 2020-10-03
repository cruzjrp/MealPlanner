using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MealPlanner.Models
{
    [Serializable]
    public class PersonModel
    {
        public int Age { get; set; }
        public string Gender { get; set; }
        public int Height { get; set; }
        public int Weight { get; set; }
        public string Activity { get; set; }
        public int Bmr { get; set; }
        public double LbsPerWeek { get; set; }
        public int ZigzagPlan { get; set; }
        public List<int> DailyCalories { get; set; }
        public List<int> WeeklyMeals { get; set; }
    }
}
