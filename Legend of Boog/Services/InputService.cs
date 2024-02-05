using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Legend_of_Boog.Services
{
    public class InputService
    {
        public void Continue()
        {
            Console.Write("Type (E) to Continue\n");
            Console.Write(":");

            var input = Console.ReadLine();

            while (!ValidateInput(input ?? "", inputMatcher: "e"))
            {
                Console.Clear();
                UIService.Header();
                Console.Write("Type (E) to Continue\n");
                Console.Write(":");
                input = Console.ReadLine();
            }

            Console.Clear();
        }

        public static bool ValidateInput(string input, int minLength = 1, int maxLength = 999, string inputMatcher = "", bool intCheck = false)
        {
            if (input.Length > maxLength || input.Length < minLength)
            {
                return false;
            }

            if (inputMatcher != "" && input.ToLower() != inputMatcher.ToLower())
            {
                return false;
            }

            if (intCheck && int.TryParse(input, out int trash))
            {
                return false;
            }

            return true;
        }

    }
}
