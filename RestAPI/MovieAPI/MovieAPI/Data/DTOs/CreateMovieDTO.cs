using System.ComponentModel.DataAnnotations;

namespace MovieAPI.Data.DTOs;

public class CreateMovieDTO
{ 
    [Required(ErrorMessage = "The title is required")]
    [StringLength(50, ErrorMessage = "The title must not be longer than 50 characters")]
    public string Title { get; set; }

    [Required(ErrorMessage = "The genre is required and must not be longer than 50 characters")]
    [StringLength(50, ErrorMessage = "The genre must not be longer than 50 characters")]
    public string Genre { get; set; }

    [Required(ErrorMessage = "The runtime is required")]
    [Range(70, 600, ErrorMessage = "The runtime must be between 70 and 600 minutes")]
    public int Runtime { get; set; }
}
