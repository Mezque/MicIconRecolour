using MelonLoader;
using System;
using UnityEngine;
using UnityEngine.UI;

namespace MicIconRecolour
{
    internal class Main : MelonMod
    {
        private static bool UIManagerInitialized = false;
        private static Image muteIcon;
        private static GameObject goVoiceDotMuted;
        public override void OnPreferencesSaved()
        {
            if (UIManagerInitialized)
            {
                Modules.ModLog.Msg(ConsoleColor.Yellow, "[Info] Recoloring microphone icon");
                muteIcon.color = new(float.Parse(Modules.Prefs.MicColourR.Value) / 255f, float.Parse(Modules.Prefs.MicColourG.Value) / 255f, float.Parse(Modules.Prefs.MicColourB.Value) / 255f, float.Parse(Modules.Prefs.MicColourA.Value) / 255f);
                goVoiceDotMuted.transform.localScale = new Vector3(Modules.Prefs.Scale.Value, Modules.Prefs.Scale.Value, Modules.Prefs.Scale.Value);
                Visability();
            }
        }
        private static void Visability()
        {
            if (Modules.Prefs.ToggleMuteIconVisable.Value == false)
            {
                goVoiceDotMuted.active = false;
            }
            else
            {
                goVoiceDotMuted.active = true;  
            }
        }
        public override void OnSceneWasLoaded(int buildIndex, string sceneName)
        {
            if (sceneName != "Application2") //needs more work, currently throws 2 errors before it reaches the right scene.
                Modules.ModLog.Msg(ConsoleColor.Yellow, "[DEBUG] Scene name is" + sceneName);
                Setup();
                
        }
        private static void Setup()
        {
            Modules.ModLog.Msg(ConsoleColor.Yellow, "[DEBUG] SETUP STAGE 1");
            var uiChild = GameObject.Find("PlayerDisplay").transform.parent;
            var uiString = uiChild.ToString().Remove(50); // removed the " (UnityEngine.Transform)" text from our string leaving us with just the UserInterface+GUID game object :)
            Modules.ModLog.Msg(ConsoleColor.Yellow, "[DEBUG] SETUP STAGE 2, uiChild found " + uiString);
            Modules.ModLog.Msg(ConsoleColor.Yellow, uiString);
            goVoiceDotMuted = GameObject.Find(uiString).transform.Find("UnscaledUI/HudContent/HUD_UI 2(Clone)/VR Canvas/Container/Left/Icons/Mic").gameObject;
            Modules.ModLog.Msg(ConsoleColor.Yellow, "[DEBUG] SETUP STAGE 5 found voice icon game object");
            muteIcon = GameObject.Find(uiString).transform.Find("UnscaledUI/HudContent/HUD_UI 2(Clone)/VR Canvas/Container/Left/Icons/Mic/MicIcon").GetComponent<Image>();
            Modules.ModLog.Msg(ConsoleColor.Yellow, "[DEBUG] SETUP STAGE 6 found voice icon image object");
            UIManagerInitialized = true;
            Visability();
        }
        public override void OnUpdate()
        {
            if (!UIManagerInitialized || !Modules.Prefs.MicRgb.Value) return;
            muteIcon.color = new((float)Math.Sin(2 * Time.time * 0.5f + 0.5f), (float)Math.Sin((2 * Time.time) + Math.PI * 2.0 / 3.0) * 0.5f + 0.5f, (float)Math.Sin((2 * Time.time) + Math.PI * 4.0 / 3.0) * 0.5f + 0.5f);
        }
    }
}
