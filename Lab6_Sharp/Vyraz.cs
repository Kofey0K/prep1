using System;
using System.Collections.Generic;
using System.Text;

namespace Lab6_Sharp
{
    class Vyraz
    {
        public double a { get; set; }
        public double b { get; set; }
        public double c { get; set; }
        public double d { get; set; }

        public Vyraz()
        {
            
        }
        public Vyraz(double aa, double bb, double cc, double dd)
        {
            a = aa;
            b = bb;
            c = cc;
            d = dd;
        }
        public double Calc()
        {
            double res;
            try {
                if (Double.IsNaN(Math.Sqrt(41 - d))) { throw new Exception("Square root of a negative number was taken."); }
                if ((Math.Sqrt(41 - d) - b * a + c)==0) { throw new Exception("Division by zero."); }
                res = (a * b / 4 - 1) / (Math.Sqrt(41 - d) - b * a + c);
                return res;
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
            return -1;
        }
        public static double operator /(Vyraz a, double b)
        {
            try
            {
                if (b == 0)
                {
                    throw new Exception("Division by zero.");
                }
                return a.Calc() / b;
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
            return -1;
        }

    }
}
