using Microsoft.AspNetCore.Mvc;
using Quantify.ViewModels;
using Quantify.Core.Data;
using System.Security.Claims;
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
        var id =  long.Parse(User.FindFirstValue(ClaimTypes.NameIdentifier)!);
        var student = await _context.Users.OfType<Student>().FirstOrDefaultAsync(user=> user.Id == id);
        if(student == null)    return NotFound();
        
        var editStudentView = new EditStudentViewModel()
        {
            Name = student.Name,
            Surname = student.Surname,
            Email = student.Email,
            PhoneNumber = student.PhoneNumber,
            NickName = student.NickName
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

        var id =  long.Parse(User.FindFirstValue(ClaimTypes.NameIdentifier)!);
        var student = await _context.Users.OfType<Student>().FirstOrDefaultAsync(user => user.Id == id);
        if(student == null)    return NotFound();

        student.Name = edition.Name;
        student.Surname = edition.Surname;
        student.PhoneNumber = edition.PhoneNumber;

        await _context.SaveChangesAsync();

        return RedirectToAction("EditStudent","Profile");
    }

    [Authorize(Roles = "Tutor")]
    public async Task<IActionResult> EditTutor()
    {
        var id =  long.Parse(User.FindFirstValue(ClaimTypes.NameIdentifier)!);
        var tutor = await _context.Users.OfType<Tutor>().FirstOrDefaultAsync(user => user.Id == id);
        if(tutor == null)    return NotFound();
        
        var editTutorView = new EditTutorViewModel()
        {
            Name = tutor.Name,
            Surname = tutor.Surname,
            Email = tutor.Email,
            PhoneNumber = tutor.PhoneNumber,
            NickName = tutor.NickName,
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

        var id =  long.Parse(User.FindFirstValue(ClaimTypes.NameIdentifier)!);
        var tutor = await _context.Users.OfType<Tutor>().FirstOrDefaultAsync(user => user.Id == id);
        if(tutor == null)    return NotFound();

        tutor.Name = edition.Name;
        tutor.Surname = edition.Surname;
        tutor.PhoneNumber = edition.PhoneNumber;
        tutor.AboutTutor = edition.AboutTutor;
        tutor.EmploymentPlace = edition.EmploymentPlace;
        tutor.Experience = edition.Experience; 


        await _context.SaveChangesAsync();

        return RedirectToAction("EditTutor","Profile");
    }

    [Authorize(Roles = "Admin")]
    public async Task<IActionResult> EditAdmin()
    {
        var id =  long.Parse(User.FindFirstValue(ClaimTypes.NameIdentifier)!);
        var admin = await _context.Users.OfType<Admin>().FirstOrDefaultAsync(user=> user.Id == id);
        if(admin == null)    return NotFound();
        
        var editAdminView = new EditAdminViewModel()
        {
            Name = admin.Name,
            Surname = admin.Surname,
            Email = admin.Email,
            PhoneNumber = admin.PhoneNumber,
            NickName = admin.NickName
        };

        return View(editAdminView);
    }

    [HttpPost]
    [Authorize(Roles = "Admin")]
    public async Task<IActionResult> EditAdmin(EditAdminViewModel edition)
    {
        if (!ModelState.IsValid)
        {
            return View(edition);
        }
        long id = long.Parse(User.FindFirstValue(ClaimTypes.NameIdentifier)!);
        var admin = await _context.Users.OfType<Admin>().FirstOrDefaultAsync(user => user.Id == id);
        if(admin == null)    return NotFound();

        admin.Name = edition.Name;
        admin.Surname = edition.Surname;
        admin.PhoneNumber = edition.PhoneNumber;

        await _context.SaveChangesAsync();


        return RedirectToAction("EditAdmin","Profile");
    }
}