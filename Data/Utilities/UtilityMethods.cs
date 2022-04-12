using System;
using System.Collections.Generic;
using System.Text;

namespace Data.Utilities
{
    public class UtilityMethods
    {
        public static int DisplayMenuAndGetUserChoice (string [] menuOptions)
        {
            while (true)
            {
                Console.Clear();
                for (var idx = 0; idx < menuOptions.Length; idx++)
                {
                    Console.WriteLine($"{idx + 1}. {menuOptions[idx]}");
                }
                bool isValidInput = int.TryParse(Console.ReadLine(), out int choice);
                if(isValidInput && choice > 0 && choice < menuOptions.Length + 1)
                {
                    return choice;
                }
            }
        }
    }
}