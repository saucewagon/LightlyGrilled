using System;
using Xunit;
using LightlyGrilled;

namespace LightlyGrilled.Tests
{
    public class UnitTest1
    {
        [Fact]
        public void TwoSumTests()
        {
            TwoSumTestBase(new int[] { 2, 7, 11, 15 }, 9, new int[] { 0, 1 });
            TwoSumTestBase(new int[] { 3, 2, 4 }, 6, new int[] { 1, 2 });
            TwoSumTestBase(new int[] { 3, 3 }, 6, new int[] { 0, 1 });
        }
        public void TwoSumTestBase(int[] nums, int target, int[] expectedResult)
        {
            int[] actual = LightlyGrilledQuestions.TwoSum(new int[] { 2, 7, 11, 15 }, 9);
            Assert.NotNull(actual);
            Assert.Equal(2, actual.Length);
            Assert.Equal(expectedResult, actual);
        }
    }
}
