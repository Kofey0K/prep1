using System;
using Lab8_SharpLib;

namespace Lab8_Sharp
{

    class Program
    {
        static void Main(string[] args)
        {
            Lib Tariff1 = new Lib(1);
            Tariff1.AddMoney(100);
            Tariff1.UseInternet(3.4);
            Tariff1.NextDay();
            Tariff1.Check();
            Tariff1.UseInternet(3.4);
            Tariff1.Check();

            double[] a = new double[1];
            double[] b = new double[1];
            a[0] = 2;
            b[0] = 2;
            Tariff1.CompareExemplary(a, b, 0);
            Lib.EqualityDelegate my_delegate = Lib.Compare;
            Console.WriteLine(my_delegate(a,b,0));
        }
    }
}
