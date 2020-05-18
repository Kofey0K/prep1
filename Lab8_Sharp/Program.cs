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

            double[] nums2 = new double[4] { 1, 2, 3, 5 };

            double[] nums3 = new double[] { 1, 2, 3, 5 };

            Console.WriteLine(Tariff1.CompareExemplary(nums2, nums3, 0) ); 
            Lib.EqualityDelegate my_delegate = Lib.Compare;
            Console.WriteLine(my_delegate(nums2,nums3,0));
        }
    }
}
