using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace MicDotRecolour.Modules
{
    internal class UpdateNotice
    {
        internal static void UpdateCheck()
        {
            using var sha = SHA256.Create();
            var gitURL = "https://github.com/Mezque/MicDotRecolour/releases/latest/download/MLMicDotRecolour.dll";
            byte[] DllCur = null;
            byte[] DLLupdate = null;
            var ModDLL = "Mods//MLMicDotRecolour.dll";
            using var wc = new WebClient();

            if (File.Exists(ModDLL))
            {
                DllCur = File.ReadAllBytes(ModDLL);
            }
            try
            {
                DLLupdate = wc.DownloadData($"{gitURL}");
            }
            catch (WebException ex)
            {
                Modules.ModLog.Warn($"Unable to check for mod update \n{ex}");
            }
            try
            {
                string CurModHash = ComputeHash(sha, DllCur);
                string UpdateModHash = ComputeHash(sha, DLLupdate);

                if (CurModHash != UpdateModHash)
                {
                    Modules.ModLog.Warn($"There Is A Mod Update Available At:\n {gitURL}\n Certan Features May NOT Work Until You Update!");
                }
                else
                {
                    Modules.ModLog.Msg(ConsoleColor.White, "[INFO] No Updates Available :)");
                }
            }
            catch (Exception ex)
            {
                Modules.ModLog.Warn($"Failed To Check For Updates:\n{ex}");
            }
        }

        private static string ComputeHash(HashAlgorithm sha256, byte[] data)
        {
            byte[] array = sha256.ComputeHash(data);
            StringBuilder stringBuilder = new StringBuilder();
            foreach (byte b in array)
            { stringBuilder.Append(b.ToString("x2")); }
            return stringBuilder.ToString();
        }
    }
}
