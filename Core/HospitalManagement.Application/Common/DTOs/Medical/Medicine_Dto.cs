namespace HospitalManagement.Application.Common.DTOs.Medical
{
    public class GetAllPaged_Medicine_Index_Dto
    {
        public int PageIndex { get; set; } = 1;
        public string? SearchText { get; set; }
        public int ActiveStatus { get; set; } = 1;
        public int IsPrescriptionRequired { get; set; }
        public int Take { get; set; } = 25;
        public string? OrderBy { get; set; } = "Id ASC";
    }
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

    public class Update_Medicine_Dto
    {
        public Guid Guid { get; set; }
        public string Name { get; set; }
        public string? Desc { get; set; }
        public string? Manufacturer { get; set; }
        public string? Usage { get; set; }
        public double Price { get; set; }
        public bool IsPrescriptionRequired { get; set; }
        public DateTime ManufactureDate { get; set; }
        public DateTime ExpiryDate { get; set; }
        public int Stock { get; set; }
        public MedicineType MedicineType { get; set; }
        public int MedicineCategory { get; set; }
        public Update_MedicineDetail_Dto MedicineDetail { get; set; }
    }
    public class Update_MedicineDetail_Dto
    {
        public string Indications { get; set; } 
        public string Contraindications { get; set; } 
        public string? Interactions { get; set; } 
        public string? SpecialInstructionsForUse { get; set; } 
        public string? Ingredients { get; set; } 
        public string? SideEffects { get; set; }  
        public string? StorageConditions { get; set; } 
        public string? DosageInstructions { get; set; } 
    }
    public class Add_MedicineDetail_Dto
    {
        public int MedicineId { get; set; }
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
