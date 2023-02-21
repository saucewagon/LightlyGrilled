using System;
namespace LightlyGrilled
{
	public class TwoPointers
	{
        public static int[] PairWithTargetSum(int[] nums, int target)
        {
            int endPointer = nums.Length - 1;
            int startPointer = 0;
            int[] pair = new int[2];

            while (startPointer != endPointer)
            {
                int currentSum = nums[startPointer] + nums[endPointer];

                if (currentSum == target)
                {
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
            return pair;
        }
    }
}

