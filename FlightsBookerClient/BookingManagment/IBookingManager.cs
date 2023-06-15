using FlightsBookerClient.RequestObjects;

namespace FlightsBookerClient.BookingManagment
{
    public interface IBookingManager
    {
        Task<HttpResponseMessage> BookFlightAsync(FlightBookingRequest bookingRequest);
    }
}
