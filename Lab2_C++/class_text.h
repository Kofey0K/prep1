#pragma once
#include "class_str.h"

class class_text
{
	int size = 0;
	class_str* text = nullptr;
public:
	class_text() = default;
	~class_text();
	class_text(class_str a);
	void Add(class_str a);
	void Del();
	void Clear();
	int Elements()const;
	void Replace(const char s, const char ss);

	int HowMany( class_str s);
};