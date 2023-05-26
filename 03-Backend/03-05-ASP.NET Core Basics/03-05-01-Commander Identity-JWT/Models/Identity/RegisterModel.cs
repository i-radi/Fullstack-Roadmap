namespace Commander.Models.Identity
{
    public class RegisterModel
    {
        public RegisterModel(string firstName, string lastName, string username, string email, string password)
        {
            FirstName = firstName;
            LastName = lastName;
            Username = username;
            Email = email;
            Password = password;
        }

        [Required, StringLength(100)]
        public string FirstName { get; }

        [Required, StringLength(100)]
        public string LastName { get; }

        [Required, StringLength(50)]
        public string Username { get; }

        [Required, StringLength(128)]
        public string Email { get; }

        [Required, StringLength(256)]
        public string Password { get; }
    }
}