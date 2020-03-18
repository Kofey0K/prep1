using System;

namespace oop_lab3
{
    class Program
    {
        static void Main(string[] args)
        {
            Text one = new Text(2,2);
            one.Add(0, 0, '1');
            one.Add(0, 1, 'a');
            one.Add(1, 0, '2');
            one.Add(1, 1, 'b');
            Console.WriteLine(one.IntCount);
            Console.WriteLine(one[0]);
            Console.WriteLine(one[1]);

        }
    }

    class Text
    {
        readonly char[,] text;
        private int intCount;
        private string output;

        public Text(int row, int column)
        {
            text = new char[row, column];
        }

        public void Add(int row, int column, char value)
        {
            text[row,column] = value;
            if (value >= 48 && value <= 57) intCount++;
            return;
        }
        public string this[int index]
        {

            get
            {
                output = "";
                for (int i = 0; i < text.GetUpperBound(1) + 1; i++)
                    output += text[i, index];
                return output;
            }
        }
        public int IntCount
        {
            get => intCount;
        }
    }
}