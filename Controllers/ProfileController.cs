using Microsoft.AspNetCore.Mvc;
using Quantify.ViewModels;
using Quantify.Core.Data;
using System.Security.Claims;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authorization;
using Microsoft.EntityFrameworkCore;
using Quantify.Core.Users;

namespace Quantify.Controllers;

[Authorize]
public class ProfileController : Controller
{
    private readonly QuantifyDbContext _context;

    public ProfileController(QuantifyDbContext context)
    {
        _context = context;
    }

    [Authorize(Roles = "Student")]
    public async Task<IActionResult> EditStudent()
    {
        var email =  User.FindFirstValue(ClaimTypes.NameIdentifier);
        var student = await _context.Users.OfType<Student>().FirstOrDefaultAsync(user=> user.Email == email);
        if(student == null)    return NotFound();
        
        var editStudentView = new EditStudentViewModel()
        {
            Name = student.Name,
            Surname = student.Surname,
            Email = student.Email,
            PhoneNumber = student.PhoneNumber
        };

        return View(editStudentView);
    }

    [HttpPost]
    [Authorize(Roles = "Student")]
    public async Task<IActionResult> EditStudent(EditStudentViewModel edition)
    {
        if (!ModelState.IsValid)
        {
            return View(edition);
        }

        var student = await _context.Users.OfType<Student>().FirstOrDefaultAsync(user=>user.Email == User.FindFirstValue(ClaimTypes.NameIdentifier));
        if(student == null)    return NotFound();

        student.Name = edition.Name;
        student.Surname = edition.Surname;
        student.PhoneNumber = edition.PhoneNumber;

        await _context.SaveChangesAsync();

        var claims = new List<Claim>();

        claims.Add(new Claim(ClaimTypes.NameIdentifier, student.Email));
        claims.Add(new Claim(ClaimTypes.Name, student.Name));
        claims.Add(new Claim(ClaimTypes.Surname, student.Surname));

        var identity = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);
        var principal = new ClaimsPrincipal(identity);

        await HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, principal);

        return RedirectToAction("EditStudent","Profile");
    }

    [Authorize(Roles = "Tutor")]
    public async Task<IActionResult> EditTutor()
    {
        var email =  User.FindFirstValue(ClaimTypes.NameIdentifier);
        var tutor = await _context.Users.OfType<Tutor>().FirstOrDefaultAsync(user=> user.Email == email);
        if(tutor == null)    return NotFound();
        
        var editTutorView = new EditTutorViewModel()
        {
            Name = tutor.Name,
            Surname = tutor.Surname,
            Email = tutor.Email,
            PhoneNumber = tutor.PhoneNumber,
            Experience = tutor.Experience,
            EmploymentPlace = tutor.EmploymentPlace,
            AboutTutor = tutor.AboutTutor
        };

        return View(editTutorView);
    }

    [HttpPost]
    [Authorize(Roles = "Tutor")]
    public async Task<IActionResult> EditTutor(EditTutorViewModel edition)
    {
        if (!ModelState.IsValid)
        {
            return View(edition);
        }

        var tutor = await _context.Users.OfType<Tutor>().FirstOrDefaultAsync(user=>user.Email == User.FindFirstValue(ClaimTypes.NameIdentifier));
        if(tutor == null)    return NotFound();

        tutor.Name = edition.Name;
        tutor.Surname = edition.Surname;
        tutor.PhoneNumber = edition.PhoneNumber;
        tutor.AboutTutor = edition.AboutTutor;
        tutor.EmploymentPlace = edition.EmploymentPlace;
        //((Tutor)user).Experience = edition.Experience; 
        // blad: bo zrobilam priavte set dla expirience


        await _context.SaveChangesAsync();

        var claims = new List<Claim>();

        claims.Add(new Claim(ClaimTypes.NameIdentifier, tutor.Email));
        claims.Add(new Claim(ClaimTypes.Name, tutor.Name));
        claims.Add(new Claim(ClaimTypes.Surname, tutor.Surname));

        var identity = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);
        var principal = new ClaimsPrincipal(identity);

        await HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, principal);

        return RedirectToAction("EditTutor","Profile");
    }
}