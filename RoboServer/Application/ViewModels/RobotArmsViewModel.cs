using Core.Enums;

namespace Application.ViewModels;

public class RobotArmsViewModel
{
    public RobotArmsViewModel(int id, ElbowState leftElbow, WristState leftWrist, ElbowState rightElbow, WristState rightWrist)
    {
        Id = id;
        LeftElbow = leftElbow;
        LeftWrist = leftWrist;
        RightElbow = rightElbow;
        RightWrist = rightWrist;
    }

    public int Id { get; private set; }

    public ElbowState LeftElbow { get; private set; }

    public WristState LeftWrist { get; private set; }

    public ElbowState RightElbow { get; private set; }

    public WristState RightWrist { get; private set; }
}
