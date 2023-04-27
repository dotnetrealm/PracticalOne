namespace Calculator
{
    internal class Program
    {
        static void Main(string[] args)
        {
            double num1 = 0, num2 = 0;

            Console.Write("Please enter first number: ");
            while (!Double.TryParse(Console.ReadLine(), out num1))
            {
                Program.PrintError("[ERROR]: Value must numberic\n");
                Console.Write("Please enter first number: ");
            }

            Console.Write("Please enter secound number: ");
            while (!Double.TryParse(Console.ReadLine(), out num2) || num1.ToString().Length > 25)
            {
                Program.PrintError("[ERROR]: Value must numberic\n");
                Console.Write("Please enter secound number: ");
            }
            Console.WriteLine();
            Calculate(num1, num2);
            Console.ReadKey();
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
                div = Math.Round(num1 / num2, 4);
            }
            catch (DivideByZeroException)
            {
                Program.PrintError("[Exception]: Can't divide first number by zero(0).");
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
    }
}