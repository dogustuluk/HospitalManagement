using HospitalManagement.Application.Features.Commands.Hospital.CreateHospital;

namespace HospitalManagement.Application.Common.Validators.Common
{
    public class CreateHospitalCommandValidator : AbstractValidator<CreateHospitalCommandRequest>
    {
        public CreateHospitalCommandValidator()
        {
            RuleFor(x => x.HospitalName)
               .NotEmpty().WithMessage("Hastane adı boş geçilemez!")
               .MinimumLength(10).WithMessage("Hastane adı en az 10 karakter olabilir")
               .MaximumLength(100).WithMessage("Hastane adı en fazla 100 karakter olabilir");
        }
    }
}
