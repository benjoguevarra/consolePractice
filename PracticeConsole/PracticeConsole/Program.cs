using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PracticeConsole
{
    public class Program
    {
        public static void Main(string[] args)
        {
            // call main menu
            MainMenu();
        }

        static void MainMenu()
        {
            string x = string.Empty;

            do
            {
                Console.WriteLine("===============================");
                Console.WriteLine("1. Login 2. Register 0. Exit");
                Console.WriteLine("===============================");
                x = Console.ReadLine();

                if (x.StartsWith("1"))
                {
                    Login();
                }
                else if (x.StartsWith("2"))
                {
                    Register();
                }
                else if (x.StartsWith("0"))
                {
                    Exit();
                }
            }
            while (!x.StartsWith("1") || !x.StartsWith("2") || !x.StartsWith("0"));
        }

        static void Register()
        {
            bool containsNumber = false;
            bool correctLenght = false;
            bool hasSpace;
            string name = string.Empty;
            string password = string.Empty;
            
            Console.WriteLine("REGISTRATION");    
            do
            {
                Console.Write("Enter your name: ");
                name = Console.ReadLine();

                containsNumber = name.Any(c => char.IsDigit(c)); // check kung my number, mag rereturn ng bool
                hasSpace = name.Contains(" "); // check kung my space, mag rereturn ng bool

                if (containsNumber)
                    Console.WriteLine("Your name has a number. "); // message lang does not validate anything.

                if (hasSpace)
                    Console.WriteLine("Your name has a space. ");

                if (name == "")
                    Console.WriteLine("Enter a name. ");
            }
            while (containsNumber || hasSpace || name == ""); // actual validation, mag loloop pag may nag true.

            do
            {
                const int Min = 8;
                const int Max = 16;

                Console.Write("Enter your password: ");
                password = Console.ReadLine();

                int lenght = password.Length;

                if (lenght < Min || lenght > Max)
                {
                    Console.WriteLine($"Password should be {Min} to {Max} characters. ");
                    correctLenght = false;
                }
                else if(password.Trim() == "")
                {
                    Console.WriteLine($"Enter a password!");
                }
                else
                {
                    correctLenght = true;
                }
            }
            while (!correctLenght || password.Trim() == ""); // actual validation, mag loloop pag may nag true.

            StorePassword(name, password);
            Console.WriteLine($"You are now registered.");

            MainMenu();
        }

        public static void Login()
        {
            string name = string.Empty;
            string password = string.Empty;

            Console.WriteLine("LOGIN");
            do
            {

                Console.Write("Enter name: ");
                name = Console.ReadLine();
                Console.Write("Enter password: ");
                password = Console.ReadLine();
            }
            while (!ValidatePassword(name, password)); // icacall ung nasa baba with name and password as parameters

            Console.WriteLine("You are now logged in.");
            MainMenu();
        }

        static void Exit()
        {
            Environment.Exit(0);
        }

        // store password method
        static void StorePassword(string username, string password)
        {
            string[] credentials = new string[] { username, password };
            System.IO.File.WriteAllLines(@"C:\Users\Benjo\Desktop\test.txt", credentials); //change mo sa path ng desktop mo. auto create na ung notepad
        }

        // validate password method, will return a boolean
        static bool ValidatePassword(string username, string password)
        {
            try
            {
                string[] content = System.IO.File.ReadAllLines(@"C:\Users\Benjo\Desktop\test.txt");

                if (username != content[0] || password != content[1])
                {
                    Console.WriteLine("Wrong name or password.");
                    return false;
                }
                else
                { 
                    return true;
                }
              
            }
            catch (Exception ex)
            {
                Console.WriteLine("Register first.", ex.Message);
                MainMenu();
                return false;
            }

        }

    }
}
