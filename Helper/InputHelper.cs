using System;

namespace CourseManagementSystem.Helpers
{
    public static class InputHelper
    {
        public static int ReadInt(string prompotMessage = "", string invalidInputMessage = "Invalid Number, Enter again:\n")
        {
            Console.Write(prompotMessage);

            int Num = 0;
            while (!int.TryParse(Console.ReadLine(), out Num))
                Console.WriteLine(invalidInputMessage);

            return Num;
        }
        public static bool IsNumberBetween(int num, int from, int to)
        {
            return !(num < from || num > to);
        }
        public static int ReadIntNumberBetween(int from, int to, string outOfRangeMessage = "Number is not within range, enter again:\n")
        {
            int Num = ReadInt();
            while (!IsNumberBetween(Num, from, to))
            {
                Console.WriteLine(outOfRangeMessage);
                Num = ReadInt();
            }
            return Num;
        }

        public static decimal ReadDecimal(string prompotMessage = "", string invalidInputMessage = "Invalid Number, Enter again:\n")
        {
            Console.Write(prompotMessage);

            decimal Num = 0;
            while (!decimal.TryParse(Console.ReadLine(), out Num))
                Console.WriteLine(invalidInputMessage);

            return Num;
        }

        public static string ReadString(string prompotMessage = "", string InvalidInputMessage = "Invalid String, Enter again:\n")
        {
            Console.Write(prompotMessage);
            string? input = Console.ReadLine();

            while (int.TryParse(input, out _))
            {
                Console.WriteLine(InvalidInputMessage);
                Console.Write(prompotMessage);
                input = Console.ReadLine();
            }
            return input ?? "";
        }
    }
}

