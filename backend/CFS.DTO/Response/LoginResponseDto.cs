namespace CFS.DTO.Response;

public class LoginResponseDto
{
    public int UserId { get; set; }
    public string? UserName { get; set; }
    public string? Email { get; set; }
    public string Token { get; set; } = null!;
}