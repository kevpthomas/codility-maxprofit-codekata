using System;
using NUnit.Framework;
using Shouldly;
// ReSharper disable InconsistentNaming

namespace MaxProfit
{
    public class MaxProfitFinderTests : UnitTestBase<MaxProfitFinder>
    {
        // N is an integer within the range [0..400,000];
        // each element of array A is an integer within the range [0..200,000]
        // class Solution { public int solution(int[] A); }

        // returns the maximum possible profit from one transaction during this period
        // return 0 if it was impossible to gain any profit
        // return 0 if array is empty
        // return 0 if array has 1 entry
        // return 0 if array has 2 entries with 2nd entry < 1st entry
        // return 0 if array has 2 entries with 2nd entry = 1st entry
        // return > 0 if array has 2 entries with 2nd entry > 1st entry

        [Test]
        public void EmptyArray()
        {
            var A = new int[0];

            TestInstance.GetMaxProfit(A).ShouldBe(0);
        }
    }

    public class MaxProfitFinder
    {
        // https://app.codility.com/programmers/lessons/9-maximum_slice_problem/max_profit/

        public int GetMaxProfit(int[] A)
        {
            return 0;
        }
    }
}