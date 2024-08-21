using HospitalManagement.Domain.Entities.Common;
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
        private static readonly string[] CityNames =
        {
            "ADANA", "ADIYAMAN", "AFYONKARAHİSAR", "Ağrı", "Amasya",
            "Ankara", "Antalya", "Artvin", "Aydın", "Balıkesir",
            "Bilecik", "Bingöl", "Bitlis", "Bolu", "Burdur",
            "Bursa", "Çanakkale", "Çankırı", "Çorum", "Denizli",
            "Diyarbakır", "Edirne", "Elazığ", "Erzincan", "Erzurum",
            "Eskişehir", "Gaziantep", "Giresun", "Gümüşhane", "Hakkari",
            "Hatay", "Isparta", "Mersin", "İstanbul", "İzmir",
            "Kars", "Kastamonu", "Kayseri", "Kırklareli", "Kırşehir",
            "Kocaeli", "Konya", "Kütahya", "Malatya", "Manisa",
            "Kahramanmaraş", "Mardin", "Muğla", "Muş", "Nevşehir",
            "Niğde", "Ordu", "Rize", "Sakarya", "Samsun",
            "Siirt", "Sinop", "Sivas", "Tekirdağ", "Tokat",
            "Trabzon", "Tunceli", "Şanlıurfa", "Uşak", "Van",
            "Yozgat", "Zonguldak", "Aksaray", "Bayburt", "Karaman",
            "Kırıkkale", "Batman", "Şırnak", "Bartın", "Ardahan",
            "Iğdır", "Yalova", "Karabük", "Kilis", "Osmaniye",
            "Düzce"
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
        public static void SeedCities(HospitalManagementDbContext context)
        {
            if (!context.Cities.Any())
            {
                var Cities = new List<City>();

                foreach (var cityName in CityNames)
                {
                    var GUIDuser = Guid.NewGuid();
                    var cityIndex = Array.IndexOf(CityNames, cityName);
                    var city = new City
                    {
                        CityName = cityName,
                        CountryID = 1,
                        SortOrderNo = 10 * cityIndex,
                        isActive = true,
                        CreatedDate = DateTime.UtcNow,
                        UpdatedDate = DateTime.UtcNow,
                        Guid = Guid.NewGuid(),
                        CreatedUser = GUIDuser,
                        UpdatedUser = GUIDuser
                    };

                    Cities.Add(city);
                }

                context.Cities.AddRange(Cities);
                context.SaveChanges();
            }
        }


    }
}
