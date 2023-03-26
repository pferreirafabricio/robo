
using Application.InputModels;
using Application.Services.Interfaces;
using Application.ViewModels;
using Core.Entities;
using Infrastructure.Persistence;

namespace Application.Services.Implementation;

public class RobotService : IRobotService
{
    private readonly RoboDbContext _dbContext;

    public RobotService(RoboDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public Robot GetById(int id)
    {
        return _dbContext.Robots.SingleOrDefault(x => x.Id == id);
    }

    public RobotArmsViewModel GetArms(int id)
    {
        var robot = GetById(id);

        if (robot is null)
            return null;

        return new RobotArmsViewModel(robot.Id, robot.LeftElbow, robot.LeftWrist, robot.RightElbow, robot.RightWrist);
    }

    public RobotHeadViewModel GetHead(int id)
    {
        var robot = GetById(id);

        if (robot is null)
            return null;

        return new RobotHeadViewModel(robot.Id, robot.HeadRotation, robot.HeadInclination);
    }

    public void InclineHead(InclineHeadInputModel inputModel)
    {
        var robot = GetById(inputModel.Id);

        if (robot is null)
            return;

        robot.InclineHead(inputModel.Inclination);
        _dbContext.SaveChanges();
    }

    public void RotateHead(RotateHeadInputModel inputModel)
    {
        var robot = GetById(inputModel.Id);

        if (robot is null)
            return;

        robot.RotateHead(inputModel.Rotation);
        _dbContext.SaveChanges();
    }

    public void ChangeElbowState(RotateArmElbowInputModel inputModel)
    {
        var robot = GetById(inputModel.Id);

        if (robot is null)
            return;

        robot.ChangeElbowState(inputModel.ArmName, inputModel.State);

        _dbContext.SaveChanges();
    }

    public void RotateArmWrist(RotateArmWristInputModel inputModel)
    {
        var robot = GetById(inputModel.Id);

        if (robot is null)
            return;

        robot.RotateWrist(inputModel.ArmName, inputModel.State);

        _dbContext.SaveChanges();
    }

    public int Create()
    {
        var robot = new Robot();

        _dbContext.Robots.Add(robot);
        _dbContext.SaveChanges();

        return robot.Id;
    }
}