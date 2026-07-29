using Quantify.Core.Data;
using Quantify.Core.Models;
using Quantify.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Authorization;
using Microsoft.EntityFrameworkCore.Metadata.Internal;

public class ModulesController: Controller
{
    private readonly QuantifyDbContext _context;

    public ModulesController(QuantifyDbContext context)
    {
        _context = context;
    }


    [Authorize(Roles = "Admin")]
    public IActionResult AddModule()
    {
        return View();
    }

    [Authorize(Roles = "Admin")]
    public ActionResult AddTopic(long moduleId)
    {
        AddTopicViewModel topicView = new AddTopicViewModel()
        {
            ModuleId = moduleId
        };
        return View(topicView);
    }

    
    // [Authorize(Roles = "Admin")]
    // public IActionResult AddTask()
    // {
    //     return View();
    // }


    [HttpPost]
    [Authorize(Roles = "Admin")]
    public async Task<IActionResult> AddModule(AddModuleViewModel module)
    {
        if (!ModelState.IsValid)
        {
            return View(module);
        }
        Module newModule = new Module(module.Name, module.Description);
        _context.Modules.Add(newModule);

        await _context.SaveChangesAsync();

        return RedirectToAction("ShowModuleContent","LearningMaterials", new { moduleId = newModule.ModuleId });
    }


    [HttpPost]
    [Authorize(Roles = "Admin")]
    public async Task<IActionResult> AddTopic(AddTopicViewModel topic)
    {
        if (!ModelState.IsValid)
        {
            return View(topic);
        }

        Module? module = await _context.Modules.Include(module => module.Topics).FirstOrDefaultAsync(module => module.ModuleId == topic.ModuleId);
        if(module == null)
            return NotFound();

        Topic newTopic = new Topic(topic.Name!, topic.Content!);
        module.AddNewTopic(newTopic);

        await _context.SaveChangesAsync();
        
        return RedirectToAction("ShowTopicContent","LearningMaterials", new { moduleId = module.ModuleId, topicId = newTopic.TopicId});
    }


    //[HttpPost]
    //[Authorize(Roles = "Admin")]
    // public async Task<IActionResult> AddTask(long moduleId, long topicId, AddTaskViewModel task)
    // {
        //  if (!ModelState.IsValid)
        // {
        //     return View(task);
        // }
    //     Module module = await _context.Modules.Include(module => module.Topics)
    //                 .FirstOrDefaultAsync(module => module.ModuleId == moduleId);
    //     if(module == null)
    //         return NotFound();

    //     Topic topic = module.Topics.FirstOrDefault(topic => topic.TopicId == topicId);
    //     if(topic == null)
    //         return NotFound();
        
    //     MathTask newTask = new MathTask(task.PointsCount, (DifficultyLevel)task.Level, task.Contents);
    //     topic.AddNewTask(newTask);

    //     await _context.SaveChangesAsync();
        
    //     return RedirectToAction("ShowTaskContent");
    // }
}