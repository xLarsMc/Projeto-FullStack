using Solution.Communication.Requests;
using Solution.Communication.Responses;

namespace Solution.Application.useCases.User
{
    public class RegisterUserUseCase
    {
        public ResponseRegisterUserJson userRegister(RequestUserRegisterJson request)
        {
            //Valida request
            Validate(request);
            //Mapeia request
            //Criptografa senha
            //Salva no banco
            return new ResponseRegisterUserJson { Name = request.Name };

        }

        private void Validate(RequestUserRegisterJson req)
        {
            var validation = new RegisterUserUseCaseValidator();

            var result = validation.Validate(req);

            if (!result.IsValid)
            {
                var errorMsg = result.Errors.Select(e => e.ErrorMessage);

                throw new Exception();
            }
                
        }
    }
}
