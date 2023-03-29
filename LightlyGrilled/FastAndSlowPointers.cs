using System;
using System.Collections.Generic;

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
		public static ListNode GetStartOfLinkedListCycle(ListNode head)
		{
			ListNode pointer1 = head;
			ListNode pointer2 = head;
			int k = GetLinkedListCycleLength(head);

			int count = 0;
			while (count < k)
			{
				pointer1 = pointer1.Next;
				count++;
			}
			while (pointer1!= pointer2)
			{
				pointer1 = pointer1.Next;
				pointer2 = pointer2.Next;
			}


			return pointer1;
		}

        public static int GetLinkedListCycleLength(ListNode head)
        {
            if (head == null) return 0;
            ListNode fast = head.Next;
            ListNode slow = head;

            while (fast != null && fast.Next != null)
            {
                if (fast == slow)
                {
                    return CalculateLength(slow);
                }
                slow = slow.Next;
                fast = fast.Next.Next;
            }
            return 0;
        }

        private static int CalculateLength(ListNode slow)
        {
			int count = 1;

			ListNode trav = slow.Next;
			while(trav != slow)
			{
                trav = trav.Next;
                count++;

			}
			return count;
        }

        public static bool IsHappyNumber(int num)
        {
			// while something
			// iterate over each digit to calculate the happy number
			// if sum is 1 return true
			// else add to list
			// if the sum has been seen before return false

			var seenBefore = new HashSet<int>();
			int sum = num;

			while (true)
			{
				sum = GetSquaredSumOfDigits(sum);
				if (sum == 1) return true;
				else
				{
					if (seenBefore.Contains(sum))
					{
						return false;
					}
					else
					{
						seenBefore.Add(sum);
					}
				}
			}
        }

        private static int GetSquaredSumOfDigits(int num)
        {
			double sum = 0;

			while(num > 0)
			{
				int rightmostDigit = num % 10;
				sum += Math.Pow((double)rightmostDigit, 2);
				num /= 10;
			}

			return (int)sum;
        }

        public static ListNode GetMiddleNode(ListNode head)
        {
			ListNode middle = head;

			ListNode fast = head;
			ListNode slow = head;

			while (slow != null && fast != null && fast.Next != null)
			{
				slow = slow.Next;
				fast = fast.Next.Next;
			}
			return slow;
        }

        public static bool LinkedListIsPalindrome(ListNode head)
        {
			var middleNode = GetMiddleNode(head);
			// reverse the list starting at the node after the middlenode
			ListNode newMiddleNodePlusOne = reverseList(middleNode.Next);
			middleNode.Next = newMiddleNodePlusOne;

			ListNode fast = middleNode.Next;
			ListNode slow = head;

			while (fast != null)
			{
				if (slow.Value != fast.Value) return false;
				slow = slow.Next;
				fast = fast.Next;
			}

			return true;
        }

        private static ListNode reverseList(ListNode head)
        {
			ListNode prev = null;

			while (head != null)
			{
				ListNode next = head.Next;
                head.Next = prev;
				prev = head;
                head = next;
			}
			return prev;
        }

        public static ListNode RearrangeLinkedList(ListNode head)
        {
            var middleNode = GetMiddleNode(head);
            ListNode newMiddleNodePlusOne = reverseList(middleNode);

            ListNode fast = newMiddleNodePlusOne;
            ListNode slow = head;

            while (slow != null && fast != null)
            {
				ListNode tmp = slow.Next;
				slow.Next = fast;
				slow = tmp;

                tmp = fast.Next;
                fast.Next = slow;
				fast = tmp;
            }
			if (slow != null)
			{
				slow.Next = null;
			}
			return head;
        }

        public static bool CycleInCircularArray(int[] nums)
        {

			for (int i = 0; i < nums.Length; i++)
			{
				bool isMovingForward = nums[i] >= 0;
				int slow = i;
				int fast = i;

				do
				{
					slow = findNextIndex(nums, isMovingForward, slow);
					fast = findNextIndex(nums, isMovingForward, fast);
					if (fast != -1)
					{
						fast = findNextIndex(nums, isMovingForward, fast);
					}
				} while (slow != -1 && fast != -1 && slow != fast);

				if (slow != -1 && slow == fast)
				{
					return true;
				}
			}
			return false;
        }

        private static int findNextIndex(int[] nums, bool isMovingForward, int currentIndex)
        {
			if (nums[currentIndex] >= 0 != isMovingForward) return -1;
			int next = (currentIndex + nums[currentIndex]) % nums.Length;

			if (next < 0)
			{
				next += nums.Length;
			}
			if (next == currentIndex) return -1;

			return next;
        }
    }
}

