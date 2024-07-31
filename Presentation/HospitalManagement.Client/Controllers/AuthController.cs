using HospitalManagement.Application.GenericObjects;
using HospitalManagement.Client.HelperServices;
using HospitalManagement.Client.Models;
using HospitalManagement.Client.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace HospitalManagement.Client.Controllers
{
    public class AuthController : Controller
    {
        private readonly IHttpClientService _httpClientService;

        public AuthController(IHttpClientService httpClientService)
        {
            _httpClientService = httpClientService;
        }

        [AllowAnonymous]
        [HttpGet]
        public async Task<IActionResult> Login()
        {
            if (User.Identity != null && User.Identity.IsAuthenticated)
            {
                return RedirectToAction("Index", "Home");
            }
            return View();
        }
        [AllowAnonymous]
        [HttpPost]
        public async Task<IActionResult> Login(LoginViewModel Model)
        {
            //eksik
            var queryString = QueryStringHelperService.ToQueryString(Model);

            var requestParameters = new RequestParameters
            {
                Folder = "auth",
                Controller = "Auth",
                Action = "Login",
                QueryString = queryString
            };
            var response = await _httpClientService.PostAsync2<OptResult<LoginViewModel>>(requestParameters, Model);
            
            var a = response.Succeeded;
            var b = response.Data;
            return Ok(response);
        }
    }
}
