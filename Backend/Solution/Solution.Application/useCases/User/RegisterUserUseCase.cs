using AutoMapper;
using Solution.Application.Services.AutoMapper;
using Solution.Application.Services.Criptografia;
using Solution.Communication.Requests;
using Solution.Communication.Responses;
using Solution.Domain.Repositories;
using Solution.Domain.Repositories.User;
using Solution.Exceptions;
using Solution.Exceptions.ExceptionBase;

namespace Solution.Application.useCases.User
{
    public class RegisterUserUseCase : IRegisterUserUseCase
    {
        private readonly IUserReadOnlyRepository _readOnly;
        private readonly IUserWriteOnlyRepository _writeOnly;
        private readonly IUnitOfWork _UnitOfWork;
        private readonly IMapper _mapper;
        private readonly PasswordEncrypter _passwordEncripter;

        public RegisterUserUseCase(
            PasswordEncrypter passwordEncripter, 
            IUserReadOnlyRepository readOnly, 
            IUserWriteOnlyRepository writeOnly, 
            IMapper mapper, 
            IUnitOfWork unitOfWork)
        {
            _passwordEncripter = passwordEncripter;
            _readOnly = readOnly;
            _writeOnly = writeOnly;
            _mapper = mapper;
            _UnitOfWork = unitOfWork;
        }

        public async Task<ResponseRegisterUserJson> userRegister(RequestUserRegisterJson request)
        {
            //Valida request
            await Validate(request);

            //Mapeia request
            var user = _mapper.Map<Domain.Entities.User>(request);

            //Criptografa senha
            user.Password = _passwordEncripter.Encrypt(request.Password);

            //Salva no banco
            await _writeOnly.Add(user);

            await _UnitOfWork.Commit();

            return new ResponseRegisterUserJson { Name = user.Name };
        }

        private async Task Validate(RequestUserRegisterJson req)
        {
            var validation = new RegisterUserUseCaseValidator();

            var result = validation.Validate(req);

            var emailExist = await _readOnly.UserExist(req.Email);

            if (emailExist)
                result.Errors.Add(new FluentValidation.Results.ValidationFailure(string.Empty, ResourceMessageException.EMAIL_ALREADY_EXISTS));

            if (!result.IsValid)
            {
                var errorMsg = result.Errors.Select(e => e.ErrorMessage).ToList();

                throw new ErrorOnValidationException(errorMsg);
            }
                
        }
    }
}
