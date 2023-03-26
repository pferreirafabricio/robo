using Application.Services.Implementation;
using Core.Entities;
using Core.Repositories;
using Infrastructure.Persistence;

namespace Application.Repositories;

public class RobotRepository : IRobotRepository
{
    private readonly RoboDbContext _dbContext;

    public RobotRepository(RoboDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public Robot GetById(int id)
    {
        return _dbContext.Robots.SingleOrDefault(x => x.Id == id);
    }

    public int Create()
    {
        var robot = new Robot();

        _dbContext.Robots.Add(robot);
        Save();

        return robot.Id;    
    }

    public void Save()
    {
        _dbContext.SaveChanges();
    }
}


