using Core.Enums;

namespace Application.ViewModels;

public class RobotHeadViewModel
{
    public RobotHeadViewModel(int id, HeadRotation headRotation, HeadInclination headInclination)
    {
        Id = id;
        HeadRotation = headRotation;
        HeadInclination = headInclination;
    }

    public int Id { get; private set; }

    public HeadRotation HeadRotation { get; private set; }

    public HeadInclination HeadInclination { get; private set; }
}

