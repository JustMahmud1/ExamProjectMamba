﻿using Microsoft.AspNetCore.Identity;

namespace ProjectMambaExam.Models
{
    public class AppUser:IdentityUser
    {
        public string FullName { get; set; }
    }
}
