#pragma once
#include "STRING.h"

class CAPITAL :
	public STRING
{
public:
    CAPITAL(const char val[])
    {
        size = strlen(val);
        symb = new char[size];
        for (int i = 0; i < size; i++)
        {
            symb[i] = val[i];
        }
        char* temp = nullptr;
        temp = new char[size];
        int counter1 = 0, counter2 = 0;
        for (int i = 0; i < size; i++)
        {
            if (val[i] < 65 || val[i] > 90)
            {
                std::cout << val[i] << " - not a capital letter!\n";
                counter2++;
            }
            else
            {
                temp[counter1] = val[i];
                counter1++;
            }
        }
        size -= counter2;
        symb = new char[size];
        for (int j = 0; j < size; j++)
        {
            symb[j] = temp[j];
        }
    }
    int Leng() override
    {
        return size;
    }
    int FindChar() override
    {
        int counter = 0;
        for (int i = 0; i < size; i++)
        {
            if (symb[i] == 'B') {
                counter++;
            }
        }
        return counter;
    }
};

