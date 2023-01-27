using System;
using System.Collections.Generic;

namespace LightlyGrilled
{
    public class LightlyGrilledQuestions
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
        }
        /* TWO SUM
         
        Problem:        
        Given an array of integers nums and an integer target, return indices of the two numbers such that they add up to target.

        You may assume that each input would have exactly one solution, and you may not use the same element twice.

        You can return the answer in any order.

        Input: nums = [2,7,11,15], target = 9
        Output: [0,1]
        Explanation: Because nums[0] + nums[1] == 9, we return [0, 1].

        Time complexity: O(n)
        Space complexity: O(n)
         */

        public static int[] TwoSum(int[] nums, int target)
        {
            int[] result = new int[2];
            var valueToIndicesDictionary = new Dictionary<int, HashSet<int>>();

            for(int i = 0; i < nums.Length; i++)
            {
                if (valueToIndicesDictionary.ContainsKey(nums[i]) == false)
                {
                    valueToIndicesDictionary.Add(nums[i], new HashSet<int>() { i });
                }
                else
                {
                    var indices = valueToIndicesDictionary[nums[i]];
                    indices.Add(i);
                    valueToIndicesDictionary[nums[i]] = indices;
                }
            }

            for(int i = 0; i < nums.Length; i++)
            {
                int complement = target - nums[i];

                if (valueToIndicesDictionary.ContainsKey(complement))
                {
                    var indices = valueToIndicesDictionary[complement];

                    foreach(int index in indices)
                    {
                        if (index != i)
                        {
                            result[0] = i;
                            result[1] = index;
                            return result;
                        }
                    }
                }
            }
            return result;
        }

        /*
         * CONTAINS DUPLICATE
         * 
         * Given an integer array nums, return true if any value appears at least twice in the array, 
         * and return false if every element is distinct.
         * 
         * Input: nums = [1,2,3,1]
         * Output: true
         * 
         * Time complexity: O(n)
         * Space complexity: O(n)    
         */

        public static bool ContainsDuplicate(int[] nums)
        {
            var duplicateSet = new HashSet<int>();

            for(int i = 0; i < nums.Length; i++)
            {
                if (duplicateSet.Contains(nums[i]))
                {
                    return true;
                }
                else
                {
                    duplicateSet.Add(nums[i]);
                }
            }
            return false;
        }
    }
}
