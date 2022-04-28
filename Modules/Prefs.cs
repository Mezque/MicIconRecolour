using MelonLoader;
using UnityEngine;

namespace MicDotRecolour.Modules
{
    internal class Prefs
    {
        internal static void InitPrefs()
        {
            MDR = MelonPreferences.CreateCategory("Mic Dot Recolour");
            MicColourR = MDR.CreateEntry("Mic Colour R", "215.628", "Mic Icon (Red 0-255)  (Default 215.628)");
            MicColourG = MDR.CreateEntry("Mic Colour G", "0", "Mic Icon (Green; 0-255) (Default 0)");
            MicColourB = MDR.CreateEntry("Mic Colour B", "0", "Mic Icon (Blue; 0-255) (Default 0)");
            MicColourA = MDR.CreateEntry("Mic Colour A", "155.805", "Mic Icon (Alpha; 0-255) (Default 155.805)");
            MicRgb = MDR.CreateEntry<bool>("Mic RGB", false, "Toggle for rgb mode");
            MelonLoader.MelonPreferences.Save();
        }
        internal static MelonPreferences_Category MDR;
        internal static MelonPreferences_Entry<string> MicColourR;
        internal static MelonPreferences_Entry<string> MicColourG;
        internal static MelonPreferences_Entry<string> MicColourB;
        internal static MelonPreferences_Entry<string> MicColourA;
        internal static MelonPreferences_Entry<bool> MicRgb;
    }
}
