using Newtonsoft.Json;

namespace CodingExercise
{
    class Order
    {
        [JsonIgnore]
        public int Number { get; private set; }
        public Airport Destination { get; set; }

        static int nextOrderNumber = 1;

        public Order(Airport destination)
        {
            Number = nextOrderNumber++;
            Destination = destination;
        }

        public override string ToString()
        {
            return string.Format("order-{0:000}", Number);
        }
    }
}
