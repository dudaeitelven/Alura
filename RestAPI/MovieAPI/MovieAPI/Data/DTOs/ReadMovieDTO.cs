using System.ComponentModel.DataAnnotations;

namespace MovieAPI.Data.DTOs;

public class ReadMovieDTO
{ 
    public string Title { get; set; }

    public string Genre { get; set; }

    public int Runtime { get; set; }

    public DateTime TimeResearch { get; set; } = DateTime.Now;
}
