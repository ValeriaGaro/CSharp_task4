using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lesson_4
{
	//1
	static class String
	{
		public static string CuttingString(this string first_string, int index)
		{
			string result = first_string.Substring(index);
			return result;
		}

		public static string Return_Part(this string first_string, int first_index, int second_index)
		{

			string result = first_string.Substring(first_index, second_index - first_index + 1);
			return result;
		}

		public static string Adding_String(this string first_string, string[] array)
		{

			string first_adding = string.Concat(first_string, string.Join(" ", array));

			return first_adding;
		}

		public static string Lower_Upper(this string first_string)

		{

			string result_LU = first_string.ToUpper() + first_string.ToLower();
			return result_LU;
		}
	}
	//2
	class Byte_Converting
	{
		static public string ReturnToByte(int a)
		{

			byte[] result_convering = BitConverter.GetBytes(a);
			return BitConverter.ToString(result_convering);
		}
	}


	//3
	class Type_of
	{
		public static object GetTypeOf(object a)
		{

			return a.GetType().ToString();
		}
	}
//4
	class Vector
	{
		public static double[] Adding_Vectors(double[] a, double[] b)
		{
			double[] res = new double[a.GetLength(0)];
			for (int i = 0; i < a.GetLength(0); i++)
			{
				res[i] += a[i] + b[i];
			}
			return res;
		}

		public static double[] MinVectors(double[] a, double[] b)
		{
			double[] res = new double[a.GetLength(0)];
			for (int i = 0; i < a.GetLength(0); i++)
			{
				res[i] += a[i] - b[i];
			}
			return res;
		}
	}
	//5
	struct Book
	{
		public string bookName;
		public Book(string bookName)
		{
			this.bookName = bookName;
		}
	}
	class Library
	{
		private Book[] list;
		private int counter = 0;
		public Library(int LibrarySize) 
		{
			this.list = new Book[LibrarySize + 1];
		}

		public void AddBook(string bookName)
		{
			list[counter] = new Book(bookName);
			counter++;
		}

		public void AddBook(Book book) 
		{
			list[counter] = book;
			counter++;
		}

		public void ShowBooks() 
		{
			for (var i = 0; i < counter; i++)
			{
				Console.WriteLine(list[i].bookName);
			}
		}

		public bool IsBookExist(string bookName) 
		{
			foreach (var book in list)
			{
				if (bookName == book.bookName) 
				{
					return true;
				}
			}
			return false;
		}

		public bool IsBookExist(Book book)
		{
			return IsBookExist(book.bookName);
		}

		public void RemoveBook(string bookName)
        {
			bool a = false;
			for (var x = 0; x < counter; x++)
			{
				if (bookName == list[x].bookName)
				{
					a = true;
				}

				if (a == true)
                {
					list[x] = list[x + 1];
                }

			}
			--counter;
        }
		public void RemoveBook(Book book)
        {
			RemoveBook(book.bookName);
        }
	}
//6
	static class PrNumber 
	{
		public static string Pr(this float firstNumber)
		{
			double x;
			string letter = "";
			string Inputting;

			if (firstNumber / 1000000000000 >= 1)
			{
				x = firstNumber / 1000000000000;
				letter = "T";

			}

			else if (firstNumber / 1000000000 >= 1)
			{
				x = firstNumber / 1000000000;
				letter = "B";
			}

			else if (firstNumber / 1000000 >= 1)
			{
				x = firstNumber / 1000000;
				letter = "M";
			}
			else if (firstNumber / 1000 >= 1)
			{
				x = firstNumber / 1000;
				letter = "K";
			}
			else 
			{
				x = firstNumber;
			}
			Inputting = x.ToString();

			if (x == (int)x)
			{
				return ((int)x).ToString() + letter;
			}
			else if (double.Parse(Inputting.Substring(0, 4)) == (int)x)
			{
				return ((int)x).ToString() + letter;
			}
			else 
			{
				return Inputting.Substring(0, 4) + letter;
			}

		}

		public static string Pr(this long firstNumber) 
		{
			return Pr((float)firstNumber);
		}
		public static string Pr(this int firstNumber)
		{
			return Pr((float)firstNumber);
		}
	}
	
	class Program
	{
		static void Main()
		{

			// данные строки для проверки того, что выполнила 
			//checking 1
			string our_string = "our first string this ";
			Console.WriteLine(our_string.CuttingString(8));
			Console.WriteLine(our_string.Return_Part(4, 9));
			string[] new_array = { "and", "this", "we added" };
			Console.WriteLine(our_string.Adding_String(new_array));
			Console.WriteLine(our_string.Lower_Upper());
			
			//checking 2
			Console.WriteLine(Byte_Converting.ReturnToByte(108));
			
			//checking 4
			Console.WriteLine(Type_of.GetTypeOf("qwerrt"));
			
			//checking 3
			double[] a = { 1, 2, 6 };
			double[] b = { 3, 4, 2 };
			double[] res = Vector.Adding_Vectors(a, b);
			Console.WriteLine(string.Join(" ", res));
			double[] q = { 1, 2, 6 };
			double[] z = { 3, 4, 2 };
			double[] res_of_min = Vector.MinVectors(q, z);
			Console.WriteLine(string.Join(" ", res_of_min));

			//checking 5
			Library checking_library = new Library(3);
			Book tolstoy = new Book("Ann Karenina");
			checking_library.AddBook(tolstoy);
			checking_library.AddBook("Finansist");
			checking_library.ShowBooks();

			Console.WriteLine(checking_library.IsBookExist(tolstoy));
			Console.WriteLine(checking_library.IsBookExist("Finansist"));

			checking_library.RemoveBook(tolstoy);

			checking_library.AddBook("Sapiens");
			checking_library.AddBook("Blood");
			checking_library.ShowBooks();

			//checking 6
			int first_checking = 1000380;
			int second_checking = 1024;
			float third_checking = 23.84F;
			Console.WriteLine(first_checking.Pr());
			Console.WriteLine(second_checking.Pr());
			Console.WriteLine(third_checking.Pr());

			Console.ReadKey();
			/*
			+ 1.  Создать класс с методами расширения для типа String
			Класс должен уметь:
				+ • Обрезать входную строку до индекса, заданного пользователем
				+ • Возвращать часть строки, в качестве параметров начальный индекс и конечный
				+ • Присоединять к строке произвольное количество других строк
				+ • Заменять все буквы на заглавные и наоборот

			+ 2.  Создать метод, который преобразует целое число в массив байт

			+ 3.  Создать класс или структуру (на своё усмотрение), описывающую трехмерный вектор
				Вектор должен быть трехмерным (координаты x, y, z)
				Должны быть методы работы с векторами: сложение и вычитание

			+ 4. 	Создать метод, принимающий любой тип и возвращающий название этого типа в виде строки

			+ 5. + Создать класс Library и + структуру Book
				+ Класс Library должен содержать массив типа Book
				Класс Library должен предоставлять методы:
					+ • Добавление книги 
						+ void AddBook(string bookName) 
						+ void AddBook(Book book)
					+ • Удаление книги
						+ void RemoveBook(string bookName)
						+ void RemoveBook(Book book)
					+ • Вывод на экран названий всех книг, который на данный момент есть в библиотеке
						void ShowBooks()
					+ • Метод поиска книги 
						+ bool IsBookExist(string bookName)
						+ bool IsBookExist(Book book)

			6.	Написать методы расширения для типов int, float, long.
				Методы должны возвращать строку формата XXXZ, где XXX это первые 3 (если их 3 или больше) цифры числа, а Z - сокращенное обозначение степени.
				Z для различных степеней:
				• K для тысяч
				• M для миллионов
				• B для миллиардов
				• T для триллионов
				Для отсальных степеней выводить просто 3 первых цифры
	
				Примеры:
				для числа 1_000_380 метод должен возвратить 1M
				для числа 1024 метод должен возвратить 1,02K
				для числа 23,84 метод должен возвратить число 23,8
			*/


		}
	}

}

