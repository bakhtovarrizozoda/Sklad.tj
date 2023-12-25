using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Domain.Entities;

public class BranchAccess
{
    [Key]
    public int Id { get; set; }
    [Required]
    public int UserId { get; set; }
    [Required]
    public int BranchId { get; set; }
    [Required]
    public int StorageId { get; set; }
    [NotMapped]
    public User User { get; set; }
    [NotMapped]
    public Branch Branch { get; set; }
    [NotMapped]
    public Storage Storage { get; set; }
}