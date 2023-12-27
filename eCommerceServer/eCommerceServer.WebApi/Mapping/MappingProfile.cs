using AutoMapper;
using eCommerceServer.WebApi.DTOs;
using eCommerceServer.WebApi.Entities;

namespace eCommerceServer.WebApi.Mapping;

/// <summary>
/// AutoMapper için profil sınıfı. DTO ve Entity sınıfları arasında haritalamaları tanımlar.
/// </summary>
public class MappingProfile : Profile
{
    /// <summary>
    /// Haritalamaları yapılandıran sınıfın kurucu metodu.
    /// </summary>
    public MappingProfile()
    {
        // RegisterDto sınıfını AppUser sınıfına haritala.
        CreateMap<RegisterDto, AppUser>();
    }
}
