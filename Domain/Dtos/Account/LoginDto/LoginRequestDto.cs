using System.ComponentModel.DataAnnotations;

namespace Domain.Dtos.Account.LoginDto;

public class LoginRequestDto
{
    [Required(ErrorMessage = "Username is required!")]
    public string Username { get; set; }
    [Required(ErrorMessage = "Password is required!")]
    public string Password { get; set; }
}
