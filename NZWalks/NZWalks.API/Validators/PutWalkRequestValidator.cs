using FluentValidation;

namespace NZWalks.API.Validators
{
    public class PutWalkRequestValidator : AbstractValidator<Models.DTO.PutWalkRequest>
    {
        public PutWalkRequestValidator()
        {
            RuleFor(x => x.Name).NotEmpty();
            RuleFor(x => x.Length).GreaterThan(0);
        }
    }
}
