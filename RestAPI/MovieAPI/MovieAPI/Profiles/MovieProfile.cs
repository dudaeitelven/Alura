using AutoMapper;
using MovieAPI.Data.DTOs;
using MovieAPI.Models;

namespace MovieAPI.Profiles;

public class MovieProfile : Profile
{
	public MovieProfile()
	{
		CreateMap<CreateMovieDTO, Movie>();
        CreateMap<UpdateMovieDTO, Movie>();
        CreateMap<Movie, UpdateMovieDTO>();
        CreateMap<Movie, ReadMovieDTO>();
    }
}
