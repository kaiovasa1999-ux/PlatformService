using Microsoft.EntityFrameworkCore;
using PlatformService.Models;

namespace PlatformService.Data
{
    public static class PrepDb
    {
        public static void DbPreparor(this IApplicationBuilder app)
        {
            using var scoperService = app.ApplicationServices.CreateScope();
            DataSeeder(scoperService.ServiceProvider.GetService<AppDbContext>());
        }


        private static void DataSeeder(AppDbContext context)
        {
            if (!context.Platforms.Any())
            {
                Console.WriteLine("-->Seeding Data...");
                context.Platforms.AddRange(
                        new Platform() { Name = "Oracle", Publisher="Oracle",Cost="May cost alote but is free"},
                        new Platform() { Name = "Docker", Publisher= "Docker", Cost="Free"},
                        new Platform() { Name = "Dot Net", Publisher= "Dot Net", Cost="Free"},
                        new Platform() { Name = "Node.js", Publisher= "Node.js", Cost="10$/month"}
                    );

                context.SaveChanges();
            }
            else
            {
                Console.WriteLine("--> Already have Data");
            }
        }
    }
}
