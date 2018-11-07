namespace Coursework.API.DTOs
{
    public class AuthenticationToken
    {
        public string Token { get; set; }
        public string Email { get; set; }

        public AuthenticationToken()
        {

        }

        public AuthenticationToken(string token, string email)
        {
            Token = token;
            Email = email;
        }
    }
}
