using System;

namespace Calculator
{
    public class Calculator
    {
        public int add(string input)
        {
            var splitter = new Char[] {',', '\n'};

            if (input.Length == 0) return 0;
            if ((input.StartsWith(",") || input.StartsWith("\n")) && input.Length == 1) return 0;
            if (input.Length == 1) return Int32.Parse(input);
            if(input.StartsWith("//"))
            {
                splitter = input.Substring(2, 1).ToCharArray();
                input = input.Substring(3);
            }
            string[] values = input.Split(splitter);
            if (splitter.Contains('-')) 
            {
                if (input.Contains("--")) throw new ArgumentException("negatives not allowed");
            }
            int sum = values
                .Select(x => x.Trim())
                .Select(x => x == "" ? 0 : Int32.Parse(x))
                .Where(x => x<1001)
                .Select(x => x >= 0 ? x : throw new ArgumentException("negatives not allowed"))
                .Aggregate(0, (x, y) => x + y);

            return sum;
        }
    }
}
