using MelonLoader;
using System;
using System.Reflection;
using System.Runtime.InteropServices;

[assembly: AssemblyTitle("MicDotRecolour")]
[assembly: AssemblyDescription("A Melonloader mod for vrchat to recolour the mic dot")]
[assembly: AssemblyConfiguration("")]
[assembly: AssemblyCompany("Mezque")]
[assembly: AssemblyProduct("MicDotRecolour")]
[assembly: AssemblyCopyright("Copyright ©  2022")]
[assembly: AssemblyTrademark("Mezque")]
[assembly: AssemblyCulture("")]
[assembly: MelonInfo(typeof(MicDotRecolour.Main), "MicDotRecolour", $"{MicDotRecolourVerion.Version}", "Mezque", "https://github.com/Mezque/MicDotRecolour/releases/latest/download/MLMicDotRecolour.dll")]
[assembly: MelonGame("VRChat", "VRChat")]
[assembly: MelonColor(ConsoleColor.Blue)]
[assembly: ComVisible(false)]
[assembly: Guid("ed4799fc-d7a8-4ab0-b6b8-4cd1583397c7")]
[assembly: AssemblyVersion($"{MicDotRecolourVerion.Version}")]
[assembly: AssemblyFileVersion($"{MicDotRecolourVerion.Version}")]
internal struct MicDotRecolourVerion
{
    internal const string Version = "1.2.1.3";
}