﻿using System.Data.Entity;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using POS_Rezor.Models;

namespace OurDestination.Models
{
    // You can add profile data for the user by adding more properties to your ApplicationUser class, please visit http://go.microsoft.com/fwlink/?LinkID=317594 to learn more.
    public class ApplicationUser : IdentityUser
    {
        public async Task<ClaimsIdentity> GenerateUserIdentityAsync(UserManager<ApplicationUser> manager)
        {
            // Note the authenticationType must match the one defined in CookieAuthenticationOptions.AuthenticationType
            var userIdentity = await manager.CreateIdentityAsync(this, DefaultAuthenticationTypes.ApplicationCookie);
            // Add custom user claims here
            return userIdentity;
        }
    }

    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        public ApplicationDbContext()
            : base("DefaultConnection", throwIfV1Schema: false)
        {
        }

        public virtual DbSet<Member> Member { get; set; }
        public virtual DbSet<Committee> Committee { get; set; }
        public virtual DbSet<Transection> Transection { get; set; }
        public virtual DbSet<Invest> Invest { get; set; }
        public virtual DbSet<Profit> Profit { get; set; }
        public virtual DbSet<Expenses_Master> Expenses_Master { get; set; }
        public virtual DbSet<Expenses_Details> Expenses_Details { get; set; }


        public static ApplicationDbContext Create()
        {
            return new ApplicationDbContext();
        }

        public System.Data.Entity.DbSet<POS_Rezor.Models.BloodGroup> BloodGroups { get; set; }
    }
}