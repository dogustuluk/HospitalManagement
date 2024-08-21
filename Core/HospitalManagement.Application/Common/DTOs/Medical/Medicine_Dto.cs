namespace HospitalManagement.Application.Common.DTOs.Medical
{
    public class Create_Medicine_Dto
    {
        public string Name { get; set; }
        public string? Desc { get; set; }
        public string? Manufacturer { get; set; }
        public string? Usage { get; set; }
        public double Price { get; set; }
        public bool IsPrescriptionRequired { get; set; }
        public DateTime ManufactureDate { get; set; }
        public DateTime ExpiryDate { get; set; }
        public int Stock { get; set; }

        public Create_MedicineDetail_Dto MedicineDetail { get; set; }
    }

    public class Create_MedicineDetail_Dto
    {
        public string Indications { get; set; } //ilacin hangi durumlarda kullanılması gerektiği, hangi hastalıklar veya semptomlar için reçete edildiğini belirtir
        public string Contraindications { get; set; } // ilacın kullanılmaması gereken durumlar, hangi koşullarda veya hastalıklarda kullanılmaması gerektiğini belirtir
        public string? Interactions { get; set; } //ilacın diğer ilaçlar veya besinlerle etkileşimleri, yan etkilere neden olabilecek etkileşimler.
        public string? SpecialInstructionsForUse { get; set; } //ozel kullanim talimatlari
        public string? Ingredients { get; set; }  // içerik
        public string? SideEffects { get; set; }  // yan etkileri
        public string? StorageConditions { get; set; } // saklama koşulları
        public string? DosageInstructions { get; set; } // dozaj talimatları
    }
}
