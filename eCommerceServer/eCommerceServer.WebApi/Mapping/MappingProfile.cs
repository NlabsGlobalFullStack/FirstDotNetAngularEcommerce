using AutoMapper;
using ECommerceServer.WebApi.DTOs;
using ECommerceServer.WebApi.Models;

namespace ECommerceServer.WebApi.Mapping;

public class MappingProfile : Profile
{
    public MappingProfile()
    {
        CreateMap<RegisterDto, AppUser>();
    }
}
