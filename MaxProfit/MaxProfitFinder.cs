using System;
using System.Linq;

// ReSharper disable InconsistentNaming

namespace MaxProfit
{
    public class MaxProfitFinder
    {
        // https://app.codility.com/programmers/lessons/9-maximum_slice_problem/max_profit/

        public const int MaxLength = 400000;
        public const int MaxValue = 200000;

        public int GetMaxProfit(int[] A)
        {
            if (A.Length > MaxLength) 
                throw new ArgumentException($"Supplied array must have no more than {MaxLength} members but had {A.Length}.", $"{nameof(A)}");
            
            if (A.Length < 2) return 0;

            var maxValueInArray = A.Max();
            if (maxValueInArray > MaxValue) 
                throw new ArgumentException($"Supplied array must contain no value greater than {MaxValue} but contains value {maxValueInArray}.", $"{nameof(A)}");

            var profitOrLoss = A[1] - A[0];
            //var minValue = A.Min();
            //var minValuePosition = Array.IndexOf(A, minValue);

            //var maxValue = A.Max();
            //var maxValuePosition = Array.IndexOf(A, maxValue);

            //var profitOrLoss = minValuePosition > maxValuePosition 
            //    ? minValue - maxValue 
            //    : maxValue - minValue;

            return profitOrLoss > 0 ? profitOrLoss : 0;
        }
    }
}