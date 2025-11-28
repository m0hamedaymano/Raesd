
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Raesd.Web.Extentions;
using Rased.Domain.Entitys.IdentityModule;
using Rased.Domain.Interfaces;
using Rased.Persistence.IdentityData.DataSeed;
using Rased.Persistence.IdentityData.DbContext;
using System.Threading.Tasks;

namespace Raesd
{
    public class Program
    {
        public static async Task Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.

            builder.Services.AddControllers();
            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();

            builder.Services.AddDbContext<RasedIdentityDbContext>(options =>
            {
                options.UseSqlServer(builder.Configuration.GetConnectionString("IdentityConnection"));
            });

            builder.Services.AddKeyedScoped<IDataIntializer, IdentityDataIntializer>("Identity");


            builder.Services.AddIdentityCore<ApplicationUser>()
                .AddRoles<IdentityRole>()
                .AddEntityFrameworkStores<RasedIdentityDbContext>();

            builder.Services.AddScoped<IAuthenticationService, AuthenticationService>();

            var app = builder.Build();
            #region DataSeeding - Apply Pending Migration
            //await app.MigrateDatabaseAsync();
            await app.SeedIdentityDatabaseAsync();
            #endregion

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseHttpsRedirection();

            app.UseAuthorization();


            app.MapControllers();

            app.Run();
        }
    }
}
