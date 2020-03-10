#include "class_text.h"


int class_text::Find(class_str s) {
	bool k = 1;
	int i;
	for (i = 0; i < size; i++)
	{

		k = 1;
		for (int j = 0; j < text[i].getSize(); j++) {
			if (s.getChar(j) != text[i].getChar(j)) {
				k = 0;
			}
		}
		if (k == 1) return i;
	}
	if (k == 0) return -1;
}


int class_text::HowMany(class_str s)
{
	int c = 0;
	for (int i = 0; i < size; i++)
	{
		int k = 1;
		for (int j = 0; j < text[i].getSize(); j++) {
			if (s.getChar(j) != text[i].getChar(j)) {
				k = 0;
			}
		}
		c += k;
	}
	return c;
}

class_text::class_text(class_str a)
{

	text = new class_str[size];
	text[0] = a;
}

void class_text::Add(class_str a)
{
	size++;
	text[size - 1] = a;
}

void class_text::Del(class_str s)
{
	bool k = 1;
	int i;
	for (i = 0; i < size; i++)
	{

		k = 1;
		for (int j = 0; j < text[i].getSize(); j++) {
			if (s.getChar(j) != text[i].getChar(j)) {
				k = 0;
			}
		}
		if (k == 1) break;
	}
	if (k == 0) return;

	for (long z = i; z < size; ++z)
	{
		text[z] = text[z + 1];
	}
	--size;
}

void class_text::Clear()
{
	*text = nullptr;
	size = 0;
}

int class_text::Elements()const
{
	int e = 0;
	for (int i = 0; i < size; i++)
	{
		e += text[i].getSize();
	}
	return e;
}


void class_text::Replace(char s, char ss)
{
	for (int i = 0; i < size; i++)
	{
		if (text[i].Replace(s, ss) == 1)
		{
			return;
		}
	}
}