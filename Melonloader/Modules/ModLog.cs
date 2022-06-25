using MelonLoader;
using System;

namespace MicDotRecolour.Modules
{
    internal static class ModLog
    {
        internal static MelonLogger.Instance Conlog = new("MicDotRecolour");
        internal static void Msg(ConsoleColor ConColour, string obj) => Conlog.Msg(ConColour, obj);
    }
}