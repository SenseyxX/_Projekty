using FluentValidation;
using Mag.Dtos.UserDtos;
using Mag.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Mag.Validators
{
        public class RegisterUserValidator : AbstractValidator<UserAddDto>
        {
                public RegisterUserValidator(MagContext magContext)
                {
                        RuleFor(x => x.Email).NotEmpty();
                        RuleFor(x => x.Email).Custom((value, context) =>
                          {
                                  var userAlreadyExist = magContext.users.Any(user => user.Email == value);
                                  if (userAlreadyExist)
                                  {
                                          context.AddFailure("Email","That email address is taken");
                                  }
                           });
                        RuleFor(x => x.PasswordHash).MinimumLength(6);
                        RuleFor(x => x.PasswordHash).Equal(x => x.ConfirmPassword);


                }

        }
}
