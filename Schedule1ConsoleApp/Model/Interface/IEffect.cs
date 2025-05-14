using System;
using Schedule1ConsoleApp.Model;

namespace Schedule1ConsoleApp.Model;

public interface IEffect
{
    string Name();
    decimal Multiplier();
    IEffectType Type();
    string Description();
}
