using System;
using System.Runtime.InteropServices;

namespace Lab1_sharp
{
    class Program
    {
        static void Main(string[] args)
        {
            
        }
        static bool IsSmaller(int value1, int value2)
        {
            int size = Marshal.SizeOf(value2) * 8;
            if ((value2 & 1 << size - 1) != 0 || (value1 & 1 << size - 1) != 0)
                for (int i = 0; i < size; i++)
                {
                    if ((value2 & 1 << i) != 0 && (value1 & 1 << i) == 0)
                        return true;
                    if ((value1 & 1 << i) != 0 && (value2 & 1 << i) == 0)
                        return false;
                }
            else
                for (int i = size - 1; i >= 0; i--)
                {
                    if ((value2 & 1 << i) != 0 && (value1 & 1 << i) == 0)
                        return true;
                    if ((value1 & 1 << i) != 0 && (value2 & 1 << i) == 0)
                        return false;
                }
            return false;
        }
    }
}
