using System;
using System.Collections.Generic;

namespace Boxing
{
    class Program
    {
        static void Main(string[] args)
        {
            List<object> mylist = new List<object>();
            // object value;
            // value = 7;
            mylist.Add(7);
            // value = 28;
            mylist.Add(28);
            mylist.Add(-1);
            mylist.Add(true);
            mylist.Add("chair");
            int sum = 0;
            foreach (var x in mylist)
            {


                Console.WriteLine(x);
                if (x is int)
                {
                    sum += (int)x;

                }

            }
            Console.WriteLine("The sum of all ints = "+ sum);
        }
    }
}
