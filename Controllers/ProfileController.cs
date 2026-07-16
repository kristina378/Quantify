using Microsoft.AspNetCore.Mvc;
using Quantify.Core.Users;
using Quantify.ViewModels;
using Microsoft.AspNetCore.Identity;
using Quantify.Core.Data;
using System.Security.Claims;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authorization;
using System.ComponentModel.DataAnnotations;
using Microsoft.EntityFrameworkCore;

namespace Quantify.Controllers;

[Authorize]
public class ProfileController : Controller
{
    private readonly QuantifyDbContext _context;

    public ProfileController(QuantifyDbContext context)
    {
        _context = context;
    }

    public async Task<IActionResult> Edit()
    {
        var email =  User.FindFirstValue(ClaimTypes.NameIdentifier);
        var user = await _context.Users.FirstOrDefaultAsync(user=> user.Email == email);
        if(user == null)    return NotFound();
        
        var editView = new EditViewModel()
        {
            Name = user.Name,
            Surname = user.Surname,
            Email = user.Email,
            PhoneNumber = user.PhoneNumber
        };

        return View(editView);
    }

    [HttpPost]
    public async Task<IActionResult> Edit(EditViewModel edition)
    {
        if (!ModelState.IsValid)
        {
            return View(edition);
        }

        var user = await _context.Users.FirstOrDefaultAsync(user=>user.Email == User.FindFirstValue(ClaimTypes.NameIdentifier));
        if(user == null)    return NotFound();

        user.Name = edition.Name;
        user.Surname = edition.Surname;
        user.PhoneNumber = edition.PhoneNumber;

        await _context.SaveChangesAsync();

        var claims = new List<Claim>();

        claims.Add(new Claim(ClaimTypes.NameIdentifier, user.Email));
        claims.Add(new Claim(ClaimTypes.Name, user.Name));
        claims.Add(new Claim(ClaimTypes.Surname, user.Surname));

        var identity = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);
        var principal = new ClaimsPrincipal(identity);

        await HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, principal);

        return RedirectToAction("Edit","Profile");
    }
}