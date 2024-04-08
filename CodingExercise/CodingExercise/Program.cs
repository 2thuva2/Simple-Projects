using System;
using System.Linq;
using Newtonsoft.Json;
using System.Collections.Generic;

namespace CodingExercise
{
    class Program
    {
        static void Main(string[] args)
        {
            List<Flight> flights = JsonConvert.DeserializeObject<List<Flight>>(Properties.Resources.Flights);
            ViewFlightSchedule(flights);
            Console.Write("Press any key to continue.");
            Console.ReadLine();

            Dictionary<string, Order> orders = JsonConvert.DeserializeObject<Dictionary<string, Order>>(Properties.Resources.Orders);
            ScheduleOrders(flights, orders);

            Console.Write("Flight itineraries processed press any key to continue.");
            Console.ReadLine();
        }

        static void ViewFlightSchedule(List<Flight> flights)
        {
            foreach (Flight flight in flights)
            {
                Console.WriteLine(string.Format("Flight: {0}", flight));
            }
        }

        private static void ScheduleOrders(List<Flight> flights, Dictionary<string, Order> orders)
        {
            foreach (Order order in orders.Values)
            {
                Flight flight = FindAvailableFlight(flights, order.Destination);
                if (flight != null)
                {
                    flight.AddOrder(order);
                    Console.WriteLine(string.Format("order: {0}, flightNumber: {1}", order, flight));
                }
                else
                {
                    Console.WriteLine(string.Format("order: {0}, flightNumber: not scheduled", order));
                }
            }
        }

        static Flight FindAvailableFlight(List<Flight> flights, Airport destination)
        {
            return flights.FirstOrDefault(f => f.Arrival == destination && f.Orders.Count < 20);
        }
    }
}
