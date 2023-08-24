namespace PFINAL_PROGRA.Migrations
{
    using Microsoft.AspNet.Identity.EntityFramework;
    using Microsoft.AspNet.Identity;
    using PFINAL_PROGRA.Models;
    using System.Data.Entity.Migrations;


    internal sealed class Configuration : DbMigrationsConfiguration<PFINAL_PROGRA.Models.ApplicationDbContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
            ContextKey = "PFINAL_PROGRA.Models.ApplicationDbContext";
        }

     
           protected override void Seed(PFINAL_PROGRA.Models.ApplicationDbContext context)
        {
            var userManager = new UserManager<ApplicationUser>(new UserStore<ApplicationUser>(context));
            var roleManager = new RoleManager<IdentityRole>(new RoleStore<IdentityRole>(context));

            // Verifica si el usuario administrador ya existe
            var adminUser = userManager.FindByName("abc@abc.com");
            if (adminUser == null)
            {
                adminUser = new ApplicationUser
                {
                    UserName = "admin",
                    Email = "abc@abc.com"
                };
                var result = userManager.Create(adminUser, "abc123");
                if (result.Succeeded)
                {
                    // Asignar el rol "admin" al usuario administrador
                    userManager.AddToRole(adminUser.Id, "admin");
                }
            }

    }
    }
}
