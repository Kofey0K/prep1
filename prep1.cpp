#include <iostream>
using namespace std;

void func1(int&);

int main(){
    int value = 63;
    func1(value);

    unsigned int s;

    std::cout << "Enter the number of s" << endl;
    std::cin >> s;
    for (unsigned int mask = 1 << sizeof(int) * 8 - 1; mask; mask >>= 1)
        std::cout << (s & mask ? '1' : '0');

    
}

void func1(int& value)
{
    for (int counter = 1; ((value ^= counter) & counter) == 0; counter <<= 1);
}


/*bool func2(int value, int op) {
    for (int i = 1
}*/