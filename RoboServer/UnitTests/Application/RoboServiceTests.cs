using Application.InputModels;
using Application.Services.Implementation;
using Application.ViewModels;
using Core.Constants;
using Core.Entities;
using Core.Enums;
using Core.Repositories;
using Infrastructure.Persistence;
using Moq;

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
    public void GetRobotById_Executed_ShouldReturnOk()
    {
        var defaultRobot = new Robot();
        var robotRepositoryMock = new Mock<IRobotRepository>();
        var robotService = new RobotService(robotRepositoryMock.Object);
        robotRepositoryMock.Setup(rs => rs.GetById(1)).Returns(defaultRobot);

        var returnedRobot = robotService.GetById(1);

        Assert.Equal(defaultRobot, returnedRobot);
    }

    [Fact]
    public void GetRobotByInexistingId_Executed_ShouldReturnNull()
    {
        var defaultRobot = new Robot();
        var robotRepositoryMock = new Mock<IRobotRepository>();
        var robotService = new RobotService(robotRepositoryMock.Object);
        robotRepositoryMock.Setup(rs => rs.GetById(1)).Returns(defaultRobot);

        var returnedRobot = robotService.GetById(2);

        Assert.Null(returnedRobot);
    }

    [Fact]
    public void GetRobotHeadWithInexistingId_Executed_ShouldReturnNull()
    {
        var defaultRobot = new Robot();
        var robotRepositoryMock = new Mock<IRobotRepository>();
        var robotService = new RobotService(robotRepositoryMock.Object);
        robotRepositoryMock.Setup(rs => rs.GetById(1)).Returns(defaultRobot);
        
        var returnedHead = robotService.GetHead(2);

        Assert.Null(returnedHead);
    }

    [Fact]
    public void GetRobotArmsWithInexistingId_Executed_ShouldReturnNull()
    {
        var defaultRobot = new Robot();
        var robotRepositoryMock = new Mock<IRobotRepository>();
        var robotService = new RobotService(robotRepositoryMock.Object);
        robotRepositoryMock.Setup(rs => rs.GetById(1)).Returns(defaultRobot);

        var returnedArms = robotService.GetArms(2);

        Assert.Null(returnedArms);
    }

    [Fact]
    public void TryRotateWristWithElbowStronglyContracted_Executed_ShouldNotThrowException()
    {
        var defaultRobot = new Robot(leftElbow: ElbowState.StronglyContracted);
        var robotRepositoryMock = new Mock<IRobotRepository>();
        var robotService = new RobotService(robotRepositoryMock.Object);
        robotRepositoryMock.Setup(rs => rs.GetById(1)).Returns(defaultRobot);

        var inputModel = new RotateArmWristInputModel
        {
            Id = 1,
            ArmName = ArmNames.LEFT,
            State = WristState.RotationToMinus45
        };

        var exception = Record.Exception(() => robotService.RotateArmWrist(inputModel));

        Assert.Null(exception);
    }

    [Fact]
    public void TryRotateWristWithElbowNotStronglyContracted_Executed_ShouldThrowException()
    {
        var defaultRobot = new Robot();
        var robotRepositoryMock = new Mock<IRobotRepository>();
        var robotService = new RobotService(robotRepositoryMock.Object);
        robotRepositoryMock.Setup(rs => rs.GetById(1)).Returns(defaultRobot);

        var inputModel = new RotateArmWristInputModel
        {
            Id = 1,
            ArmName = ArmNames.LEFT,
            State = WristState.RotationToMinus45
        };

        var exception = Record.Exception(() => robotService.RotateArmWrist(inputModel));

        Assert.NotNull(exception);
    }


    [Fact]
    public void TryRotateWristSkipingStateToMinus_Executed_ShouldThrowException()
    {
        var defaultRobot = new Robot();
        var robotRepositoryMock = new Mock<IRobotRepository>();
        var robotService = new RobotService(robotRepositoryMock.Object);
        robotRepositoryMock.Setup(rs => rs.GetById(1)).Returns(defaultRobot);

        var inputModel = new RotateArmWristInputModel
        {
            Id = 1,
            ArmName = ArmNames.LEFT,
            State = WristState.RotationToMinus90
        };

        var exception = Record.Exception(() => robotService.RotateArmWrist(inputModel));

        Assert.NotNull(exception);
    }

    [Fact]
    public void TryRotateWristSkipingStateToMax_Executed_ShouldThrowException()
    {
        var defaultRobot = new Robot();
        var robotRepositoryMock = new Mock<IRobotRepository>();
        var robotService = new RobotService(robotRepositoryMock.Object);
        robotRepositoryMock.Setup(rs => rs.GetById(1)).Returns(defaultRobot);

        var inputModel = new RotateArmWristInputModel
        {
            Id = 1,
            ArmName = ArmNames.LEFT,
            State = WristState.RotationTo90
        };

        var exception = Record.Exception(() => robotService.RotateArmWrist(inputModel));

        Assert.NotNull(exception);
    }

    [Fact]
    public void TryChangeElbowStateWithDefaultValue_Executed_ShouldNotException()
    {
        var defaultRobot = new Robot();
        var robotRepositoryMock = new Mock<IRobotRepository>();
        var robotService = new RobotService(robotRepositoryMock.Object);
        robotRepositoryMock.Setup(rs => rs.GetById(1)).Returns(defaultRobot);

        var inputModel = new RotateArmElbowInputModel
        {
            Id = 1,
            ArmName = ArmNames.RIGHT,
            State = ElbowState.SlightlyContracted
        };

        var exception = Record.Exception(() => robotService.ChangeElbowState(inputModel));

        Assert.Null(exception);
    }

    [Fact]
    public void TryChangeElbowStateToMinus_Executed_ShouldThrowException()
    {
        var defaultRobot = new Robot(rightElbow: ElbowState.StronglyContracted);
        var robotRepositoryMock = new Mock<IRobotRepository>();
        var robotService = new RobotService(robotRepositoryMock.Object);
        robotRepositoryMock.Setup(rs => rs.GetById(1)).Returns(defaultRobot);

        var inputModel = new RotateArmElbowInputModel
        {
            Id = 1,
            ArmName = ArmNames.RIGHT,
            State = ElbowState.SlightlyContracted
        };

        var exception = Record.Exception(() => robotService.ChangeElbowState(inputModel));

        Assert.NotNull(exception);
    }

    [Fact]
    public void TryChangeElbowStateToMax_Executed_ShouldThrowException()
    {
        var defaultRobot = new Robot();
        var robotRepositoryMock = new Mock<IRobotRepository>();
        var robotService = new RobotService(robotRepositoryMock.Object);
        robotRepositoryMock.Setup(rs => rs.GetById(1)).Returns(defaultRobot);

        var inputModel = new RotateArmElbowInputModel
        {
            Id = 1,
            ArmName = ArmNames.RIGHT,
            State = ElbowState.StronglyContracted
        };

        var exception = Record.Exception(() => robotService.ChangeElbowState(inputModel));

        Assert.NotNull(exception);
    }

    [Fact]
    public void TryRotateHeadWithInclinationInDefaultValue_Executed_ShouldNotThrowException()
    {
        var defaultRobot = new Robot();
        var robotRepositoryMock = new Mock<IRobotRepository>();
        var robotService = new RobotService(robotRepositoryMock.Object);
        robotRepositoryMock.Setup(rs => rs.GetById(1)).Returns(defaultRobot);

        var inputModel = new RotateHeadInputModel
        {
            Id = 1,
            Rotation = HeadRotation.RotationMinus45,
        };

        var exception = Record.Exception(() => robotService.RotateHead(inputModel));

        Assert.Null(exception);
    }

    [Fact]
    public void TryRotateHeadWithInclinationToDown_Executed_ShouldNotThrowException()
    {
        var defaultRobot = new Robot(headInclination: HeadInclination.Down);
        var robotRepositoryMock = new Mock<IRobotRepository>();
        var robotService = new RobotService(robotRepositoryMock.Object);
        robotRepositoryMock.Setup(rs => rs.GetById(1)).Returns(defaultRobot);

        var inputModel = new RotateHeadInputModel
        {
            Id = 1,
            Rotation = HeadRotation.RotationMinus45,
        };

        var exception = Record.Exception(() => robotService.RotateHead(inputModel));

        Assert.NotNull(exception);
    }

    [Fact]
    public void TryInclineHeadSkipingStateToMax_Executed_ShouldThrowException()
    {
        var defaultRobot = new Robot(headInclination: HeadInclination.Up);
        var robotRepositoryMock = new Mock<IRobotRepository>();
        var robotService = new RobotService(robotRepositoryMock.Object);
        robotRepositoryMock.Setup(rs => rs.GetById(1)).Returns(defaultRobot);

        var inputModel = new InclineHeadInputModel
        {
            Id = 1,
            Inclination = HeadInclination.Down
        };

        var exception = Record.Exception(() => robotService.InclineHead(inputModel));

        Assert.NotNull(exception);
    }

    [Fact]
    public void TryChangeInclineHeadWithDefaultValue_Executed_ShouldThrowException()
    {
        var defaultRobot = new Robot();
        var robotRepositoryMock = new Mock<IRobotRepository>();
        var robotService = new RobotService(robotRepositoryMock.Object);
        robotRepositoryMock.Setup(rs => rs.GetById(1)).Returns(defaultRobot);

        var inputModel = new InclineHeadInputModel
        {
            Id = 1,
            Inclination = HeadInclination.Down
        };

        var exception = Record.Exception(() => robotService.InclineHead(inputModel));

        Assert.Null(exception);
    }
}
