using HospitalManagement.Application.Features.Queries.Appointment.GetAllAppointment;

namespace HospitalManagement.Application.Common.Specifications
{
    public class AppointmentSpecifications
    {
        public Expression<Func<Appointment, bool>> GetAllPredicate(GetAllAppointmentQueryRequest appointmentRequestParameters)
        {
            var predicate1 = PredicateBuilder.New<Appointment>(true);

            if (!string.IsNullOrEmpty(appointmentRequestParameters.SearchText))
                predicate1 = predicate1.And(a => a.NameSurname.Contains(appointmentRequestParameters.SearchText) || a.PhoneNumber.Contains(appointmentRequestParameters.SearchText));

            if (appointmentRequestParameters.Status > 0)
                predicate1 = predicate1.And(a => a.Status == appointmentRequestParameters.Status);

            if (appointmentRequestParameters.ExaminationAppointment != null)
            {
                predicate1 = predicate1.And(a => a is ExaminationAppointment);

                if (appointmentRequestParameters.ExaminationAppointment.ClinicId > 0)
                    predicate1 = predicate1.And(a => ((ExaminationAppointment)a).ClinicId == appointmentRequestParameters.ExaminationAppointment.ClinicId);

                if (!string.IsNullOrEmpty(appointmentRequestParameters.ExaminationAppointment.ExaminationPlace))
                    predicate1 = predicate1.And(a => ((ExaminationAppointment)a).ExaminationPlace.Contains(appointmentRequestParameters.ExaminationAppointment.ExaminationPlace));

                if (appointmentRequestParameters.ExaminationAppointment.StartDate != DateTime.MinValue && appointmentRequestParameters.ExaminationAppointment.EndDate != DateTime.MinValue)
                    predicate1 = predicate1.And(a => ((ExaminationAppointment)a).StartDate >= appointmentRequestParameters.ExaminationAppointment.StartDate && ((ExaminationAppointment)a).EndDate <= appointmentRequestParameters.ExaminationAppointment.EndDate);
            }

            if (appointmentRequestParameters.VisitorAppointment != null)
            {
                predicate1 = predicate1.And(a => a is VisitorAppointment);


                if (appointmentRequestParameters.VisitorAppointment.PatientId > 0)
                    predicate1 = predicate1.And(a => ((VisitorAppointment)a).PatientId == appointmentRequestParameters.VisitorAppointment.PatientId);

                if (appointmentRequestParameters.VisitorAppointment.AppointmentDate != DateTime.MinValue)
                    predicate1 = predicate1.And(a => ((VisitorAppointment)a).AppointmentDate.Date == appointmentRequestParameters.VisitorAppointment.AppointmentDate.Value);
            }

            if (appointmentRequestParameters.Discriminator == 1)
            {
                predicate1 = predicate1.And(a => a is VisitorAppointment);
            }
            else if (appointmentRequestParameters.Discriminator == 2)
            {
                predicate1 = predicate1.And(a => a is ExaminationAppointment);
            }

            return predicate1;
        }
    }
}
