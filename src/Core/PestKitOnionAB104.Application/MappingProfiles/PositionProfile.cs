using AutoMapper;
using PestKitOnionAB104.Application.DTOs.Author;
using PestKitOnionAB104.Application.DTOs.Position;
using PestKitOnionAB104.Application.DTOs.Positions;
using PestKitOnionAB104.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PestKitOnionAB104.Application.MappingProfiles
{
    public class PositionProfile:Profile
    {
        public PositionProfile()
        {
            CreateMap<Position, PositionItemDto>();
            CreateMap<Position, PositionGetDto>();
            CreateMap<PositionCreateDto, Position>();
            CreateMap<Position, IncludePositionDto>();
        }
    }
}
