/*
* -----------------------------------------------------------------------------
*  Copyright (c) 2025 John / K VAMSI KRISHNA. 
*  This test suite is created for educational and QA automation purposes 
*  against the Restful-Booker API.
* -----------------------------------------------------------------------------
*/

using NUnit.Framework;
using RestSharp;
using System.Net;
using Newtonsoft.Json.Linq;

namespace RestfulBookerTests
{
    /// <summary>
    /// NUnit test suite for validating the Restful-Booker API endpoints.
    /// Covers positive and negative scenarios for GET, POST, PUT, PATCH, DELETE.
    /// Uses AAA (Arrange-Act-Assert) pattern with one assertion per test.
    /// </summary>
    [TestFixture]
    public class BookingTests
    {
        private RestClient client;
        private string authToken;

        /// <summary>
        /// Runs once before all tests to set up the RestClient and fetch an auth token.
        /// </summary>
        [OneTimeSetUp]
        public void OneTimeSetup()
        {
            // Arrange
            client = new RestClient("https://998877dtd-99f5-480c-bc6c-5737d2dc1b84.mock.pstmn.io");

            var authRequest = new RestRequest("auth", Method.Post);
            authRequest.AddJsonBody(new { username = "admin", password = "password123" });

            // Act
            var response = client.Execute(authRequest);
            var json = JObject.Parse(response.Content);

            // Assert
            authToken = json["token"]?.ToString();
            Assert.IsNotNull(authToken, "Auth token should not be null.");
        }

        // ----------------------------------------------------------------------
        // GET BOOKING TESTS
        // ----------------------------------------------------------------------

        /// <summary>
        /// Verify GET /booking returns 200 OK.
        /// </summary>
        [Test]
        public void GetBookingIds_StatusCodeIs200()
        {
            // Arrange
            var request = new RestRequest("booking", Method.Get);

            // Act
            var response = client.Execute(request);

            // Assert
            Assert.That(response.StatusCode, Is.EqualTo(HttpStatusCode.OK));
        }

        /// <summary>
        /// Verify GET /booking/{id} returns 200 OK.
        /// </summary>
        [Test]
        public void GetBooking_StatusCodeIs200()
        {
            // Arrange
            var request = new RestRequest("booking/10", Method.Get);

            // Act
            var response = client.Execute(request);

            // Assert
            Assert.That(response.StatusCode, Is.EqualTo(HttpStatusCode.OK));
        }

        /// <summary>
        /// Verify GET /booking/{id} returns a response with firstname field.
        /// </summary>
        [Test]
        public void GetBooking_ResponseContainsFirstname()
        {
            // Arrange
            var request = new RestRequest("booking/10", Method.Get);

            // Act
            var response = client.Execute(request);
            var json = JObject.Parse(response.Content);

            // Assert
            Assert.IsTrue(json.ContainsKey("firstname"));
        }

        /// <summary>
        /// Verify GET /booking/{id} returns a response with lastname field.
        /// </summary>
        [Test]
        public void GetBooking_ResponseContainsLastname()
        {
            // Arrange
            var request = new RestRequest("booking/10", Method.Get);

            // Act
            var response = client.Execute(request);
            var json = JObject.Parse(response.Content);

            // Assert
            Assert.IsTrue(json.ContainsKey("lastname"));
        }

        /// <summary>
        /// Verify GET /booking/{id} returns 404 Not Found for invalid ID.
        /// </summary>
        [Test]
        public void GetBooking_InvalidId_Returns404()
        {
            // Arrange
            var request = new RestRequest("booking/99999", Method.Get);

            // Act
            var response = client.Execute(request);

            // Assert
            Assert.That(response.StatusCode, Is.EqualTo(HttpStatusCode.NotFound));
        }

        // ----------------------------------------------------------------------
        // CREATE BOOKING TESTS
        // ----------------------------------------------------------------------

        /// <summary>
        /// Verify POST /booking returns 200 OK.
        /// </summary>
        [Test]
        public void CreateBooking_StatusCodeIs200()
        {
            // Arrange
            var request = new RestRequest("booking", Method.Post);
            request.AddJsonBody(new
            {
                firstname = "Elangovan",
                lastname = "R",
                totalprice = 109,
                depositpaid = true,
                bookingdates = new { checkin = "2025-08-17", checkout = "2025-08-20" },
                additionalneeds = "Breakfast"
            });

            // Act
            var response = client.Execute(request);

            // Assert
            Assert.That(response.StatusCode, Is.EqualTo(HttpStatusCode.OK));
        }

        /// <summary>
        /// Verify POST /booking response contains bookingid.
        /// </summary>
        [Test]
        public void CreateBooking_ResponseContainsBookingId()
        {
            // Arrange
            var request = new RestRequest("booking", Method.Post);
            request.AddJsonBody(new
            {
                firstname = "Elangovan",
                lastname = "R",
                totalprice = 109,
                depositpaid = true,
                bookingdates = new { checkin = "2025-08-17", checkout = "2025-08-20" },
                additionalneeds = "Breakfast"
            });

            // Act
            var response = client.Execute(request);

            // Assert
            Assert.That(response.Content, Does.Contain("bookingid"));
        }

