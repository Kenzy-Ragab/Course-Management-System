using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CourseManagementSystem.Screens.Reports
{
    public static class ReportPrinter
    {
        // Generic method to display report with header and empty data check
        public static void ShowReport<T>(string header, Func<IEnumerable<T>> getDate, Action<IEnumerable<T>> render)
        {

            Console.Clear();
            Console.WriteLine("┌───────────────────────────────────────┐");
            Console.WriteLine($"│        {header.PadRight(31)}│");
            Console.WriteLine("└───────────────────────────────────────┘");

            try
            {
                // call Function
                var data = getDate.Invoke();

                // check
                if (data == null || !data.Any())
                {
                    Console.WriteLine("\n\t\tNo data found!\n");
                    return;
                }

                //print each method with their own render
                render(data);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"\n\nError: {ex.Message}");
            }
        }
    }
}
