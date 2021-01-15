using System.Collections.Generic;

namespace TestNinjaCore.Fundamentals
{
    public class Math
    {
        // only have 1 execution path
        public int Add(int a, int b)
        { 
            return a + b;
            // return 0; // this line supposed to make test pass
            // return 1;
        }
        
        // have 2 execution paths based on condition
        // number of tests >= number of execution paths
        public int Max(int a, int b)
        {
            return (a > b) ? a : b;
        }

        public IEnumerable<int> GetOddNumbers(int limit)
        {
            for (var i = 0; i <= limit; i++)
                if (i % 2 != 0)
                    yield return i; 
        }
    }
}