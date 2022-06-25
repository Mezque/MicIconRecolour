using MelonLoader;
using System;
using UnityEngine;
using UnityEngine.UI;

namespace MicDotRecolour
{
    internal class Main : MelonMod
    {
        private static bool UIManagerInitialized = false;
        private static Image muteIcon;
        private static GameObject goVoiceDotMuted;

        public override void OnApplicationStart() => Modules.UpdateNotice.UpdateCheck();
        public override void OnPreferencesSaved()
        {
            if (UIManagerInitialized && Modules.Prefs.MicRgb.Value)
            {
                Modules.ModLog.Msg(ConsoleColor.Yellow, "[Info] Recoloring microphone icon");
                muteIcon.color = new(float.Parse(Modules.Prefs.MicColourR.Value) / 255f, float.Parse(Modules.Prefs.MicColourG.Value) / 255f, float.Parse(Modules.Prefs.MicColourB.Value) / 255f, float.Parse(Modules.Prefs.MicColourA.Value) / 255f);
                goVoiceDotMuted.transform.localScale = new Vector3(Modules.Prefs.Scale.Value, Modules.Prefs.Scale.Value, Modules.Prefs.Scale.Value);
            }
        }

        public override void OnSceneWasLoaded(int index, string _)
        {
            if (index == 1)
                Setup();
        }

        private static void Setup()
        {
            goVoiceDotMuted = GameObject.Find("UserInterface").transform.Find("UnscaledUI/HudContent_Old/Hud/VoiceDotParent/VoiceDotDisabled").gameObject;
            muteIcon = GameObject.Find("UserInterface").transform.Find("UnscaledUI/HudContent_Old/Hud/VoiceDotParent/VoiceDotDisabled").GetComponent<Image>();
            UIManagerInitialized = true;
        }

        public override void OnUpdate()
        {
            if (!UIManagerInitialized || !Modules.Prefs.MicRgb.Value) return;
            muteIcon.color = new((float)Math.Sin(2 * Time.time * 0.5f + 0.5f), (float)Math.Sin((2 * Time.time) + Math.PI * 2.0 / 3.0) * 0.5f + 0.5f, (float)Math.Sin((2 * Time.time) + Math.PI * 4.0 / 3.0) * 0.5f + 0.5f);
        }
    }
}
