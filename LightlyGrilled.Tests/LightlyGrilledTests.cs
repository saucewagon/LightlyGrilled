using System;
using Xunit;
using LightlyGrilled;

namespace LightlyGrilled.Tests
{
    public class LightlyGrilledTests
    {
        #region TwoSum
        [Fact]
        public void TwoSumTest1()
        {
            TwoSumTestBase(new int[] { 2, 7, 11, 15 }, 9, new int[] { 0, 1 });
        }
        [Fact]
        public void TwoSumTest2()
        {
            TwoSumTestBase(new int[] { 3, 2, 4 }, 6, new int[] { 1, 2 });
        }
        [Fact]
        public void TwoSumTest3()
        {
            TwoSumTestBase(new int[] { 3, 3 }, 6, new int[] { 0, 1 });
        }
        public void TwoSumTestBase(int[] nums, int target, int[] expectedResult)
        {
            int[] actual = LightlyGrilledQuestions.TwoSum(nums, target);
            Assert.NotNull(actual);
            Assert.Equal(2, actual.Length);
            Assert.Equal(expectedResult, actual);
        }
        #endregion
        #region ContainsDuplicate

        [Theory]
        [InlineData(1,2,3,1)]
        [InlineData(1, 1, 1, 3, 3, 4, 3, 2, 4, 2)]
        public void ContainsDuplicatePositiveTest(params int[] nums)
        {
            Assert.True(LightlyGrilledQuestions.ContainsDuplicate(nums));
        }
        [Theory]
        [InlineData(1, 2, 3, 4)]
        [InlineData(1)]
        public void ContainsDuplicateNegativeTest(params int[] nums)
        {
            Assert.False(LightlyGrilledQuestions.ContainsDuplicate(nums));
        }

        #endregion
    }
}
