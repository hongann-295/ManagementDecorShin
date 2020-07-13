﻿using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ManagementDecorShin.Models
{
    public class ApplicationUser : IdentityUser
    {
        public string City { get; set; }
        public string Address { get; set; }
    }
}
