using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignment6
{
    internal class Scenario
    {
        static Customer cust;
        static int items = 0;
        static int numberOfItems;
        static int controlItemNumber;

        public Scenario(int r, int c)
        {
            Console.WriteLine(r + "dressing rooms " + " for " + c + "customer.");

            controlItemNumber = 0;
            numberOfItems = 0;
        }

        static void Main(string[] args)
        {
            //clothingItems = 0 will indicate the use of a random number
            //clothingItems = 1 - 20 will allow for load tsting by forcing a specific number of items.
            Console.WriteLine("how many customers do you want? ");
            int numberOfCustomers = Int32.Parse(Console.ReadLine());
            Console.WriteLine("there are " + numberOfCustomers + " total customers");

            //set the number of dressing rooms
            Console.WriteLine("how mnay dressing rooms do you want? ");
            int totalRooms = Int32.Parse(Console.ReadLine());

            //start the scenario for testing
            Scenario s = new Scenario(totalRooms, numberOfCustomers);

            //create the dressing rooms object with number of rooms
            DressingRoom dr = new DressingRoom(totalRooms);

            List<Task> tasks = new List<Task>();

            //loop through the customers and create threads
            for (int i = 0; i < numberOfCustomers; i++)
            {
                //create the customer object
                cust = new Customer(controlItemNumber);

                //get the number of items
                numberOfItems = cust.getNumberOfItems();

                //track total number of items
                items += numberOfItems;

                //start async request room
                tasks.Add(Task.Factory.StartNew(async () =>
                {
                    await dr.RequestRoom(cust);
                }));
            }

            Task.WaitAll(tasks.ToArray());

            Console.WriteLine("average run time in milliseconds {0}", dr.getRunTime() / numberOfCustomers);
            Console.WriteLine("average wait time in millseconds {0} ", dr.getWaitTime()/numberOfCustomers);
            Console.WriteLine("total customers is {0}", numberOfCustomers);
            int averageitemsPerCustomer = items / numberOfCustomers;
            Console.WriteLine("average number of items was: " + averageitemsPerCustomer );
            Console.ReadLine();
        }

    }
}
