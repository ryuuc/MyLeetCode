using MyLeetCode.CSharp.BaseModels;

namespace MyLeetCode.CSharp;

public class AddTwoNumbersSolution : BaseSolution
{
    public override string ProblemName => "Add Two Numbers";

    public override string ProblemDescription =>
        "You are given two non-empty linked lists representing two non-negative integers. The digits are stored in reverse order, and each of their nodes contains a single digit. Add the two numbers and return the sum as a linked list.\n\nYou may assume the two numbers do not contain any leading zero, except the number 0 itself.";

    public override string ProblemUrl => "https://leetcode.com/problems/add-two-numbers";
    public override Level ProblemLevel => Level.Medium;

    public override SpaceComplexity SpaceComplexity => SpaceComplexity.LinearOrder;
    public override TimeComplexity TimeComplexity => TimeComplexity.LinearOrder;

    public ListNode AddTwoNumbers(ListNode l1, ListNode l2)
    {
        var dummyHead = new ListNode(0);
        var current = dummyHead;
        var carry = 0;

        while (l1 != null || l2 != null || carry > 0)
        {
            var sum = (l1 == null ? 0 : l1.val) + (l2 == null ? 0 : l2.val) + carry;
            carry = sum / 10;
            current.next = new ListNode(sum % 10);
            current = current.next;

            if (l1 != null) l1 = l1.next;
            if (l2 != null) l2 = l2.next;
        }

        return dummyHead.next;
    }

    public ListNode AddTwoNumbers_v2(ListNode l1, ListNode l2, int carry = 0)
    {
        if (l1 == null && l2 == null && carry == 0) return null;
        var total = (l1 != null ? l1.val : 0) + (l2 != null ? l2.val : 0) + carry;
        carry = total / 10;
        return new ListNode(total % 10, AddTwoNumbers_v2(l1?.next, l2?.next, carry));
    }

    public ListNode AddTwoNumbers_v1(ListNode l1, ListNode l2)
    {
        var total = l1.val + l2.val;
        var result = new ListNode(total > 9 ? total - 10 : total);
        if (l1.next != null || l2.next != null || total > 9)
        {
            if (l1.next == null)
            {
                l1.next = new ListNode(total > 9 ? 1 : 0);
            }
            else
            {
                l1.next.val = total > 9 ? l1.next.val + 1 : l1.next.val;
            }

            result.next = AddTwoNumbers_v1(l1.next,
                l2.next == null ? new ListNode(0) : l2.next);
        }

        return result;
    }

    /// <summary>
    /// Definition for singly-linked list
    /// </summary>
    public class ListNode
    {
        public int val;
        public ListNode next;

        public ListNode(int val = 0, ListNode next = null)
        {
            this.val = val;
            this.next = next;
        }
    }
}