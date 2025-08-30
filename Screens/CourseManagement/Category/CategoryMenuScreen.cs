using CourseManagementSystem.Helper;
using CourseManagementSystem.Helpers;
using CourseManagementSystem.Models;
using CourseManagementSystem.Screens.Course;
using CourseManagementSystem.Screens.Instructor;
using CourseManagementSystem.Services;
using System;
using System.Diagnostics;


namespace CourseManagementSystem.Screens.Category
{
    public static class CategoryMenuScreen
    {
        public static void Show(CategoryService categoryServices, InstructorService instructorService, CourseService courseService)
        {
            while (true)
            {
                // menu
                ConsoleUIHelper.ShowMenu("CATEGORY MENU", new List<string>
                {
                    "Add Category",
                    "View Categories",
                    "Main Menu"
                });

                var choice = InputHelper.ReadIntNumberBetween(1, 3).ToString();

                // options
                switch (choice)
                {
                    case "1":
                        Console.WriteLine("\n\n[1] Add Category only, OR [2] Add Category and Instructor right away");
                        Console.Write("\n Select an option: ");
                        var cateChoice = InputHelper.ReadIntNumberBetween(1, 2).ToString();

                        switch(cateChoice)
                        {
                            case "1": AddCategoryScreen.Show(categoryServices); break;
                            case "2":
                                var categotyId = AddCategoryScreen.Show(categoryServices);
                                // After adding category -> Move to Add Instructor Screen
                                Console.WriteLine("\n\nNow let's add Instructor for this category...");
                                Console.ReadKey();
                                AddInstructorScreen.Show(categoryServices, instructorService, courseService, categotyId);
                                break;
                        }
                        break;

                    case "2":
                        ViewCategoriesScreen.Show(categoryServices);
                        // After view category -> Move to Instructor Menu Screen
                        Console.WriteLine("\n\nYou can now manage Instructors in these categories...");
                        Console.ReadKey();
                        InstructorMenuScreen.Show(categoryServices, instructorService, courseService);
                        break;

                    case "3": return;
                }

                Console.WriteLine("\nPress any key to return to Category Menu Screen...");
                Console.ReadKey();
            }
        }
    }
}
