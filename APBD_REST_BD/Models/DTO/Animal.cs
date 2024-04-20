using System.ComponentModel.DataAnnotations;

namespace APBD_REST_BD.Models.DTO;

public class Animal
{
    [Required]
    public string Name { get; set; }

    public string? Description { get; set; }

    [Required]
    public string Category { get; set; }
    
    [Required]
    public string Area { get; set; }
}