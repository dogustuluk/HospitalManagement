namespace HospitalManagement.Application.Common.DTOs.Management;
public class Create_ServiceLog_Dto
{
    public int LogType { get; set; }
    public string FunctionName { get; set; }
    public int TotalOpts1 { get; set; }
    public int TotalOpts2 { get; set; }
    public string OptIds { get; set; }
    public string Token { get; set; }
    public string IP { get; set; }
    public string ResultText { get; set; }
    public Guid Guid { get; set; }
    public Guid CreatedUser { get; set; }
    public DateTime CreatedDate { get; set; }
    public Guid UpdatedUser { get; set; }
    public DateTime UpdatedDate { get; set; }
}
