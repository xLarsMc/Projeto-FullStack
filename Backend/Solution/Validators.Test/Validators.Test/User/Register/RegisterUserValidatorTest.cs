using CommonTestUtilities.Requests;
using Shouldly;
using Solution.Application.useCases.User;
using Solution.Exceptions;

namespace Validators.Test.User.Register
{
    public class RegisterUserValidatorTest
    {
        [Fact]
        public void Sucess()
        {
            var validator = new RegisterUserUseCaseValidator();

            var request = RequestRegisterUserJsonBuilder.Build();

            var result = validator.Validate(request);

            result.IsValid.ShouldBeTrue();
        }
        [Fact]
        public void Error_WhenName_IsEmpty()
        {
            var validator = new RegisterUserUseCaseValidator();

            var request = RequestRegisterUserJsonBuilder.Build();

            request.Name = string.Empty;

            var result = validator.Validate(request);

            result.IsValid.ShouldBeFalse();
            result.Errors.ShouldNotBeEmpty();
            result.Errors.ShouldContain(e => e.ErrorMessage.Equals(ResourceMessageException.NAME_EMPTY));
        }
        [Fact]
        public void Error_WhenEmail_IsEmpty()
        {
            var validator = new RegisterUserUseCaseValidator();

            var request = RequestRegisterUserJsonBuilder.Build();

            request.Email = "";

            var result = validator.Validate(request);

            result.IsValid.ShouldBeFalse();
            result.Errors.ShouldNotBeEmpty();
            result.Errors.ShouldContain(e => e.ErrorMessage.Equals(ResourceMessageException.EMAIL_EMPTY));
        }
        [Fact]

        public void Error_WhenEmail_IsInvalid()
        {
            var validator = new RegisterUserUseCaseValidator();

            var request = RequestRegisterUserJsonBuilder.Build();

            request.Email = "salsaspal";

            var result = validator.Validate(request);

            result.IsValid.ShouldBeFalse();
            result.Errors.ShouldNotBeEmpty();
            result.Errors.ShouldContain(e => e.ErrorMessage.Equals(ResourceMessageException.EMAIL_VALID));
        }
        [Theory]
        [InlineData(1)]
        [InlineData(2)]
        [InlineData(3)]
        [InlineData(4)]
        [InlineData(5)]
        public void Error_WhenPassword_IsInvalid(int passwordLength)
        {
            var validator = new RegisterUserUseCaseValidator();

            var request = RequestRegisterUserJsonBuilder.Build(passwordLength);

            var result = validator.Validate(request);

            result.IsValid.ShouldBeFalse();
            result.Errors.ShouldNotBeEmpty();
            result.Errors.ShouldContain(e => e.ErrorMessage.Equals(ResourceMessageException.PASSWORD_LENGTH));
        }
    }
}
