using System;
using System.Collections.Generic;
using System.Linq;

namespace Radi
{
	class Program
	{
		static void Main(string[] args)
		{
			Console.ReadKey();
		}
	}
	class Radi
	{
		public static double sin(double num) => Math.Sin(num *Math.PI /180);
		
		public static double cos(double num) => Math.Cos(num *Math.PI /180);
		
		public static double tan(double num) => Math.Tan(num *Math.PI /180);
		
		public static double arcsin(double num) => Math.Asin(num )* 180 / Math.PI;
		
		public static double arccos(double num) => Math.Acos(num )* 180 / Math.PI;
		
		public static double arctan(double num) => Math.Atan(num )* 180 / Math.PI;
		public static int pwr (int num,int exp)
        {
			if (exp == 0) return 1;
			else return (num * pwr(num, exp - 1));
        }
		
		public static int SumOfDigits (int num)
        {
			int sum = 0;
            for (int i = num; i > 0; i/=10)
            {
				sum += (num % 10);
            }
			return sum;
        }
		
		public static int CountWordsInString(string str)
		{
			int count = 1;
			foreach (var ch in str)
			{
				count = (ch == ' ') ? count + 1 : count;
			}
			count = str[str.Length - 1] == ' ' ? count - 1 : count;
			return count;
		}
		
		public static int ConvertChartToInteger(char ch) => ch - '0';
		
		public static int ConvertCharToASCII(char ch) => (int)ch;
		
		public static int ConvertBinaryToDecimal(int num)
		{
			int  dec = 0, baseval = 1 ;

			while (num > 0)
			{
				dec += (num % 10) * baseval;
				num /=  10;
				baseval *=  2;
			}
			return dec;
		}
		
		public static int ConvertDecimalToBinary(int num)
		{
			string bin = "";
			int i;
			int[] arr = new int[20];

			for (i = 0; num > 0; i++)
			{
				bin += (num % 2);
				num = num / 2;
			}
			return int.Parse( ReverseString(bin));
		}
		
		public static int ConvertDecimalToOctal(int num)
		{
			string oct = "";
			int i;
			int[] arr = new int[20];

			for (i = 0; num > 0; i++)
			{
				oct += (num % 8);
				num = num / 8;
			}
			return int.Parse(ReverseString(oct));
		}
		
		public static string ConvertDecimalToHexadecimal(int num)
		{
            char a;
			string hex = "";
			 while(num > 0)
            {
                int x = num % 16;
                if (x < 10)
                {
                    x +=  48;
                }
                else
                {
                    x +=  55;
                }
                a = Convert.ToChar(x);
                hex += a;
				num /= 16;
            }
			return ReverseString(hex);
		}
		
		public static int ReverseNumber(int num)
		{
			int remainder, reverse = 0;
			for (int i = num; i != 0; i /= 10)
			{
				remainder = i % 10;
				reverse = reverse * 10 + remainder;
			}
			return reverse;
		}
		
		public static string ReverseString(string str)
		{
			string reverse = "";
			for (int i = str.Length - 1; i >= 0; i--)
			{
				reverse += str[i];
			}
			return reverse;
		}
		
		public static void FibonacciSeries(int num)                 //0 1 1 2 3 5 8
		{
			int fb1 = 0, fb2 = 1, fb, x;

			Console.Write(fb1 + " " + fb2 + " ");
			for (x = 2; x < num; ++x)
			{
				fb = fb1 + fb2;
				Console.Write(fb + " ");
				fb1 = fb2;
				fb2 = fb;
			}
		}
		
		public static bool PalindromeNumber(int num) => num == ReverseNumber(num) ? true : false;           //1234554321
		
		public static bool LeapYear(int year) => year % 4 == 0 ? true : false;
		
		public static bool IsEvenNumber(int num) => num % 2 == 0 ? true : false;
		
		public static bool IsPositive(int num) => num >= 0 ? true : false;
		
		public static int ConvertFromCelciusToFahrenheit(int Celcius) => Celcius * 9 / 5 + 32;
		
		public static (int, int, int) NumberOfAlphabetsDigitsSpecialCharacters(string str)
		{
			int dig = 0, alp = 0, spc = 0;
			for (int i = 0; i < str.Length; i++)
			{
				if ((str[i] >= 'a' && str[i] <= 'z') || str[i] >= 'A' && str[i] <= 'Z')
				{
					alp++;
				}
				else if (str[i] >= '0' && str[i] <= '9')
				{
					dig++;
				}
				else
				{
					spc++;
				}
			}
			return (alp, dig, spc);
		}
		
