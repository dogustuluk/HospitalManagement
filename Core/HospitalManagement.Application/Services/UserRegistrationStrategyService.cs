using HospitalManagement.Application.Features.Commands.User.AppUser.CreateUser;
using HospitalManagement.Domain.Entities.Users;

namespace HospitalManagement.Application.Services
{
    public class DefaultUserRegistrationStrategyService : IUserRegistrationStrategyService
    {
        public Task ExecuteAsync(AppUser user, Create_Patient_Dto? patientDto)
        { //send mail
            Console.WriteLine($"{user.NameSurname} adlı kullanıcı kayıt olmuştur.");
            return Task.CompletedTask;
        }
    }


    public class DoctorUserRegistrationStrategyService : IUserRegistrationStrategyService
    {
        public Task ExecuteAsync(AppUser user, Create_Patient_Dto? patientDto)
        {
            Console.WriteLine($"{user.NameSurname} adlı doktor sisteme kayıt olmuştur.");
            return Task.CompletedTask;
        }
    }


    public class PatientUserRegistrationStrategyService : IUserRegistrationStrategyService
    {
        private readonly IPatientService _patientService;
        private readonly IMapper _mapper;

        public PatientUserRegistrationStrategyService(IPatientService patientService, IMapper mapper)
        {
            _patientService = patientService;
            _mapper = mapper;
        }

        public async Task ExecuteAsync(AppUser user, Create_Patient_Dto? patientDto)
        {
            if (patientDto != null)
            {
               // var patient = _mapper.Map<Patient>(patientDto);
                patientDto.AppUserId = user.Id;
                var result = await _patientService.CreateAsync(patientDto);
                if (result.Succeeded)
                {
                    Console.WriteLine($"{user.NameSurname} isimli hasta kayıt olmuştur.");
                }
            }
            //Console.WriteLine($"{user.NameSurname} isimli hasta kayıt olmuştur.");
            //Console.WriteLine($"{user.NameSurname} isimli hastaya XXX adlı doktor atanmıştır.");
            //Console.WriteLine($"{user.NameSurname} adlı hasta için randevu kaydı oluşturulmuştur.");
            //Console.WriteLine($"{user.NameSurname} isimli şahıs sizin hastanız olmuştur.");
            //return Task.CompletedTask;
        }
    }



    public class ExaminationAppointmentUserRegistrationStrategyService : IUserRegistrationStrategyService
    {
        public Task ExecuteAsync(AppUser user, Create_Patient_Dto patient_Dto)
        {
            Console.WriteLine($"{user.NameSurname} adlı şahıs ziyaretçi tablosuna kaydedilmiştir.");
            return Task.CompletedTask;
        }
    }



    public class VisitorAppointmentUserRegistrationStrategyService : IUserRegistrationStrategyService
    {
        public Task ExecuteAsync(AppUser user, Create_Patient_Dto? patientDto)
        {
            Console.WriteLine($"{user.NameSurname} adlı şahıs ziyaretçi tablosuna kaydedilmiştir.");
            return Task.CompletedTask;
        }
    }
}
