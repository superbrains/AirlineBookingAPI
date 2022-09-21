﻿using Data.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Repositories.FlightRepo
{
    public class FlightRepository : GenericRepository<Flight>, IFlightRepository
    {
        public FlightRepository(Data.DBContext.DBContext context, ILogger logger) : base(context, logger) { }

        public override async Task<IEnumerable<Flight>> All()
        {
            try
            {
                return await dbSet.ToListAsync();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "{Repo} All function error", typeof(FlightRepository));
                return new List<Flight>();
            }
        }

        public override async Task<bool> Update(Flight entity)
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
                _logger.LogError(ex, "{Repo} Upsert function error", typeof(FlightRepository));
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
                _logger.LogError(ex, "{Repo} Delete function error", typeof(FlightRepository));
                return false;
            }
        }
    }
}
