using System;

namespace Lab2_SharpLib
{
    class Program
    {
        static void Main(string[] args)
        {
            Class_str h = new Class_str(new char[] { 'h', 'e', 'l', 'l', 'o', ' ' });
            
            Class_str w = new Class_str(new char[] { 'w', 'o', 'r', 'l', 'd', '3' });
            Class_text t = new Class_text(new Class_str[] { h });
            
            t.Add(w);
            t.Del(h);
            int xd = t.Elements();
            Console.WriteLine(xd);
            t.Clear();
            t.Add(h);
            t.Add(h);
            t.Add(w);
            Console.WriteLine(t.HowMany(h));
        }

    }
}