/*
 * -----------------------------------------------------------------------------
 *  Copyright (c) 2025 Jagadeeswar Reddy Arava
 *  This test suite is created for educational and QA automation purposes 
 *  against the Restful-Booker API.
 * -----------------------------------------------------------------------------
 */

using NUnit.Framework;
using RestSharp;
using System.Net;
using Newtonsoft.Json;

namespace RestfulBookerTests
{
    /// <summary>
    /// Test suite to validate CRUD operations against the Restful-Booker API.
    /// Covers: Create, Get, Update, Partial Update, Delete bookings and Auth.
    /// </summary>
    [TestFixture]
    public class BookingTests
    {
        private RestClient _client;
        private string _authToken;

        #region Setup and Teardown

        /// <summary>
        /// One-time setup to initialize RestClient and authentication token.
        /// </summary>
        [OneTimeSetUp]
        public void OneTimeSetup()
        {
            _client = new RestClient("https://restful-booker.herokuapp.com/");
            _authToken = GetAuthToken();
        }

        /// <summary>
        /// One-time teardown to dispose RestClient after all tests.
        /// </summary>
        [OneTimeTearDown]
        public void OneTimeTearDown()
        {
            _client?.Dispose();
        }

        #endregion

        #region Helper Methods

        /// <summary>
        /// Generates a valid auth token for tests requiring authorization.
        /// </summary>
        private string GetAuthToken()
        {
            var request = new RestRequest("auth", Method.Post);
            request.AddHeader("Content-Type", "application/json");
            request.AddJsonBody(new { username = "admin", password = "password123" });

            var response = _client.Execute(request);

            Assert.That(response.StatusCode, Is.EqualTo(HttpStatusCode.OK),
                $"Auth request failed. Status: {response.StatusCode}, Content: {response.Content}");

            dynamic authResponse = JsonConvert.DeserializeObject(response.Content);
            return authResponse.token;
        }

        /// <summary>
        /// Creates a new booking for use in tests.
        /// </summary>
        private int CreateBookingForTest()
        {
            var request = new RestRequest("booking", Method.Post);
            request.AddHeader("Content-Type", "application/json");
            request.AddHeader("Accept", "application/json");
            request.AddJsonBody(new
            {
                firstname = "TestUser",
                lastname = "Automation",
                totalprice = 250,
                depositpaid = true,
                bookingdates = new
                {
                    checkin = "2025-01-01",
                    checkout = "2025-01-10"
                },
                additionalneeds = "Breakfast"
            });

            var response = _client.Execute(request);
            Assert.That(response.StatusCode, Is.EqualTo(HttpStatusCode.OK),
                $"Booking creation failed. Status: {response.StatusCode}, Content: {response.Content}");

            dynamic bookingResponse = JsonConvert.DeserializeObject(response.Content);
            return (int)bookingResponse.bookingid;
        }

        #endregion

        #region Test Cases

        [Test]
        public void CreateBooking_ShouldReturn200()
        {
            var bookingId = CreateBookingForTest();
            Assert.That(bookingId, Is.GreaterThan(0), "Booking ID should be greater than 0.");
        }
    /// <summary>
        /// Test: Get Booking by valid ID should return 200 OK.
        /// FIXED: Creates a booking first to ensure ID exists.
        /// </summary>
        [Test]
        public void GetBooking_ShouldReturn200()
        {
            // Arrange - create booking first
            int bookingId = CreateBookingForTest();

            // Act
            var request = new RestRequest($"/booking/{bookingId}", Method.Get);
            var response = _client.Execute(request);

            // Assert
            Assert.That(response.StatusCode, Is.EqualTo(HttpStatusCode.OK), $"Expected 200 but got {(int)response.StatusCode}. Response: {response.Content}");
        }

        [Test]
        public void UpdateBooking_WithValidToken_ShouldReturn200()
        {
            var bookingId = CreateBookingForTest();

            var request = new RestRequest($"booking/{bookingId}", Method.Put);
            request.AddHeader("Content-Type", "application/json");
            request.AddHeader("Accept", "application/json");
            request.AddHeader("Cookie", $"token={_authToken}");

            request.AddJsonBody(new
            {
                firstname = "Updated",
                lastname = "User",
                totalprice = 500,
                depositpaid = false,
                bookingdates = new { checkin = "2025-02-01", checkout = "2025-02-10" },
                additionalneeds = "Lunch"
            });

            var response = _client.Execute(request);
            Assert.That(response.StatusCode, Is.EqualTo(HttpStatusCode.OK),
                $"Expected OK but got {response.StatusCode}. Response: {response.Content}");
        }

