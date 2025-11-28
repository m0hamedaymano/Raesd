using Microsoft.EntityFrameworkCore;
using Rased.Domain.Interfaces;
using Rased.Persistence.IdentityData.DbContext;

namespace Raesd.Web.Extentions
{
    public static class WepApplicationRegisteration
    {
        public static WebApplication MigrateDatabase(this WebApplication app)
        {
            await using var scope = app.Services.CreateAsyncScope();
            var DbContextService = scope.ServiceProvider.GetRequiredService<RasedIdentityDbContext>();
            if (DbContextService.Database.GetPendingMigrations().Any())
            {
                DbContextService.Database.Migrate();
            }
            return app;
        }

        public static async Task<WebApplication> SeedIdentityDatabaseAsync(this WebApplication app)
        {
            await using var scope = app.Services.CreateAsyncScope();
            var DbContextService = scope.ServiceProvider.GetRequiredService<RasedIdentityDbContext>();
            var dataIntializerService = scope.ServiceProvider.GetRequiredService<IDataIntializer>();
            await dataIntializerService.InitializeAsync();

            return app;
        }
    }
}
