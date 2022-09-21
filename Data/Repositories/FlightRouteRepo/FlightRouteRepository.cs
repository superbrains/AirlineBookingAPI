using Data.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Repositories.FlightDestinationRepo
{
    public class FlightDestinationRepository : GenericRepository<FlightDestinations>, IFlightDestinationRepository
    {
        public FlightDestinationRepository(Data.DBContext.DBContext context, ILogger logger) : base(context, logger) { }

        public override async Task<IEnumerable<FlightDestinations>> All()
        {
            try
            {
                return await dbSet.ToListAsync();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "{Repo} All function error", typeof(FlightDestinationRepository));
                return new List<FlightDestinations>();
            }
        }

        public override async Task<bool> Update(FlightDestinations entity)
        {
            try
            {
                var existingUser = await dbSet.Where(x => x.Id == entity.Id)
                                                    .FirstOrDefaultAsync();

                if (existingUser == null)
                    return await Add(entity);

                //  existingUser.FirstName = entity.FirstName;
                // existingUser.LastName = entity.LastName;
                // existingUser.Email = entity.Email;

                return true;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "{Repo} Upsert function error", typeof(FlightDestinationRepository));
                return false;
            }
        }

        public override async Task<bool> Delete(int id)
        {
            try
            {
                var exist = await dbSet.Where(x => x.Id == id)
                                        .FirstOrDefaultAsync();

                if (exist == null) return false;

                dbSet.Remove(exist);

                return true;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "{Repo} Delete function error", typeof(FlightDestinationRepository));
                return false;
            }
        }
    }
}
