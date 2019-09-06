using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Calculator_StacyHong
{
   public class Calculator
    {
        private readonly List<string> _listOfDelimiters = new List<string>() { ",", "\n" };

        public int Add(string value)
        {
            if (String.IsNullOrEmpty(value)) return 0;
            
            return AddOperator(value);
        }

        private int AddOperator(string value)
        {
            int total = 0;
            string[] arrayOfNumbers = value.Split(_listOfDelimiters.ToArray(), StringSplitOptions.None);

            //Invalid/Missing Numbers will be converted as 0.
            var tryParseResult = 0;
            var convertedToIntList = arrayOfNumbers.Select(num => int.TryParse(num, out tryParseResult)).Select(res => tryParseResult).ToList();

            //To support step one where we can only have a maximum of 2 numbers.
            if (convertedToIntList.Count() > 2)
            {
                Console.WriteLine("We do not support more than two numbers.");
                return 0;
            }

            else
            {
                foreach (var number in convertedToIntList)
                {
                    total += number;
                }

                return total;
            }
        }
    }
}
