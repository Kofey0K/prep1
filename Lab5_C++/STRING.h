#pragma once
#include <iostream>
class STRING
{
protected:
    int size = 0;
    char* symb = nullptr;
public:
    STRING() = default; 
    virtual int Leng()
    {
        return 0;
    }
    virtual int FindChar()
    {
        return 0;
    }
};

