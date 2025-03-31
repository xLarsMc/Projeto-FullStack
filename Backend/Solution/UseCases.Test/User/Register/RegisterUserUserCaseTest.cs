using CommonTestUtilities.Criptography;
using CommonTestUtilities.Mapper;
using CommonTestUtilities.Requests;
using CommonTestUtilities.Respositories;
using Shouldly;
using Solution.Application.useCases.User;
using Solution.Exceptions;
using Solution.Exceptions.ExceptionBase;

namespace UseCases.Test.User.Register
{
    public class RegisterUserUserCaseTest
    {
        [Fact]
        public async Task Sucess()
        {
            var request = RequestRegisterUserJsonBuilder.Build();

            var useCase = CreateUseCase();

            var result = await useCase.userRegister(request);

            result.Name.ShouldNotBeNull(result.Name);
            result.Name.ShouldBe(result.Name);
        }

        [Fact]
        public async Task Erro_WhenEmail_IsAlreadyRegistered()
        {
            var request = RequestRegisterUserJsonBuilder.Build();

            var useCase = CreateUseCase(request.Email);

            Func<Task> act = async () => await useCase.userRegister(request);

            var exception = await Should.ThrowAsync<ErrorOnValidationException>(act);
            exception.ErrorsMessage.Count.ShouldBe(1);
            exception.ErrorsMessage.First().ShouldContain(ResourceMessageException.EMAIL_ALREADY_EXISTS);
        }

        private RegisterUserUseCase CreateUseCase(string? email = null)
        {
            var mapper = MapperBuilder.Build();
            var passwordEncripter = PasswordEncripterBuilder.Build();
            var writeRepositoy = UserWriteOnlyRespoitoryBuilder.Build();
            var unitOfWork = UnitOfWorkBuilder.Build();
            var readRepositoryBuilder = new UserReadOnlyRepositoryBuilder();

            //Quando eu quiser que o método de uma função mockada (nesse caso a userRead) devolva algo diferente.
            if (string.IsNullOrEmpty(email) == false)
                readRepositoryBuilder.ExistActiveUserWithEmail(email);

            return new RegisterUserUseCase(passwordEncripter, readRepositoryBuilder.Build(), writeRepositoy, mapper, unitOfWork);
        }
    }
}
