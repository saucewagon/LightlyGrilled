using System;
using Xunit;

namespace LightlyGrilled.Tests
{
	public class TwoPointersTests
	{
        [Fact]
        public void PairWithTargetSumTest1()
        {
            PairWithTargetSumTestBase(new int[] { 1, 2, 3, 4, 6 }, 6, new int[] { 1 , 3});
        }
        [Fact]
        public void PairWithTargetSumTest2()
        {
            PairWithTargetSumTestBase(new int[] { 2, 5, 9, 11 }, 11, new int[] { 0,2 });
        }
        [Fact]
        public void PairWithTargetSumTest3()
        {
            PairWithTargetSumTestBase(new int[] { -1, 4, 45, 110 }, 44, new int[] { 0, 2 });
        }
        public void PairWithTargetSumTestBase(int[] nums, int target, int[] expectedResult)
        {
            int[] actual = TwoPointers.PairWithTargetSum(nums, target);
            Assert.NotNull(actual);
            Assert.Equal(2, actual.Length);
            Assert.Equal(expectedResult, actual);
        }
    }
}

