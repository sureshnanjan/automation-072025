// =============================
// File: Tests/AuthTests.cs
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
    public class AuthTests
    {
        [Test]
        public async Task CreateToken_Success_ReturnsToken()
        {
            var req = new RestRequest("/auth", Method.Post)
            .AddJsonBody(new AuthRequest(
            Environment.GetEnvironmentVariable("USERNAME") ?? "admin",
            Environment.GetEnvironmentVariable("PASSWORD") ?? "password123"));


            var resp = await TestBase.Client.ExecuteAsync(req);
            resp.StatusCode.Should().Be(HttpStatusCode.OK);


            var json = JsonSerializer.Deserialize<AuthResponse>(resp.Content!, TestBase.JsonOptions);
            json.Should().NotBeNull();
            json!.Token.Should().NotBeNullOrWhiteSpace();
        }


        [Test]
        public async Task CreateToken_Failure_BadCredentials()
        {
            var req = new RestRequest("/auth", Method.Post)
            .AddJsonBody(new AuthRequest("admin", "wrong-pass"));


            var resp = await TestBase.Client.ExecuteAsync(req);
            // Real API may return 200 with a reason; your mock might return 403.
            resp.StatusCode.Should().BeOneOf(HttpStatusCode.OK, HttpStatusCode.Forbidden);


            var err = JsonSerializer.Deserialize<ErrorResponse>(resp.Content!, TestBase.JsonOptions);
            err.Should().NotBeNull();
            (err!.Reason ?? err.Error).Should().Be("Bad credentials");
        }
    }
}