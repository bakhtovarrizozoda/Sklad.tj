using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Domain.Entities;

public class Storage
{
    [Key]
    public int Id { get; set; }
    [Required, MaxLength(50)]
    public string StorageName { get; set; }
    [Required]
    public int BranchId { get; set; }
    [Required]
    public int UserId { get; set; }
    [NotMapped] 
    public User User { get; set; }

    public List<BranchAccess> BranchAccesses { get; set; }
    [NotMapped]
    public Branch Branch { get; set; }

    public List<Incoming> Incomings { get; set; }
    public List<Outcoming> Outcomings { get; set; }
    
}