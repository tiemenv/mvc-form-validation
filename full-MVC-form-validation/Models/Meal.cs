using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace fullMVCformvalidation.Models
{
public enum MealType
{
    Breakfast,
    Lunch,
    Dinner
}
    public class Meal
{
        [Required]
    public int Id { get; set; }

        [Display(Name = "Meal")]
        [Required(ErrorMessage = "Please enter a description")]
    public string Name { get; set; }

        [Display(Name = "Type of meal")]
    public MealType Type { get; set; }

        [Required]
        [Range(typeof(decimal), "5", "150", ErrorMessage = "Please enter a value between {1} and {2} for {0}")]
    public decimal Price { get; set; }

        public List<SelectListItem> TypeList()
        {
            List<SelectListItem> mealTypes = new List<SelectListItem>();
            foreach (string type in Enum.GetNames(typeof(MealType)))
            {
                mealTypes.Add(new SelectListItem() { Text = type, Value = type });
            }
            return mealTypes;
        }
}

}
