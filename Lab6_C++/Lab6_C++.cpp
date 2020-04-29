
#include <iostream>
#include "Vyraz.h"

int main()
{
    Vyraz example[] = { Vyraz(),  Vyraz(1, 2, 0, 42),  Vyraz(0, 0, 0, 41) };
    example[0].setA(1);
    example[0].setB(2);
    example[0].setC(3);
    example[0].setD(4);


    for (int i = 0; i < 3; i++)
    {
        std::cout << example[i].Calc()<<"\n";
    }

    double second_example = example[0] / 3;
    std::cout << second_example;

}
