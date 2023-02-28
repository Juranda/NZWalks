using FluentValidation;

namespace NZWalks.API.Validators
{
    public class UserLoginRequestValidator : AbstractValidator<Models.DTO.UserLoginRequest>
    {
        public UserLoginRequestValidator()
        {
            RuleFor(u => u.Username).NotEmpty();
            RuleFor(u => u.Password).NotEmpty();
        }
    }
}
