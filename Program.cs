using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataStructuresAndAlgorithm
{
    class Program
    {
        static void Main(string[] args)
        {
            #region Array
            int[] numbers1 = { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11 };
            int[] numb1 = { 1, 1 };
            int[] numb2 = { 1, 2};
            int[] a = { -2, -3, 4, -1, -2, 1, 5, -3 };
            ArrayPractice.ArrayFindMaxSubArray(a);
            ArrayPractice.ArrayFindMedianSortedArrays(numb1, numb2);
            int[] numbers2 = { -4225, 5442, -9006, -429, 160, -9234, -4444, 3586, -5711, -9506, -79, -4418, -4348, -5891 };
            ArrayPractice.ArrayMaxSubAverage(numbers2, 4);
            ArrayPractice.ArrayReverse(numbers1, 2, 7);
            ArrayPractice.ArrayRotateCyclicReplacementToLeft(numbers1, 2);
            ArrayPractice.ArrayRotateCyclicReplacementToRight(numbers1, 2);
            ArrayPractice.ArrayRotate(numbers1, 3, true);
            ArrayPractice.ArrayFindingMissingNumber(numbers1);
            ArrayPractice.ArrayOverview();
            #endregion

        }
    }
}
