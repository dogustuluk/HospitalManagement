using HospitalManagement.Domain.Entities.Common;

namespace HospitalManagement.Domain.Entities.Medical
{
    public class MedicineDetail : BaseEntity
    {
        public int? MedicineId { get; set; }
        public string Indications { get; set; } //ilacin hangi durumlarda kullanılması gerektiği, hangi hastalıklar veya semptomlar için reçete edildiğini belirtir
        public string Contraindications { get; set; } // ilacın kullanılmaması gereken durumlar, hangi koşullarda veya hastalıklarda kullanılmaması gerektiğini belirtir
        public string? Interactions { get; set; } //ilacın diğer ilaçlar veya besinlerle etkileşimleri, yan etkilere neden olabilecek etkileşimler.
        public string? SpecialInstructionsForUse { get; set; } //ozel kullanim talimatlari
        public string? Ingredients { get; set; }  // içerik
        public string? SideEffects { get; set; }  // yan etkileri
        public string? StorageConditions { get; set; } // saklama koşulları
        public string? DosageInstructions { get; set; } // dozaj talimatları

        public virtual Medicine Medicine { get; set; }
    }
}
