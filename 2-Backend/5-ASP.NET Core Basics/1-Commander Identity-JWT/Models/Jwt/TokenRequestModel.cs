namespace Commander.Models.Jwt
{
    public class TokenRequestModel
    {
        public TokenRequestModel(string email, string password)
        {
            Email = email;
            Password = password;
        }

        [Required]
        public string Email { get; }

        [Required]
        public string Password { get; }
    }
}