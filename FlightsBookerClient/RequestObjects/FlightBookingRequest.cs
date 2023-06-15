namespace FlightsBookerClient.RequestObjects
{
    public class FlightBookingRequest
    {
        public string passengerName { get; set; }
        public string Seat { get; set; }
        public DateTime date { get; set; }
    }
}
