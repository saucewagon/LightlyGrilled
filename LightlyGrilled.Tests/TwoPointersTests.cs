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

        [Fact]
        public void SeparateDuplicatesTest1()
        {
            SeparateDuplicatesTestBase(new int[] { 2, 3, 3, 3, 6, 9, 9 }, 4);
        }
        [Fact]
        public void SeparateDuplicatesTest2()
        {
            SeparateDuplicatesTestBase(new int[] { 2, 2, 2, 11 }, 2);
        }
        public void SeparateDuplicatesTestBase(int[] nums, int expectedLength)
        {
            int actual = TwoPointers.SeparateDuplicates(nums);
            Assert.Equal(actual, expectedLength);
        }
        [Fact]
        public void RemovesKeysTest1()
        {
            RemovesKeysTestBase(new int[] { 3, 2, 3, 6, 3, 10, 9, 3 }, 3 , 4);
        }
        [Fact]
        public void RemovesKeysTest2()
        {
            RemovesKeysTestBase(new int[] { 2, 11, 2, 2, 1 }, 2, 2);
        }
        [Fact]
        public void RemovesKeysTest3()
        {
            RemovesKeysTestBase(new int[] { 7, 7, 7, 7, 7, 1, 1 }, 7, 2);
        }
        public void RemovesKeysTestBase(int[] nums, int key, int expectedLength)
        {
            int actual = TwoPointers.RemoveKeyFromArray(nums, key);
            Assert.Equal(actual, expectedLength);
        }
    }
}

