﻿using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Models
{
    public class UserRole : IdentityRole
    {
        public string? Name { get; set; }
        public string? NormalizedName { get; set; }
    }
}