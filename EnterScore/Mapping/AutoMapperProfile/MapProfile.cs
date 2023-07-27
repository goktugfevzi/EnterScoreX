using AutoMapper;
using DTOLayer.DTOs.ContactUsDTOs;
using EntityLayer.Concrete;

namespace EnterScore.Mapping.AutoMapperProfile
{
    public class MapProfile : Profile
    {
        public MapProfile()
        {
            CreateMap<SendMessageDto, ContactUs>().ReverseMap();



        }

    }
}
