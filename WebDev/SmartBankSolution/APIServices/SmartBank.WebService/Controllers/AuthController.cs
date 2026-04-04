using Microsoft.AspNetCore.Mvc;
using WebApplicationMVC.DTOs;
using WebApplicationMVC.Services;
using Newtonsoft.Json.Linq;

namespace WebApplicationMVC.Controllers
{
    public class AuthController : Controller
    {
        private readonly APIService _api;

        public AuthController(APIService api)
        {
            _api = api;
        }

        // ================= LOGIN =================

        [HttpGet]
        public IActionResult Login() => View();

        [HttpPost]
        public async Task<IActionResult> Login(LoginDTO dto)
        {
            if (!ModelState.IsValid)
                return View(dto);

            var (success, status, content, data) =
                await _api.PostWithResponseAsync<dynamic>(
                    "GatewayClient",
                    "/auth/login",   // ✅ FIXED
                    dto
                );

            if (!success)
            {
                if (status == 0)
                    ViewBag.Error = "Gateway/Auth service unavailable.";
                else if (status == 401)
                    ViewBag.Error = content ?? "Invalid credentials";
                else
                    ViewBag.Error = content ?? "Login failed";

                return View(dto);
            }

            HttpContext.Session.SetString("JWT", (string)data.token);

            return RedirectToAction("Index", "Account");
        }

        // ================= REGISTER =================

        [HttpGet]
        public IActionResult Register() => View();

        [HttpPost]
        public async Task<IActionResult> Register(RegisterDTO dto)
        {
            if (!ModelState.IsValid)
                return View(dto);

            var (success, status, content, data) =
                await _api.PostWithResponseAsync<dynamic>(
                    "GatewayClient",
                    "/auth/register",   // ✅ FIXED
                    dto
                );

            if (!success)
            {
                if (status == 0)
                {
                    ModelState.AddModelError("", "Gateway/Auth service unavailable.");
                    return View(dto);
                }

                if (status == 400 && !string.IsNullOrEmpty(content))
                {
                    try
                    {
                        var errors = JArray.Parse(content);

                        foreach (var item in errors)
                        {
                            var desc = item["Description"]?.ToString()
                                    ?? item["description"]?.ToString();

                            if (!string.IsNullOrEmpty(desc))
                                ModelState.AddModelError("", desc);
                        }
                    }
                    catch
                    {
                        ModelState.AddModelError("", content);
                    }

                    return View(dto);
                }

                ModelState.AddModelError("", content ?? "Registration failed.");
                return View(dto);
            }

            TempData["Success"] = "Registration successful. Please login.";
            return RedirectToAction("Login");
        }

        // ================= LOGOUT =================

        //[HttpGet]
        //public IActionResult Logout()
        //{
        //    return RedirectToAction("Index", "Home");
        //}

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Logout()
        {
            HttpContext.Session.Clear();
            return RedirectToAction("Index", "Home");
        }
    }
}