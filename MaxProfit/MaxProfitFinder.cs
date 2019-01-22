using System;
using System.Diagnostics;
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
            var aLen = A.Length;

            if (aLen > MaxLength) 
                throw new ArgumentException($"Supplied array must have no more than {MaxLength} members but had {A.Length}.", $"{nameof(A)}");
            
            if (aLen < 2) return 0;

            var maxValueInArray = A.Max();
            if (maxValueInArray > MaxValue) 
                throw new ArgumentException($"Supplied array must contain no value greater than {MaxValue} but contains value {maxValueInArray}.", $"{nameof(A)}");

            var max = 0;
            var profitOrLoss = 0;

            for(var i = aLen-1; i >= 0; --i)
            {
                if(A[i] > max)
                    max = A[i];

                var tmpResult = max - A[i];        
                if(tmpResult > profitOrLoss)
                    profitOrLoss = tmpResult;
            }

            return profitOrLoss;
        }
    }
}