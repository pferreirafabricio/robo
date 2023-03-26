using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Core.Enums;

namespace Core.ValueObjects;

public class Head
{
    public Head(HeadRotation rotation = HeadRotation.AtRest, HeadInclination inclination = HeadInclination.AtRest)
    {
        Rotation = rotation;
        Inclination = inclination;
    }

    public HeadRotation Rotation { get; private set; }
    public HeadInclination Inclination { get; private set; }
}