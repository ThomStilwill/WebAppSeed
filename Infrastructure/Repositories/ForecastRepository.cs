using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Application.Abstractions;
using Domain.Weather;
using Infrastructure.Contexts;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Repositories
{
    public class ForecastRepository: IForecastRepository
    {
        private readonly ApplicationDbContext _context;

        public ForecastRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<Forecast> Add(Forecast toCreate)
        {
            _context.Forecast.Add(toCreate);
            await _context.SaveChangesAsync();
            return toCreate;
        }

        public async Task Delete(int id)
        {
            var person = _context.Forecast
                .FirstOrDefault(p => p.Id == id);

            if (person is null) return;

            _context.Forecast.Remove(person);

            await _context.SaveChangesAsync();
        }

        public async Task<IEnumerable<Forecast>> GetAll()
        {
            return await _context.Forecast.ToListAsync();
        }

        public async Task<Forecast> GetById(int id)
        {
            return await _context.Forecast.FirstOrDefaultAsync(p => p.Id == id);
        }

        public async Task<Forecast> Update(int id, Forecast tObject)
        {
            var forecast = await _context.Forecast.FirstOrDefaultAsync(p => p.Id == id);
           
            

            await _context.SaveChangesAsync();

            return forecast;
        }
    }
}
