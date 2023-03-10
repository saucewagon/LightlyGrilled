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

