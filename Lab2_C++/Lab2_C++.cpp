#include "class_text.h"
using namespace std;

int main()
{


	char eh[4] = { 'e','l','l' };
	class_str c("hello");
	class_str aa("world 333");
	class_text t(c);

	t.Add(aa);
	t.Add(aa);
	int e = t.Elements();
	int it2 = c.Find(eh);
	c.Del(eh);
	c.Add(eh);

	t.Del(c);
	e = t.Elements();
	int it = t.Find(aa);

	class_str b("world 333");


	c.Replace('l', 'w');

	t.Replace('s', 'r');
	t.Replace('l', 'e');
	t.Add(c);
	cout << e;


}