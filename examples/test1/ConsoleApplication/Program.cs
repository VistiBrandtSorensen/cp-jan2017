using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ConsoleApplication
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var calculator = new Calculator();
            // calculator.Add(2);
            // calculator.Add(8); // 10
            // calculator.Multiply(2); // 20
            // calculator.Divide(4); // 5
            // calculator.Minus(3); // 2

            string operation = "+";
            do
            {
                Console.WriteLine("Indtast et tal: ");
                string numberText = Console.ReadLine();
                int number = int.Parse(numberText);

                if (operation == "+")
                {
                    calculator.Add(number);
                }
                else if (operation == "-")
                {
                    calculator.Minus(number);
                }
                else if (operation == "*")
                {
                    calculator.Multiply(number);
                }
                else if (operation == "/")
                {
                    calculator.Divide(number);
                }
                else if (operation == "=")
                {
                    break;
                }
                else
                {
                    Console.WriteLine("Ugyldig operation");
                }

                Console.WriteLine("Indtast +, -, *, /, =");
                operation = Console.ReadLine();
                if (operation != "+" || operation != "-" || operation != "*" || operation != "/" || operation != "=")
                {
                    Console.WriteLine("Ugyldig operation");
                }
            } while(operation != "=");


            int resultat = calculator.Resultat();

            Console.Write("Resultat: ");
            Console.WriteLine(resultat);
        }
    }
}