		public static (int, int) CountNumberOfVowelsAndConsonants(string str)
		{
			int vol = 0, con = 0;

			for (int i = 0; i < str.Length; i++)
			{
				if (str[i] == 'a' || str[i] == 'A' || str[i] == 'e' || str[i] == 'E' ||
					str[i] == 'i' || str[i] == 'I' || str[i] == 'o' || str[i] == 'O' ||
					str[i] == 'u' || str[i] == 'U')
				{
					vol++;
				}
				else if ((str[i] >= 'a' && str[i] <= 'z') || (str[i] >= 'A' && str[i] <= 'Z'))
				{
					con++;
				}
			}
			return (vol, con);
		}
		
		public static int SumOneToNumber(int num)
		{
			int sum = 0;
			for (int i = 1; i <= num; i++)
			{
				sum += i;
			}
			return sum;
		}
		
		public static int MagnitudeOfAnInteger(int num)
		{
			int Magn = 0;
			for (int i = num; i != 0; i /= 10)
			{
				Magn++;
			}
			return Magn;
		}
		
		public static void DislpayDateFormats(int Y, int M, int D)
		{
			DateTime DT = new DateTime(Y, M, D);

			Console.WriteLine($"Date and Time is: {DT}");
			Console.WriteLine(DT.ToString("yyyy-MM-dd"));
			Console.WriteLine(DT.ToString("dd-MM-yyyy"));
			Console.WriteLine(DT.ToString("MM-dd-yyyy"));
			Console.WriteLine(DT.ToString("M/d/yyyy"));
			Console.WriteLine(DT.ToString("M/d/yy"));
		}
		
		public static string addBinary(string a, string b)
		{
			// Initialize result 
			string result = "";

			// Initialize digit sum 
			int s = 0;

			// Traverse both strings starting  
			// from last characters 
			int i = a.Length - 1, j = b.Length - 1;
			while (i >= 0 || j >= 0 || s == 1)
			{

				// Comput sum of last  
				// digits and carry 
				s += ((i >= 0) ? a[i] - '0' : 0);
				s += ((j >= 0) ? b[j] - '0' : 0);

				// If current digit sum is  
				// 1 or 3, add 1 to result 
				result = (char)(s % 2 + '0') + result;

				// Compute carry 
				s /= 2;

				// Move to next digits 
				i--; j--;
			}
			return result;
		}
		
		public static bool IsArmstrongNumber(int num)
		{
			//370==3**3 + 7**3 + **3

			int x, sum = 0;
			for (int i = num; i != 0; i /= 10)
			{
				x = i % 10;
				sum += (x * x * x);
			}
			return sum == num ? true : false;
		}
		
		public static List<int> FactorsOfNumber(int num)
		{
			var fac = new List<int>();
			for (int i = 1; i <= num; i++)
			{
				if (num % i == 0)
				{
					fac.Add(i);
				}
			}
			return fac;
		}
		
		public static (int, int, int) FindLCM_GCD_HCF(int num1, int num2)
		{
			int n1, n2, result, lcm, gcd, hcf = 0;

			n1 = num1;
			n2 = num2;

			do
			{
				result = n2;
				n2 = n1 % n2;
				n1 = result;
			} while (n2 > 0);

			gcd = n1;
			lcm = (num1 * num2) / gcd;

			for (int i = 1; i <= num1 || i <= num2; ++i)
			{
				if (num1 % i == 0 && num2 % i == 0)
				{
					hcf = i;
				}
			}
			return (lcm, gcd, hcf);
		}
		
		public static int[] BubbleSort(int[] arr)
		{
			int x;
			for (int y = 0; y <= arr.Length - 2; y++)
			{
				for (int z = 0; z <= arr.Length - 2; z++)
				{
					if (arr[z] > arr[z + 1])
					{
						x = arr[z + 1];
						arr[z + 1] = arr[z];
						arr[z] = x;
					}
				}
			}
			return arr;
		}
		
		public static int[] InsertionSort(int[] arr)
		{
			int i, j;
			for (i = 1; i < arr.Length; i++)
			{
				int a = arr[i];
				int b = 0;
				for (j = i - 1; j >= 0 && b != 1;)
				{
					if (a < arr[j])
					{
						arr[j + 1] = arr[j];
						j--;
						arr[j + 1] = a;
					}
					else
					{
						b = 1;
					}
				}
			}
			return arr;
		}
	}
}
