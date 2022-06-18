using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProConfitec.Application.DTOs.Validations
{
    public class UserDTOValidator : AbstractValidator<UserDTO>
    {
        public UserDTOValidator()
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
                .WithMessage("Telefone deve ser informado")
                .EmailAddress()
                .WithMessage("O Email invalido");

            RuleFor(x => x.BirthDate)
               .NotEmpty()
               .NotNull()
               .WithMessage("Data de Nascimento deve ser informado")
               .Must(validDate).WithMessage("A data de nascimento deve ser menor que hoje");

            RuleFor(x => x.ScholarityId)
               .NotEmpty()
               .NotNull()
               .WithMessage("Id Escolaridade deve ser informado")
               .Must(x => (x > 0 && x <= 4))
               .WithMessage("O campo ScholarityId deve conter valores entre 1 e 4");

            RuleFor(x => x.SchoolRecordsId)
               .NotEmpty()
               .NotNull()
               .WithMessage("SchoolRecordsId escolar deve ser informado");
        }
        private static bool validDate(DateTime birthDate)
        {
            return birthDate < DateTime.Now;
        }

    }
}
