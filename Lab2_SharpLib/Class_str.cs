using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab2_SharpLib
{
    public class Class_str
    {
		private char[] class_Str;
		public Class_str(char[] s)
		{
			class_Str = new char[s.Length];
			s.CopyTo(class_Str, 0);
		}
		public int Find(char[] s)
		{
			int k = 0;
			int index = -1;
			for (int i = 0; i < class_Str.Length; i++)

			{
				if (class_Str[i] == s[0])
				{
					for (int j = 0; j < s.Length + 1; j++)
					{
						if (class_Str[i] == s[j])
							k++;
					}
				}
				if (k == s.Length)
				{
					index = i;
					return index;
				}
			}
			return index;
		}

		public void Add(char[] s)
		{
			int j = class_Str.Length;

			for (int i = j; i < (j + s.Length); i++)
			{
				class_Str[i] = s[i - class_Str.Length];
			}
		}
		public int getSize()
		{
			return class_Str.Length;
		}
		public void Del(char[] s)
		{
			for (int i = Find(s); i < (class_Str.Length - s.Length); i++)
			{
				class_Str[i] = class_Str[i + s.Length];
			}
		}

		public int Numbers()
		{
			int n = 0;
			for (int i = 0; i < class_Str.Length; i++)
			{
				if (class_Str[i] >= 48 && class_Str[i] <= 57)
					n++;
			}
			return n;
		}
		public char getChar(int i)
		{
			return class_Str[i];
		}
		public bool Replace(char s, char ss)
		{
			for (int i = 0; i < class_Str.Length; i++)
			{
				if (class_Str[i] == s)
				{
					class_Str[i] = ss;
					return true;
				}
			}
			return false;
		}
	}
	public class Class_text
	{
		private Class_str[] text = null;
		public Class_text()
		{
			text = new Class_str[] { };
		}
		public Class_text(Class_str[] a)
		{
			text = new Class_str[a.Length];
			a.CopyTo(text, 0);
		}

		public void Add(Class_str a)
		{
			Array.Resize(ref text, text.Length + 1);
			text[text.Length - 1] = a;
		}
		public void Del()
		{
			Array.Resize(ref text, text.Length - 1);
		}
		public void Clear()
		{
			text = null;
			text = new Class_str[] { };
		}

		public int Elements()
		{
			int e = 0;
			for (int i = 0; i < text.Length; i++)
			{
				e += text[i].getSize();
			}
			return e;
		}


		public int HowMany(Class_str s)
		{
			int c = 0;
			for (int i = 0; i < text.Length; i++)
			{
				int k = 1;
				for (int j = 0; j < text[i].getSize(); j++)
				{
					if (s.getChar(j) != text[i].getChar(j))
					{
						k = 0;
					}
				}
				c += k;
			}
			return c;
		}
		public void Replace(char s, char ss)
		{
			for (int i = 0; i < text.Length; i++)
			{
				if (text[i].Replace(s, ss) == true)
				{
					return;
				}
			}
		}
	}
	}
