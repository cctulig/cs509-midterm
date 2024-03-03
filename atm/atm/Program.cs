using Dapper;
using Google.Protobuf.WellKnownTypes;
using MySql.Data.MySqlClient;
using System.Data;



class Program
{
    static void Main(string[] args)
    {
        bool endApp = false;

        Console.WriteLine("ATM Application");
        Console.WriteLine("------------------------");

        while (!endApp)
        {
            Console.WriteLine("Sign in!");
            
            Console.WriteLine("Enter login:");
            string username = Console.ReadLine();

            Console.WriteLine("Enter Pin code:");
            string password = Console.ReadLine();

            // Assume admin for now
            Console.WriteLine("1----Create New Account\r\n2----Delete Existing Account\r\n3----Update Account Information\r\n4----Search for Account\r\n6----Exit\r\n");
            string navCommand = Console.ReadLine();
            int navCommandNum = 0;

            bool success = int.TryParse(navCommand, out navCommandNum);
            if (!success)
            {
                Console.WriteLine($"Attempted conversion of '{navCommand ?? "<null>"}' failed. Using Command 1 by default");
                navCommandNum = 1;
            }

            if (navCommandNum < 1 || navCommandNum > 5)
            {
                Console.WriteLine($"Invalid command '{navCommand}'. Using Command 1 by default");
                navCommandNum = 1;
            }

            switch(navCommandNum)
            {
                case 1:
                    Console.WriteLine("Create New Account");
                    break;
                case 2:
                    Console.WriteLine("Delete Existing Account");
                    break;
                case 3:
                    Console.WriteLine("Update Account Information");
                    break;
                case 4:
                    Console.WriteLine("Search for Account");
                    break;
                case 5:
                    Console.WriteLine("Exit");
                    break;
            }
        }
    }
}