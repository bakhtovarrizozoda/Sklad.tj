namespace Domain.Dtos.Outcoming;

public class OutcomingBaseDto
{
    public int Id { get; set; }
    public int IncomingId { get; set; }
    public int Counto { get; set; }
    public string Recipient { get; set; }
    public int StorageId { get; set; }
}