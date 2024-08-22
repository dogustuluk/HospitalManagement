namespace HospitalManagement.Application.Features.Queries.Medicine.GetMedicineDetail
{
    public class GetMedicineDetailQueryResponse
    {
        public int? MedicineId { get; set; }
        public string Indications { get; set; } 
        public string Contraindications { get; set; } 
        public string? Interactions { get; set; }
        public string? SpecialInstructionsForUse { get; set; } 
        public string? Ingredients { get; set; }  
        public string? SideEffects { get; set; } 
        public string? StorageConditions { get; set; }
        public string? DosageInstructions { get; set; }
    }
}