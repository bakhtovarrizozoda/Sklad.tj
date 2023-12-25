using System.ComponentModel.DataAnnotations;

namespace Domain.Entities;

public class Role
{
    [Key]
    public int Id { get; set; }
    [Required]
    public string RolName { get; set; }

    public List<User> Users { get; set; }
}