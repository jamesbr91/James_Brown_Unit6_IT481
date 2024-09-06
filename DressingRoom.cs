using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Assignment6
{
    internal class DressingRoom
    {
        int rooms;
        Semaphore semaphore;
        long waitTimer;
        long runTimer;

        public DressingRoom()
        {
            rooms = 3;
            //set the semaphore object
            semaphore = new Semaphore(rooms, rooms);
        }

        public DressingRoom(int r)
        {
            rooms = r;
            semaphore = new Semaphore(rooms, rooms);
        }

        public async Task RequestRoom(Customer c)
        {
            Stopwatch stopwatch = Stopwatch.StartNew();
            //waiting thread
            Console.WriteLine("Customer is waiting");

            //start the wait timer
            stopwatch.Start();

            semaphore.WaitOne();

            //stop the wait timer
            stopwatch.Stop();

            //get the time elapsed for waiting
            waitTimer += stopwatch.ElapsedTicks;

            int roomWaitTime = getRandomNumber(1, 3);

            //start the timer
            stopwatch.Start();

            Thread.Sleep((roomWaitTime * c.getNumberOfItems()));

            //stop the wait timer
            stopwatch.Stop();

            //get the elapsed run time
            runTimer += stopwatch.ElapsedTicks;

            Console.WriteLine("Customer finished trying on items in room");
            semaphore.Release();
        }

        public long getWaitTime() { return waitTimer; }

        public long getRunTime() {  return runTimer; }

        //random number methods
        private static readonly Random getRandom = new Random();

        public static int getRandomNumber(int min, int max)
        {
            lock (getRandom)
            {
                return getRandom.Next(min, max);
            }
        }
    }
}
