using HospitalManagement.Application.Features.Commands.Announcement.CrearteAnnouncement;

namespace HospitalManagement.Application.Common.Validators.Management
{
    public class Create_Announcement_Validator : AbstractValidator<CreateAnnouncementCommandRequest>
    {
        public Create_Announcement_Validator()
        {
            RuleFor(x => x.AnnouncementTitle)
            .Cascade(CascadeMode.Stop)
            .NotEmpty().WithMessage("Duyuru başlığı boş geçilemez!")
            .MinimumLength(10).WithMessage("Duyuru başlığı en az 10 karakter olabilir")
            .MaximumLength(50).WithMessage("Duyuru başlığı en fazla 50 karakter olabilir");

            RuleFor(x => x.AnnouncementContent)
            .Cascade(CascadeMode.Stop)
            .NotEmpty().WithMessage("Duyuru içeriği boş geçilemez!")
            .MinimumLength(50).WithMessage("Duyuru içeriği en az 50 karakter olabilir")
            .MaximumLength(500).WithMessage("Duyuru içeriği en fazla 500 karakter olabilir");

            RuleFor(x => x.AnnouncementSummary)
            .Cascade(CascadeMode.Stop)
            .MinimumLength(10).WithMessage("Duyuru özeti en az 50 karakter olabilir")
            .MaximumLength(50).WithMessage("Duyuru içeriği en fazla 500 karakter olabilir");
        }
    }
}
