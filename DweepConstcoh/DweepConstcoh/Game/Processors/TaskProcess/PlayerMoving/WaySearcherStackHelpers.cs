using System.Collections.Generic;
using CuttingEdge.Conditions;
using MoreLinq;

namespace DweepConstcoh.Game.Processors.TaskProcess.PlayerMoving
{
    public static class WaySearcherStackHelpers
    {
        public static Stack<T> ToStack<T>(
            this IEnumerable<T> items)
        {
            Condition.Requires(items, nameof(items)).IsNotNull();

            var stack = new Stack<T>();

            items.ForEach(item => stack.Push(item));

            return stack;
        }

        public static void PushRange<T>(
            this Stack<T> stack,
            IEnumerable<T> items)
        {
            Condition.Requires(stack, nameof(stack)).IsNotNull();
            Condition.Requires(items, nameof(items)).IsNotNull();

            items.ForEach(item => stack.Push(item));
        }
    }
}
