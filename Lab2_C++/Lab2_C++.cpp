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
	int e = t.Elements();
	cout << e;
	t.Del(c);
	e = t.Elements();
	cout << e;
	class_str b("3");



}