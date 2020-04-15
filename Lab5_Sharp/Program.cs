using System;

namespace Lab5_Sharp
{
    class Program
    {
        static void Main(string[] args)
        {
            //first task

            double[,] xpoints = { { 1, 1 }, { 3, 1 }, { 3, 3 }, { 1, 3 } };
            double[,] bad = { { 0, 1 }, { 3, 0 }, { 3, 3 }, { 0, 3 } };
            Square sq = new Square(xpoints);
            Square sq2 = new Square(bad);
            double[,] a = sq.Points;
            Console.WriteLine("Side: "+sq.side);
            Console.WriteLine("Area: "+sq.Area());
            Console.WriteLine("Perimeter: "+sq.Perimeter());

            //second task

            CAPITAL ya = new CAPITAL("lowerCAPITALBBBB");
            char[] k = ya.Symb();
            Console.WriteLine(k);
            Console.WriteLine("Amount of chars 'B': "+ya.FindChar());
            Console.WriteLine("Length: "+ya.Leng());
            SYMBOLS stars = new SYMBOLS("lowBIG***");
            Console.WriteLine(stars.Symb());
            Console.WriteLine("Amount of chars '*': " + stars.FindChar());
            Console.WriteLine("Length: " + stars.Leng());
        }
    }
}
