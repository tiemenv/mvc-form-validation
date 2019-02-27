using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using fullMVCformvalidation.Models;
using Newtonsoft.Json;
using Microsoft.AspNetCore.Http;
using System.Diagnostics;

namespace full_MVC_form_validation.Controllers
{
    public class MealsController : Controller
    {
        private List<Meal> meals;
        public MealsController()
        {
            meals = new List<Meal>
            {
                new Meal
                {
                    Id = 1,
                    Type = MealType.Breakfast,
                    Name = "Full Irish Breakfast",
                    Price = 8.50m

                },
                new Meal
                {
                    Id = 2,
                    Type = MealType.Dinner,
                    Name = "Chicken Dinner",
                    Price = 15.50m
                }
            };
        }
        public ViewResult Index()
        {
            return View(GetMeals());
        }
        [HttpGet]
        public ViewResult Create()
        {
            return View(new Meal { Type = MealType.Breakfast });
        }

        [HttpPost]
        public IActionResult Create(Meal newMeal)
        {
            if(newMeal.Name == "test")
            {
                ModelState.AddModelError("Extra", "Please enter a valid name");
            }

            if (ModelState.IsValid)
            {


                meals = GetMeals().ToList();
                meals.Add(newMeal);
                HttpContext.Session.SetString("meals", JsonConvert.SerializeObject(meals));

                return View("Finish", newMeal);
            }
            return View(newMeal);
        }

        #region Private Methods
        private IEnumerable<Meal> GetMeals()
        {
            if (!string.IsNullOrEmpty(HttpContext.Session.GetString("meals")))
            {
                return JsonConvert.DeserializeObject<List<Meal>>(HttpContext.Session.GetString("meals"));
            }

            return meals;
        }
        #endregion
    }
}