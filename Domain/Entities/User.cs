using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Domain.Entities;

public class User
{
    [Key]
    public int Id { get; set; }
    [Required, MaxLength(50)]
    public string FirstName { get; set; }
    [Required, MaxLength(50)]
    public string LastName { get; set; }
    [Required, MaxLength(50)]
    public string Phone { get; set; }
    [Required]
    public int PositionId { get; set; }
    [Required]
    public int RoleId { get; set; }
    
    [NotMapped]
    public Role Role { get; set; }
    [NotMapped]
    public Position Position { get; set; }

    public List<Branch> Branches { get; set; }
    public List<BranchAccess> BranchAccesses { get; set; }
    public List<Storage> Storages { get; set; }
}