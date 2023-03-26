using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Core.ValueObjects;

namespace Core.Entities;

public class Robot
{
    public Head Head { get; private set; }
    public Arm LeftArm { get; private set; }
    public Arm RightArm { get; private set; }
}