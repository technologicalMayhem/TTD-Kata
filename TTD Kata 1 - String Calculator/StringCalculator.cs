using System;
using System.Linq;

namespace TTD_Kata
{
    public static class StringCalculator
    {
        public static int Add(string numbers)
        {
            var delimiters = new[]
            {
                ",", "\n"
            };
            if (numbers == string.Empty) return 0;
            if (numbers.StartsWith("//"))
            {
                numbers = numbers.Remove(0, 2);
                var parts = numbers.Split(@"\n");
                delimiters = parts[0].Split(new string[] {"][", "[", "]"}, StringSplitOptions.RemoveEmptyEntries)
                    .ToArray();
                numbers = parts[1];
            }

            var nums = numbers.Split(delimiters, StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();

            var negatives = nums.Where(i => i < 0).ToArray();
            if (negatives.Any())
                throw new InvalidOperationException($"Negatives not allowed: {string.Join(',', negatives)}");

            return nums.Where(i => i <= 1000).Sum();
        }
    }
}