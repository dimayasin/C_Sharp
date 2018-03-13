using System;
using DbConnection;
using System.Collections.Generic;

namespace SimpleCRUD
{
    class Program
    {
        static void DisplayData(){

            foreach (var row in DbConnector.Query("Select * From Users;")){
                Console.WriteLine("{0}\t{1}\t{2}",row["FirstName"],row["LastName"],row["FavoriteNumber"]);
            }

        }


        static void AddUsers()
        {
            string userFN, userLN;
            int num;
            Console.Write("Enter New User's First Name: ");
            userFN = Console.ReadLine();
            Console.Write("Enter New User's Lasst Name: ");
            userLN = Console.ReadLine();
            Console.Write("Enter New User's favorite Number: ");
            num = Int32.Parse(Console.ReadLine());
            string myquery;
            myquery = "insert into Users (FirstName,LastName,FavoriteNumber) Values ('" + userFN + "','" + userLN + "'," + num + ");";

            DbConnector.Execute(myquery);

        }
        static void Main(string[] args)
        {
            AddUsers();
            DisplayData();
            // Console.WriteLine("Hello World!");
        }
    }
}
