using System;

namespace Lab6_Sharp
{
    class Program
    {
        static void Main(string[] args)
        {
            Vyraz[] example = { new Vyraz(), new Vyraz(1, 2, 0, 42), new Vyraz(0,0,0,41) };
            example[0].a = 1;
            example[0].b = 2;
            example[0].c = 3;
            example[0].d = 4;

            foreach (Vyraz item in example)
            {
                Console.WriteLine(item.Calc());
            }

            double second_example = example[0] / 3;
            Console.WriteLine(second_example);
        }

    }
}


