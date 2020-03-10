#pragma once
#include "class_str.h"

class class_text
{
	int size = 1;
	class_str* text = nullptr;
public:
	class_text() = default;

	class_text(class_str a);
	int Find(class_str s);
	void Add(class_str a);
	void Del(class_str a);
	void Clear();
	int Elements()const;
	void Replace(char s, char ss);

	int HowMany(class_str s);
};