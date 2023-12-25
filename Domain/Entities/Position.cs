using System.ComponentModel.DataAnnotations;

namespace Domain.Entities;

public class Position
{
    [Key]
    public int Id { get; set; }
    [Required]
    public string PositionName { get; set; }

    public List<User> Users { get; set; }
}