﻿using System;
using System.Collections.Generic;
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
        [Fact]
        public void SquareSortedArrayTest1()
        {
            SquareSortedArrayBase(new int[] { -2, -1, 0, 2, 3 }, new int[] { 0, 1, 4, 4, 9 });
        }
        [Fact]
        public void SquareSortedArrayTest2()
        {
            SquareSortedArrayBase(new int[] { -3, -1, 0, 1, 2 }, new int[] { 0, 1, 1, 4, 9 });
        }
        [Fact]
        public void SquareSortedArrayTest3()
        {
            SquareSortedArrayBase(new int[] { -1 }, new int[] { 1 });
        }
        [Fact]
        public void SquareSortedArrayTest4()
        {
            SquareSortedArrayBase(new int[] { -3,-2,-1}, new int[] { 1,4,9 });
        }
        [Fact]
        public void SquareSortedArrayTest5()
        {
            SquareSortedArrayBase(new int[] { 1, 2, 3 }, new int[] { 1,4,9});
        }
        public void SquareSortedArrayBase(int[] nums, int[] expectedResult)
        {
            int[] actual = TwoPointers.SquareSortedArray(nums);
            Assert.NotNull(actual);
            Assert.Equal(expectedResult.Length, actual.Length);
            Assert.Equal(expectedResult, actual);
        }
        [Fact]
        public void TripletSumToZeroTest1()
        {
            List<List<int>> expected = new List<List<int>>();
            expected.Add(new List<int>() { -3, 1, 2 });
            expected.Add(new List<int>() { -2, 0, 2 });
            expected.Add(new List<int>() { -2, 1, 1 });
            expected.Add(new List<int>() { -1, 0, 1 });

            TripletSumToZeroTestBase(new int[] { -3, 0, 1, 2, -1, 1, -2 }, expected);
        }
        [Fact]
        public void TripletSumToZeroTest2()
        {
            List<List<int>> expected = new List<List<int>>();
            expected.Add(new List<int>() { -5, 2, 3 });
            expected.Add(new List<int>() { -2, -1, 3 });

            TripletSumToZeroTestBase(new int[] { -5, 2, -1, -2, 3 }, expected);
        }
        private void TripletSumToZeroTestBase(int[] nums, List<List<int>> expected)
        {
            List<List<int>> result = TwoPointers.TripletSumToZero(nums);
            Assert.Equal(expected, result);
        }
        [Fact]
        public void TripletSumCloseToTargetTest1()
        {
            TripletSumCloseToTargetTestBase(new int[] { -2, 0, 1, 2 }, 2, 1);
        }
        [Fact]
        public void TripletSumCloseToTargetTest2()
        {
            TripletSumCloseToTargetTestBase(new int[] { -3, -1, 1, 2 }, 1, 0);
        }
        [Fact]
        public void TripletSumCloseToTargetTest3()
        {
            TripletSumCloseToTargetTestBase(new int[] { 1, 0, 1, 1 }, 100, 3);
        }
        private void TripletSumCloseToTargetTestBase(int[] nums, int target, int expected)
        {
            int result = TwoPointers.TripletSumCloseToTarget(nums, target);
            Assert.Equal(expected, result);
        }
        [Fact]
        public void TripletsWithSmallerSumTest1()
        {
            TripletsWithSmallerSumTestBase(new int[] { -1, 0, 2, 3 }, 3, 2);
        }
        [Fact]
        public void TripletsWithSmallerSumTest2()
        {
            TripletsWithSmallerSumTestBase(new int[] { -1, 4, 2, 1, 3 }, 5, 4);
        }
        private void TripletsWithSmallerSumTestBase(int[] nums, int target, int expected)
        {
            int result = TwoPointers.TripletsWithSmallerSum(nums, target);
            Assert.Equal(expected, result);
        }
        [Fact]
        public void SubarraysWithProductLessThanTargetTest1()
        {
            List<List<int>> expected = new List<List<int>>();
            expected.Add(new List<int>() { 2 });
            expected.Add(new List<int>() { 5 });
            expected.Add(new List<int>() { 2,5 });
            expected.Add(new List<int>() { 3 });
            expected.Add(new List<int>() { 5,3 });
            expected.Add(new List<int>() { 10 });

            SubarraysWithProductLessThanTargetTestBase(new int[] { 2, 5, 3, 10 }, 30, expected);
        }
        [Fact]
        public void SubarraysWithProductLessThanTargetTest2()
        {
            List<List<int>> expected = new List<List<int>>();
            expected.Add(new List<int>() { 8 });
            expected.Add(new List<int>() { 2 });
            expected.Add(new List<int>() { 8,2 });
            expected.Add(new List<int>() { 6 });
            expected.Add(new List<int>() { 2,6 });
            expected.Add(new List<int>() { 5 });
            expected.Add(new List<int>() { 6,5 });

            SubarraysWithProductLessThanTargetTestBase(new int[] { 8,2,6,5 }, 50, expected);
        }
        private void SubarraysWithProductLessThanTargetTestBase(int[] nums, int target, List<List<int>> expected)
        {
            List<List<int>> result = TwoPointers.SubarraysWithProductLessThanTarget(nums, target);
            Assert.Equal(expected.Count, result.Count);
            foreach (var list in expected)
            {
                Assert.True(expected.Contains(list));
            }
        }
        [Fact]
        public void DutchNationalFlagTest1()
        {
            DutchNationalFlagTestBase(new int[] { 1, 0, 2, 1, 0 }, new int[] { 0,0,1,1,2 });
        }
        public void DutchNationalFlagTestBase(int[] nums, int[] expectedResult)
        {
            int[] actual = TwoPointers.DutchNationalFlag(nums);
            Assert.NotNull(actual);
            Assert.Equal(actual.Length, expectedResult.Length);
            Assert.Equal(actual, expectedResult);
        }
        [Fact]
        public void QuadrupleSumToTargetTest1()
        {
            List<List<int>> expected = new List<List<int>>();
            expected.Add(new List<int>() { -3, -1, 1, 4 });
            expected.Add(new List<int>() { -3, 1, 1, 2 });
            QuadrupleSumToTargetTestBase(new int[] { 4, 1, 2, -1, 1, -3 }, 1, expected);
        }
        [Fact]
        public void QuadrupleSumToTargetTest2()
        {
            List<List<int>> expected = new List<List<int>>();
            expected.Add(new List<int>() { -2, 0, 2, 2 });
            expected.Add(new List<int>() { -1, 0, 1, 2 });
            QuadrupleSumToTargetTestBase(new int[] { 2, 0, -1, 1, -2, 2 }, 2, expected);
        }
        private void QuadrupleSumToTargetTestBase(int[] nums, int target, List<List<int>> expected)
        {
            List<List<int>> result = TwoPointers.QuadrupleSumToTarget(nums, target);
            Assert.Equal(expected, result);
        }
        [Fact]
        public void CompareStringsBackspaceTests()
        {
            Assert.True(TwoPointers.CompareStringsBackspace("xy#z", "xzz#"));
            Assert.False(TwoPointers.CompareStringsBackspace("xy#z", "xyz#"));
            Assert.True(TwoPointers.CompareStringsBackspace("xp#", "xyz##"));
            Assert.True(TwoPointers.CompareStringsBackspace("xywrrmp", "xywrrmu#p"));
        }

        [Fact]
        public void MinimumWindowSortTest1()
        {
            MinimumWindowSortTestBase(new int[] { 1, 2, 5, 3, 7, 10, 9, 12 }, 5);
        }
        [Fact]
        public void MinimumWindowSortTest2()
        {
            MinimumWindowSortTestBase(new int[] { 1, 3, 2, 0, -1, 7, 10 }, 5);
        }
        public void MinimumWindowSortTestBase(int[] nums, int expectedLength)
        {
            int actual = TwoPointers.MinimumWindowSort(nums);
            Assert.Equal(expectedLength, actual);
        }
    }
}

