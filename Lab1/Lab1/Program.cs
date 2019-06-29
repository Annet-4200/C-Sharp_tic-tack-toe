using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab1
{
    class Program
    {
        static void Printarr( int[,] arr) //Выводит двумерный массив
        {
            for (int i = 0; i < arr.GetLength(0); i++)
            {
                for (int n = 0; n < arr.GetLength(1); n++)
                {
                    Console.Write("{0} ",arr[i, n]);
                }
                Console.WriteLine();
            }
        }
        static int Check(int [,] arr) //Проверяет целочисленное ли значение 
        {
            while (true)
            {
                int i;
                if (int.TryParse(Console.ReadLine(), out i) && i < arr.GetLength(0))
                    return i;
                else
                    Console.WriteLine("Error! Please try again: ");
            }
        }

        static int ScanLine(int [,] arr, int n, int k)
        {
            int count1 = 0, count2 = 0;
            for (int i = 0; i<n; i++)
            {
                if (arr[i, k] == 1)
                    count1++;
                else if (arr[i,k]==2)
                    count2++;
            }
            if (count1 == n)
                return 1;
            else if (count2 == n)
                return 2;
            else
                return 0;

        }

        static int MainDig(int[,] arr, int n)
        {
            int count1 = 0, count2 = 0;
            for (int i = 0; i < n; i++)
            {
                if (arr[i, i] == 1)
                    count1++;
                else if (arr[i, i] == 2)
                    count2++;
            }
            if (count1 == n)
                return 1;
            else if (count2 == n)
                return 2;
            else
                return 0;

        }

        static int ScanColumn(int[,] arr, int n, int k)
        {
            int count1 = 0, count2 = 0;
            for (int i = 0; i < n; i++)
            {
                if (arr[k, i] == 1)
                    count1++;
                else if (arr[k, i] == 2)
                    count2++;
            }
            if (count1 == n)
                return 1;
            else if (count2 == n)
                return 2;
            else
                return 0;

        }

        static int SecondaryDig(int[,] arr, int n)
        {
            int count1 = 0, count2 = 0;
            for (int i = 0; i < n; i++)
            {
                if (arr[i, n-i-1] == 1)
                    count1++;
                else if (arr[i, n-1-i] == 2)
                    count2++;
            }
            if (count1 == n)
                return 1;
            else if (count2 == n)
                return 2;
            else
                return 0;

        }
        
        static void Main(string[] args)
            {
                int size;
                int turn1, turn2;
                Console.WriteLine("Enter the size of game field:");
                size = Convert.ToInt32(Console.ReadLine());
                int[,] arr = new int[size, size];
                for (int i = 0; i < arr.GetLength(0); i++)
                {
                    for (int j = 0; j < arr.GetLength(1); j++)
                    {
                        arr[i, j] = 0;
                    }
                }
                Printarr(arr);

            bool victory1 = false, victory2 = false;
            bool Continue= true;
            

            while (victory1 == false && victory2 == false && Continue == true) {

                Continue = false;
                Console.WriteLine("First player's turn:");
                turn1 = Check(arr);
                turn2 = Check(arr);
                
                if (arr[turn1,turn2] == 0)
                    arr[turn1, turn2] = 1;
                else Console.WriteLine("This spot is closed! Choose another");
                Printarr(arr);

                for (int i = 0; i < arr.GetLength(0); i++)
                {
                    if (ScanLine(arr, arr.GetLength(0), i) == 1 ||
                        ScanColumn(arr, arr.GetLength(0), i) == 1 ||
                        MainDig(arr, arr.GetLength(0)) == 1 ||
                        SecondaryDig(arr, arr.GetLength(0)) == 1)
                        victory1 = true;
                }
                if (victory1 == true)
                    break;

                Console.WriteLine("Second player's turn:");
                turn1 = Check(arr);
                turn2 = Check(arr);
                
                if (arr[turn1, turn2] == 0)
                    arr[turn1, turn2] = 2;
                else Console.WriteLine("This spot is closed! Choose another one");
                Printarr(arr);

                for (int i = 0; i < arr.GetLength(0); i++)
                {
                    if (ScanLine(arr, arr.GetLength(0), i) == 2 ||
                        ScanColumn(arr, arr.GetLength(0), i) == 2 ||
                        MainDig(arr, arr.GetLength(0)) == 2 ||
                        SecondaryDig(arr, arr.GetLength(0)) == 2)
                        victory2 = true;
                }
                
                for (int i = 0; i <arr.GetLength(0); i++)
                {
                    for (int j = 0; j< arr.GetLength(1); j++)
                    {
                        if (arr[i,j] == 0)
                            Continue = true;
                    }
                }

            }
            
            if (victory1 == true)
                Console.WriteLine("The first player won!");
            else if (victory2 == true)
                Console.WriteLine("The second player won!");
            else Console.WriteLine("Noone won :/");
           
             Console.ReadLine();

        }
     
    }   
}
