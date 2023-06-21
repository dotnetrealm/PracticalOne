namespace Calculator
{
    public static class Program
    {
        public static void Main(string[] args)
        {
            do
            {
                double num1 = 0, num2 = 0;

                #region User Inputs
                Console.Write("\n\nPlease enter first number: ");
                while (!Double.TryParse(Console.ReadLine(), out num1))
                {
                    PrintError("[ERROR]: first number must numberic\n");
                    Console.Write("Please enter first number: ");
                }
                Console.Write("Please enter second number: ");
                while (!Double.TryParse(Console.ReadLine(), out num2) || num1.ToString().Length > 25)
                {
                    PrintError("[ERROR]: second number must numberic\n");
                    Console.Write("Please enter second number: ");
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
        public static void Calculate(double num1, double num2)
        {
            ResultSet res = new ResultSet();
            res.Add = num1 + num2;
            res.Sub = num1 - num2;
            res.Mul = num1 * num2;

            try
            {
                if (num2 == 0) throw new DivideByZeroException();
                res.Div = num1 / num2;
            }
            catch (DivideByZeroException)
            {
                PrintError($"[Exception]: Can't divide {num1} by zero(0).");
            }
            PrintData(res, num1, num2);
        }
        public static void PrintData(ResultSet data, double num1, double num2)
        {
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("=======================================");
            Console.WriteLine($"\t\tResult");
            Console.WriteLine("=======================================");
            Console.WriteLine($" {num1} + {num2} = {data.Add}");
            Console.WriteLine($" {num1} - {num2} = {data.Sub}");
            Console.WriteLine($" {num1} * {num2} = {data.Mul}");
            Console.WriteLine($" {num1} / {num2} = {data.Div}");
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