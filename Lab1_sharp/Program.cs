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
            bool result = true;
            int size = Marshal.SizeOf(value1) * 8;
            if ((value1 & 1 << size - 1) != 0 || (value2 & 1 << size - 1) != 0)
                for (int i = 0; i < size; i++)
                {
                    if ((value1 & 1 << i) != 0 && (value2 & 1 << i) == 0)
                        result =  false;
                    if ((value2 & 1 << i) != 0 && (value1 & 1 << i) == 0)
                        result = true;
                }
            else
                for (int i = size - 1; i >= 0; i--)
                {
                    if ((value1 & 1 << i) != 0 && (value2 & 1 << i) == 0)
                        result = false;
                    if ((value2 & 1 << i) != 0 && (value1 & 1 << i) == 0)
                        result =  true;
                }
            if (value1 * value2 < 0)
            {
                if (result == true)
                {
                    result = false;
                }
                else
                {
                    result = true;
                }
                
            }
            return result;
        }
        static void PlusOne(ref int a)
        {
            for (int i = 1; ((a ^= i) & i) == 0; i <<= 1) ;
        }
    }
}
