namespace HospitalManagement.Application.Features.Queries.User.GetAllUser
{
    public class GetAllUserQueryResponse
    {
        public int Id { get; set; }
        public Guid Guid { get; set; }
        public int UserType { get; set; }
        public string NameSurname { get; set; }
        public string? GSM { get; set; }
        public string? GSMPersonal { get; set; }
        public string? Email { get; set; }
        public int CityId { get; set; }
        public string? CityName { get; set; }
        public int StatusId { get; set; }
    }
}