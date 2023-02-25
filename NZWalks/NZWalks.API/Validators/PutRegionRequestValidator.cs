using FluentValidation;

namespace NZWalks.API.Validators
{
    public class PutRegionRequestValidator : AbstractValidator<Models.DTO.PutRegionRequest>
    {
        public PutRegionRequestValidator()
        {
            RuleFor(x => x.Code).NotEmpty();
            RuleFor(x => x.Name).NotEmpty();
            RuleFor(x => x.Area).GreaterThan(0);
            RuleFor(x => x.Population).GreaterThanOrEqualTo(0);
        }
    }
}
