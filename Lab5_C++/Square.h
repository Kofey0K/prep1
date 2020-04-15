#pragma once
#include "Figure.h"
#include <iostream>


class Square :
    public Figure
{
private:
    double side;
public:

    Square(double ex[4][2]) :Figure(ex)
    {
        for (int i = 0; i < 3; i++)
        {
            if (sides[i] != sides[i + 1] || GetSide(0, 2) != GetSide(1, 3))
            {
                std::cout << "Not a square!\n";
                break;
            }
        }
        side = sides[0];
    }
    double Area()
    {
        return side * side;
    }
    double Perimeter()
    {
        return 4 * side;
    }
    double Side() {
        return side;
    }
};

