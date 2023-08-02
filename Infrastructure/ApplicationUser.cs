﻿using Microsoft.AspNetCore.Identity;

namespace Infrastructure
{
    public class ApplicationUser :IdentityUser
    {
        public string FirstName { get;  set; }
        public string LastName { get; set; }

    }
}