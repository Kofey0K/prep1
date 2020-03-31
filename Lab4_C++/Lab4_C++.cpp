#include <iostream>
#include <math.h>

class Triangle
{
private:
    double P11 = 0, P12 = 0, P22 = 0, P21 = 1, P31 = 1, P32 = 0;
    double Side(double a11, double a12, double a21, double a22)
    {
        return sqrt((a21 - a11) * (a21 - a11) + (a22 - a12) * (a22 - a12));
    }
public:
    Triangle() = default;

    Triangle(double _p11, double _p12, double _p21, double _p22, double _p31, double _p32)
    {
        P11 = _p11;
        P12 = _p12;
        P21 = _p21;
        P22 = _p22;
        P31 = _p31;
        P32 = _p32;
    }
    Triangle(Triangle& st) : Triangle(st.GetP11(), st.GetP12(), st.GetP21(), st.GetP22(), st.GetP31(), st.GetP32()) { }


    double Perimeter()
    {
        return Side(P11, P12, P21, P22) + Side(P21, P22, P31, P32) + Side(P11, P12, P31, P32);
    }
    double Area()
    {
        return abs(((P11 - P31) * (P22 - P32) - (P21 - P31) * (P12 - P32)) / 2);
    }
    Triangle operator+(Triangle t)
    {
        Triangle result(GetP11() + t.GetP11(), GetP12() + t.GetP12(), GetP21() + t.GetP21(), GetP22() + t.GetP22(), GetP31() + t.GetP31(), GetP32() + t.GetP32());
        return result;
    }
    Triangle operator *(double num)
    {
        Triangle result(GetP11() * num, GetP12() * num, GetP21() * num, GetP22() * num, GetP31() * num, GetP32() * num);
        return result;
    }

    void PrintInfo()
    {
        std::cout << "Координати вершин трикутника: (" << P11 << ", " << P12 << "), (" << P21 << ", " << P22 << "), (" << P31 << ", " << P32 << ").\n";
        std::cout << "Його площа: " << Area() << std::endl;
        std::cout << "Його периметр: " << Perimeter() << "\n\n";
    }
    double GetP11()
    {
        return P11;
    }
    double GetP21()
    {
        return P21;
    }
    double GetP31()
    {
        return P31;
    }
    double GetP12()
    {
        return P12;
    }
    double GetP22()
    {
        return P22;
    }
    double GetP32()
    {
        return P32;
    }
};
Triangle operator *(double num, Triangle& t1)
{
    Triangle result(t1.GetP11() * num, t1.GetP12() * num, t1.GetP21() * num, t1.GetP22() * num, t1.GetP31() * num, t1.GetP32() * num);
    return result;
}



int main()
{
    setlocale(LC_CTYPE, "ukr");
    double a = 1, b = 2, c = 3, d = 4, e = 5, f = 7;
    Triangle T1;
    Triangle T2(a, b, c, d, e, f);
    Triangle T3(T2);
    T3 = T3 * 2;

    T1.PrintInfo();
    T2.PrintInfo();
    T3.PrintInfo();
    T1 = T2 + T3;
    T1.PrintInfo();
    T1 = 2 * T1;
    T1.PrintInfo();
}