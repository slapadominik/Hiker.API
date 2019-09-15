namespace Hiker.Application.Features.Authentication.DTO
{
    public class Token
    {
        public string Value { get; set; }
        public long Expiry { get; set; }
    }
}