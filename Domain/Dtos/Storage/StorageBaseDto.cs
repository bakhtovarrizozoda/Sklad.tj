namespace Domain.Dtos.Storage;

public class StorageBaseDto
{
    public int Id { get; set; }
    public string StorageName { get; set; }
    public int BranchId { get; set; }
    public int UserId { get; set; }
}