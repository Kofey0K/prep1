#pragma once
#include "STRING.h"

class SYMBOLS :
	public STRING
{
public:
	SYMBOLS(const char val[])
	{
		size = strlen(val);
		symb = new char[size];
		for (int i = 0; i < size; i++)
		{
			symb[i] = val[i];
		}
	}
	SYMBOLS(char* val)
	{
		symb = val;
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
            if (symb[i] == '*') {
                counter++;
            }
        }
        return counter;
    }
};

