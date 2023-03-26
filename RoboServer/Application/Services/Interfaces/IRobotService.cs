using Application.InputModels;
using Application.ViewModels;
using Core.Entities;
using Core.Enums;

namespace Application.Services.Interfaces
{
    public interface IRobotService
    {
        Robot GetById(int id);
        RobotHeadViewModel GetHead(int id);
        RobotArmsViewModel GetArms(int id);
        int Create();
        void RotateHead(RotateHeadInputModel inputModel);
        void InclineHead(InclineHeadInputModel inputModel);
        void ChangeElbowState(RotateArmElbowInputModel inputModel);
        void RotateArmWrist(RotateArmWristInputModel inputModel);
    }
}