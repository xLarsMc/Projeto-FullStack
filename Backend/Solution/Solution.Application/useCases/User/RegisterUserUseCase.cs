using Solution.Application.Services.AutoMapper;
using Solution.Application.Services.Criptografia;
using Solution.Communication.Requests;
using Solution.Communication.Responses;
using Solution.Exceptions.ExceptionBase;

namespace Solution.Application.useCases.User
{
    public class RegisterUserUseCase
    {
        public ResponseRegisterUserJson userRegister(RequestUserRegisterJson request)
        {
            var criptografia = new PasswordEncrypter();
            var autoMapper = new AutoMapper.MapperConfiguration(options =>
            {
                options.AddProfile(new AutoMapperConfiguration());
            }).CreateMapper();

            //Valida request
            Validate(request);

            //Mapeia request
            var user = autoMapper.Map<Domain.Entities.User>(request);

            //Criptografa senha
            user.Password = criptografia.Encrypt(request.Password);
            //Salva no banco
            return new ResponseRegisterUserJson { Name = request.Name };

        }

        private void Validate(RequestUserRegisterJson req)
        {
            var validation = new RegisterUserUseCaseValidator();

            var result = validation.Validate(req);

            if (!result.IsValid)
            {
                var errorMsg = result.Errors.Select(e => e.ErrorMessage).ToList();

                throw new ErrorOnValidationException(errorMsg);
            }
                
        }
    }
}
