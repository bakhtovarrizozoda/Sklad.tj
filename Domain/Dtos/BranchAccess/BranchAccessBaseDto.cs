namespace Domain.Dtos.BranchAccess;

public class BranchAccessBaseDto
{
    public int Id { get; set; }
    public int UserId { get; set; }
    public int BranchId { get; set; }
    public int StorageId { get; set; }
}