        /// <summary>
        /// Verify POST /booking without body returns 400 Bad Request.
        /// </summary>
        [Test]
        public void CreateBooking_MissingBody_Returns400()
        {
            // Arrange
            var request = new RestRequest("booking", Method.Post);

            // Act
            var response = client.Execute(request);

            // Assert
            Assert.That(response.StatusCode, Is.EqualTo(HttpStatusCode.BadRequest));
        }

        // ----------------------------------------------------------------------
        // UPDATE BOOKING TESTS
        // ----------------------------------------------------------------------

        /// <summary>
        /// Verify PUT /booking/{id} with valid token returns 200 OK.
        /// </summary>
        [Test]
        public void UpdateBooking_StatusCodeIs200()
        {
            // Arrange
            var request = new RestRequest("booking/1436", Method.Put);
            request.AddHeader("Cookie", $"token={authToken}");
            request.AddJsonBody(new
            {
                firstname = "UpdatedName",
                lastname = "R",
                totalprice = 200,
                depositpaid = true,
                bookingdates = new { checkin = "2025-09-01", checkout = "2025-09-10" },
                additionalneeds = "Lunch"
            });

            // Act
            var response = client.Execute(request);

            // Assert
            Assert.That(response.StatusCode, Is.EqualTo(HttpStatusCode.OK));
        }

        /// <summary>
        /// Verify PUT /booking/{id} with invalid ID returns 404 Not Found.
        /// </summary>
        [Test]
        public void UpdateBooking_InvalidId_Returns404()
        {
            // Arrange
            var request = new RestRequest("booking/99999", Method.Put);
            request.AddHeader("Cookie", $"token={authToken}");
            request.AddJsonBody(new { firstname = "Fail" });

            // Act
            var response = client.Execute(request);

            // Assert
            Assert.That(response.StatusCode, Is.EqualTo(HttpStatusCode.NotFound));
        }

        /// <summary>
        /// Verify PUT /booking/{id} with invalid token returns 403/401.
        /// </summary>
        [Test]
        public void UpdateBooking_InvalidToken_Returns403()
        {
            // Arrange
            var request = new RestRequest("booking/1436", Method.Put);
            request.AddHeader("Cookie", "token=InvalidToken");
            request.AddJsonBody(new { firstname = "Fail" });

            // Act
            var response = client.Execute(request);

            // Assert
            Assert.That(response.StatusCode, Is.EqualTo(HttpStatusCode.Forbidden)
                .Or.EqualTo(HttpStatusCode.Unauthorized));
        }

        // ----------------------------------------------------------------------
        // PARTIAL UPDATE BOOKING TESTS
        // ----------------------------------------------------------------------

        /// <summary>
        /// Verify PATCH /booking/{id} returns 200 OK with valid token.
        /// </summary>
        [Test]
        public void PartialUpdateBooking_StatusCodeIs200()
        {
            // Arrange
            var request = new RestRequest("booking/9", Method.Patch);
            request.AddHeader("Cookie", $"token={authToken}");
            request.AddJsonBody(new { firstname = "PatchedName" });

            // Act
            var response = client.Execute(request);

            // Assert
            Assert.That(response.StatusCode, Is.EqualTo(HttpStatusCode.OK));
        }

        /// <summary>
        /// Verify PATCH /booking/{id} with invalid ID returns 404.
        /// </summary>
        [Test]
        public void PartialUpdateBooking_InvalidId_Returns404()
        {
            // Arrange
            var request = new RestRequest("booking/99999", Method.Patch);
            request.AddHeader("Cookie", $"token={authToken}");
            request.AddJsonBody(new { firstname = "Fail" });

            // Act
            var response = client.Execute(request);

            // Assert
            Assert.That(response.StatusCode, Is.EqualTo(HttpStatusCode.NotFound));
        }

        // ----------------------------------------------------------------------
        // DELETE BOOKING TESTS
        // ----------------------------------------------------------------------

        /// <summary>
        /// Verify DELETE /booking/{id} returns 201 Created with valid token.
        /// </summary>
        [Test]
        public void DeleteBooking_StatusCodeIs201()
        {
            // Arrange
            var request = new RestRequest("booking/10", Method.Delete);
            request.AddHeader("Cookie", $"token={authToken}");

            // Act
            var response = client.Execute(request);

            // Assert
            Assert.That(response.StatusCode, Is.EqualTo(HttpStatusCode.Created));
        }

        /// <summary>
        /// Verify DELETE /booking/{id} with invalid ID returns 404 Not Found.
        /// </summary>
        [Test]
        public void DeleteBooking_InvalidId_Returns404()
        {
            // Arrange
            var request = new RestRequest("booking/99999", Method.Delete);
            request.AddHeader("Cookie", $"token={authToken}");

            // Act
            var response = client.Execute(request);

            // Assert
            Assert.That(response.StatusCode, Is.EqualTo(HttpStatusCode.NotFound));
        }

        /// <summary>
        /// Verify DELETE /booking/{id} with invalid token returns 403/401.
        /// </summary>
        [Test]
        public void DeleteBooking_InvalidToken_Returns403()
        {
            // Arrange
            var request = new RestRequest("booking/10", Method.Delete);
            request.AddHeader("Cookie", "token=InvalidToken");

            // Act
            var response = client.Execute(request);

            // Assert
            Assert.That(response.StatusCode, Is.EqualTo(HttpStatusCode.Forbidden)
                .Or.EqualTo(HttpStatusCode.Unauthorized));
        }
    }
}