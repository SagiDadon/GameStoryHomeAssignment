using FlightsBookerClient.RequestObjects;
using System.Net.Http.Json;

namespace FlightsBookerClient.BookingManagment
{
    public class BookingManager : IBookingManager
    {
        private readonly HttpClient _httpClient;

        public BookingManager(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public Task<HttpResponseMessage> BookFlightAsync(FlightBookingRequest bookingRequest)
        {
            Task<HttpResponseMessage> result = _httpClient.PostAsJsonAsync("/flight/book", bookingRequest);


            return Task.FromResult(result.Result);


        }
    }
}
