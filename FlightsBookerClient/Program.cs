using FlightsBookerClient.BookingManagment;
using FlightsBookerClient.RequestObjects;
using System;
using System.Net.Http;
using System.Threading.Tasks;

namespace FlightsBookerClient
{
    class Program
    {
        static async Task Main()
        {
            HttpClient client = new HttpClient { BaseAddress = new Uri("https://localhost:5001") };


            //request data example
            FlightBookingRequest bookingData = new FlightBookingRequest
            {
                passengerName = "sagi dadon",
                Seat = "A1",
                date = DateTime.Now
            };

            IBookingManager bookingManager = new BookingManager(client);


            // Prompt the user for the number of messages to send
            Console.Write("Enter the number of bookings (50 minimum) to send: ");
            if (!int.TryParse(Console.ReadLine(), out int numberOfMessages) || numberOfMessages < 50)
            {
                Console.WriteLine("Invalid input. Please enter a minimum of 50");
                return;
            }


            for (int i = 0; i < numberOfMessages; i++)
            {
                try
                {
                    var response = await bookingManager.BookFlightAsync(bookingData);

                    // Check if the request was successful
                    if (response.IsSuccessStatusCode)
                    {
                        Console.WriteLine("Flight booked successfully!");
                    }
                    else
                    {
                        Console.WriteLine("Failed to create booking. Status code: " + response.StatusCode);
                    }

                }
                catch (Exception ex)
                {
                    Console.WriteLine("An error occurred: " + ex.Message);
                }
            }
        }
    }
}
