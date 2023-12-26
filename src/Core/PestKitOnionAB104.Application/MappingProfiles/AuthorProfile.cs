using AutoMapper;
using PestKitOnionAB104.Application.DTOs.Author;
using PestKitOnionAB104.Application.DTOs.Authors;
using PestKitOnionAB104.Domain.Entities;

namespace PestKitOnionAB104.Application.MappingProfiles
{
    public class AuthorProfile:Profile
    {
        public AuthorProfile()
        {
            CreateMap<Author, AuthorItemDto>();
            CreateMap<Author, AuthorGetDto>();
            CreateMap<AuthorCreateDto, Author>();
        }
    }
}
