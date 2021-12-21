using System;
using System.Collections.Generic;
using System.Text;

namespace BankCallCentre
{
     static class Features
     {
        public static bool Try { get; private set; }
        static public bool TryAgain()                                      //end of game, press "y" to restart
        {
            Console.WriteLine("\nWould you like to perform one more operation? Press 'Y' or any other button to exit");
            Try = Console.ReadKey().Key == ConsoleKey.Y;
            if (Try == true)
            {
                return true;
            }
            else
            {
                System.Environment.Exit(0);
                return false;                                   //if !"Y" stop the program
            }
        }
        static public void Menu()
        {
            Console.WriteLine("\nChoose one of the following operations:\n" +
              "[+] 1 Add Data to the queue\n" +
              "[+] 2 Put call through to operator\n" +
              "[+] 3 Remove call from queue\n" +
              "[+] 4 Update queue\n" +
              "   [-] 5 Exit\n");
        }
    }
}
