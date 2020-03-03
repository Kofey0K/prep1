#include "class_str.h"



class_str::class_str(const char s[])
{
	size = strlen(s);
	class_Str = new char[size];
	for (int i = 0; i < size; i++)
	{
		class_Str[i] = s[i];
	}
}


void class_str::print()
{
	for (int i = 0; i < size; i++)
	{
		cout << class_Str[i];
	}
	cout << endl;
}

int class_str::Find(const char s[])
{
	int k = 0;
	int index = -1;
	int SSize = strlen(s);
	for (int i = 0; i < size; i++)

	{
		if (class_Str[i] == s[0])
		{
			for (int j = 0; j < strlen(s) + 1; j++)
			{
				if (class_Str[i] == s[j])
					k++;
			}
		}
		if (k == strlen(s))
		{
			index = i;
			return index;
		}
	}
	return index;
}

void class_str::Add(const char s[])
{
	int j = size;
	size += strlen(s);
	for (int i = j; i < size; i++)
	{
		class_Str[i] = s[i - j];
	}
}

void class_str::Del(const char s[])
{
	for (int i = Find(s); i < (size - strlen(s)); i++)
	{
		class_Str[i] = class_Str[i + strlen(s)];
	}
	size -= (strlen(s));
}

int class_str::getSize() const
{
	return size;
}

char class_str::getChar(int i) const
{
	return class_Str[i];
}


bool class_str::Replace(const char s, const char ss)
{
	for (int i = 0; i < size; i++)
	{
		if (class_Str[i] == s)
		{
			class_Str[i] = ss;
			return 1;
		}
	}
	return 0;
}