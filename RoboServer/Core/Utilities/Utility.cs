using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace Core.Utilities;

public static class Utility
{
    /// <summary>
    /// Verify if the enum state change is valid
    /// </summary>
    /// <typeparam name="TEnum"></typeparam>
    /// <param name="enum"></param>
    /// <param name="newValue"></param>
    /// <returns></returns>
    public static bool CanChangeState<TEnum>(TEnum @enum, TEnum newValue) where TEnum : Enum
    {
        var currentState = Unsafe.As<TEnum, int>(ref @enum);
        var newState = Unsafe.As<TEnum, int>(ref newValue);

        if (currentState == newState)
            return true;

        (int Min, int Max) validStates = (currentState - 1, currentState + 1);

        if (newState != validStates.Min && newState != validStates.Max)
            return false;

        return true;
    }
}
