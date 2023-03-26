using Core.Entities;
using Core.Enums;

namespace UnitTests.Core.Entities;

public class RobotTests
{
    [Fact]
    public void RobotCreated_Executed_AllPropertiesAreAtRest()
    {
        var defaultRobot = new Robot();

        Assert.Equal(ElbowState.AtRest, defaultRobot.LeftElbow);
        Assert.Equal(WristState.AtRest, defaultRobot.LeftWrist);
        Assert.Equal(ElbowState.AtRest, defaultRobot.RightElbow);
        Assert.Equal(WristState.AtRest, defaultRobot.RightWrist);
        Assert.Equal(HeadInclination.AtRest, defaultRobot.HeadInclination);
        Assert.Equal(HeadRotation.AtRest, defaultRobot.HeadRotation);
    }
}
