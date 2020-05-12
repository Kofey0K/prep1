using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab8_SharpLib
{
    public class Lib
    {
        private int Tariff;
        private decimal account, price;
        private double speed, megabytes;
        public static event TrafficOverloadHandler Notify = (string message) => { Console.WriteLine(message); };
        public delegate void TrafficOverloadHandler(string message);
        public delegate bool EqualityDelegate(double[] ar1, double[] ar2, int i);
        public Lib(int choose) {
            
            account = 0;
            Set_Values(choose);
            }
        public Lib(int choose, decimal money)
        {
            Set_Values(choose);
            account = money;
        }
        public void Choose_Tariff(int choose)
        {
            Set_Values(choose);
            account -= 10;
        }
        private void Set_Values(int choose)
        {
            switch (choose)
            {
                case 1:
                    Tariff = choose;
                    speed = 30;
                    megabytes = 4000;
                    price = 60;
                    break;
                case 2:
                    Tariff = choose;
                    speed = 30;
                    megabytes = 8000;
                    price = 80;
                    break;
                case 3:
                    Tariff = choose;
                    speed = 60;
                    megabytes = 12000;
                    price = 100;
                    break;
                case 4:
                    Tariff = choose;
                    speed = 60;
                    megabytes = 16000;
                    price = 120;
                    break;
                default:
                    Console.WriteLine("The chosen tariff is missing.");
                    break;
            }
        }
        public void AddMoney(decimal money)
        {
            account += money;
        }
        public void Check()
        {
            Console.WriteLine("You have "+account+" left on your account. Megabytes left: "+megabytes);
        }
        public void UseInternet(double hours)
        {
            if (hours > 0)
            {
                for (double i = 0; i < hours; i+=0.1)
                {
                    megabytes -= speed * 2.5;
                    if (megabytes <= 0)
                    {
                        Notify?.Invoke("You have no megabytes left!");
                        megabytes = 0;
                        return;
                    }
                }
            }
        }
        public void NextDay()
        {
            account -= price / 30;
            if (account < 0) { megabytes = 0; }
        }
        public static bool Compare(double[] arr1, double[] arr2, int i)
        {
            return arr1[i] == arr2[i];
        }
        public bool CompareExemplary(double[] arr1, double[] arr2, int i)
        {
            return arr1[i] == arr2[i];
        }
        
    }
}
