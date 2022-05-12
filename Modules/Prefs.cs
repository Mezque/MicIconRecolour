using MelonLoader;

namespace MicDotRecolour.Modules
{
    internal class Prefs
    {
        private static readonly MelonPreferences_Category MDR = MelonPreferences.CreateCategory("Mic Dot Recolour");
        internal static MelonPreferences_Entry<string> MicColourR = MDR.CreateEntry("Mic Colour R", "215.628", "Mic Icon (Red 0-255)  (Default 215.628)");
        internal static MelonPreferences_Entry<string> MicColourG = MDR.CreateEntry("Mic Colour G", "0", "Mic Icon (Green; 0-255) (Default 0)");
        internal static MelonPreferences_Entry<string> MicColourB = MDR.CreateEntry("Mic Colour B", "0", "Mic Icon (Blue; 0-255) (Default 0)");
        internal static MelonPreferences_Entry<string> MicColourA = MDR.CreateEntry("Mic Colour A", "155.805", "Mic Icon (Alpha; 0-255) (Default 155.805)");
        internal static MelonPreferences_Entry<float> Scale = MDR.CreateEntry("Mic Dot Scale", 1f, "Mic Dot Scale (Recommended 0.5-2.1");
        internal static MelonPreferences_Entry<bool> MicRgb = MDR.CreateEntry("Mic RGB", false, "Toggle for rgb mode");
    }
}