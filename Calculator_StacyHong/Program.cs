using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Calculator_StacyHong
{
    class Program
    {
        static void Main(string[] args)
        {
            //I set it as false if the user only inputs one argument. This is to support the negative functionality.            
            var allowNegatives = false;

            //To account for if there are more than one argument and to support the negative functionality.
            if (args.Length > 1)
            {
                allowNegatives = Convert.ToBoolean(args[1]);
            }

            var calculate = new Calculator();
            calculate.Add(args[0], allowNegatives);

        }
    }
}
