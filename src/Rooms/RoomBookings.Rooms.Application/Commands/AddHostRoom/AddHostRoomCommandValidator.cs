﻿using FluentValidation;
using FluentValidation.Results;

namespace RoomBookings.Rooms.Application.Commands.AddHostRoom;

public class AddHostRoomCommandValidator : AbstractValidator<AddHostRoomCommand>
{
    public AddHostRoomCommandValidator()
    {
        RuleFor(x => x.Address).NotNull();
        RuleFor(x => x.Address.Address1).NotEmpty();
        RuleFor(x => x.Address.City).NotEmpty();
        RuleFor(x => x.Address.Region).NotEmpty();
        RuleFor(x => x.Address.PostalCode).NotEmpty().MaximumLength(10);
        RuleFor(x => x.Beds).NotEmpty().WithMessage("At least one bed is required");
        RuleFor(x => x.DailyPrice).GreaterThan(0).WithMessage("Daily Price must be greater than 0");
    }
}
