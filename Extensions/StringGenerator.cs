using System;
using System.Collections.Generic;
using System.Linq;

namespace Extensions
{
    public static class StringGenerator
    {
        private static readonly Random Random = new Random();

        public static string RandomString(int maxLenght)
        {
            var min = (maxLenght/3);
            var len = new Random(Random.Next()).Next(min, maxLenght);

            var lst = Generate().Take(len).ToList();

            var str = string.Join(string.Empty, lst);
            return str;
        }

        private static IEnumerable<char> Generate()
        {
            while (true)
            {
                yield return Convert.ToChar(Convert.ToInt32(Math.Floor(26 * new Random(Random.Next()).NextDouble() + 65)));
            }
        }
    }
}