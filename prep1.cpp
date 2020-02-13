#include <iostream>
using namespace std;

void PlusOne(int&);
bool IsSmaller(int, int);


int main(){
    int value = -128;
    PlusOne(value);
    int a1 = 33;
    int a2 = 117;
    bool result =  IsSmaller(a1, a2);
    
}

void PlusOne(int& value)
{
    for (int mask = 1; ((value ^= mask) & mask) == 0; mask <<= 1);
}
bool IsSmaller(int value1, int value2)
{
    int size = sizeof(value1) * 8;
    if ((value1 & 1 << size - 1) != 0 && (value2 & 1 << size - 1) == 0) {
        return true;
    }
    if ((value1 & 1 << size - 1) == 0 && (value2 & 1 << size - 1) != 0) {
        return false;
    }
    else
        for (int i = size - 1; i >= 0; i--)
        {
            if ((value1 & 1 << i) != 0 && (value2 & 1 << i) == 0)
                return false;
            if ((value2 & 1 << i) != 0 && (value1 & 1 << i) == 0)
                return true;
        }
    
    return false;
}


