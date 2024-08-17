using HospitalManagement.Application.Common.GenericObjects;
using HospitalManagement.Application.Features.Queries.Department.GetDataPagedList;
using HospitalManagement.Client.HelperServices;
using HospitalManagement.Client.Models;
using HospitalManagement.Client.Models.Management;
using HospitalManagement.Client.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace HospitalManagement.Client.Controllers
{
    public class DepartmentController : Controller
    {
        private IHttpClientService _httpClientService;

        public DepartmentController(IHttpClientService httpClientService)
        {
            _httpClientService = httpClientService;
        }

        [AllowAnonymous]
        [HttpGet]
        public async Task<IActionResult> Index(Department_Index_ViewModel model)
        {
            var queryString = QueryStringHelperService.ToQueryString(model);
            var response = await _httpClientService.GetAsync<PaginatedList<GetDataPagedListQueryResponse>>(
                    new RequestParameters
                    {
                        Action= "GetAllPagedData",
                        Controller = "Department",
                        Folder = "management",
                        QueryString = queryString
                    }
                );

            List<Department_GridData_ViewModel> myData = new();
            foreach (var data in response.Data.Data)
            {
                myData.Add(new Department_GridData_ViewModel()
                {
                    Id = data.Id,
                    Guid = data.Guid,
                    DepartmentCode = data.DepartmentCode,
                    DepartmentName = data.DepartmentName,
                    SortOrderNo = data.SortOrderNo,
                    ManagerMemberId = data.ManagerMemberId,
                    isActive = data.isActive,
                    //UpdatedBy = data.UpdatedBy,
                    //UpdatedDate = data.UpdatedDate,
                    //SubDepartments = SubDepartments

                });
            }

            Department_Index_ViewModel MYRESULT = new Department_Index_ViewModel()
            {
                PageTitle = "Yönetim",
                SubPageTitle = "Departmanlar",
                MyGridData = myData,
                MyPagination = response.Data.Pagination,
                SearchText = model.SearchText,
                OrderBy = model.OrderBy
            };

            return View(MYRESULT);
        }
    }
}
