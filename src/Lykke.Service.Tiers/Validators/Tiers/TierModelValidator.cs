using System;
using FluentValidation;
using JetBrains.Annotations;
using Lykke.Service.Tiers.Client.Models.Tiers;

namespace Lykke.Service.Tiers.Validators.Tiers
{
    [UsedImplicitly]
    public class TierModelValidator : AbstractValidator<TierModel>
    {
        public TierModelValidator()
        {
            RuleFor(o => o.Id)
                .Must(o => o != Guid.Empty)
                .WithMessage("Id required.");

            RuleFor(o => o.Name)
                .NotEmpty()
                .WithMessage("Name required.")
                .MaximumLength(50)
                .WithMessage("Name shouldn't be longer than 50 characters.");

            RuleFor(o => o.Threshold)
                .GreaterThanOrEqualTo(0)
                .WithMessage("Threshold should be greater than or equal to zero.");
        }
    }
}
