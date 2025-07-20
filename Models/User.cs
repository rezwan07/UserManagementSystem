﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace UserManagementSystem.Models
{
    public class User
    {
        public int Id { get; set; }  

        public string Name { get; set; }

        public string Email { get; set; }

        public int Age { get; set; }

        public bool IsActive { get; set; }
    }
}