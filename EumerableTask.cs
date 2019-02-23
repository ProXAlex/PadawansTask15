using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace PadawansTask15
{
    public class EnumerableTask
    {
        /// <summary> Transforms all strings to upper case.</summary>
        /// <param name="data">Source string sequence.</param>
        /// <returns>
        ///   Returns sequence of source strings in uppercase.
        /// </returns>
        /// <example>
        ///    {"a", "b", "c"} => { "A", "B", "C" }
        ///    { "A", "B", "C" } => { "A", "B", "C" }
        ///    { "a", "A", "", null } => { "A", "A", "", null }
        /// </example>
        public IEnumerable<string> GetUppercaseStrings(IEnumerable<string> data)
        {
            if (data == null)
                throw new ArgumentNullException();
            if (!data.Any())
                throw new ArgumentException();

            //Use LINQ
            return data.Select(s => s?.ToUpper());

            List<string> result = new List<string>();
            foreach (string item in data)
            {
                result.Add(item?.ToUpper());
            }

            return result;
        }

        /// <summary> Transforms an each string from sequence to its length.</summary>
        /// <param name="data">Source strings sequence.</param>
        /// <returns>
        ///   Returns sequence of strings length.
        /// </returns>
        /// <example>
        ///   { } => { }
        ///   {"a", "aa", "aaa" } => { 1, 2, 3 }
        ///   {"aa", "bb", "cc", "", "  ", null } => { 2, 2, 2, 0, 2, 0 }
        /// </example>
        public IEnumerable<int> GetStringsLength(IEnumerable<string> data)
        {
            if (data == null)
                throw new ArgumentNullException();
            if (!data.Any())
                return new List<int>();
            //Use LINQ
            return data.Select(s => s?.Length ?? 0);

            List<int> result = new List<int>();
            foreach (string item in data)
            {
                result.Add(item?.Length ?? 0);
            }

            return result;

        }

        /// <summary>Transforms integer sequence to its square sequence, f(x) = x * x. </summary>
        /// <param name="data">Source int sequence.</param>
        /// <returns>
        ///   Returns sequence of squared items.
        /// </returns>
        /// <example>
        ///   { } => { }
        ///   { 1, 2, 3, 4, 5 } => { 1, 4, 9, 16, 25 }
        ///   { -1, -2, -3, -4, -5 } => { 1, 4, 9, 16, 25 }
        /// </example>
        public IEnumerable<long> GetSquareSequence(IEnumerable<int> data)
        {
            if (data == null)
                throw new ArgumentNullException();
            if (!data.Any())
                return new List<long>();
            //Use LINQ
            return data.Select(item => (long)item * item);    //(long)Math.Pow(item, 2) - невенро изза приведения double to long


            List<long> result = new List<long>();
            foreach (var item in data)
            {
                result.Add((long)item * item);
            }

            return result;

        }

        /// <summary> Filters a string sequence by a prefix value (case insensitive).</summary>
        /// <param name="data">Source string sequence.</param>
        /// <param name="prefix">Prefix value to filter.</param>
        /// <returns>
        ///  Returns items from data that started with required prefix (case insensitive).
        /// </returns>
        /// <exception cref="ArgumentNullException">Thrown when prefix is null.</exception>
        /// <example>
        ///  { "aaa", "bbbb", "ccc", null }, prefix = "b"  =>  { "bbbb" }
        ///  { "aaa", "bbbb", "ccc", null }, prefix = "B"  =>  { "bbbb" }
        ///  { "a","b","c" }, prefix = "D"  => { }
        ///  { "a","b","c" }, prefix = ""   => { "a","b","c" }
        ///  { "a","b","c", null }, prefix = ""   => { "a","b","c" }
        ///  { "a","b","c" }, prefix = null => ArgumentNullException
        /// </example>
        public IEnumerable<string> GetPrefixItems(IEnumerable<string> data, string prefix)
        {
            if (data == null)
                throw new ArgumentNullException();
            if (prefix == null)
                throw new ArgumentNullException();
            if (!data.Any())
                return data;

            //Use LINQ
            return data.Where(s => s != null).Where(s => s.StartsWith(prefix, StringComparison.OrdinalIgnoreCase) || prefix == "");

            List<string> result = new List<string>();

            foreach (var item in data)
            {
                if ((item != null && item.StartsWith(prefix, StringComparison.OrdinalIgnoreCase)) || prefix == "")
                    result.Add(item);
            }

            return result;
        }

        /// <summary> Finds the 3 largest numbers from a sequence.</summary>
        /// <param name="data">Source sequence.</param>
        /// <returns>
        ///   Returns the 3 largest numbers from a sequence.
        /// </returns>
        /// <example>
        ///   { } => { }
        ///   { 1, 2 } => { 2, 1 }
        ///   { 1, 2, 3 } => { 3, 2, 1 }
        ///   { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10 } => { 10, 9, 8 }
        ///   { 10, 10, 10, 10 } => { 10, 10, 10 }
        /// </example>
        public IEnumerable<int> Get3LargestItems(IEnumerable<int> data)
        {
            if (data == null)
                throw new ArgumentNullException();
            if (!data.Any())
                return new List<int>();

            //Use LINQ
            //return data.OrderByDescending(i => i).Take(3);

            List<int> tempList = new List<int>();
            List<int> result = new List<int>();
            foreach (var i in data)
            {
                tempList.Add(i);

            }
            tempList.Sort(Comparison);

            int count = tempList.Count < 3 ? tempList.Count : 3;
            for (int i = 0; i < count; i++)
            {
                result.Add(tempList[i]);
            }

            return result;

        }

        private int Comparison(int x, int y)
        {
            if (x >= y)
                return -1;
            return 1;
        }


        /// <summary> Calculates sum of all integers from object array.</summary>
        /// <param name="data">Source array.</param>
        /// <returns>
        ///    Returns the sum of all integers from object array.
        /// </returns>
        /// <example>
        ///    { 1, true, "a", "b", false, 1 } => 2
        ///    { true, false } => 0
        ///    { 10, "ten", 10 } => 20 
        ///    { } => 0
        /// </example>
        public int GetSumOfAllIntegers(object[] data)
        {
            if (data == null)
                throw new ArgumentNullException();
            if (!data.Any())
                return 0;

            //use LINQ
            return data.Where(o => o is int).Cast<int>().Sum();


            int sum = 0;
            foreach (var i in data)
            {
                try
                {
                    checked
                    {
                        if (i is int)
                            sum += (int)i;
                    }
                }
                catch (Exception e)
                {
                    throw new OverflowException();
                }


            }

            return sum;

        }
    }
}