namespace HospitalManagement.Application.Services
{
    public class DefaultUserRegistrationStrategyService : IUserRegistrationStrategyService
    {
        public Task ExecuteAsync(AppUser user)
        { //send mail
            Console.WriteLine($"{user.NameSurname} adlı kullanıcı kayıt olmuştur.");
            return Task.CompletedTask;
        }
    }

    public class DoctorUserRegistrationStrategyService : IUserRegistrationStrategyService
    {
        public Task ExecuteAsync(AppUser user)
        {
            Console.WriteLine($"{user.NameSurname} adlı doktor sisteme kayıt olmuştur.");
            return Task.CompletedTask;
        }
    }
    public class PatientUserRegistrationStrategyService : IUserRegistrationStrategyService
    {
        public Task ExecuteAsync(AppUser user)
        { 
            Console.WriteLine($"{user.NameSurname} isimli hasta kayıt olmuştur.");
            Console.WriteLine($"{user.NameSurname} isimli hastaya XXX adlı doktor atanmıştır.");
            Console.WriteLine($"{user.NameSurname} adlı hasta için randevu kaydı oluşturulmuştur.");
            Console.WriteLine($"{user.NameSurname} isimli şahıs sizin hastanız olmuştur.");
            return Task.CompletedTask;
        }
    }
    public class ExaminationAppointmentUserRegistrationStrategyService : IUserRegistrationStrategyService
    {
        public Task ExecuteAsync(AppUser user)
        {
            Console.WriteLine($"{user.NameSurname} adlı şahıs ziyaretçi tablosuna kaydedilmiştir.");
            return Task.CompletedTask;
        }
    }
    public class VisitorAppointmentUserRegistrationStrategyService : IUserRegistrationStrategyService
    {
        public Task ExecuteAsync(AppUser user)
        {
            Console.WriteLine($"{user.NameSurname} adlı şahıs ziyaretçi tablosuna kaydedilmiştir.");
            return Task.CompletedTask;
        }
    }
}
