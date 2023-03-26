using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Core.Enums;

namespace Core.ValueObjects;

public class Arm
{
    public Arm(ElbowState elbow = ElbowState.AtRest, ElbowState wrist = ElbowState.AtRest)
    {
        Elbow = elbow;
        Wrist = wrist;
    }

    public ElbowState Elbow { get; private set; }
    public ElbowState Wrist { get; private set; }
}