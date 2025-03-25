using Solution.Communication.Requests;
using Solution.Communication.Responses;

namespace Solution.Application.useCases.User
{
    public interface IRegisterUserUseCase
    {
        Task<ResponseRegisterUserJson> userRegister(RequestUserRegisterJson request);
    }
}