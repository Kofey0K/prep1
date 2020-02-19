using System;
using System.Runtime.InteropServices;

namespace Lab1_sharp
{
    class Program
    {
        static void Main(string[] args)
        {
            int a = -128;
            PlusOne(ref a);
            bool result = IsSmaller(33, 1);
        }
        static bool IsSmaller(int value1, int value2)
        {
 
            int size = Marshal.SizeOf(value1) * 8;
            if ((value1 & 1 << size - 1) != 0 && (value2 & 1 << size - 1) == 0)
            {
                return true;
            }
            if ((value1 & 1 << size - 1) == 0 && (value2 & 1 << size - 1) != 0)
            {
                return false;
            }
            else
                for (int i = size - 1; i >= 0; i--)
                {
                    if ((value1 & 1 << i) != 0 && (value2 & 1 << i) == 0)
                        return false;
                    if ((value2 & 1 << i) != 0 && (value1 & 1 << i) == 0)
                        return true;
                }

            return false;
        }
        static void PlusOne(ref int a)
        {
            //for (int i = 1; ((a ^= i) & i) == 0; i <<= 1)
            int i = 1;
            while (((a ^= i) & i) == 0)
            {
                i <<= 1;
            }
                
        }
    }
}
