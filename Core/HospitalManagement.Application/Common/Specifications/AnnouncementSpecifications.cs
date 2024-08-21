using HospitalManagement.Application.Common.DTOs.Common;
using HospitalManagement.Application.Features.Queries.Announcement.GetAllAnnouncement;
using HospitalManagement.Application.Features.Queries.Hospital.GetAllHospital;
using HospitalManagement.Application.Features.Queries.Hospital.GetAllPagedHospital;
using HospitalManagement.Domain.Entities.Common;

namespace HospitalManagement.Application.Common.Specifications
{
    public class AnnouncementSpecifications
    {
        public Expression<Func<Announcement, bool>> GetAllPredicate(GetAllAnnouncementQueryRequest announcementRequestParameters)
        {
            var predicate1 = PredicateBuilder.New<Announcement>(true);

            return predicate1;
        }
        public Expression<Func<Announcement, bool>> GetAllPagedPredicate(GetAllPaged_Announcement_Dto announcementRequestParameters)
        {
            var predicate1 = PredicateBuilder.New<Announcement>(true);

            if (!string.IsNullOrEmpty(announcementRequestParameters.SearchText))
                predicate1 = predicate1.And(a => a.AnnouncementTitle.Contains(announcementRequestParameters.SearchText));

            return predicate1;
        }
    }
}
