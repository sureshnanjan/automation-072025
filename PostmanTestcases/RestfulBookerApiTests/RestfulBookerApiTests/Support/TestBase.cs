using System.Text.Json;
using RestSharp;
using System.Threading.Tasks;
using RestfulBookerApiTests.Models;

namespace RestfulBookerApiTests.Support
{
    public static class TestBase
    {
        public static RestClient Client { get; } = new RestClient("https://46a3d7ae-80a4-40ca-981b-37df110c39e2.mock.pstmn.io");

        public static JsonSerializerOptions JsonOptions { get; } = new JsonSerializerOptions
        {
            PropertyNameCaseInsensitive = true,
            PropertyNamingPolicy = JsonNamingPolicy.CamelCase
        };

        //public static Booking SampleBooking(
        //    string firstname = "John",
        //    string lastname = "Smith",
        //    int totalprice = 123,
        //    bool depositpaid = true,
        //    string checkin = "2024-01-01",
        //    string checkout = "2024-01-05",
        //    string additionalneeds = "Breakfast")
        //{
        //    return new Booking
        //    {
        //        Firstname = firstname,
        //        Lastname = lastname,
        //        Totalprice = totalprice,
        //        Depositpaid = depositpaid,
        //        Bookingdates = new BookingDates
        //        {
        //            Checkin = checkin,
        //            Checkout = checkout
        //        },
        //        Additionalneeds = additionalneeds
        //    };
        //}
        public static Booking SampleBooking(
           string firstname = "John",
           string lastname = "Smith",
           int totalprice = 123,
           bool depositpaid = true,
           string checkin = "2024-01-01",
           string checkout = "2024-01-05",
           string additionalneeds = "Breakfast")
        {
            var bookingDates = new BookingDates(checkin, checkout);

            return new Booking(
                firstname,
                lastname,
                totalprice,
                depositpaid,
                bookingDates,
                additionalneeds
            );
        }


        public static async Task<int> CreateBookingAsync(Booking booking)
        {
            var req = new RestRequest("/booking", Method.Post).AddJsonBody(booking);
            var resp = await Client.ExecuteAsync<CreateBookingResponse>(req);
            return resp.Data?.BookingId ?? 1; // fallback for mock
        }

        public static void AddAuthCookie(RestRequest request)
        {
            request.AddHeader("Cookie", "token=abc123");
        }
    }
}
