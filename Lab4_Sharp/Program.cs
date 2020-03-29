using System;

namespace Lab4_Sharp
{
    class Program
    {
        
        static void Main(string[] args)
        {

            double a = 1, b = 2, c = 3, d = 4, e = 5, f = 7;
            Triangle T1 = new Triangle();
            Triangle T2 = new Triangle(a,b,c,d,e,f);
            Triangle T3 = new Triangle(T2);
            T3 *= 2;
            T1.PrintInfo();
            T2.PrintInfo();
            T3.PrintInfo();
            T1 = T2 + T3;
            T1.PrintInfo();
        }
        
        class Triangle
        {
            private double P11, P12, P22, P21, P31, P32;
            public Triangle() : this(0, 0, 0, 1, 1, 0) { }
            public Triangle(double _p11, double _p12, double _p21, double _p22, double _p31, double _p32)
            {                
                 P11 = _p11;
                 P12 = _p12;
                 P21 = _p21;
                 P22 = _p22;
                 P31 = _p31;
                 P32 = _p32;
            }
            public Triangle(Triangle st) : this(st.GetP11(), st.GetP12(), st.GetP21(), st.GetP22(), st.GetP31(), st.GetP32()) { }
            
            private double Side(double a11, double a12, double a21, double a22)
            {
                return Math.Sqrt((a21-a11)* (a21 - a11)+ (a22 - a12) * (a22 - a12));
            }
            public double Perimeter()
            {
                return Side(P11, P12, P21, P22) + Side(P21, P22, P31, P32) + Side(P11, P12, P31, P32);
            }
            public double Area()
            {
                return Math.Abs(((P11 - P31) * (P22 - P32) - (P21 - P31) * (P12 - P32)) / 2);
            }
            public static Triangle operator +(Triangle t1, Triangle t2)
            {
                Triangle result = new Triangle(t1.GetP11() + t2.GetP11(), t1.GetP12() + t2.GetP12(), t1.GetP21() + t2.GetP21(), t1.GetP22() + t2.GetP22(), t1.GetP31() + t2.GetP31(), t1.GetP32() + t2.GetP32());
                return result;
            }
            public static Triangle operator *(Triangle t1, double num)
            {
                Triangle result = new Triangle(t1.GetP11() * num, t1.GetP12() * num, t1.GetP21() * num, t1.GetP22() * num, t1.GetP31() * num, t1.GetP32() * num);
                return result;
            }
            public static Triangle operator *(double num,Triangle t1)
            {
                Triangle result = new Triangle(t1.GetP11() * num, t1.GetP12() * num, t1.GetP21() * num, t1.GetP22() * num, t1.GetP31() * num, t1.GetP32() * num);
                return result;
            }
            public void PrintInfo()
            {
                Console.WriteLine("Координати вершин трикутника: (" + P11 + ", " + P12 + "), (" + P21 + ", " + P22 + "), (" + P31 + ", " + P32 + ").");
                Console.WriteLine("Його площа: "+Area());
                Console.WriteLine("Його периметр: "+Perimeter()+"\n");
            }
            public double GetP11()
            {
                return P11;
            }
            public double GetP21()
            {
                return P21;
            }
            public double GetP31()
            {
                return P31;
            }
            public double GetP12()
            {
                return P12;
            }
            public double GetP22()
            {
                return P22;
            }
            public double GetP32()
            {
                return P32;
            }
            public double p11
            {
                get => P11;
                set => P11 = value;
            }
            public double p12
            {
                get => P12;
                set => P12 = value;
            }
            public double p21
            {
                get => P21;
                set => P21 = value;
            }
            public double p22
            {
                get => P22;
                set => P22 = value;
            }
            public double p31
            {
                get => P31;
                set => P31 = value;
            }
            public double p32
            {
                get => P32;
                set => P32 = value;
            }
        }
    }
}
