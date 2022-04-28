using MelonLoader;
using System;
using System.Collections;
using UnityEngine;
using UnityEngine.UI;

namespace MicDotRecolour
{
    internal class Main : MelonMod
    {
        internal static bool RGBToggle = false;
        internal static Image ImageDot = GameObject.Find("UserInterface").transform.Find("UnscaledUI/HudContent/Hud/VoiceDotParent/VoiceDotDisabled").GetComponent<Image>();
        internal static GameObject UserInterface = GameObject.Find("UserInterface");

        public override void OnApplicationStart()
        {
            Modules.Prefs.InitPrefs();
            MelonCoroutines.Start(StartUserInterfaceInitIEnumerator());
        }

        public override void OnPreferencesSaved()
        {
            if (GameObject.Find("UserInterface") == null) return;
            Icon();
        }

        internal static IEnumerator StartUserInterfaceInitIEnumerator()
        {
            while (UserInterface == null) yield return null;
            Modules.ModLog.Msg(ConsoleColor.Yellow, "[Info] User Interface Found! Starting Mic Dot Recolour!");
            Icon();
        }

        public static void Icon()
        {
            if (!Modules.Prefs.MicRgb.Value)
            {
                GameObject.Find("UserInterface").transform.Find("UnscaledUI/HudContent/Hud/VoiceDotParent/VoiceDotDisabled").GetComponent<Image>().color = new Color(float.Parse(Modules.Prefs.MicColourR.Value) / 255f, float.Parse(Modules.Prefs.MicColourG.Value) / 255f, float.Parse(Modules.Prefs.MicColourB.Value) / 255f, float.Parse(Modules.Prefs.MicColourA.Value) / 255f);
                Modules.ModLog.Msg(ConsoleColor.Yellow, "[Info] Mic Dot Has Been Recoloured!");
            }
        }

        public override void OnUpdate()
        {
            while (UserInterface == null) return;
            Color Rainbow = new Color((float)Math.Sin(2 * Time.time * 0.5f + 0.5f), (float)Math.Sin((2 * Time.time) + Math.PI * 2.0 / 3.0) * 0.5f + 0.5f, (float)Math.Sin((2 * Time.time) + Math.PI * 4.0 / 3.0) * 0.5f + 0.5f);
            if (Modules.Prefs.MicRgb.Value) return;
            ImageDot.color = Rainbow;
        }
    }
}