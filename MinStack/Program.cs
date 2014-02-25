using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

// Implement a Stack with Min(), Pop() and Push() operations

namespace MinStack
{
    class Program
    {
        static void Main(string[] args)
        {
            // Test case 1
            Console.WriteLine("Test case 1");
            StackWithMin stack = new StackWithMin();

            stack.Push(5);
            Console.WriteLine("Min is {0}", stack.Min());

            stack.Push(6);
            Console.WriteLine("Min is {0}", stack.Min());

            stack.Push(3);
            Console.WriteLine("Min is {0}", stack.Min());

            stack.Push(7);
            Console.WriteLine("Min is {0}", stack.Min());

            stack.Push(3);
            Console.WriteLine("Min is {0}", stack.Min());

            stack.Pop();
            Console.WriteLine("Min is {0}", stack.Min());

            stack.Pop();
            Console.WriteLine("Min is {0}", stack.Min());

            // Test case 2
            Console.WriteLine("Test case 2");
            StackWithMinV2 stack2 = new StackWithMinV2();

            stack2.Push(5);
            Console.WriteLine("Min is {0}", stack2.Min());

            stack2.Push(6);
            Console.WriteLine("Min is {0}", stack2.Min());

            stack2.Push(3);
            Console.WriteLine("Min is {0}", stack2.Min());

            stack2.Push(7);
            Console.WriteLine("Min is {0}", stack2.Min());

            stack2.Push(3);
            Console.WriteLine("Min is {0}", stack2.Min());

            stack2.Pop();
            Console.WriteLine("Min is {0}", stack2.Min());

            stack2.Pop();
            Console.WriteLine("Min is {0}", stack2.Min());

        }


    }

    // Uses a stack with a custom class that keeps
    // track of min with each value
    class StackWithMin
    {
        private Stack<NodeWithMin> stack = new Stack<NodeWithMin>();

        public void Push(int value)
        {
            int newMin = Math.Min(value, Min());

            NodeWithMin newNode = new NodeWithMin();
            newNode.Value = value;
            newNode.Min = newMin;
            stack.Push(newNode);
        }

        public int Min()
        {
            if (stack.Count == 0)
            {
                return Int32.MaxValue;
            }
            else
            {
                return stack.Peek().Min;
            }
        }

        public int Pop()
        {
            return stack.Pop().Value;
        }

    }

    class NodeWithMin
    {
        public int Value { get; set; }

        public int Min { get; set; }
    }

    class StackWithMinV2
    {
        private Stack<int> stack = new Stack<int>();

        private Stack<int> minStack = new Stack<int>();

        public void Push(int value)
        {
            stack.Push(value);

            if (minStack.Count > 0)
            {
                // NOTE: Comparison should be '<=' if this 
                // needs to work for duplicate values
                if (value <= minStack.Peek())
                {
                    minStack.Push(value);
                }
            }
            else
            {
                minStack.Push(value);
            }
        }

        public int Pop()
        {
            if (stack.Count == 0)
            {
                throw new Exception("Cannot pop from empty stack");
            }

            int poppedValue = stack.Pop();

            if (poppedValue == minStack.Peek())
            {
                minStack.Pop();
            }

            return poppedValue;
        }

        public int Min()
        {
            return minStack.Peek();
        }
    }


}
