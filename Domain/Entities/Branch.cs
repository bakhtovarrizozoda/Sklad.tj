using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Domain.Entities;

public class Branch
{
    [Key]
    public int Id { get; set; }
    [Required, MaxLength(50)]
    public string BrachName { get; set; }
    [Required, MaxLength(50)]
    public string Address { get; set; }
    [Required]
    public int UserId { get; set; }
    [NotMapped] 
    public User User { get; set; }

    public List<BranchAccess> BranchAccesses { get; set; }
    public List<Storage> Storages { get; set; }
    
    
}