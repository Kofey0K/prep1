#include <iostream>
using namespace std;

void func1(int&);
bool IsSmaller(int, int);

int main(){
    int value = 63;
    func1(value);

    bool result =  IsSmaller(33, 2);
    
}

void func1(int& value)
{
    for (int counter = 1; ((value ^= counter) & counter) == 0; counter <<= 1);
}
bool IsSmaller(int value1, int value2)
{
    bool result = true;
    int size = sizeof(value1) * 8;
    if ((value1 & 1 << size - 1) != 0 || (value2 & 1 << size - 1) != 0)
        for (int i = 0; i < size; i++)
        {
            if ((value1 & 1 << i) != 0 && (value2 & 1 << i) == 0)
                result = false;
            if ((value2 & 1 << i) != 0 && (value1 & 1 << i) == 0)
                result = true;
        }
    else
        for (int i = size - 1; i >= 0; i--)
        {
            if ((value1 & 1 << i) != 0 && (value2 & 1 << i) == 0)
                result = false;
            if ((value2 & 1 << i) != 0 && (value1 & 1 << i) == 0)
                result = true;
        }
    if (value1 * value2 < 0)
    {
        if (result == true)
        {
            result = false;
        }
        else
        {
            result = true;
        }

    }
    return result;
}


