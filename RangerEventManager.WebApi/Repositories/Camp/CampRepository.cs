using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using RangerEventManager.Persistence.Entities.Camp;

namespace RangerEventManager.WebApi.Repositories.Camp;

public class CampRepository(IServiceProvider serviceProvider) : BaseRepository(serviceProvider), ICampRepository
{
    public async Task<List<CampEntity>> GetAllCampsFull()
    {
        return await Context.Camps
            .Include(c => c.Employees)
            .Include(c => c.Leaders)
            .Include(c => c.Deadlines)
            .Include(c => c.Events)
            .Include(c => c.Files)
            .Include(c => c.Finance)
            .Include(c => c.Location)
            .Include(c => c.Materials)
            .Include(c => c.Registration)
            .Include(c => c.Participants)
            .Include(c => c.Tasks).ToListAsync();
    }

    public async Task<List<CampEntity>> GetAllCampsByUserNameFull(string username)
    {
        return await Context.Camps
            .Where(c => 
                c.Employees.Any(e => e.UserName == username) 
                || c.Leaders.Any(l => l.UserName == username))
            .Include(c => c.Employees)
            .Include(c => c.Leaders)
            .Include(c => c.Deadlines)
            .Include(c => c.Events)
            .Include(c => c.Files)
            .Include(c => c.Finance)
            .Include(c => c.Location)
            .Include(c => c.Materials)
            .Include(c => c.Registration)
            .Include(c => c.Participants)
            .Include(c => c.Tasks)
            .ToListAsync();
    }

    public async Task<List<CampEntity>> GetAllCampsByUserNameOverview(string username)
    {
        return await Context.Camps
            .Where(c => 
                c.Employees.Any(e => e.UserName == username) 
                || c.Leaders.Any(l => l.UserName == username))
            .Include(c => c.Leaders)
            .ToListAsync();
    }
}