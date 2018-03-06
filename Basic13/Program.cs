using System;
using System.Collections.Generic;

namespace Basic13
{
    class Program
    {
        public static int arrayLength(int[] arr, int y)
        {
            int count = 0;
            for (int i = 0; i < arr.Length; i++)
            {
                if (arr[i] > y)
                {
                    count++;
                }
            }
            return count;

        }
        static void Main(string[] args)
        {
            Console.WriteLine("============");
            Console.WriteLine("Print 1-255");
            Console.WriteLine("============");
            for (int i = 1; i < 256; i++)
            {
                Console.Write(i + " ");
                if (i % 10 == 0)
                    Console.WriteLine();
            }
            Console.WriteLine("===============================");
            Console.WriteLine("Print odd numbers between 1-255");
            Console.WriteLine("===============================");
            for (int i = 1; i < 256; i += 2)
            {
                Console.Write(i + " ");
                if (i % 5 == 0)
                    Console.WriteLine();
            }
            Console.WriteLine();
            Console.WriteLine("===========");
            Console.WriteLine("Print Sum");
            Console.WriteLine("===========");
            int sum = 0;
            for (int i = 0; i < 256; i += 2)
            {
                sum += i;
                Console.WriteLine("New number: " + i + " Sum: " + sum);

            }
            Console.WriteLine("==========================");
            Console.WriteLine("Iterating through an Array");
            Console.WriteLine("==========================");
            int[] X = { 1, 3, 5, 7, 9, 13 };
            for (int i = 0; i < 6; i++)
            {
                Console.Write(X[i] + " ");
            }

            Console.WriteLine();

            Console.WriteLine("===========");
            Console.WriteLine("Find Max");
            Console.WriteLine("===========");
            // int[] X = { 1, 3, 5, 7, 9, 13 };
            int[] X1 = { -3, -4, -5, -6, -7, -11 };
            int max = X1[0];
            for (int i = 0; i < 6; i++)
            {
                if (max < X1[i])
                    max = X1[i];
                Console.Write(X1[i] + " ");
            }
            Console.WriteLine(". The max number = " + max);

            Console.WriteLine("===========");
            Console.WriteLine("Get Average");
            Console.WriteLine("===========");
            int[] X2 = { 1, 3, 5, 7, 9, 13 };
            // int[] X2={-3,-4,-5,-6,-7,-11};
            int avg;
            sum = 0;
            for (int i = 0; i < X2.Length; i++)
            {
                sum = X2[i];
                Console.Write(X2[i] + " ");
            }
            avg = sum / X2.Length;
            Console.WriteLine(". avrg = " + avg);

            Console.WriteLine("======================");
            Console.WriteLine("Array with Odd Numbers");
            Console.WriteLine("======================");
            int[] y = new int[128];
            int index = 0;

            for (int i = 1; i < 256; i += 2)
            {
                y[index] = i;

                Console.Write(y[index] + " ");
                if (index % 10 == 0)
                    Console.WriteLine();
                index++;
            }

            Console.WriteLine();

            Console.WriteLine("==============");
            Console.WriteLine("Greater than Y");
            Console.WriteLine("==============");
            int[] array = { 1, 3, 5, 7 };
            int Y = 3;
            Console.WriteLine("The number of items in the array that are greater than {0} = {1}", Y, arrayLength(array, Y));


            Console.WriteLine("================");
            Console.WriteLine("Square the Value");
            Console.WriteLine("================");

            int[] arrayX = { 1, 5, 10, -2 };

            Console.WriteLine("Before the square loop: ");
            for (int i = 1; i < arrayX.Length; i++)
            {
                Console.Write(arrayX[i] + " ");
                arrayX[i] *= arrayX[i];

            }
            Console.WriteLine();
            Console.WriteLine("After the square loop: ");
            for (int i = 1; i < arrayX.Length; i++)
            {

                Console.Write(arrayX[i] + " ");

            }
            Console.WriteLine();

            Console.WriteLine("===========================");
            Console.WriteLine("Eliminate Negative Numbers");
            Console.WriteLine("==========================");

            int[] arrayY = { 1, 5, 10, -2 };

            for (int i = 0; i < arrayY.Length; i++)
            {
                if (arrayY[i] < 0)
                {
                    arrayY[i] = 0;
                }
                Console.Write(arrayY[i] + " ");


            }
            Console.WriteLine();

            Console.WriteLine("===========================");
            Console.WriteLine("Min, Max, and Average");
            Console.WriteLine("==========================");

            int[] arrayZ = { 1, 5, 10, -2 };
            int Min = arrayZ[0];
            int Max = arrayZ[0];
            int sum1 = 0, Avg;
            Console.Write("My array is: [");
            for (int i = 0; i < arrayZ.Length; i++)
            {
                if (arrayZ[i] < Min)
                {
                    Min = arrayZ[i];
                }
                if (arrayZ[i] > Max)
                {
                    Max = arrayZ[i];
                }
                sum1 += arrayZ[i];
                Console.Write(arrayZ[i] + " ");


            }
            Avg = sum1 / arrayZ.Length;
            Console.WriteLine("]. \n Min= {0} \n Max= {1} \n Avg= {2}", Min, Max, Avg);
            Console.WriteLine();

            Console.WriteLine("===============================");
            Console.WriteLine("Shifting the values in an array");
            Console.WriteLine("===============================");

            int[] arr = { 1, 5, 10, 7, -2 };
            Console.Write("My array before shifting is: [");
            for (int i = 0; i < arr.Length; i++)
            {

                Console.Write(arr[i] + " ");


            }
            Console.Write("].\nMy array after shifting is: [");
            for (int i = 0; i < arr.Length - 1; i++)
            {

                arr[i] = arr[i + 1];
                Console.Write(arr[i] + " ");
            }
            arr[arr.Length - 1] = 0;

            Console.WriteLine(arr[arr.Length - 1] + "].");

            
            Console.WriteLine("================");
            Console.WriteLine("Number to String");
            Console.WriteLine("================");

            List<string> arrX = new List<string>();
            arrX.Add("-1");
            arrX.Add("-3");
            arrX.Add("2");

            for (int j=0;j< arrX.Count; j++)
            {
                if (Int32.Parse(arrX[j]) < 0)
                {
                    arrX.RemoveAt(j);
                    arrX.Insert(j,"Dojo");
                }
            }
            foreach (var item in arrX)
            {
                Console.Write(item + " ");
            }
            Console.WriteLine();





        }

    }
}
