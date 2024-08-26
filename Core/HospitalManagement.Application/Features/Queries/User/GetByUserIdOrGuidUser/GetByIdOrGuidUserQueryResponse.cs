namespace HospitalManagement.Application.Features.Queries.User.GetByUserIdOrGuidUser
{
    public class GetByIdOrGuidUserQueryResponse
    {
        public int Id { get; set; }
        public Guid Guid { get; set; }
        public int UserType { get; set; }
        public string NameSurname { get; set; }
        public string? Gender { get; set; }
        public string? IdentityNo { get; set; }
        public string? GSM { get; set; }
        public string? GSMPersonal { get; set; }
        public string? Email { get; set; }
        public int CountyId { get; set; }
        public int CityId { get; set; }
        public string? CityName { get; set; }
        public string? Address { get; set; }
        public int StatusId { get; set; }
        public DateTime? BirthDate { get; set; }
        public string? UserDetailsJSON { get; set; }
        public DateTime? Experience { get; set; }

        public string? RefreshToken { get; set; }
        public DateTime? RefreshTokenEndDate { get; set; }
    }
}