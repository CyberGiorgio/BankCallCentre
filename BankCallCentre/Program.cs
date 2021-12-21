using System;

namespace BankCallCentre
{
    class Program
    {
        static void Main(string[] args)
        {
            bool isTrue;
            Queue cq = new Queue(); 
            cq.Init(); //initialize Queue
            do
            {
                cq.Display();   //display Queue
                Features.Menu();    //show menu
                isTrue = false;
                try
                {
                    switch (Convert.ToInt32(Console.ReadLine()))
                    {
                        case 1:
                            cq.EnQueue();
                            break;
                        case 2:
                            cq.DeQueue();
                            break;
                        case 3:
                            cq.RemoveMessage();
                            break;
                        case 4:
                            cq.Update();
                            break;
                        case 5:
                            isTrue = true;  //exit the program
                            System.Environment.Exit(0);
                            break;
                        default:
                            Console.WriteLine("Invalid input");
                            break;
                    }
                }
                catch (FormatException e)
                {
                    Console.WriteLine("Invalid input");
                }
                try
                {
                    if (Features.TryAgain() == true)    // new operation 'Y' or 'N'?   
                    {
                        Console.Clear();            //if press "Y" clear screen
                    }
                }
                catch (FormatException e)
                {
                    Console.WriteLine("Invalid input");
                }
            } while (!isTrue) ; //exit the program
        }
    }
}
