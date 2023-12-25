using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Domain.Entities;

public class Outcoming
{
    [Key]
    public int Id { get; set; }
    [Required]
    public int IncomingId { get; set; }
    [Required]
    public int Counto { get; set; }
    [Required, MaxLength(50)]
    public string Recipient { get; set; }
    [Required]
    public int StorageId { get; set; }
    [NotMapped]
    public Storage Storage { get; set; }
    [NotMapped]
    public Incoming Incoming { get; set; }
}