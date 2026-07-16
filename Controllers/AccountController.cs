using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using Quantify.Models;
using Quantify.Core.Users;
using Quantify.ViewModels;
using Microsoft.AspNetCore.Identity;
using Quantify.Core.Data;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.Security.Claims;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.EntityFrameworkCore;

namespace Quantify.Controllers;

public class AccountController : Controller
{
    private readonly QuantifyDbContext _context;

    public AccountController(QuantifyDbContext context)
    {
        _context = context;
    }
    public IActionResult Index()
    {
        return View();
    }

    public IActionResult Register()
    {
        return View();
    }

    public IActionResult RegisterStudent()
    {
        return View();
    }

    [HttpPost]
    public IActionResult RegisterStudent(RegisterStudentViewModel registration)
    {
        if (!ModelState.IsValid)
        {
            return View(registration);
        }
        var hasher = new PasswordHasher<User>();
        string hashedPassword = hasher.HashPassword(null!, registration.Password);
        
        User newUser = new Student(registration.Name,registration.Surname,registration.Email,
                registration.PhoneNumber,hashedPassword);
        
        _context.Users.Add(newUser);
        _context.SaveChanges();
        
        return RedirectToAction("Index", "Home");
    }

    public IActionResult RegisterTutor()
    {
        return View();
    }

    [HttpPost]
    public IActionResult RegisterTutor(RegisterTutorViewModel registration)
    {
        if (!ModelState.IsValid)
        {
            return View(registration);
        }

        var hasher = new PasswordHasher<User>();
        string hashedPassword = hasher.HashPassword(null!, registration.Password);
        
        User newUser = new Tutor(registration.Name,registration.Surname,registration.Email,
                registration.PhoneNumber,hashedPassword,registration.Experience,
                            registration.EmploymentPlace,registration.AboutTutor);
        
        _context.Users.Add(newUser);
        _context.SaveChanges();
        
        return RedirectToAction("Index", "Home");
    }

    public IActionResult Login()
    {
        return View();
    }

    [HttpPost]
    public async Task<IActionResult> Login(LoginViewModel loginData)
    {
        if (!ModelState.IsValid)
        {
            return View(loginData);
        }

        var row = await _context.Users.FirstOrDefaultAsync(user => user.Email == loginData.Email);
        if(row == null)
        {
            ModelState.AddModelError(string.Empty, "Nieprawidłowy e-mail lub hasło.");
            return View(loginData);
        }

        var hasher = new PasswordHasher<User>();
        var checkResult = hasher.VerifyHashedPassword(row,row.PasswordHash,loginData.Password);
        if (checkResult == PasswordVerificationResult.Success)
        {
            var claims = new List<Claim>();

            claims.Add(new Claim(ClaimTypes.NameIdentifier, row.Email));
            claims.Add(new Claim(ClaimTypes.Name, row.Name));
            claims.Add(new Claim(ClaimTypes.Surname, row.Surname));
            
            var identity = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);
            var principal = new ClaimsPrincipal(identity);
            await HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, principal);

            return RedirectToAction("Index", "Home");
        }

        ModelState.AddModelError(string.Empty, "Nieprawidłowy e-mail lub hasło.");
        return View(loginData);
    }

    [HttpPost]
    public async Task<IActionResult> Logout()
    {
        await HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);
        return RedirectToAction("Index", "Home");
    }

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
}
