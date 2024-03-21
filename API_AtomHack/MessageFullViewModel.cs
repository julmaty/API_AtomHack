using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Test.Domain
{
    public class MessageFullViewModel
    {
        public int Id { get; set; }
        public string User_Items { get; set; }
        public bool Visible_Steps { get; set; }
        public int User_Id { get; set; }
        public string User_Login { get; set; }
        public string User_Name { get; set; }
        public string User_Surname { get; set; }
        public string User_Patronymic { get; set; }
    }
}
