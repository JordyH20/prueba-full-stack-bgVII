
namespace WebAPI_Jordy_Hurtado_2026_11_13.Models
{
    public class User
    {
        public int UserId { get; set; }
        public string Username { get; set; } = null!;
        public string Email { get; set; } = null!;
        public string? PasswordHash { get; set; }
        public string Role { get; set; } = null!;
    }
}

