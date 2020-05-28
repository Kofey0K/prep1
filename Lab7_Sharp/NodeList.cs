using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace Lab7_Sharp
{
    public class Node
    {
        public double Data { get; set; }
        public Node Previous { get; set; }
        public Node Next { get; set; }

        public Node(double data)
        {
            Data = data;

        }
    }
    public class TwoWayList
    {
        Node head;
        Node tail;

        public void Add(double data)
        {
            Node node = new Node(data);

            if (head == null)
                head = node;
            else
            {
                tail.Next = node;
                node.Previous = tail;
            }
            tail = node;
            Count++;
        }
        public void AddFirst(double data)
        {
            Node node = new Node(data);
            Node temp = head;
            node.Next = temp;
            head = node;
            if (Count == 0)
                tail = head;
            else
                temp.Previous = node;
            Count++;
        }
        public int Count { get; private set; }
        public bool IsEmpty { get { return Count == 0; } }

        public void Clear()
        {
            head = null;
            tail = null;
            Count = 0;
        }
        public bool Contains(double data)
        {
            Node current = head;
            while (current != null)
            {
                if (current.Data.Equals(data))
                    return true;
                current = current.Next;
            }
            return false;
        }
        public bool Delete(double data)
        {
            Node current = head;
            while (current != null)
            {
                if (current.Data.Equals(data))
                    break;
                current = current.Next;
            }
            if (current != null)
            {
                if (current.Next != null)
                {
                    current.Next.Previous = current.Previous;
                }
                else
                {
                    tail = current.Previous;

                }
                if (current.Previous != null)
                {
                    current.Previous.Next = current.Next;
                }
                else
                {
                    head = current.Next;
                }
                Count--;
                return true;
            }
            return false;
        }
        public void DeleteNodesAfterMax()
        {
            Node max = FindMaxNode();
            Node current = head;
            while (current != max)
            {
                current = current.Next;
            }
            current = current.Next;
            while (current != null)
            {
                Delete(current.Data);
                current = current.Next;
            }

        }


        public IEnumerator GetEnumerator()
        {
            Node current = head;
            while (current != null)
            {
                yield return current.Data;
                current = current.Next;
            }
        }
        public IEnumerable BackEnumerator()
        {
            Node current = tail;
            while (current != null)
            {
                yield return current.Data;
                current = current.Previous;
            }
        }
        public double Sum()
        {
            Node current = head;
            double sum = 0d;
            while (current != null)
            {

                sum += Convert.ToDouble(current.Data);
                current = current.Next;
            }
            return sum;
        }
        public double LettersLessThanAvg()
        {
            Node current = head;
            int counter = 0;
            double data;
            double sum = Sum();
            while (current != null)
            {
                data = Convert.ToDouble(current.Data);
                if (data.CompareTo(sum / Count) < 0) counter++;
                current = current.Next;
            }
            return counter;
        }
        public Node FindMaxNode()
        {
            Node current = head;
            Node max = current;
            while (current != null)
            {

                //find last max
                if (max.Data <= current.Data)

                    max = current;

                current = current.Next;
            }
            return max;
        }


    }
}
