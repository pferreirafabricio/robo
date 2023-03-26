using Core.Enums;
using Core.Utilities;

namespace Core.Entities;

public class Robot
{
    public Robot(
        HeadRotation headRotation = HeadRotation.AtRest,
        HeadInclination headInclination = HeadInclination.AtRest,
        ElbowState leftElbow = ElbowState.AtRest,
        WristState leftWrist = WristState.AtRest,
        ElbowState rightElbow = ElbowState.AtRest,
        WristState rightWrist = WristState.AtRest
    )
    {
        HeadRotation = headRotation;
        HeadInclination = headInclination;
        LeftElbow = leftElbow;
        LeftWrist = leftWrist;
        RightElbow = rightElbow;
        RightWrist = rightWrist;
    }

    public int Id { get; private set; }

    public HeadRotation HeadRotation { get; private set; } = HeadRotation.AtRest;

    public HeadInclination HeadInclination { get; private set; } = HeadInclination.AtRest;

    public ElbowState LeftElbow { get; private set; } = ElbowState.AtRest;

    public WristState LeftWrist { get; private set; } = WristState.AtRest;

    public ElbowState RightElbow { get; private set; } = ElbowState.AtRest;

    public WristState RightWrist { get; private set; } = WristState.AtRest;

    public void RotateWrist(string armName, WristState newWristState)
    {
        if (!Utility.CanChangeState(RightWrist, newWristState))
            throw new Exception("Can't skip states changing writs rotation");

        if (RightElbow != ElbowState.StronglyContracted)
            throw new Exception("Can't rotate the wrist if the elbow isn't strongly contracted");

        if (armName == "left")
            LeftWrist = newWristState;
        else if (armName == "right")
            RightWrist = newWristState;
        else
            throw new ArgumentException("Invalid arm name");
    }

    public void ChangeElbowState(string armName, ElbowState newElbowState)
    {
        if (!Utility.CanChangeState(RightElbow, newElbowState))
            throw new Exception("Can't skip states changing elbow state");

        if (armName == "left")
            LeftElbow = newElbowState;
        else if (armName == "right")
            RightElbow = newElbowState;
        else
            throw new ArgumentException("Invalid arm name");
    }

    public void RotateHead(HeadRotation newHeadRotation)
    {
        if (!Utility.CanChangeState(HeadRotation, newHeadRotation))
            throw new Exception("Can't skip states changing head rotation");

        if (HeadInclination == HeadInclination.Down)
            throw new Exception("Can't rotate the head when the the inclination is down");

        HeadRotation = newHeadRotation;
    }

    public void InclineHead(HeadInclination newHeadInclination)
    {
        if (!Utility.CanChangeState(HeadInclination, newHeadInclination))
            throw new Exception("Can't skip states changing head inclination");

        HeadInclination = newHeadInclination;
    }
}