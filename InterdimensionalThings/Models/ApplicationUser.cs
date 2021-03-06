﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;

namespace InterdimensionalThings.Models
{
    // Add profile data for application users by adding properties to the ApplicationUser class
    public class ApplicationUser : IdentityUser<int>
    {


        public ApplicationUser(): base()
        {
            this.ThingCart = new ThingCart();
        }

        public ApplicationUser(string userName) : base(userName)
        {

            this.ThingCart = new ThingCart();
        }
        public ThingCart ThingCart { get; set; }
        public int ThingCartID { get; set; }
    }
    public class ApplicationRole : IdentityRole<int>
    {
        public ApplicationRole() : base()
        {
        }
        public ApplicationRole(string roleName)
        {
            Name = roleName;
        }
    }
}
