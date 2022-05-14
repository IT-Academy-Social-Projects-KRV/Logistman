﻿using Core.DTO.OfferDTO;
using FluentValidation;
using System;

namespace Core.Validation
{
    public class OfferCreateValidation : AbstractValidator<OfferCreateDTO>
    {
        private readonly TimeSpan _hour = new TimeSpan(12, 0, 0);
        public OfferCreateValidation()
        {
            RuleFor(offer => offer.GoodsWeight)
                .GreaterThan(0);
            RuleFor(offer => offer.Point)
                .NotNull();
            RuleFor(offer => offer.Point.Latitude)
                .NotEmpty();

            RuleFor(offer => offer.Point.Longitude)
                .NotEmpty();

            RuleFor(offer => offer.Point.Address)
                .NotEmpty()
                .MaximumLength(100);

            RuleFor(offer => offer.Point.Settlement)
                .NotEmpty()
                .MaximumLength(100);

            RuleFor(offer => offer.Point.Region)
                .NotEmpty()
                .MaximumLength(100);

            RuleFor(offer => offer.Point.Order)
                .GreaterThan(-1);

            RuleFor(offer => offer.StartDate)
                .NotEmpty()
                .Must(date => date >= DateTimeOffset.UtcNow)
                .WithMessage("StartDate cannot be created in the past");

            RuleFor(offer => offer.ExpirationDate)
                .NotEmpty();

            RuleFor(offer => offer.ExpirationDate.Subtract(offer.StartDate) < _hour)
                .Must(date => !date)
                .WithMessage(
                    $"The difference between the StartDate and the ExpirationDate must be at least {_hour.Hours} hours!");

        }
    }
}
