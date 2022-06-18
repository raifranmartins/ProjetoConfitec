using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProConfitec.Application.DTOs.Validations
{

        public class UserDatailDTOValidator : AbstractValidator<UserDetailDTO>
        {
            public UserDatailDTOValidator()
            {
                RuleFor(x => x.Name)
                    .NotEmpty()
                    .NotNull()
                    .WithMessage("Name deve ser informado");

                RuleFor(x => x.Surname)
                    .NotEmpty()
                    .NotNull()
                    .WithMessage("Sobenome deve ser informado");

                RuleFor(x => x.Email)
                    .NotEmpty()
                    .NotNull()
                    .WithMessage("Telefone deve ser informado");

                RuleFor(x => x.BirthDate)
                   .NotEmpty()
                   .NotNull()
                   .WithMessage("Data de nascimento deve ser informado")
                   .Must(validDate).WithMessage("A data de nascimento deve ser menor que hoje");

                RuleFor(x => x.SchoolRecordsName)
                   .NotEmpty()
                   .NotNull()
                   .WithMessage("Nome do arquivo deve ser informado");
        }

        private static bool validDate(DateTime birthDate)
        {
            return birthDate < DateTime.Now;
        }
    }
    }

