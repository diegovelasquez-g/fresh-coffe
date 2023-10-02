namespace CFS.DTO.Request;

public class EditUserRequestDto
{
    public string? UserName { get; set; }
    public string? Email { get; set; }
    public string? Password { get; set; }
    public int RoleId { get; set; }
    public string? UpdateBy { get; set; }
}