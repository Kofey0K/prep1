
#include <iostream>
#include "Lib.h"

bool Compare(double arr1[], double arr2[], int i) {
    return arr1[i] == arr2[i];
}
bool (*point)(double arr1[], double arr2[], int i);

int main()
{
    /*Lib Tariff1(1);
    Tariff1.AddMoney(100);
    Tariff1.UseInternet(3.4);
    Tariff1.NextDay();
    Tariff1.Check();
    Tariff1.UseInternet(3.4);
    Tariff1.Check();*/

    double a[3] = { 1,2,3 };
    double b[3] = { 3,2,1 };

    point = Compare;
    std::cout << point(a, b, 1) << "\n";
    std::cout << point(a, b, 2) << "\n";
}

