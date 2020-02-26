#include "class_text.h"
using namespace std;

int main()
{
	char b[] = { "ll" };
	class_str a("hello");
	class_str aa("world 333");
	class_text t(a);
	t.Add(aa);
	
	int e = t.Elements();


}