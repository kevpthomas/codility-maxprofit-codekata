using System;
using System.Collections.Generic;
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

        private const int TooBigValue = MaxProfitFinder.MaxValue + 1;
        private const int TooLongValue = MaxProfitFinder.MaxLength + 1;

        [Test]
        public void EmptyArray()
        {
            var A = new int[0];

            TestInstance.GetMaxProfit(A).ShouldBe(0);
        }

        [Test]
        public void EmptyMaximumValidLengthArray()
        {
            var A = new int[MaxProfitFinder.MaxLength];

            TestInstance.GetMaxProfit(A).ShouldBe(0);
        }

        [Test]
        public void TooLongArray()
        {
            var A = new int[TooLongValue];

            Should.Throw<ArgumentException>(() => TestInstance.GetMaxProfit(A));
        }

        [Test]
        public void SingleValueArrayTooBigValueInArray()
        {
            var A = new[] {Faker.Random.Int(TooBigValue, int.MaxValue)};

            TestInstance.GetMaxProfit(A).ShouldBe(0);
        }

        [TestCase(0, TooBigValue)]
        [TestCase(TooBigValue, 0)]
        [TestCase(TooBigValue, TooBigValue)]
        public void TwoValueArrayWithTooBigValueInArray(int val1, int val2)
        {
            var A = new[] {val1, val2};

            Should.Throw<ArgumentException>(() => TestInstance.GetMaxProfit(A));
        }

        [Test]
        public void SingleValueArray()
        {
            var A = new[] {Faker.Random.Int(0, MaxProfitFinder.MaxValue)};

            TestInstance.GetMaxProfit(A).ShouldBe(0);
        }

        [Test]
        public void TwoValueArrayWithEqualValues()
        {
            var val = Faker.Random.Int(0, MaxProfitFinder.MaxValue);
            var A = new[] { val, val };

            TestInstance.GetMaxProfit(A).ShouldBe(0);
        }

        [Test]
        public void TwoValueArrayWithLoss()
        {
            var val1 = Faker.Random.Int(1, MaxProfitFinder.MaxValue);
            var val2 = val1 - 1;
            var A = new[] { val1, val2 };

            TestInstance.GetMaxProfit(A).ShouldBe(0);
        }

        [Test]
        public void TwoValueArrayWithProfit()
        {
            var val1 = Faker.Random.Int(0, MaxProfitFinder.MaxValue - 1);
            var val2 = val1 + 1;
            var A = new[] { val1, val2 };

            TestInstance.GetMaxProfit(A).ShouldBe(val2 - val1);
        }

        [Test]
        public void LargeArrayWithoutProfit()
        {
            const int length = 100;
            var valNext = MaxProfitFinder.MaxValue;

            var valueList = new List<int>(length) {valNext};
            for (var i = 0; i < length - 1; i++)
            {
                valNext = Faker.Random.Int(0, valNext - 1);
                valueList.Add(valNext);
            }

            var A = valueList.ToArray();

            TestInstance.GetMaxProfit(A).ShouldBe(0);
        }
        
        [Test]
        public void CodilityTestArray()
        {
            var A = new[] {23171, 21011, 21123, 21366, 21013, 21367};

            TestInstance.GetMaxProfit(A).ShouldBe(356);
        }

        //[Test]
        //public void LargeArrayWithProfit()
        //{
        //    const int length = 100;
        //    var valNext = 0;

        //    var valueList = new List<int>(length) { valNext };
        //    for (var i = 0; i < length - 1; i++)
        //    {
        //        valNext = Faker.Random.Int(1, MaxProfitFinder.MaxValue);
        //        valueList.Add(valNext);
        //    }

        //    var maxValue = valueList.Max();

        //    var A = valueList.ToArray();

        //    TestInstance.GetMaxProfit(A).ShouldBe(maxValue);
        //}
    }
}