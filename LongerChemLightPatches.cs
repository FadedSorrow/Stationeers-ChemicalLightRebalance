using System;
using BepInEx;
using HarmonyLib;
using UnityEngine;
using Assets.Scripts.Objects.Items;

namespace StationeersLongChemLight
{
    [HarmonyPatch(typeof(ChemLight))]
    class AlterationPatch
    {
        [HarmonyPatch("Start")]
        [HarmonyPrefix]
        public static void DurationPatch(ChemLight __instance)
        {
            __instance.LifeSpan = 300f; //100f
        }

        [HarmonyPatch("OnInteractableUpdated")]
        [HarmonyPrefix]
        public static void RadiancePatch(ChemLight __instance)
        {
            Traverse.Create(__instance).Field("_light").Property("intensity").SetValue(2.1f); //1.5f
            Traverse.Create(__instance).Field("_light").Property("range").SetValue(6.5f); //3f
            Traverse.Create(__instance).Field("_light").Property("bounceIntensity").SetValue(0.5f); //0f
            Traverse.Create(__instance).Field("_light").Property("shadowStrength").SetValue(0.5f); //1f
            Traverse.Create(__instance).Field("_light").Property("shadowSoftness").SetValue(6f); //4f
            Traverse.Create(__instance).Field("_light").Property("shadowSoftnessFade").SetValue(2f); //1f
        }

        //Unity Log.
        public static void Log(string msg)
        {
            Debug.Log($"StationeersLongChemLight: {msg}");
        }
    }
}
