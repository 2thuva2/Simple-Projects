using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using System;
using System.Collections.Generic;

namespace CodingExercise
{
    [JsonConverter(typeof(StringEnumConverter))]
    enum Airport
    {
        YUL = 0,
        YVR = 1,
        YYC = 3,
        YYE = 4,
        YYZ = 5
    }

    class Flight
    {
        public int Day { get; set; }
        public int Number { get; set; }
        public Airport Departure { get; set; }
        public Airport Arrival { get; set; }
        [JsonIgnore]
        public List<Order> Orders { get; } = new List<Order>();

        public Flight(int day, int number, Airport departure, Airport arrival)
        {
            Day = day;
            Number = number;
            Departure = departure;
            Arrival = arrival;
        }
        
        public void AddOrder(Order order)
        {
            if (Orders.Count < 20)
            {
                Orders.Add(order);
            }    
        }

        public override string ToString()
        {
            return String.Format("{0}, departure: {1}, arrival: {2}, day: {3}",
                          Number, Departure, Arrival.ToString(), Day.ToString());
        }
    }
}
