#pragma once
#include <iostream>
using namespace std;

class class_str
{
	int size = 0;
	char* class_Str = nullptr;
public:
	class_str() = default;
	~class_str();
	class_str(const char s[]);
	void print();
	int Find(const char s[]);
	void Add(const char s[]);
	void Del(const char s[]);
	int getSize()const;
	char getChar(int i)const;
	bool Replace(const char s, const char ss);
};
