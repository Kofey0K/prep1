#pragma once
#include <math.h>
class Figure
{
protected:
    double points[4][2];
    double sides[4];
public:
    Figure(double ex[4][2])
    {
        for (int i = 0; i < 4; i++)
        {
            for (int j = 0; j < 2; j++)
            {
                points[i][j] = ex[i][j];
            }
        }
        for (int i = 0; i < 3; i++)
        {
            sides[i] = GetSide(i, i + 1);
        }
        sides[3] = GetSide(0, 3);
    }
    virtual double GetSide(int p1, int p2)
    {
        return sqrt(pow(points[p2][0] - points[p1][0], 2) + pow(points[p2][1] - points[p1][1], 2));
    }
};
