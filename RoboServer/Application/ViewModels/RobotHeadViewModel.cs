using Core.Enums;

namespace Application.ViewModels;

public class RobotHeadViewModel
{
    public RobotHeadViewModel(int id, HeadRotation rotation, HeadInclination inclination)
    {
        Id = id;
        Rotation = rotation;
        Inclination = inclination;
    }

    public int Id { get; private set; }

    public HeadRotation Rotation { get; private set; }

    public HeadInclination Inclination { get; private set; }
}

