using FluentValidation;
using Solution.Communication.Requests;
using Solution.Exceptions;

namespace Solution.Application.useCases.User
{
    public class RegisterUserUseCaseValidator : AbstractValidator<RequestUserRegisterJson>
    {
        public RegisterUserUseCaseValidator()
        {
            RuleFor(user => user.Name).NotEmpty().WithMessage(ResourceMessageException.NAME_EMPTY);
            RuleFor(user => user.Email).EmailAddress().WithMessage(ResourceMessageException.EMAIL_VALID);
            //RuleFor(user => user.Password).GreaterThanOrEqualTo(8);
            RuleFor(user => user.Password.Length).GreaterThanOrEqualTo(8).WithMessage(ResourceMessageException.PASSWORD_LENGTH);
        }
    }
}
