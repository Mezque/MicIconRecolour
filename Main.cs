using MelonLoader;
using System;
using UnityEngine;
using UnityEngine.UI;

namespace MicDotRecolour
{
    internal class Main : MelonMod
    {
        private static bool UIManagerInitialized = false;
        private static Image icon;

        public override void OnApplicationStart() => Modules.Prefs.InitPrefs();
        public override void OnPreferencesSaved()
        {
            if (UIManagerInitialized && Modules.Prefs.MicRgb.Value)
            {
                Modules.ModLog.Msg(ConsoleColor.Yellow, "[Info] Recoloring microphone icon"); // i put the log before the action incase the action causes a crash, so we know what did it
                icon.color = new(
                    float.Parse(Modules.Prefs.MicColourR.Value) / 255f, 
                    float.Parse(Modules.Prefs.MicColourG.Value) / 255f, float.Parse(Modules.Prefs.MicColourB.Value) / 255f, 
                    float.Parse(Modules.Prefs.MicColourA.Value) / 255f
                );
            }
        }

        public override void OnSceneWasLoaded(int index, string _)
        {
            if (index == 1) // scene 1 is the UI 
                Setup();
        }

        private static void Setup()
        {
            icon = GameObject.Find("UserInterface").transform.Find("UnscaledUI/HudContent/Hud/VoiceDotParent/VoiceDotDisabled").GetComponent<Image>();
            UIManagerInitialized = true;
        }

        public override void OnUpdate()
        {
            if (!UIManagerInitialized || !Modules.Prefs.MicRgb.Value) return;

            icon.color = new(
                (float)Math.Sin(2 * Time.time * 0.5f + 0.5f), 
                (float)Math.Sin((2 * Time.time) + Math.PI * 2.0 / 3.0) * 0.5f + 0.5f, 
                (float)Math.Sin((2 * Time.time) + Math.PI * 4.0 / 3.0) * 0.5f + 0.5f
            );
        }
    }
}