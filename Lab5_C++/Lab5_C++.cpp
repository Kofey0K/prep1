
#include "Square.h"
#include "CAPITAL.h"
#include "SYMBOLS.h"
int main()
{
    //first task

    double xpoints[4][2] = { { 1, 1 }, { 3, 1 }, { 3, 3 }, { 1, 3 } };
    double bad[4][2] = { { 0, 1 }, { 3, 0 }, { 3, 3 }, { 0, 3 } };
    Square sq(xpoints);
    Square sq2(bad);

    std::cout << "Side: " << sq.Side() << "\n";
    std::cout << "Area: " << sq.Area() << "\n";
    std::cout << "Perimeter: " << sq.Perimeter() << "\n";

    //second task

    CAPITAL ya("lowerCAPITALBBBB");
    std::cout<< "Amount of chars 'B': "<<ya.FindChar() << "\n";
    std::cout << "Length: "<<ya.Leng() << "\n";
    SYMBOLS stars("lowBIG***");
    std::cout << "Amount of chars '*': " << stars.FindChar() << "\n";
    std::cout << "Length: " << stars.Leng() << "\n";
}
