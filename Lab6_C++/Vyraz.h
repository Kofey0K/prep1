#pragma once
#include <math.h>
#include <iostream>
#include <fstream>
class Vyraz
{
private:
    double a, b, c, d;

public:
    Vyraz() {}

    Vyraz(double aa, double bb, double cc, double dd)
    {
        a = aa;
        b = bb;
        c = cc;
        d = dd;
    }
    double Calc()
    {
        double res;
        try {
            if (d>41) { throw std::runtime_error("Square root of a negative number was taken."); }
            if ((sqrt(41 - d) - b * a + c) == 0) { throw std::runtime_error("Division by zero."); }
            res = (a * b / 4 - 1) / (sqrt(41 - d) - b * a + c);
            return res;
        }
        catch (std::runtime_error er)
        {
            std::ofstream out("log.txt", std::ios::app);
            if (out.is_open())
            {
                out << er.what() << std::endl;
            }
            out.close();
            std::cout << er.what() << "\n";
        }
        return -1;
    }
    double operator /(double b)
    {
        try
        {
            if (b == 0)
            {
                throw std::runtime_error("Division by zero.");
            }
            return this->Calc() / b;
        }
        catch (std::runtime_error er)
        {
            throw std::runtime_error("Division by zero.");
            std::ofstream out("log.txt", std::ios::app);
            if (out.is_open())
            {
                out << er.what() << std::endl;
            }
            out.close();
            std::cout << er.what() << "\n";
        }
        
        
        return -1;
    }
    double getA() { return a; }
    double getB() { return b; }
    double getC() { return c; }
    double getD() { return d; }

    void setA(int x) { a = x; }
    void setB(int x) { b = x; }
    void setC(int x) { c = x; }
    void setD(int x) { d = x; }
};

