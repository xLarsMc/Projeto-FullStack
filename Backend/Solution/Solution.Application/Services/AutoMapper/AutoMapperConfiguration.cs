using AutoMapper;
using Solution.Communication.Requests;

namespace Solution.Application.Services.AutoMapper
{
    public class AutoMapperConfiguration : Profile
    {
        public AutoMapperConfiguration()
        {
            RequestToDomain();
        }

        private void RequestToDomain()
        {
            CreateMap<RequestUserRegisterJson, Domain.Entities.User>()
                .ForMember(dest => dest.Password, opt => opt.Ignore());
        }
    }
}
