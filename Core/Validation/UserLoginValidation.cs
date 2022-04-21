﻿using System.Threading;
using System.Threading.Tasks;
using Core.DTO.UserDTO;
using Core.Entities.UserEntity;
using FluentValidation;
using Microsoft.AspNetCore.Identity;

namespace Core.Validation
{
    public class UserLoginValidation : AbstractValidator<UserLoginDTO>
    {
        protected readonly UserManager<User> _userManager;

        public UserLoginValidation(UserManager<User> userManager)
        {
            _userManager = userManager;

            RuleFor(user => user.Email)
                .NotNull()
                .EmailAddress().WithMessage("'{PropertyValue}' - is not an email address!");

            RuleFor(user => user.Password)
                .NotNull()
                .Length(8, 50)
                .Matches("[A-Z]").WithMessage("'{PropertyName}' must contain one or more uppercase letters!")
                .Matches("[a-z]").WithMessage("'{PropertyName}' must contain one or more lowercase letters!")
                .Matches(@"\d").WithMessage("'{PropertyName}' must contain one or more digits!")
                .Matches(@"[][""!@$%^&*(){}:;<>,.?/+_=|'~\\-]").WithMessage("'{PropertyName}' must contain one or more special characters!")
                .Matches("^[^£# “”]*$").WithMessage("'{PropertyName}' must not contain the following characters £ # “” or spaces!");
        }
    }
}
