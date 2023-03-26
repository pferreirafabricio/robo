using Core.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.InputModels;

public class RotateArmWristInputModel
{
    public int Id { get; set; }
    public string ArmName { get; set; }
    public WristState State { get; set; }
}
