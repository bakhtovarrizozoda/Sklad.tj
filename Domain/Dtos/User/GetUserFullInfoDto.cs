namespace Domain.Dtos.User;

public class GetUserFullInfoDto
{
    public int Id { get; set; }
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public string Phone { get; set; }
    public string PositionName { get; set; }
    public int PositionId { get; set; }
    public string RolName { get; set; }
    public int RoleId { get; set; }
}
