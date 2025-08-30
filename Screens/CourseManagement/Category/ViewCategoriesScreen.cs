using CourseManagementSystem.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CourseManagementSystem.Screens.Category
{
    public static class ViewCategoriesScreen
    {
        public static void Show(CategoryService categoryServices)
        {
            Console.Clear();
            Console.WriteLine("┌────┬────────────────────────────────┐");
            Console.WriteLine("│ ID │          Name                  │");
            Console.WriteLine("├────┼────────────────────────────────┤");

            var categories = categoryServices.GetAll();
            if (categories.Count == 0)
            {
                Console.WriteLine("│         No categories found!        │");
                Console.WriteLine("└────┴────────────────────────────────┘");
                return;
            }

            foreach (var category in categories)
            {
                Console.WriteLine(
                    $"│ {category.Id.ToString().PadLeft(2)} " +
                    $"│ {category.Name.PadRight(31)}│"
                );
            }

            Console.WriteLine("└────┴────────────────────────────────┘");
        }
    }
}
