using System;
using System.Collections.Generic;

namespace first_CS
{
    class Program
    {
        static int getReminder(int num, int div)
        {
            return (num - div * (num / div));
        }
        static void Main(string[] args)
        {

            Console.WriteLine("Three Basic Arrays: ");
            Console.WriteLine("========================");
            int[] array = new int[10];
            for (int i = 0; i < 10; i++)
            {
                array[i] = i;
                Console.Write(array[i] + " ");

            }
            Console.WriteLine();
            string[] names = { "Time", "Martin", "Nikki", "Sara" };
            bool[] flags = new bool[10];
            for (int i = 0; i < 10; i++)
            {
                if (i % 2 == 0)
                {
                    flags[i] = true;
                }
                else
                    flags[i] = false;
            }
            for (int i = 0; i < 4; i++)
            {
                Console.Write(names[i] + " ");
            }
            Console.WriteLine();
            for (int i = 0; i < 10; i++)
            {
                Console.Write(flags[i].ToString() + " ");
            }
            Console.WriteLine();
            Console.WriteLine("=========================================================");

            Console.WriteLine("Multiplcation Table: ");
            Console.WriteLine("================================");
            int number;
            for (int i = 1; i <= 10; i++)
            {
                Console.Write("[ ");
                for (int j = 1; j <= 10; j++)
                {
                    number = i * j;
                    Console.Write(" {0},", number.ToString());
                }
                Console.WriteLine("]");
            }
            Console.WriteLine("=========================================================");

            Console.WriteLine("Ice Cream Flavors: ");
            Console.WriteLine("================================");
            List<string> ice_cream = new List<string>();
            ice_cream.Add("Butter Pecan");
            ice_cream.Add("Cookies and Cream");
            ice_cream.Add("Mint Chocolate Chip");
            ice_cream.Add("Wild Cherry");
            ice_cream.Add("Cookie Dough");
            ice_cream.Add("Coffee");
            ice_cream.Add("Chunky Monkey");

            foreach (string flavor in ice_cream)
            {
                Console.Write(flavor + ", ");
            }
            Console.WriteLine();

            Console.WriteLine("=========================================================");

            Console.WriteLine("Dictionary of names: ");
            Console.WriteLine("================================");
            Dictionary<string, string> profiles = new Dictionary<string, string>();
            // for(int i=0;i<4;i++){
            // profiles.Add(names[i],null);

            // }
            Random rand = new Random();
            // foreach (var name in profiles){
            for (int i = 0; i < 4; i++)
            {
                profiles.Add(names[i], ice_cream[rand.Next(0, 3)]);

            }
            foreach (var name in profiles){
                Console.WriteLine(name.Key +": "+name.Value);
            }
            






        }
    }
}
