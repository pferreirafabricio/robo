using Application.InputModels;
using Application.Services.Implementation;
using Application.Services.Interfaces;
using Core.Entities;
using Core.Enums;
using Core.Repositories;
using Moq;
using System.Xml;

namespace UnitTests.Application;

public class RoboServiceTests
{
    [Fact]
    public void RobotCreate_Executed_IdMatch()
    {
        var defaultRobot = new Robot();
        var robotRepositoryMock = new Mock<IRobotRepository>();
        var robotService = new RobotService(robotRepositoryMock.Object);
        robotRepositoryMock.Setup(rs => rs.Create()).Returns(1);

        var createdId = robotService.Create();

        Assert.Equal(1, createdId);
    }

    [Fact]
    public void TryRotateWristWithElbowStronglyContracted_Executed_ShouldReturnOk()
    {
        var defaultRobot = new Robot();
        var robotRepositoryMock = new Mock<IRobotRepository>();
        var robotService = new RobotService(robotRepositoryMock.Object);
        robotRepositoryMock.Setup(rs => rs.GetById(1)).Returns(defaultRobot);

        var inputModel = new RotateArmWristInputModel
        {
            Id = 1,
            ArmName = "left",
            State = WristState.RotationTo180
        };

        var exception = Record.Exception(() => robotService.RotateArmWrist(inputModel));

        Assert.Null(exception);
    }
}
