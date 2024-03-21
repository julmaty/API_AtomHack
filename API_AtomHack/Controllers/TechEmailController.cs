using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using API_AtomHack.Model;
using API_AtomHack.ViewModel;
using QuartzScheduler;
using System.IO;

namespace API_AtomHack.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TechEmailController : ControllerBase
    {
        private readonly ApplicationContext _context;
        EmailService _emailService;
        private readonly IWebHostEnvironment _appEnvironment;

        public TechEmailController(ApplicationContext context, EmailService emailService, IWebHostEnvironment appEnvironment)
        {
            _context = context;
            _emailService = emailService;
            _appEnvironment = appEnvironment;
        }
        [HttpPost]
        public async Task<ActionResult> Post(TechApplication apply)
        {
            var user = await _context.Users.FindAsync(apply.UserId);
            Message1 message = new Message1 { };
            message.Content = apply.Content; ;
            message.DataCreated = DateTime.Now;
            message.AI = false;
            message.UserId = user.Id;
            _context.Messages.Add(message);
            await _context.SaveChangesAsync();

            if (apply.uploads != null)
            {
                foreach (var formFile in apply.uploads)
                {
                    if (formFile.Length > 0)
                    {
                        var name = formFile.FileName;
                        var filePath = _appEnvironment.WebRootPath + "/files/" + name;
                        using (var fileStream = new FileStream(filePath, FileMode.Create))
                        {
                            await formFile.CopyToAsync(fileStream);
                        }
                        Model.File1 file = new Model.File1();
                        file.messageId = (int)message.Id;
                        file.Name = filePath;
                        await _context.Files.AddAsync(file);
                        await _context.SaveChangesAsync();

                    }
                }
            }
                
            var userHistory = new userHistory { Case = 4, messageId=(int)message.Id, UserId=user.Id, DateTime = DateTime.Now };
            _context.userHistories.Add(userHistory);
            await _context.SaveChangesAsync();
            await _emailService.SendEmailAsync("hste-media-1@yandex.ru", "Обращение в техподдержку", $"<div> Поступило обращение от {user.Name}!<br/><br/>{apply.Content} </div>");
            
            await _context.SaveChangesAsync();

            return Ok();
        }
    }
}
