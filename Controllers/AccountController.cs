using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using Quantify.Models;
using Quantify.Core.Users;
using Quantify.ViewModels;
using Microsoft.AspNetCore.Identity;
using Quantify.Core.Data;

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
    [HttpPost]
    public IActionResult Register(RegisterViewModel registration)
    {
        if (!ModelState.IsValid)
        {
            return View(registration);
        }
        var hasher = new PasswordHasher<User>();
        string hashedPassword = hasher.HashPassword(null, registration.Password);
        
        User newUser = new Student(registration.Name,registration.Surname,registration.Email,
                registration.PhoneNumber,hashedPassword);
        
        _context.Users.Add(newUser);
        _context.SaveChanges();
        
        return RedirectToAction("Index", "Home");
    }

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
}
