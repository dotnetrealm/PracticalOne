namespace DebuggingApplication
{
    public class Program
    {
        public static void Main(string[] args)
        {
            Console.Write("Enter string: ");
            string userResponse = Console.ReadLine()!;

            if (Convert.ToBoolean(int.Parse(userResponse)))
            {
                Console.WriteLine("The entered value is a integer");
            }
            Console.ReadKey();
        }
    }
}