using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using Quantify.Models;
using Quantify.Core.Data;
using Microsoft.EntityFrameworkCore;
using Quantify.Core.Models;
using Quantify.ViewModels;


namespace Quantify.Controllers;

public class LearningMaterialsController : Controller
{
    private readonly QuantifyDbContext _context;

    public LearningMaterialsController(QuantifyDbContext context)
    {
        _context = context;
    }

    public IActionResult Index()
    {
        return View();
    }

    public async Task<IActionResult> ShowModuleContent(long moduleId)
    {
        var module = await _context.Modules.Include(module => module.Topics).FirstOrDefaultAsync(module => module.ModuleId == moduleId);
        if(module == null)
            return NotFound();

        var topics = module.Topics;
        List<ShowTopicContentModel>? topicsView = null;
        if(topics != null)
        {   
            topicsView = new List<ShowTopicContentModel>();
            foreach(var topic in topics)
            {
                var newTopicView = new ShowTopicContentModel()
                {
                    TopicId = topic.TopicId,
                    Name = topic.Name,
                    Content = topic.Content
                };
                topicsView.Add(newTopicView);
            }
        }
        var moduleView = new ShowModuleContentModel()
        {
            ModuleId = module.ModuleId,
            Name = module.Name,
            Description = module.Description,
            Topics = topicsView
        };
    
        
        return View(moduleView);
    }

    public async Task<IActionResult> ShowTopicContent(long moduleId, long topicId)
    {
        var module = await _context.Modules.Include(module => module.Topics).FirstOrDefaultAsync(module => module.ModuleId == moduleId);
        var topics = module?.Topics;
        if(topics == null || topics.Count == 0)
        {
            return NotFound();
        }

        var topic = topics.FirstOrDefault(topic => topic.TopicId == topicId);

        if(module == null || topic == null)
            return NotFound();
        
        var tasks = await _context.MathTasks.Where(task => task.TopicId == topic.TopicId).ToListAsync();
        List<ShowTaskContentModel>? tasksView = null;
        if(tasks.Count != 0)
        {
            tasksView = new List<ShowTaskContentModel>();
            foreach(var task in tasks)
            {
                var newTaskView = new ShowTaskContentModel()
                {
                    TaskId = task.TaskId,
                    Contents = task.Contents,
                    PointsCount = task.PointsCount,
                    DifficultyLevel = (int)task.Level
                };

                tasksView.Add(newTaskView);
            }
        }


        var topicView = new ShowTopicContentModel()
        {
            TopicId = topic.TopicId,
            Name = topic.Name,
            Content = topic.Content,
            Tasks = tasksView
        };

        
        return View(topicView);
    }
    
    public async Task<IActionResult> ShowTaskContent(long taskId)
    {
        var task = await _context.MathTasks.FirstOrDefaultAsync(task => task.TaskId == taskId);
        if(task == null)
            return NotFound();
        
        var taskView = new ShowTaskContentModel()
        {
            TaskId = task.TaskId,
            Contents = task.Contents,
            PointsCount = task.PointsCount,
            DifficultyLevel = (int)task.Level
        };

        
        return View(taskView);
    }

}
