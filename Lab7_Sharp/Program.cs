using System;

namespace Lab7_Sharp
{
    
    
    class Program
    {
        static void Main(string[] args)
        {
            TwoWayList example = new TwoWayList();
            example.AddFirst(4.5);
            example.AddFirst(21);
            example.AddFirst(322);
            example.AddFirst(24);
            example.AddFirst(80);
            example.AddFirst(11);
            example.AddFirst(3);
            Console.WriteLine($"Average: {example.Sum() / example.Count}");
            Console.WriteLine($"Sum of all numbers: {example.Sum()}");
            Console.WriteLine($"Number of elements lesser than average: {example.LettersLessThanAvg()}");
            Console.WriteLine($"Max element: {example.FindMaxNode().Data}");
            Console.Write("Before: ");
            foreach (var l in example)
            {
                Console.Write(l + "  ");
            }
            Console.WriteLine();
            Console.Write("After deleting elements after the max one: ");
            example.DeleteNodesAfterMax();
            foreach (var l in example)
            {
                Console.Write(l+"  ");
            }
            Console.WriteLine();

        }
    }
}