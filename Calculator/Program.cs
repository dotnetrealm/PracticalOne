namespace Calculator
{
    internal static class Program
    {
        static void Main(string[] args)
        {
            do
            {
                double num1 = 0, num2 = 0;

                #region User Inputs
                Console.Write("\n\nPlease enter first number: ");
                while (!Double.TryParse(Console.ReadLine(), out num1))
                {
                    PrintError("[ERROR]: Value-1 must numberic\n");
                    Console.Write("Please enter first number: ");
                }
                Console.Write("Please enter second number: ");
                while (!Double.TryParse(Console.ReadLine(), out num2) || num1.ToString().Length > 25)
                {
                    PrintError("[ERROR]: Value-2 must numberic\n");
                    Console.Write("Please enter secound number: ");
                }
                Console.WriteLine();
                #endregion User Inputs

                Calculate(num1, num2);

                Console.Write("\nDo you want to repeat again?(y/n): ");
            } while (Console.ReadKey().KeyChar.ToString().ToLower() == "y");

            #region Appreciations
            PrintSuccess("\n\n*********************");
            PrintSuccess("Thank you! \nPress any key to exit..");
            PrintSuccess("*********************");
            Console.ReadKey();
            #endregion Appreciations

        }
        static void Calculate(double num1, double num2)
        {
            double add = num1 + num2;
            double sub = num1 - num2;
            double mul = num1 * num2;
            double div = 0;

            try
            {
                if (num2 == 0) throw new DivideByZeroException();
                div = num1 / num2;
            }
            catch (DivideByZeroException)
            {
                PrintError($"[Exception]: Can't divide {num1} by zero(0).");
            }

            PrintData((add, sub, mul, div), num1, num2);

        }
        static void PrintData((double add, double sub, double mul, double div) data, double num1, double num2)
        {
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("=======================================");
            Console.WriteLine($"\t\tResult");
            Console.WriteLine("=======================================");
            Console.WriteLine($" {num1} + {num2} = {data.add}");
            Console.WriteLine($" {num1} - {num2} = {data.sub}");
            Console.WriteLine($" {num1} * {num2} = {data.mul}");
            Console.WriteLine($" {num1} / {num2} = {data.div}");
            Console.WriteLine("=======================================");
            Console.ForegroundColor = ConsoleColor.White;
        }
        public static void PrintError(string err)
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine(err);
            Console.ForegroundColor = ConsoleColor.White;
        }
        public static void PrintSuccess(string err)
        {
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine(err);
            Console.ForegroundColor = ConsoleColor.White;
        }
    }
}