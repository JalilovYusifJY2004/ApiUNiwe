using AutoMapper;
using PestKitOnionAB104.Application.DTOs.Tag;
using PestKitOnionAB104.Application.DTOs.Tags;
using PestKitOnionAB104.Domain.Entities;

namespace PestKitOnionAB104.Application.MappingProfiles
{
    public class TagProfile : Profile
    {
        public TagProfile()
        {
            CreateMap<Tag, TagItemDto>();
            CreateMap<Tag, TagGetDto>();
            CreateMap<TagCreateDto, Tag>();
        }
    }
}
