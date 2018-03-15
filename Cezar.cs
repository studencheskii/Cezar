using System;

namespace Cezar
{
	class Programm
	{
		static int Menu()
		{
			Console.WriteLine("1.Зашифровать");
			Console.WriteLine("2.Расшифровать");
			Console.WriteLine("0.Выход");
			Console.Write("Ваш выбор: ");
			return Convert.ToInt32(Console.ReadLine());
		}

		static string Encode(string alph, string text, int key)
		{
			int pos = 0;
			string temp = "";
			int len = alph.Length;
			for(int i = 0; i < text.Length; i++)
			{
				if((pos = alph.IndexOf(text[i])) != -1)
				{
					pos = (pos + key) % len;
					temp += alph[pos];
				}
				else
				{
					temp += text[i];
				}
			}
			return temp;
		}

		static string Decode(string alph,string text,int key)
		{
			int pos = 0;
			string temp = "";
			int len = alph.Length;
			for(int i = 0; i < text.Length; i++)
			{
				if((pos = alph.IndexOf(text[i])) != -1)
				{
					pos = (pos + len - (key % len)) % len;
					temp += alph[pos];
				}
				else
				{
					temp += text[i];
				}
			}
			return temp;
		}

		static void Main(string[] args)
		{
			int ans = 0;
			int key = 0;
			string alphabet = "abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ 1234567890-=_+()*&?!";
			string text = "";
			string secText = "";


			while(true)
			{
				ans = Menu();
				if(ans == 1)
				{
					Console.Write("Введите текст, который нужно зашифровать: ");
					text = Console.ReadLine();
					Console.Write("Введите сдвиг: ");
					key = Convert.ToInt32(Console.ReadLine());
					secText = Encode(alphabet,text,key);
					Console.Write("Зашифрованный текст: {0}\n", secText);
				}
				else if(ans == 2)
				{
					Console.Write("Введите текст, который нужно расшифровать: ");
					secText = Console.ReadLine();
					Console.Write("Процесс расшифровки:\n");
					for(int i = 0; i < alphabet.Length; i++)
					{
						text = Decode(alphabet,secText,i);
						Console.Write("{0}: {1} ",i+1, text);
						
						if(i == key % alphabet.Length)
						{
							Console.Write("\t OK");
						}
						Console.Write("\n");
					}
				}
				else if(ans == 0)
				{
					Environment.Exit(0);
				}
				else
				{
					Console.Write("Выберите корректный пункт меню.");
				}

			}
		}
	}
}
