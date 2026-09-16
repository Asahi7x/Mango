namespace Mango.Services.CouponAPI.DTOs
{
    public class ResponseDto
    {
        public Object? Result { get; set; }

        public bool IsSuccess { get; set; } = true;

        public string Message { get; set; } = "";
    }
}
