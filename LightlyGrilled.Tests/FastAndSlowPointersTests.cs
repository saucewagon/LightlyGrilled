using System;
using Xunit;

namespace LightlyGrilled.Tests
{
	public class FastAndSlowPointersTests
	{
		[Fact]
		public void LinkedListHasCyclePositiveTest()
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

			PrintLinkedList(head);
			Assert.True(FastAndSlowPointers.LinkedListHasCycle(head));
		}
        [Fact]
        public void LinkedListHasCycleNegativeTest()
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

            PrintLinkedList(head);
            Assert.False(FastAndSlowPointers.LinkedListHasCycle(head));
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

