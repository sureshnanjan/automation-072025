// =============================
// File: Tests/BookingTests.cs
// =============================
using System.Net;
using System.Text.Json;
using FluentAssertions;
using NUnit.Framework;
using RestSharp;
using RestfulBookerApiTests.Models;
using RestfulBookerApiTests.Support;


namespace RestfulBookerApiTests.Tests

{
    [TestFixture]
    public class BookingTests
    {
        [Test]
        public async Task GetBookingIds_ReturnsArray()
        {
            var req = new RestRequest("/booking", Method.Get);
            var resp = await TestBase.Client.ExecuteAsync(req);


            resp.StatusCode.Should().Be(HttpStatusCode.OK);
            var list = JsonSerializer.Deserialize<List<BookingIdOnly>>(resp.Content!, TestBase.JsonOptions);
            list.Should().NotBeNull();
            list!.Count.Should().BeGreaterThan(0);
            list![0].BookingId.Should().BeGreaterThan(0);
        }

        [Test]
        public async Task GetBooking_Found_ContainsRequiredFields()
        {
            // Use ID 1 by default (works with your mock example)
            var req = new RestRequest("/booking/1", Method.Get);
            var resp = await TestBase.Client.ExecuteAsync(req);


            resp.StatusCode.Should().Be(HttpStatusCode.OK);
            var booking = JsonSerializer.Deserialize<Booking>(resp.Content!, TestBase.JsonOptions);
            booking.Should().NotBeNull();
            booking!.Firstname.Should().NotBeNullOrWhiteSpace();
            booking.Lastname.Should().NotBeNullOrWhiteSpace();
            booking.Totalprice.Should().BeGreaterThan(0);
            booking.Bookingdates.Checkin.Should().NotBeNullOrWhiteSpace();
            booking.Bookingdates.Checkout.Should().NotBeNullOrWhiteSpace();
        }

        [Test]
        public async Task GetBooking_NotFound_Returns404OrError()
        {
            var req = new RestRequest("/booking/999999", Method.Get);
            var resp = await TestBase.Client.ExecuteAsync(req);


            // Mock may return 404 with JSON; real API often returns 404 with text.
            resp.StatusCode.Should().Be(HttpStatusCode.NotFound);
        }

        [Test]
        public async Task CreateBooking_Success_ReturnsIdAndEchoedBody()
        {
            var payload = TestBase.SampleBooking("John", "Doe", 150, false, "2024-01-01", "2024-01-10", "Dinner");
            var req = new RestRequest("/booking", Method.Post).AddJsonBody(payload);
            var resp = await TestBase.Client.ExecuteAsync(req);


            resp.StatusCode.Should().BeOneOf(HttpStatusCode.OK, HttpStatusCode.Created);
            var created = JsonSerializer.Deserialize<CreateBookingResponse>(resp.Content!, TestBase.JsonOptions);
            created.Should().NotBeNull();
            created!.BookingId.Should().BeGreaterThan(0);
            created.Booking.Firstname.Should().Be(payload.Firstname);
            created.Booking.Bookingdates.Checkin.Should().Be(payload.Bookingdates.Checkin);
        }

        [Test]
        public async Task UpdateBooking_Success_RequiresAuth()
        {
            // Arrange: create a booking we can update
            var bookingId = await TestBase.CreateBookingAsync(TestBase.SampleBooking("James", "Brown", 222, true, "2024-02-01", "2024-02-05", "Lunch"));


            var updated = TestBase.SampleBooking("James", "Brown", 333, true, "2024-02-02", "2024-02-06", "Lunch");
            var req = new RestRequest($"/booking/{bookingId}", Method.Put).AddJsonBody(updated);
            TestBase.AddAuthCookie(req);


            var resp = await TestBase.Client.ExecuteAsync(req);
            resp.StatusCode.Should().Be(HttpStatusCode.OK);


            var body = JsonSerializer.Deserialize<Booking>(resp.Content!, TestBase.JsonOptions);
            body.Should().NotBeNull();
            body!.Totalprice.Should().Be(333);
            body.Bookingdates.Checkin.Should().Be("2024-02-02");
        }

        [Test]
        public async Task PartialUpdateBooking_Success_RequiresAuth()
        {
            // Arrange: create a booking we can patch
            var bookingId = await TestBase.CreateBookingAsync(TestBase.SampleBooking());


            var patchBody = new { firstname = "James", lastname = "Bond" };
            var req = new RestRequest($"/booking/{bookingId}", Method.Patch).AddJsonBody(patchBody);
            TestBase.AddAuthCookie(req);


            var resp = await TestBase.Client.ExecuteAsync(req);
            resp.StatusCode.Should().Be(HttpStatusCode.OK);


            var body = JsonSerializer.Deserialize<Booking>(resp.Content!, TestBase.JsonOptions);
            body.Should().NotBeNull();
            body!.Firstname.Should().Be("James");
            body.Lastname.Should().Be("Bond");
        }

        [Test]
        public async Task DeleteBooking_Success_RequiresAuth()
        {
            // Arrange: create a booking then delete it
            var bookingId = await TestBase.CreateBookingAsync(TestBase.SampleBooking());


            var req = new RestRequest($"/booking/{bookingId}", Method.Delete);
            TestBase.AddAuthCookie(req);


            var resp = await TestBase.Client.ExecuteAsync(req);
            // Real API returns 201 with plain text "Created"; your mock may return 201 + JSON {"status":"Deleted"}
            resp.StatusCode.Should().Be(HttpStatusCode.Created);


            // Try to parse JSON body, but fall back to plain text
            if (!string.IsNullOrWhiteSpace(resp.Content) && resp.Content!.TrimStart().StartsWith("{"))
            {
                var json = JsonSerializer.Deserialize<ErrorResponse>(resp.Content!, TestBase.JsonOptions);
                (json?.Error ?? json?.Reason ?? "Deleted").Should().BeOneOf("Deleted", "Created");
            }
            else
            {
                resp.Content?.Trim().Should().Be("Created");
            }
        }
    }
}