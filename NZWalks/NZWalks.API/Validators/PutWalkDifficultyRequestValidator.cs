using FluentValidation;

namespace NZWalks.API.Validators
{
    public class PutWalkDifficultyRequestValidator : AbstractValidator<Models.DTO.PutWalkDifficultyRequest>
    {
        public PutWalkDifficultyRequestValidator()
        {
            RuleFor(x => x.Code).NotEmpty();
        }
    }
}
