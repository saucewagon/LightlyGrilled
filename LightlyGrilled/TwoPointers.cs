﻿using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;

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

                searchPair(nums, target, i + 1, nums.Length - 1, triplets);
            }
            return triplets;
        }
        private static void searchPair(int[] nums, int target, int leftIndex, int rightIndex, List<List<int>> triplets)
        {
            //int rightIndex = nums.Length - 1;

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
        public static int TripletSumCloseToTarget(int[] nums, int target)
        {
            Array.Sort(nums);
            int smallestDifferenceToTarget = int.MaxValue;

            for(int i = 0; i < nums.Length - 2; i++)
            {
                int leftIndex = i + 1;
                int rightIndex = nums.Length - 1;

                while (leftIndex < rightIndex)
                {
                    int currentDistanceToTarget = target - nums[i] - nums[leftIndex] - nums[rightIndex];
                    if (currentDistanceToTarget == 0) return target;

                    if (Math.Abs(currentDistanceToTarget) < Math.Abs(smallestDifferenceToTarget)
                        || (Math.Abs(currentDistanceToTarget) == Math.Abs(smallestDifferenceToTarget) &&
                        currentDistanceToTarget > smallestDifferenceToTarget))
                    {
                        smallestDifferenceToTarget = currentDistanceToTarget;
                    }
                    if (currentDistanceToTarget > 0) leftIndex++;
                    else rightIndex--;
                }
            }
            return target-smallestDifferenceToTarget;
        }

        public static int TripletsWithSmallerSum(int[] nums, int target)
        {
            Array.Sort(nums);
            int numTriplets = 0;

            for(int i = 0; i < nums.Length - 2; i++)
            {
                int leftIndex = i + 1;
                int rightIndex = nums.Length - 1;

                while (leftIndex < rightIndex)
                {
                    int currentSum = nums[i] + nums[leftIndex] + nums[rightIndex];
                    if (currentSum < target)
                    {
                        numTriplets+= rightIndex - leftIndex; // The number of triplets between the right and left indexes are guaranteed to be less than target
                        leftIndex++;
                    }
                    else rightIndex--;
                }
            }
            return numTriplets;
        }

        public static List<List<int>> SubarraysWithProductLessThanTarget(int[] nums, int target)
        {
            var subarrays = new List<List<int>>();
            for (int i = 0; i < nums.Length; i++)
            {
                int currentProduct = nums[i] * 1;
                int j = i + 1;
                var currentSubarray = new List<int>();
                if (currentProduct < target)
                {
                    subarrays.Add(new List<int>() { nums[i] });
                    currentSubarray.Add(nums[i]);
                }
                while (j < nums.Length && currentProduct < target)
                {
                    currentProduct = currentProduct * nums[j];
                    if (currentProduct < target)
                    {
                        currentSubarray.Add(nums[j]);
                    }
                    j++;
                }
                if (currentSubarray.Count > 1)
                {
                    var subarrayToAdd = new List<int>(currentSubarray);
                    subarrays.Add(subarrayToAdd);
                    currentSubarray.Clear();
                }

            }
            return subarrays;
        }

        public static int[] DutchNationalFlag(int[] nums)
        {
            int leftIndex = 0;
            int rightIndex = nums.Length - 1;
            int i = 0;

            while (i <= rightIndex)
            {
                if (nums[i] == 0)
                {
                    swap(nums, i, leftIndex);
                    i++;
                    leftIndex++;
                }
                else if (nums[i] == 1)
                {
                    i++;
                }
                else
                {
                    swap(nums, i, rightIndex);
                    rightIndex--;
                }
            }
            return nums;
        }
        private static void swap(int[] nums, int indexA, int indexB)
        {
            int tmp = nums[indexA];
            nums[indexA] = nums[indexB];
            nums[indexB] = tmp;
        }

        public static List<List<int>> QuadrupleSumToTarget(int[] nums, int target)
        {
            Array.Sort(nums);
            var quadruplets = new List<List<int>>();

            for (int i = 0; i < nums.Length - 3; i++)
            {
                if (i > 0 && nums[i] == nums[i - 1]) continue;

                for(int j = i+1; j < nums.Length - 2; j++)
                {
                    if (j > i + 1 && nums[j] == nums[j - 1]) continue;

                    findQuadruplets(nums, target, i, j, quadruplets);
                }
            }

            return quadruplets;
        }

        private static void findQuadruplets(int[] nums, int target, int first, int second, List<List<int>> quadruplets)
        {
            int leftIndex = second + 1;
            int rightIndex = nums.Length - 1;
            while (leftIndex < rightIndex)
            {
                int currentSum = nums[leftIndex] + nums[rightIndex] + nums[first] + nums[second];

                if (currentSum == target)
                {
                    quadruplets.Add(new List<int>() { nums[first], nums[second], nums[leftIndex], nums[rightIndex] });
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

        public static bool CompareStringsBackspace(string s1, string s2)
        {
            string s1Removed = removeBackspaces(s1);
            string s2Removed = removeBackspaces(s2);
            return s1Removed.Equals(s2Removed);
        }

        private static string removeBackspaces(string s)
        {
            StringBuilder sb = new StringBuilder();

            int i = s.Length - 1;
            int backspaceCount = 0;
            while (i >= 0)
            {
                if (s[i] == '#')
                {
                    backspaceCount++;
                    i--;
                }
                else
                {
                    if (backspaceCount > 0)
                    {
                        backspaceCount--;
                        i--;
                        continue;
                    }
       
                    sb.Insert(0, s[i]);
                    i--;
                }
            }
            return sb.ToString();
        }

        public static int MinimumWindowSort(int[] nums)
        {
            int low = 0;
            int high = nums.Length - 1;

            while (low < nums.Length - 1 && nums[low] <= nums[low + 1]) low++;
            while (high > 0 && nums[high] >= nums[high - 1]) high--;
            if (low == nums.Length - 1) return 0;

            int maxValOfSubarray = Int32.MinValue;
            int minValOfSubarray = Int32.MaxValue;

            for(int i = low; i <= high; i++)
            {
                maxValOfSubarray = Math.Max(maxValOfSubarray, nums[i]);
                minValOfSubarray = Math.Min(minValOfSubarray, nums[i]);
            }
            while(low > 0 && nums[low - 1] > minValOfSubarray)
            {
                low--;
            }
            while (high < nums.Length - 1 && nums[high + 1] < maxValOfSubarray)
            {
                high++;
            }
            return high - low + 1;
        }
    }
}
