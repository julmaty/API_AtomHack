using API_AtomHack.Model;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Composition;
using API_AtomHack.ViewModel;

namespace API_AtomHack.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly ApplicationContext _context;
        public UserController(ApplicationContext context)
        {
            _context = context;
        }
        [HttpPost]
        public async Task<ActionResult> Post(UserView user)
        {
            //поиск пользователя
            User? user_db =  _context.Users.Where(p => p.Login == user.Login && p.Name == user.Name && p.Surname == user.Surname && p.Patronymic == user.Patronymic).FirstOrDefault();
            //если не найден, то создаем нового
            if (user_db == null)
            {
                User user_new = new User { Login= user.Login, Name = user.Name, Surname = user.Surname, Patronymic=user.Patronymic };
                _context.Users.Add(user_new);
                await _context.SaveChangesAsync();
                //добавляем в историю взаимодействий
                var userHistory = new userHistory { Case = 1, UserId = user_new.Id, DateTime = DateTime.Now };
                _context.userHistories.Add(userHistory);
                await _context.SaveChangesAsync();
                //возвращаем id нового пользователя
                return Ok(user_new.Id);
            }
            //добавляем в историю взаимодействий
            var userHistorydb = new userHistory { Case = 1, UserId = user_db.Id, DateTime = DateTime.Now };
            _context.userHistories.Add(userHistorydb);
            //возвращаем id имеющегося пользователя
            return Ok(user_db.Id);

        }
    }
}
