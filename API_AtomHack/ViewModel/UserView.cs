using System.ComponentModel.DataAnnotations;

namespace API_AtomHack.ViewModel
{
    public class UserView
    {
        public string Login { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public string Patronymic { get; set; }
    }
}
