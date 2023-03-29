using System;
using Xunit;

namespace LightlyGrilled.Tests
{
	public class FastAndSlowPointersTests
	{
		private ListNode CreateLinkedListWithCycle()
		{
            ListNode head = new ListNode(1, null);
            ListNode trav = head;
            ListNode cycleNode = new ListNode();
            int i = 2;
            while (i <= 6)
            {
                trav.Next = new ListNode(i, null);
                trav = trav.Next;

                if (i == 3)
                {
                    cycleNode = trav;
                }
                i++;

            }
            trav.Next = cycleNode;
            return head;
        }
		private ListNode CreateLinkedListWithNoCycle()
		{
            ListNode head = new ListNode(1, null);
            ListNode trav = head;
            int i = 2;
            while (i <= 6)
            {
                trav.Next = new ListNode(i, null);
                trav = trav.Next;
                i++;
            }
            return head;
        }
		[Fact]
		public void LinkedListHasCyclePositiveTest()
		{
            var head = CreateLinkedListWithCycle();
			Assert.True(FastAndSlowPointers.LinkedListHasCycle(head));
		}
        [Fact]
        public void LinkedListHasCycleNegativeTest()
        {
            var head = CreateLinkedListWithNoCycle();
            Assert.False(FastAndSlowPointers.LinkedListHasCycle(head));
        }
        [Fact]
        public void CycleLengthTest()
        {
            var head = CreateLinkedListWithCycle();
            PrintLinkedList(head);
            Assert.Equal(4, FastAndSlowPointers.GetLinkedListCycleLength(head));
        }
        [Fact]
        public void StartOfLinkedListCycleTest()
        {
            var head = CreateLinkedListWithCycle();
            PrintLinkedList(head);
            Assert.Equal(3, FastAndSlowPointers.GetStartOfLinkedListCycle(head).Value);
        }
        [Fact]
        public void HappyNumberTests()
        {
            Assert.True(FastAndSlowPointers.IsHappyNumber(23));
            Assert.False(FastAndSlowPointers.IsHappyNumber(12));
        }
        [Fact]
        public void MiddleOfLinkedListTest1()
        {
            ListNode head = CreateLinkedListWithNoCycle();
            ListNode actualMiddleNode = FastAndSlowPointers.GetMiddleNode(head);
            Assert.Equal(4, actualMiddleNode.Value);
        }
        [Fact]
        public void PalindromeLinkedListPositiveTest()
        {
            ListNode head = new ListNode(2, null);
            head.Next = new ListNode(4, null);
            head.Next.Next = new ListNode(6, null);
            head.Next.Next.Next = new ListNode(4, null);
            head.Next.Next.Next.Next = new ListNode(2, null);
            //PrintLinkedList(head);
            Assert.True(FastAndSlowPointers.LinkedListIsPalindrome(head));
            PrintLinkedList(head);
        }
        [Fact]
        public void PalindromeLinkedListNegativeTest()
        {
            ListNode head = new ListNode(2, null);
            head.Next = new ListNode(4, null);
            head.Next.Next = new ListNode(6, null);
            head.Next.Next.Next = new ListNode(4, null);
            head.Next.Next.Next.Next = new ListNode(2, null);
            head.Next.Next.Next.Next.Next = new ListNode(2, null);
            //PrintLinkedList(head);
            Assert.False(FastAndSlowPointers.LinkedListIsPalindrome(head));
        }
        [Fact]
        public void RearrangeLinkedListTest()
        {
            ListNode head = new ListNode(1, null);
            head.Next = new ListNode(2, null);
            head.Next.Next = new ListNode(3, null);
            head.Next.Next.Next = new ListNode(4, null);
            head.Next.Next.Next.Next = new ListNode(5, null);
            head.Next.Next.Next.Next.Next = new ListNode(6, null);

            ListNode rearrangedHead = FastAndSlowPointers.RearrangeLinkedList(head);

            Assert.Equal(rearrangedHead.Value, 1);
            Assert.Equal(rearrangedHead.Next.Value, 6);
            Assert.Equal(rearrangedHead.Next.Next.Value, 2);
            Assert.Equal(rearrangedHead.Next.Next.Next.Value, 5);
            Assert.Equal(rearrangedHead.Next.Next.Next.Next.Value, 3);
            Assert.Equal(rearrangedHead.Next.Next.Next.Next.Next.Value, 4);
        }
        [Theory]
        [InlineData(1, 2, -1, 2, 2)]
        [InlineData(2, 2, -1, 2)]
        public void CycleInCircularArrayPositiveTest(params int[] nums)
        {
            Assert.True(FastAndSlowPointers.CycleInCircularArray(nums));
        }
        [Theory]
        [InlineData(2, 1, -1, -2)]
        public void CycleInCircularArrayNegativeTest(params int[] nums)
        {
            Assert.False(FastAndSlowPointers.CycleInCircularArray(nums));
        }
        private void PrintLinkedList(ListNode head)
		{
			int count = 0;
			ListNode trav = head;
			while (trav != null)
			{
				Console.Write(trav.Value + " ");
				trav = trav.Next;

				count++;
				if (count == 10) break;
			}
			Console.WriteLine();
		}
	}
}

