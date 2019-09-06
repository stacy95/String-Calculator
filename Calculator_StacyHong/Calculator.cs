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
        private readonly string _customDelimiterStartsWith = "//";

        public int Add(string value)
        {
            if (String.IsNullOrEmpty(value)) return 0;

            else if (value.StartsWith(_customDelimiterStartsWith, StringComparison.InvariantCultureIgnoreCase))
            {
                GetCustomDelimiter(value);

                //Setting the value without the custom delimiters that are appended
                value = value.Substring(value.IndexOf('\n') + 1);
            }

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
            //if (convertedToIntList.Count() > 2)
            //{
            //    Console.WriteLine("We do not support more than two numbers.");
            //    return 0;
            //}

            var negativeNumbers = convertedToIntList.Where(num => num < 0).ToList();

            //If negative and allowNegatives is false throw exception 
            if (negativeNumbers.Count > 0)
            {
                var listOfNegativeNumbers = string.Join(",", negativeNumbers);
                throw new ArgumentException($"These negatives: {listOfNegativeNumbers} are not allowed.");
            }

            foreach (var number in convertedToIntList)
            {
                //Ignore any numbers greater than 1000 and set as 0.
                if (number > 1000) total += 0;

                else
                {
                    total += number;
                }
            }
            return total;
        }

        private void GetCustomDelimiter(string value)
        {
            var firstIndex = 2;
            var lastIndex = value.IndexOf('\n');
            var subStringedDelimiters = value.Substring(firstIndex, lastIndex - firstIndex);

            //If Statement to support customer delimiter of any length and support multiple delimiters of any length
            if (value.StartsWith($"{_customDelimiterStartsWith}[", StringComparison.InvariantCultureIgnoreCase))
            {
                var customDelimiters = subStringedDelimiters.Split('[').Select(endsWith => endsWith.TrimEnd(']')).ToList();
                customDelimiters.Remove(string.Empty);
                _listOfDelimiters.AddRange(customDelimiters);
            }

            //Support one custom delimiter of one character length
            else _listOfDelimiters.Add(value.Substring(firstIndex, lastIndex - firstIndex));
        }

    }
}
