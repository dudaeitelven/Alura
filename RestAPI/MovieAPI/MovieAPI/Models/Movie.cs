using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace MovieAPI.Models;

public class Movie
{
    [Key]
    [Required]
    public int Id { get; set; }

    [Required(ErrorMessage = "The title is required")]
    [MaxLength(50,ErrorMessage ="The title must not be longer than 50 characters")]
    public string Title { get; set; }

    [Required(ErrorMessage = "The genre is required and must not be longer than 50 characters")]
    [MaxLength(50, ErrorMessage = "The genre must not be longer than 50 characters")]
    public string Genre { get; set; }

    [Required(ErrorMessage = "The runtime is required")]
    [Range(70,600, ErrorMessage = "The runtime must be between 70 and 600 minutes")]
    public int Runtime { get; set; }
}
