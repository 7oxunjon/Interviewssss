using AutoMapper;
using DATA.DTO;
using DATA.Model;

namespace Interviewssss.Extation
{
    public class Configuration : Profile
    {
        public Configuration()
        {
            CreateMap<SuhbatOluvchiDTO, SuhbatOluvchi>().ReverseMap();
            CreateMap<SuhbatTopshirivchiDTO, SuhbatTopshiruvchi>().ReverseMap();
            CreateMap<ApiUser, UserDTO>().ReverseMap();
        }
    }
}
