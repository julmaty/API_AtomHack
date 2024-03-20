using System.ComponentModel.DataAnnotations;

namespace API_AtomHack.Model
{
    public class User
    {
        [Key] public int Id { get; set; }
        public string Login { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public string Patronymic { get; set; }

    }
}
