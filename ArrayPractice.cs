using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace DataStructuresAndAlgorithm
{
    public class ArrayPractice
    {
        public static void ArrayOverview()
        {
            int[] array1 = new int[5];

            int[] array2 = new[] { 1, 2, 3, 4 };

            int[] array3 = { 1, 2, 3, 4, 5 };

            int[,] multiDimensionalArray1 = new int[3, 4];

            int dimension = multiDimensionalArray1.Rank;

            int[,] multiDimensionalArray2 = { { 1, 2, 3 }, { 4, 5, 6 } };

            // Declare a jagged array.
            int[][] jaggedArray = new int[3][];

            // Set the values of the first array in the jagged array structure.
            jaggedArray[0] = new int[4] { 1, 2, 3, 4 };
            jaggedArray[1] = new int[] { 0, 2, 4, 6 };
            jaggedArray[2] = new int[] { 11, 22 };


            int a = array2.Max(); // returns 16
            a = array2.Min(); // returns 6
            a = array2.Sum(); // returns 55
            double b = array2.Average();

            // Display the array elements.
            for (int i = 0; i < jaggedArray.Length; i++)
            {
                System.Console.Write("Element({0}): ", i);

                for (int j = 0; j < jaggedArray[i].Length; j++)
                {
                    System.Console.Write("{0}{1}",
                        jaggedArray[i][j],
                        j == (jaggedArray[i].Length - 1) ? "" : " ");
                }
                System.Console.WriteLine();
            }

            int[] numbers = { 2, 4, 65, 6, 7, 8, 9 };
            foreach (var number in numbers)
            {
                Console.WriteLine($"Numbers:  {number}");
            }


            int[,] numbers2D = new int[3, 2] { { 9, 99 }, { 3, 33 }, { 5, 55 } };
            // Or use the short form:
            // int[,] numbers2D = { { 9, 99 }, { 3, 33 }, { 5, 55 } };

            foreach (int i in numbers2D)
            {
                System.Console.Write("{0} ", i);
            }

            for (int i = 0; i < numbers2D.GetLength(0); i++)
            {
                for (int j = 0; j < numbers2D.GetLength(1); j++)
                {
                    System.Console.WriteLine("Element({0},{1})={2}", i, j, numbers2D[i, j]);
                }
            }


            Console.WriteLine("One dimension (Rank=1):");
            int[] numbers1 = { 1, 2, 3, 4, 5, 6, 7, 8, 9 };

            for (int i = 0; i < 9; i++)
            {
                Console.Write("{0} ", numbers1[i]);
            }
            Console.WriteLine();
            Console.WriteLine();

            Console.WriteLine("Array.Clear(numbers1, 2, 5)");
            Array.Clear(numbers1, 2, 5);


            string[] planets = { "Mercury", "Venus",
                "Earth", "Mars", "Jupiter",
                "Saturn", "Uranus", "Neptune" };

            Console.WriteLine("One or more planets begin with 'M': {0}",
                Array.Exists(planets, element => element.StartsWith("M")));

            Array.Resize(ref planets, planets.Length + 5);

            foreach (var planet in planets)
            {
                Console.WriteLine($"TEST {planet}");
            }

            // Displays the values of the Array.
            Console.WriteLine("The Array initially contains the following values:");
            foreach (var planet in planets)
            {
                Console.WriteLine($"TEST {planet}");
            }

            // Reverses the sort of the values of the Array.
            Array.Reverse(planets, 1, 3);

            // Displays the values of the Array.
            Console.WriteLine("After reversing:");
            foreach (var planet in planets)
            {
                Console.WriteLine($"TEST {planet}");
            }

            System.Console.ReadKey();
        }

        public static void ArrayReverse(int[] array, int index, int length)
        {
            Console.WriteLine("Before reversing:");
            foreach (var numbers1 in array)
            {
                Console.Write("{0} ", numbers1);
            }
            int index1 = index;
            int index2 = index + length - 1;

            do
            {
                int obj = array[index1];
                array[index1] = array[index2];
                array[index2] = obj;
                ++index1;
                --index2;

            } while (index1 < index2);
            //for (; index1 < index2; --index2)
            //{
            //    int obj = array[index1];
            //    array[index1] = array[index2];
            //    array[index2] = obj;
            //    ++index1;
            //}
            Array.ForEach(array, n => Console.Write(n));
        }

        public static void ArrayTranspose(int[,] arr)
        {
            for (int i = 0; i < arr.GetLength(0); i++)
            {
                for (int j = i; j < arr.GetLength(1); j++)
                {
                    var temp = arr[i, j];
                    arr[i, j] = arr[j, i];
                    arr[j, i] = temp;
                }
            }
        }

        public static int ArrayFindingMissingNumber(int[] arr)
        {

            int total = (arr.Length * (arr.Length + 1)) / 2;
            int sumArray = 0;
            for (int i = 0; i < arr.Length - 1; i++)
                sumArray += arr[i];

            return total - sumArray;
        }

        public static void ArrayRotateCyclicReplacementToRight(int[] nums, int times)
        {
            times = times % nums.Length;
            int count = 0;
            for (int index = 0; count < nums.Length; index++)
            {
                int currentIndex = index;
                int prev = nums[index];
                do
                {
                    int nextIndex = (currentIndex + times) % nums.Length;
                    int temp = nums[nextIndex];
                    nums[nextIndex] = prev;
                    prev = temp;
                    currentIndex = nextIndex;
                    count++;
                } while (index != currentIndex);
            }
        }

        public static void ArrayRotateCyclicReplacementToLeft(int[] nums, int times)
        {
            times = times % nums.Length;
            int count = 0;
            for (int index = 0; count < nums.Length; index++)
            {
                int currentIndex = index;
                int prev = nums[index];
                do
                {
                    int nextIndex;
                    if (currentIndex - times >= 0)
                        nextIndex = (currentIndex - times) % nums.Length;
                    else
                        nextIndex = nums.Length + (currentIndex - times);

                    int temp = nums[nextIndex];
                    nums[nextIndex] = prev;
                    prev = temp;
                    currentIndex = nextIndex;
                    count++;
                } while (index != currentIndex);
            }
        }

        public static void ArrayRotate(int[] nums, int times, bool goRight)
        {
            var linkedList = new LinkedList<int>(nums);
            if (goRight)
            {
                for (int i = 0; i < times; i++)
                {
                    var node = linkedList.Last;
                    linkedList.RemoveLast();
                    linkedList.AddFirst(node);
                }
            }
            else
            {
                for (int i = 0; i < times; i++)
                {
                    var node = linkedList.First;
                    linkedList.RemoveFirst();
                    linkedList.AddLast(node);
                }
            }
        }

        public static void ArrayMaxSubAverage(int[] nums, int subArrayLength)
        {

            int currentSum = nums.Take(subArrayLength).Sum();

            double max = currentSum / (double)subArrayLength;

            for (int i = subArrayLength; i < nums.Length; i++)
            {
                currentSum -= nums[i - subArrayLength];
                currentSum += nums[i];
                max = Math.Max(max, (currentSum / (double)subArrayLength));
            }

        }

        public static double ArrayFindMedianSortedArrays(int[] nums1, int[] nums2)
        {

            var myList = new List<int>();
            myList.AddRange(nums1);
            myList.AddRange(nums2);
            int[] arr = myList.ToArray();

            Array.Sort(arr);

            if (arr.Length % 2 != 0)
                return (double)arr[arr.Length / 2];

            double result = (double)(arr[(arr.Length - 1) / 2] + arr[arr.Length / 2]) / 2.0;

            return result;
        }

        public static void ArrayFindMaxSubArray(int[] nums1)
        {
            int size = nums1.Length;

            int maxSoFar = int.MinValue;
            int maxEndingHere = 0;

            for (int i = 0; i < size; i++)
            {
                maxEndingHere += nums1[i];

                if (maxSoFar < maxEndingHere)
                    maxSoFar = maxEndingHere;

                if (maxEndingHere < 0)
                    maxEndingHere = 0;

            }

            int result = maxSoFar;
        }

        public static void ArrayMinJumpToEndOfArray(int[] nums)
        {
            //Given an array of non - negative integers nums,
            //you are initially positioned at the first index of the array.

            //Each element in the array represents your maximum jump length at that position.
            //Your goal is to reach the last index in the minimum number of jumps.
            //You can assume that you can always reach the last index.
            int jumps = 0;
            int nextMaxPosition = 0, currentMaxPosition = 0;

            for (int i = 0; i < nums.Length - 1; i++)
            {
                int current = nums[i] + i;
                nextMaxPosition = Math.Max(current, nextMaxPosition);
                if (i == currentMaxPosition)
                {
                    jumps++;
                    currentMaxPosition = nextMaxPosition;
                }
            }
            var result = jumps;
        }
        public static void ArrayCanJumpToEndOfArray(int[] nums)
        {
            //Index   0   1   2   3   4   5   6
            //nums    9   4   2   1   0   2   0
            //memo    U   G   B   B   B   G   G
            int lastGoodIndexPosition = nums.Length - 1;

            for (int i = nums.Length - 1; i >= 0; i--)
            {
                if (i + nums[i] >= lastGoodIndexPosition)
                {
                    lastGoodIndexPosition = i;
                }
            }

            var result = lastGoodIndexPosition == 0;

        }
        public static void ArrayPartitionArrayIntoDisjointIntervals(int[] nums)
        {
            int splitIndex = 0,
                maxAtSplitIndexValue = nums[0],
                maxSoFar = nums[0];

            for (int i = 0; i < nums.Length ; i++)
            {
                if (nums[i] < maxAtSplitIndexValue)
                {
                    splitIndex = i;
                    maxAtSplitIndex = maxSoFar;
                }

                maxSoFar = Math.Max(maxSoFar, nums[i]);
            }

            int result = splitIndex + 1;
        }
    }
}
