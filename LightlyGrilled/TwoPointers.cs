using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace LightlyGrilled
{
	public class TwoPointers
	{
        public static int[] PairWithTargetSum(int[] nums, int target)
        {
            int endPointer = nums.Length - 1;
            int startPointer = 0;
            int[] pair = new int[2];
            bool foundAPair = false;

            while (startPointer != endPointer)
            {
                int currentSum = nums[startPointer] + nums[endPointer];

                if (currentSum == target)
                {
                    foundAPair = true;
                    pair[0] = startPointer;
                    pair[1] = endPointer;
                    return pair;
                }
                else if (currentSum < target)
                {
                    startPointer++;
                }
                else if (currentSum > target)
                {
                    endPointer--;
                }
            }
            if (!foundAPair)
            {
                throw new Exception();
            }
            return pair;
        }
        public static int SeparateDuplicates(int[] nums)
        {
            int beginningOfBadSectionOfArray = 1;

            for(int i = 1; i < nums.Length; i++)
            {
                int currentElement = nums[i];
                int endOfGoodSectionOfArray = beginningOfBadSectionOfArray - 1;
                int lastGoodElement = nums[endOfGoodSectionOfArray];

                if (lastGoodElement == currentElement) // if we see a duplicate, i keeps marching through the array 
                {
                    continue;
                }
                else
                {
                    nums[beginningOfBadSectionOfArray] = nums[i]; // we've found a good element, move it back
                    beginningOfBadSectionOfArray++; // bad section gets smaller, good section gets bigger 
                }
            }
            return beginningOfBadSectionOfArray;
        }
        public static int RemoveKeyFromArray(int[] nums, int key)
        {
            int startIndexOfBadPartOfArray = 0;

            for(int i = 0; i < nums.Length; i++)
            {
                if (nums[i] != key)
                {
                    nums[startIndexOfBadPartOfArray] = nums[i];
                    startIndexOfBadPartOfArray++;
                    nums[i] = key;
                }
            }
            return startIndexOfBadPartOfArray;
        }
        public static int[] SquareSortedArray(int[] nums)
        {
            int[] squared = new int[nums.Length];

            int startPointer = 0;
            int endPointer = nums.Length - 1;
            int i = nums.Length - 1;

            while (i >= 0)
            {
                if (Math.Abs(nums[startPointer]) > Math.Abs(nums[endPointer]))
                {
                    squared[i] = (int)Math.Pow(nums[startPointer], 2);
                    startPointer++;
                }
                else
                {
                    squared[i] = (int)Math.Pow(nums[endPointer], 2);
                    endPointer--;
                }

                i--;
            }
            return squared;
        }
        public static List<List<int>> TripletSumToZero(int[] nums)
        {
            var triplets = new List<List<int>>();
            Array.Sort(nums);

            for(int i = 0; i < nums.Length - 2; i++)
            {
                // look behind to see if this is a duplicate, if so, skip
                if (i > 0 && nums[i] == nums[i - 1]) { continue; }
                int target = -1 * nums[i];

                searchPair(nums, target, i + 1, triplets);
            }
            return triplets;
        }

        private static void searchPair(int[] nums, int target, int leftIndex, List<List<int>> triplets)
        {
            int rightIndex = nums.Length - 1;

            while (leftIndex < rightIndex)
            {
                int currentSum = nums[leftIndex] + nums[rightIndex];

                if (currentSum == target)
                {
                    triplets.Add(new List<int>() { -1 * target, nums[leftIndex], nums[rightIndex] });
                    leftIndex++;
                    rightIndex--;

                    while (leftIndex < rightIndex && nums[leftIndex] == nums[leftIndex - 1]) leftIndex++;
                    while (leftIndex < rightIndex && nums[rightIndex] == nums[rightIndex + 1]) rightIndex--;
                }
                else if (currentSum < target)
                {
                    leftIndex++;
                }
                else rightIndex--;
            }
        }
    }
}
