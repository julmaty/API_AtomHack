﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace API_AtomHack.Model
{
    public class File1
    {
        [Key] public int Id { get; set; }
        public string Name { get; set; }
        public int messageId { get; set; }
    }

}
