using System;
using System.Collections.Generic;
using System.Text;

namespace Lab5_Sharp
{
    class Square:Figure
    {
        public double side { get; }
        public Square(double[,] ex):base(ex)
        {
            for (int i = 0; i < sides.Length-1; i++)
            {
                if (sides[i] != sides[i + 1] || GetSide(0,2)!=GetSide(1,3))
                {
                    Console.WriteLine("Not a square!");
                    break;
                } 
            }
            side = sides[0];  
        }
        public double Area()
        {
            return side * side;
        }
        public double Perimeter()
        {
            return 4 * side;
        }
        public double[,] Points
        {
            get => points;
        }
    }
}
