using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Domain.Entities;

public class Incoming
{
    [Key]
    public int Id { get; set; }
    [Required, MaxLength(50)]
    public string IncomingName { get; set; }
    [Required]
    public int Counti { get; set; }
    [Required]
    public DateTime IncomingDate { get; set; }
    [Required]
    public decimal Price_Came { get; set; }
    [Required]
    public decimal Current_Price { get; set; }
    [Required]
    public int StorageId { get; set; }
    [NotMapped]
    public Storage Storage { get; set; }
    public List<Outcoming> Outcomings { get; set; }
}