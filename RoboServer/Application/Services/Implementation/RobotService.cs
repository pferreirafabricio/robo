
using Application.InputModels;
using Application.Services.Interfaces;
using Application.ViewModels;
using Core.Entities;
using Core.Repositories;
using Infrastructure.Persistence;

namespace Application.Services.Implementation;

public class RobotService : IRobotService
{
    private readonly IRobotRepository _repository;

    public RobotService(IRobotRepository dbContext)
    {
        _repository = dbContext;
    }

    public Robot GetById(int id) => _repository.GetById(id);

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
        _repository.Save();
    }

    public void RotateHead(RotateHeadInputModel inputModel)
    {
        var robot = GetById(inputModel.Id);

        if (robot is null)
            return;

        robot.RotateHead(inputModel.Rotation);
        _repository.Save();
    }

    public void ChangeElbowState(RotateArmElbowInputModel inputModel)
    {
        var robot = GetById(inputModel.Id);

        if (robot is null)
            return;

        robot.ChangeElbowState(inputModel.ArmName, inputModel.State);

        _repository.Save();
    }

    public void RotateArmWrist(RotateArmWristInputModel inputModel)
    {
        var robot = GetById(inputModel.Id);

        if (robot is null)
            return;

        robot.RotateWrist(inputModel.ArmName, inputModel.State);

        _repository.Save();
    }

    public int Create() => _repository.Create();
}