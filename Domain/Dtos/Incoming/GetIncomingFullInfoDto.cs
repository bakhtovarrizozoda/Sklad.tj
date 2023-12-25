namespace Domain.Dtos.Incoming;

public class GetIncomingFullInfoDto
{
    public int Id { get; set; }
    public string IncomingName { get; set; }
    public int Counti { get; set; }
    public DateTime IncomingDate { get; set; }
    public decimal Price_Came { get; set; }
    public decimal Current_Price { get; set; }
    public string StorageName { get; set; }
    public int StorageId { get; set; }
}
