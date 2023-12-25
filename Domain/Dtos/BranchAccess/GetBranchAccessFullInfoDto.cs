namespace Domain.Dtos.BranchAccess;

public class GetBranchAccessFullInfoDto
{
    public int Id { get; set; }
    public string FirstName { get; set; }
    public int UserId { get; set; }
    public string BrachName { get; set; }
    public int BranchId { get; set; }
    public string StorageName { get; set; }
    public int StorageId { get; set; }
}
