namespace App.Application.Dtos
{
    public class UserDto
    {
        public string EmailAddress { get; set; }
        public string Password { get; set; }
        public bool IsActive { get; set; }
    }
}