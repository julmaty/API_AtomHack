using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace API_AtomHack
{
    public class Message
    {
        [Key] public int? Id { get; set; }
        public string? Content { get; set; }
        public string? Response { get; set; }

        public int? UserId { get; set; }
        bool AI { get; set; }
        public DateTime DataCreated { get; set; }
        
    }
}
