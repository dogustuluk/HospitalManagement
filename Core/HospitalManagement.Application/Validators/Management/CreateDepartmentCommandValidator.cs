using FluentValidation;
using HospitalManagement.Application.Features.Commands.Department.CreateDepartment;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HospitalManagement.Application.Validators.Management
{
    public class CreateDepartmentCommandValidator : AbstractValidator<CreateDepartmentCommandRequest>
    {
        public CreateDepartmentCommandValidator()
        {
            RuleFor(x => x.DepartmentName)
               .NotEmpty().WithMessage("Departman adı boş geçilemez!")
               .MinimumLength(2).WithMessage("Departman adı en az 2 karakter olabilir")
               .MaximumLength(30).WithMessage("Departman adı en fazla 30 karakter olabilir");

            RuleFor(x => x.DepartmentCode)
               .NotEmpty().WithMessage("Departman kodu boş geçilemez!")
               .MinimumLength(5).WithMessage("Departman kodu en az 5 karakter olabilir")
               .MaximumLength(12).WithMessage("Departman kodu en fazla 12 karakter olabilir");
        }
    }
}
