using System;
using System.Collections.Generic;
using System.Text;

namespace Lab5_Sharp
{
    class CAPITAL:STRING
    {
        
        public CAPITAL(string str)
        {
            char[] temp = new char[str.Length];
            int counter1 = 0, counter2 = 0;
            for (int i = 0; i < str.Length; i++)
            {
                if (str[i] < 65 || str[i] > 90)
                {
                    Console.WriteLine(str[i] + " - not a capital letter!");
                    counter2++;
                }
                else
                {
                    temp[counter1] = str[i];
                    counter1++;
                }
            }
            symb = new char[temp.Length - counter2];
            for (int j = 0; j < symb.Length; j++)
            {
                symb[j] = temp[j];
            }
        }
        public char[] Symb()
        {
            return symb;
        }
        public override int FindChar()
        {
            int counter = 0;
            for (int i = 0; i < symb.Length; i++)
            {
                if (symb[i] == 'B')
                {
                    counter++;
                }
            }
            return counter;
        }
        public override int Leng()
        {
            return symb.Length;
        }
    }
}
