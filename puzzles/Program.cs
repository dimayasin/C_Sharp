using System;
using System.Collections.Generic;

namespace puzzles
{
    class Program
    {
        static public void RandomArray(int[] arr)
        {
            Random rand = new Random();

            for (int i = 0; i < 10; i++)
            {
                arr[i] = rand.Next(5, 26);
            }
            int max = arr[0];
            int min = arr[0];
            int sum = 0;
            for (int i = 0; i < 10; i++)
            {
                if (max < arr[i])
                    max = arr[i];
                if (min > arr[i])
                    min = arr[i];
                sum += arr[i];
                System.Console.Write(arr[i] + " ");
            }
            System.Console.WriteLine();
            System.Console.WriteLine("The max value of the array is: " + max.ToString());
            System.Console.WriteLine("The min value of the array is: " + min.ToString());
            System.Console.WriteLine("The sum of all values of the array is: " + sum.ToString());
            // return arr;


        }
        static public string TossCoin()
        {
            string toss = "Heads";
            int coin;
            Random rand = new Random();
            coin = rand.Next(1, 3);
            if (coin == 1)
                toss = "Heads";
            else if (coin == 2)
                toss = "Tails";
            return toss;
        }
        static public Double TossMultipleCoins(int num)
        {
            int sumheads = 0;
            int sumtails = 0;
            string mytoss;
            System.Console.WriteLine("The number of tosses: {0} ", num.ToString());
            Double results;
            for (int i = 1; i <= num; i++)
            {
                mytoss = TossCoin();
                if (mytoss == "Heads")
                    sumheads++;
                if (mytoss == "Tails")
                    sumtails++;

            }
            System.Console.WriteLine("The number of heads: " + sumheads.ToString());
            System.Console.WriteLine("The number of tails: " + sumtails.ToString());
            results = (Double)sumheads / (Double)sumtails;
            return results;
        }

        static public string[] Names()
        {
            string[] array = { "Todd", "Tiffany", "Charlie", "Geneva", "Sydney" };
            string[] newlist = new string[array.Length];

            Random rand = new Random();
            string temp;
            int num = rand.Next(0, array.Length);
            System.Console.WriteLine("The array before shuffling: ");
            System.Console.WriteLine("------------------------------");
            for (int i = 0; i < array.Length; i++)
            {
                System.Console.Write(array[i] + " ");

            }
            System.Console.WriteLine();

            for (int i = 0; i < array.Length; i++)
            {
                temp = array[i];
                array[i] = array[num];
                array[num] = temp;

            }

            System.Console.WriteLine("The array before shuffling: ");
            System.Console.WriteLine("------------------------------");
            for (int i = 0; i < array.Length; i++)
            {
                System.Console.Write(array[i] + " ");
                if (array[i].Length > 5)
                {
                    newlist[i] = array[i];
                }
                else
                newlist[i] = "";

            }
            System.Console.WriteLine();


            return newlist;
        }
        static void Main(string[] args)
        {
            Console.WriteLine("====================");
            Console.WriteLine("    Random Array");
            Console.WriteLine("====================");
            int[] arr = new int[10];
            RandomArray(arr);

            Console.WriteLine("====================");
            Console.WriteLine("    Coin Flip");
            Console.WriteLine("====================");
            // Console.Write("How many times do you want to toss the coin?:");
            int tosses = 20; //Int32.Parse(System.Console.ReadLine());
            Double ratio = TossMultipleCoins(tosses);

            System.Console.WriteLine("The ratio of heads to tails is: " + ratio.ToString());

            Console.WriteLine("====================");
            Console.WriteLine("        Names");
            Console.WriteLine("====================");

            string[] newNames = Names();
            System.Console.WriteLine();
            
            System.Console.WriteLine("The names longer than 5 chars: ");
            System.Console.WriteLine("---------------------------------");
            for (int i = 0; i < newNames.Length; i++)
            {
                if(newNames[i] != "")
                System.Console.WriteLine(newNames[i] + " ");

            }
            System.Console.WriteLine();


        }
    }
}
