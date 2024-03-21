using Microsoft.EntityFrameworkCore;

namespace quizapp_backend.Database
{
    public static class MigrationRunner
    {
        public static void ApplyProjectMigrations(this WebApplication app)
        {
            using (var scope = app.Services.CreateScope())
            {
                var db = scope.ServiceProvider.GetRequiredService<DatabaseContext>();
                //db.Database.Migrate();
            }
        }
    }
}
