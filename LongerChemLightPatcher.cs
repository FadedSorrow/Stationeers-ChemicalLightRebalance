using BepInEx;
using HarmonyLib;
using System;

namespace StationeersLongChemLight
{
    [BepInPlugin("FadedSorrow.Stationeers.Plugins.LongerChemLight", "Longer Chemical Light", "0.1.0.0")]
    public class LongerChemLightPlugin : BaseUnityPlugin
    {
        private void Awake()
        {
            Log("Plugin for Longer Chemical Light is loaded!");

            try
            {
                var harmony = new Harmony("FadedSorrow.Stationeers.Plugins.LongerChemLight");
                //Annotation patching.
                harmony.PatchAll();
                Log("Patch completed!");
            } catch (Exception ex)
            {
                Log($"Patcher failed due to: {ex}");
            }
        }

        //BepInEx log.
        public void Log(string msg)
        {
            Logger.LogInfo($"{msg}");
        }
    }
}
