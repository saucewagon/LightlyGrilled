using System;
namespace LightlyGrilled
{
	public class ListNode
	{
		public int Value { get; set; }
		public ListNode Next { get; set; }
		public ListNode(int value, ListNode next)
		{
			Value = value;
			Next = next;
		}

        public ListNode()
        {
        }
    }
	public class FastAndSlowPointers
	{
		public static bool LinkedListHasCycle(ListNode head)
		{
			if (head == null) return false;
			ListNode fast = head.Next;
			ListNode slow = head;

			while (fast != null && fast.Next != null)
			{
				if (fast == slow)
				{
					return true;
				}
				slow = slow.Next;
				fast = fast.Next.Next;
			}
			return false;
		}
	}
}

