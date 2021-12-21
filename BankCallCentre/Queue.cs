using System;
using System.Collections.Generic;
using System.Text;

namespace BankCallCentre
{
    public class Queue
    {
        private static int SIZE = 20; //constant size of Queue
        private int front, tail;    //pointers
        private int callNoTot;  //total calls
        private int callNoLeft; //waiting calls to be served
        private int callId; //id number of the call
        private bool[] waiting = new bool[SIZE];    //array state of calls
        private string[] time = new string[SIZE];   //array of time

        public bool [] Init()    //initialize function all set to false
        {
            for(int i = 0; i < waiting.Length; i++)
            {
                waiting[i] = false;
            }
            return waiting;
        }
        public Queue()  //constructor Queue
        {
            front = -1;
            tail = -1;
            callNoTot = 0;
        }
        public bool IsFull() // Check if the queue is full
        {
            if (front == 0 && tail == SIZE -1)
            {
                return true;
            }
            return false;
        }
        public bool IsEmpty()
        // Check if the queue is empty
        {
            if (front == -1)
                return true;
            else
                return false;
        }
        public void EnQueue()   // Adding an element 
        {
            try
            {
                if (IsFull())   // chech if Queue is full
                {
                    Console.WriteLine("Queue is full ");
                }
                else
                {
                    if (front == -1)    //if queue empty
                    {
                        front = 0;
                        callId = 0;
                        tail = 0;
                    }
                    if (waiting[tail] == true && tail <= SIZE) 
                    {       //looking for empty spaces into the queue
                        tail++;
                    }
                    callId = tail;
                    waiting[tail] = true;
                    time[tail] = DateTime.Now.ToString("dddd, dd MMMM yyyy, hh:mm:ss tt");  //set time
                    callNoTot++;        //display summary of the operation
                    Console.WriteLine("Inserted call no. " + callNoTot + " ,id no. " + callId + " ,on " + time[tail]);
                    callNoLeft++;
                }
            }
            catch (IndexOutOfRangeException e) {    //input check
                Console.WriteLine("Index out of range");
            }
        }
        public void DeQueue()  // DeQueue an element
        {
            if (IsEmpty())
            {
                Console.WriteLine("Queue is empty");
                return;
            }
            else
            {
                Remove(0); //remove the first element of the queue
            }
        }
        public void RemoveMessage() //message for Remove element
        {
            Console.WriteLine("What index do you wish to remove?");
            callId = Convert.ToInt32(Console.ReadLine());
            time[callId] = DateTime.Now.ToString("dddd, dd MMMM yyyy, hh:mm:ss tt");
            Remove(callId);
        }
        public void Remove(int callId)  // Removing a specific element
        {
            if (IsEmpty())
            {
                Console.WriteLine("Queue is empty  on " + time[callId]);
                return;
            } else if (waiting[callId] == false)
            {
                time[callId] = null;
                Console.WriteLine("This call is not on the waiting list");
                return;
            }
            else 
            {
                if (front == tail)
                {     // Q has only one element, so we reset the queue after deleting it
                    front = -1;
                    tail = -1;
                    callId = 0;
                }
                Console.WriteLine("Id call no. " + callId + " removed on " + time[callId]);
                for (int i = callId; i < time.Length; i++) //loop starting from element to remove
                {
                    if (i != time.Length - 1)
                    {
                        time[i] = time[i + 1];  //swap all indexes
                    }
                    else 
                    {
                        time[i] = null;
                    }
                    if (time[i] == null)
                    {
                        waiting[i] = false;
                    }
                }
                tail--;
                callNoLeft--;
            }
        }
        public void Update()     //update date and time of an element
        {
            Console.WriteLine("What index do you wish to update?");
            callId = Convert.ToInt32(Console.ReadLine());
            if (waiting[callId] == false)
            {
                Console.WriteLine("This call is not in the waiting list");
            }
            else
            {
                Remove(callId);     //element removed
                EnQueue();      //reintroduced as last
            }
        }
        public void Display()       //print status of Circular Queue
        {
            int i;
            if (IsEmpty())  //empty check
            {
                Console.WriteLine("Empty Queue");
            }
            else
            {
                Console.WriteLine("Front -> " + front); //start pointer
                Console.WriteLine("Rear -> " + tail); //end pointer
                Console.WriteLine("Calls on the queue ");

                for (i = 0; i < waiting.Length; i++) //display waiting list
                    Console.WriteLine(" ID call no. [" + i + "] " + " waiting for operator : " + waiting[i] + " " + time[i]);
                                            //summary of actual items into the list
                Console.WriteLine("\n[+]Call no. left = " + callNoLeft + ", call no. TodayTotal = " + callNoTot + 
                    ", on " + DateTime.Now.ToString("dddd, dd MMMM yyyy, hh:mm:ss tt"));
            }
        }
    }
}
