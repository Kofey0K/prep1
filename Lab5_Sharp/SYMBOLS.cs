using System;
using System.Collections.Generic;
using System.Text;

namespace Lab5_Sharp
{
    class SYMBOLS:STRING
    {
        
        public SYMBOLS(string str)
        {
            symb = new char[str.Length];
            for (int i = 0; i < symb.Length; i++)
            {
                symb[i] = str[i];
            }
        }
        public char[] Symb()
        {
            return symb;
        }
        public override int Leng()
        {
            return symb.Length;
        }
        public override int FindChar()
        {
            int counter = 0;
            for (int i = 0; i < symb.Length; i++)
            {
                if (symb[i] == '*'){
                    counter++;
                }
            }
            return counter;
        }
    }
}
