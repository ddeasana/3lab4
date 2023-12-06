using System.Text.RegularExpressions;
namespace console
{
    public class Program
    {
        static void Main(string[] args)
        {
            // normal method
            DigitAmountDelegate DigitAmount = DigitAmountMethod;
            double NormalTest = DigitAmount("12345abcde");
            Console.WriteLine(NormalTest + " - digits");

            // anonymous
            DigitAmount = delegate (string input)
            {
                double counts;
                counts = Regex.Matches(input, @"\d").Count;
                return counts;
            };
            double AnonymousNest = DigitAmount("12345abcde");
            Console.WriteLine(AnonymousNest + " - digits");

            // lambda
            DigitAmount = (input) =>
            {
                double counts;
                counts = Regex.Matches(input, @"\d").Count;
                return counts;
            };
            double LambdaTest = DigitAmount("12345abcde");
            Console.WriteLine(LambdaTest + " - digits");

            Stack stack = new Stack();
            stack.StackEvent += StackClearingHandler;

            stack.Push(2);
            stack.Push(3);
            stack.Pop();
            stack.Clear();
            
        }

        public delegate double DigitAmountDelegate(string input);
        public static double DigitAmountMethod(string input)
        {
            double counts;
            counts = Regex.Matches(input, @"\d").Count;
            return counts;
        }
        public static void StackClearingHandler(object sender, StackEventArgs eventArgs)
        {
            Console.WriteLine($"Stack event:{eventArgs.EventMessage}");
        }

        

    }
}