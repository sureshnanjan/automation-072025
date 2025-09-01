//using System.Text.Json.Serialization;


//namespace RestfulBookerApiTests.Models
//{
//    public record BookingDates(
//    [property: JsonPropertyName("checkin")] string Checkin,
//    [property: JsonPropertyName("checkout")] string Checkout
//    );


//    public record Booking(
//    [property: JsonPropertyName("firstname")] string Firstname,
//    [property: JsonPropertyName("lastname")] string Lastname,
//    [property: JsonPropertyName("totalprice")] int Totalprice,
//    [property: JsonPropertyName("depositpaid")] bool Depositpaid,
//    [property: JsonPropertyName("bookingdates")] BookingDates Bookingdates,
//    [property: JsonPropertyName("additionalneeds")] string? Additionalneeds
//    );


//    public record CreateBookingResponse(
//    [property: JsonPropertyName("bookingid")] int BookingId,
//    [property: JsonPropertyName("booking")] Booking Booking
//    );


//    public record BookingIdOnly([property: JsonPropertyName("bookingid")] int BookingId);


//    public record AuthRequest(
//    [property: JsonPropertyName("username")] string Username,
//    [property: JsonPropertyName("password")] string Password);


//    public record AuthResponse([property: JsonPropertyName("token")] string Token);


//    public record ErrorResponse(
//    [property: JsonPropertyName("error")] string? Error,
//    [property: JsonPropertyName("reason")] string? Reason
//    );
//}

using System.Text.Json.Serialization;

namespace RestfulBookerApiTests.Models
{
    public record BookingDates(
        [property: JsonPropertyName("checkin")] string Checkin,
        [property: JsonPropertyName("checkout")] string Checkout
    );

    public record Booking(
        [property: JsonPropertyName("firstname")] string Firstname,
        [property: JsonPropertyName("lastname")] string Lastname,
        [property: JsonPropertyName("totalprice")] int Totalprice,
        [property: JsonPropertyName("depositpaid")] bool Depositpaid,
        [property: JsonPropertyName("bookingdates")] BookingDates Bookingdates,
        [property: JsonPropertyName("additionalneeds")]
        [property: JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        string? Additionalneeds = null
    );

    public record CreateBookingResponse(
        [property: JsonPropertyName("bookingid")] int BookingId,
        [property: JsonPropertyName("booking")] Booking Booking
    );

    public record BookingIdOnly(
        [property: JsonPropertyName("bookingid")] int BookingId
    );

    public record AuthRequest(
        [property: JsonPropertyName("username")] string Username,
        [property: JsonPropertyName("password")] string Password
    );

    public record AuthResponse(
        [property: JsonPropertyName("token")] string Token
    );

    public record ErrorResponse(
        [property: JsonPropertyName("error")] string? Error = null,
        [property: JsonPropertyName("reason")] string? Reason = null
    );
}
