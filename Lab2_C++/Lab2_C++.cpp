#include "class_text.h"
using namespace std;

int main()
{

	class_str a("hello");
	a.~class_str();
	class_str c("hello");
	class_str aa("world 333");
	class_text t(c);
	t.Add(aa);
	t.Add(aa);
	int e = t.Elements();

	t.Del(c);
	e = t.Elements();

	class_str b("world 333");
	cout << t.HowMany(b);
	
	c.Replace('l', 'w');
	c.print();
	t.Replace('s', 'r');
	t.Add(c);
	cout << e;
	

}