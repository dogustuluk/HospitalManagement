﻿using HospitalManagement.Application.Constants;
using HospitalManagement.Application.GenericObjects;
using HospitalManagement.Client.HelperServices;
using HospitalManagement.Client.Models;
using HospitalManagement.Client.Services;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;

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
            var queryString = QueryStringHelperService.ToQueryString(Model);

            var requestParameters = new RequestParameters
            {
                Folder = "auth",
                Controller = "Auth",
                Action = "Login",
                QueryString = queryString
            };
            var response = await _httpClientService.PostAsync2<OptResult<LoginViewModel>>(requestParameters, Model);
            if (response.Succeeded)
            {
                Response.Cookies.Append("JWTToken", response.Data.Token.AccessToken, new CookieOptions
                {
                    HttpOnly = true,
                    Secure = false, // Production'da true olmalı
                    SameSite = SameSiteMode.Lax
                });
                var token = new JwtSecurityTokenHandler().ReadJwtToken(response.Data.Token.AccessToken);
                var identity = new ClaimsPrincipal(new ClaimsIdentity(token.Claims, "Custom"));
                await HttpContext.SignInAsync("MedsisUser", identity);

                return RedirectToAction("Index", "Home");
            }

            ModelState.AddModelError(string.Empty, Messages.UnLogin);
            return Ok(Model);
        }
        [HttpPost]
        public IActionResult Logout()
        {
            HttpContext.Session.Clear();
            return RedirectToAction("Login","Auth");
        }
    }
}
