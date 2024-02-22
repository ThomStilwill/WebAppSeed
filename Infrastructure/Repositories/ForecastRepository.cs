using Application.Abstractions;
using Domain.Weather;
using Infrastructure.Contexts;

namespace Infrastructure.Repositories
{
    public class ForecastRepository: Repository<Forecast>, IForecastRepository
    {
        private readonly ApplicationDbContext _context;
        public ForecastRepository(ApplicationDbContext context): base(context)
        {
        }
        
    }
}
