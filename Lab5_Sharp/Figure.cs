using System;
using System.Collections.Generic;
using System.Text;

namespace Lab5_Sharp
{
    class Figure
    {
        protected double[,] points;
        protected double[] sides;
        public Figure(double[,] ex)
        {
            points = ex;
            List<double> temp = new List<double>();
            for (int i = 0; i < points.Length/2-1; i++)
            {
                temp.Add(GetSide(i, i + 1));
            }
            temp.Add(GetSide(0, points.Length / 2 - 1));
            sides = temp.ToArray();
        }
        public virtual double GetSide(int p1, int p2)
        {
            return Math.Sqrt(Math.Pow(points[p2, 0] - points[p1, 0],2)+ Math.Pow(points[p2, 1] - points[p1, 1], 2));
        }
        
    }
}
