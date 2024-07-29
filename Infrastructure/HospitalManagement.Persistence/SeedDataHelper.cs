using HospitalManagement.Domain.Entities.Management;
using HospitalManagement.Persistence.Context;

namespace HospitalManagement.Domain
{
    public static class SeedDataHelper
    {
        private static readonly string[] DepartmentNames =
        {
            "Kardiyoloji", "Nöroloji", "Ortopedi", "Kadın Hastalıkları ve Doğum", "Pediatri",
            "Onkoloji", "Dermatoloji", "Üroloji", "Kulak Burun Boğaz", "Psikiyatri",
            "Göz Hastalıkları", "Radyoloji", "Acil Tıp", "Fizik Tedavi ve Rehabilitasyon",
            "İç Hastalıkları", "Nükleer Tıp", "Enfeksiyon Hastalıkları", "Genel Cerrahi",
            "Plastik Cerrahi", "Kulak Burun Boğaz", "Diş Hekimliği", "Dahiliye", "Kadın Sağlığı",
            "Oral ve Maksillofasiyal Cerrahi", "Göğüs Hastalıkları", "Hematoloji", "Endokrinoloji",
            "Nöroşirurji", "Kardiyovasküler Cerrahi", "Pulmonoloji", "Üroloji", "Gastroenteroloji",
            "Ruh Sağlığı ve Hastalıkları", "Klinik Patoloji", "Anesteziyoloji", "Onkoloji Radyasyon",
            "Romatoloji", "Ortopedi ve Travmatoloji", "Üreme Endokrinolojisi", "Kadın Ürolojisi",
            "Hepatoloji", "Nefroloji", "Perinatoloji", "Psikiyatrik Rehberlik", "Tıbbi Genetik",
            "Adli Tıp", "Fertilite ve İnfertilite", "Onkolojik Cerrahi", "Moleküler Patoloji"
        };

        private static string GenerateDepartmentCode(string departmentName)
        {
            string prefix = departmentName.Substring(0, 3).ToUpper();

            var random = new Random();
            string randomNumber = random.Next(100, 1000).ToString();

            string departmentCode = prefix + randomNumber;

            return departmentCode;
        }


        public static void SeedDepartments(HospitalManagementDbContext context)
        {
            if (!context.Departments.Any())
            {
                var departments = new List<Department>();

                foreach (var departmentName in DepartmentNames)
                {
                    var depCode = GenerateDepartmentCode(departmentName);
                    var GUIDuser = Guid.NewGuid();
                    var department = new Department
                    {
                        ParentId = 0,
                        DepartmentName = departmentName,
                        SortOrderNo = 10 * departmentName.Length,
                        DepartmentCode = depCode,
                        ManagerMemberId = 1,
                        isActive = true,
                        CreatedDate = DateTime.UtcNow,
                        UpdatedDate = DateTime.UtcNow,
                        Guid = Guid.NewGuid(),
                        CreatedUser = GUIDuser,
                        UpdatedUser = GUIDuser
                    };

                    departments.Add(department);
                }

                context.Departments.AddRange(departments);
                context.SaveChanges();
            }
        }


    }
}
