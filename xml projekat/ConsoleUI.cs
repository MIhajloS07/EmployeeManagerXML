using System;

namespace XML_project
{
    internal class ConsoleUI
    {
        public static void Help()
        {
            Console.ForegroundColor = ConsoleColor.DarkGray;
            Console.WriteLine();
            Console.WriteLine("+-----------------------------------------------+");
            Console.WriteLine("|----------------- HELP COMMANDS ---------------|");
            Console.WriteLine("|                                               |");
            Console.WriteLine("|    /add    -> Add Employee                    |");
            Console.WriteLine("|    /delete -> Remove Employee                 |");
            Console.WriteLine("|    /show   -> Employees                       |");
            Console.WriteLine("|    /clear  -> Clear cmd                       |");
            Console.WriteLine("|    /save   -> Save employees                  |");
            Console.WriteLine("|    /sort   -> Sort & arange employees by ID   |");
            Console.WriteLine("|    /update -> Update values for:              |");
            Console.ForegroundColor = ConsoleColor.Magenta;
            Console.WriteLine("|               update -age      | Update age   |");
            Console.WriteLine("|               update -fullname | Update name  |");
            Console.WriteLine("|               update -role     | Update role  |");
            Console.ForegroundColor= ConsoleColor.DarkGray;
            Console.WriteLine("|    /exit   -> Exit app                        |");
            Console.WriteLine("+-----------------------------------------------+");
            Console.WriteLine();
            Console.ResetColor();
        }
        public static void Menu()
        {
            Console.WriteLine();
            Console.WriteLine("[ /add | /delete | /show | /save | /clear | /exit ]");
            Console.WriteLine();
        }
    }
}
