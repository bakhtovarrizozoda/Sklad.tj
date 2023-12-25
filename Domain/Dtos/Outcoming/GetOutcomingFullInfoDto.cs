namespace Domain.Dtos.Outcoming;

public class GetOutcomingFullInfoDto
{
    public int Id { get; set; }
    public string IncomingName { get; set; }
    public int IncomingId { get; set; }
    public int Counto { get; set; }
    public string Recipient { get; set; }
    public decimal Profit { get; set; }
    public string StorageName { get; set; }
    public int StorageId { get; set; }
}
