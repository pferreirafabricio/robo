using Core.Enums;

namespace Application.InputModels;

public class RotateHeadInputModel
{
    public int Id { get; set; }
    public HeadRotation Rotation { get; set; }
}
