using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Contexts
{
    public class DbInitialiser
    {
        private readonly ApplicationDbContext _context;

        public DbInitialiser(ApplicationDbContext context)
        {
            _context = context;
        }

        public void Run()
        {
            //early development
            _context.Database.EnsureDeleted();
            _context.Database.EnsureCreated();

            //late development
            _context.Database.Migrate();

            // TODO: Add initialisation logic.
        }
    }
}
