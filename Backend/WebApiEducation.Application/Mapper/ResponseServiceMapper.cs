using AutoMapper;
using WebApiEducation.Application.Model;
using WebApiEducation.Domain.Model;

namespace WebApiEducation.Application.Mapper
{
    public class ResponseServiceMapper : Profile
    {
        public ResponseServiceMapper() {
            ResponseServiceRequest();
            ResponseServiceResponse();
        }

        public void ResponseServiceRequest()
        {
            CreateMap<ResponseService, ResponseServiceDTO>()
              .ForMember(x => x.Message, y => y.MapFrom(z => z.Message))
              .ForMember(x => x.Tipo, y => y.MapFrom(z => z.Tipo))
              .ForMember(x => x.Success, y => y.MapFrom(z => z.Success));

        }
        public void ResponseServiceResponse()
        {
            CreateMap<ResponseServiceDTO, ResponseService>()
              .ForMember(x => x.Message, y => y.MapFrom(z => z.Message))
              .ForMember(x => x.Tipo, y => y.MapFrom(z => z.Tipo))
              .ForMember(x => x.Success, y => y.MapFrom(z => z.Success));
        }
    }
}
