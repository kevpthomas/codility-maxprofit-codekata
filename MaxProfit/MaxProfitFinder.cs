using System;
using System.Linq;
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
        // exception if array length > 400000
        // exception if any value in array > 200000

        [Test]
        public void EmptyArray()
        {
            var A = new int[0];

            TestInstance.GetMaxProfit(A).ShouldBe(0);
        }

        [Test]
        public void SingleValueArray()
        {
            var A = new[] {Faker.Random.Int(0, 200000)};

            TestInstance.GetMaxProfit(A).ShouldBe(0);
        }

        [Test]
        public void TwoValueArrayWithEqualValues()
        {
            var val = Faker.Random.Int(0, 200000);
            var A = new[] { val, val };

            TestInstance.GetMaxProfit(A).ShouldBe(0);
        }

        [Test]
        public void TwoValueArrayWithLoss()
        {
            var val1 = Faker.Random.Int(1, 200000);
            var val2 = val1 - 1;
            var A = new[] { val1, val2 };

            TestInstance.GetMaxProfit(A).ShouldBe(0);
        }

        [Test]
        public void TwoValueArrayWithProfit()
        {
            var val1 = Faker.Random.Int(0, 199999);
            var val2 = val1 + 1;
            var A = new[] { val1, val2 };

            TestInstance.GetMaxProfit(A).ShouldBe(val2 - val1);
        }
    }

    public class MaxProfitFinder
    {
        // https://app.codility.com/programmers/lessons/9-maximum_slice_problem/max_profit/

        public int GetMaxProfit(int[] A)
        {
            if (A.Length < 2) return 0;

            var profitOrLoss = A[1] - A[0];
            return profitOrLoss > 0 ? profitOrLoss : 0;
        }
    }
}