        [Test]
        public void PartialUpdateBooking_WithValidToken_ShouldReturn200()
        {
            var bookingId = CreateBookingForTest();

            var request = new RestRequest($"booking/{bookingId}", Method.Patch);
            request.AddHeader("Content-Type", "application/json");
            request.AddHeader("Accept", "application/json");
            request.AddHeader("Cookie", $"token={_authToken}");

            request.AddJsonBody(new
            {
                firstname = "PatchedName",
                lastname = "Tester"
            });

            var response = _client.Execute(request);

            Assert.That(response.StatusCode, Is.EqualTo(HttpStatusCode.OK),
                $"Expected OK but got {response.StatusCode}. Response: {response.Content}");
        }

        [Test]
        public void DeleteBooking_WithValidToken_ShouldReturn201()
        {
            var bookingId = CreateBookingForTest();
            Assert.That(bookingId, Is.GreaterThan(0), "Booking creation failed for delete test.");

            var request = new RestRequest($"booking/{bookingId}", Method.Delete);
            request.AddHeader("Content-Type", "application/json");
            request.AddHeader("Cookie", $"token={_authToken}");

            var response = _client.Execute(request);

            Assert.That(response.StatusCode, Is.EqualTo(HttpStatusCode.Created),
                $"Delete failed. Expected 201 but got {response.StatusCode}. Response: {response.Content}");
        }

        [Test]
        public void GetBookingIds_ShouldReturn200()
        {
            var request = new RestRequest("booking", Method.Get);
            var response = _client.Execute(request);

            Assert.That(response.StatusCode, Is.EqualTo(HttpStatusCode.OK),
                $"Expected 200 but got {response.StatusCode}. Response: {response.Content}");
        }

        [Test]
        public void GetBooking_WithInvalidId_ShouldReturn404()
        {
            var request = new RestRequest("booking/9999999", Method.Get);
            var response = _client.Execute(request);

            Assert.That(response.StatusCode, Is.EqualTo(HttpStatusCode.NotFound),
                $"Expected 404 but got {response.StatusCode}. Response: {response.Content}");
        }

        [Test]
        public void UpdateBooking_WithInvalidToken_ShouldReturn403()
        {
            var bookingId = CreateBookingForTest();

            var request = new RestRequest($"booking/{bookingId}", Method.Put);
            request.AddHeader("Content-Type", "application/json");
            request.AddHeader("Cookie", "token=invalid");

            request.AddJsonBody(new
            {
                firstname = "InvalidUpdate",
                lastname = "User"
            });

            var response = _client.Execute(request);

            Assert.That(response.StatusCode, Is.EqualTo(HttpStatusCode.Forbidden),
                $"Expected 403 but got {response.StatusCode}. Response: {response.Content}");
        }

        [Test]
        public void DeleteBooking_WithInvalidToken_ShouldReturn403()
        {
            var bookingId = CreateBookingForTest();

            var request = new RestRequest($"booking/{bookingId}", Method.Delete);
            request.AddHeader("Content-Type", "application/json");
            request.AddHeader("Cookie", "token=invalid");

            var response = _client.Execute(request);

            Assert.That(response.StatusCode, Is.EqualTo(HttpStatusCode.Forbidden),
                $"Expected 403 but got {response.StatusCode}. Response: {response.Content}");
        }

        [Test]
        public void CreateBooking_WithMissingFields_ShouldReturn500()
        {
            var request = new RestRequest("booking", Method.Post);
            request.AddHeader("Content-Type", "application/json");
            request.AddJsonBody(new { firstname = "OnlyName" });

            var response = _client.Execute(request);

            Assert.That(response.StatusCode, Is.EqualTo(HttpStatusCode.InternalServerError),
                $"Expected 500 but got {response.StatusCode}. Response: {response.Content}");
        }

        [Test]
        public void Auth_WithInvalidCredentials_ShouldReturn200AndNoToken()
        {
            var request = new RestRequest("auth", Method.Post);
            request.AddHeader("Content-Type", "application/json");
            request.AddJsonBody(new { username = "wrong", password = "wrong" });

            var response = _client.Execute(request);

            Assert.That(response.StatusCode, Is.EqualTo(HttpStatusCode.OK),
                $"Expected 200 but got {response.StatusCode}. Response: {response.Content}");

            Assert.That(response.Content.Contains("token"), Is.False,
                $"Auth with invalid creds should not return token. Response: {response.Content}");
        }

        [Test]
        public void HealthCheck_ShouldReturn201()
        {
            var request = new RestRequest("ping", Method.Get);
            var response = _client.Execute(request);

            Assert.That(response.StatusCode, Is.EqualTo(HttpStatusCode.Created),
                $"Expected 201 but got {response.StatusCode}. Response: {response.Content}");
        }

        [Test]
        public void GetBookingIds_WithFilters_ShouldReturn200()
        {
            var request = new RestRequest("booking?firstname=TestUser&lastname=Automation", Method.Get);
            var response = _client.Execute(request);

            Assert.That(response.StatusCode, Is.EqualTo(HttpStatusCode.OK),
                $"Expected 200 but got {response.StatusCode}. Response: {response.Content}");
        }

        #endregion
    }
}
