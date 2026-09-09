using BepInEx;
using HarmonyLib;

namespace AutoCollectNotebooksAndPoints;

[BepInPlugin("denyscrasav4ik.thedumbfactory.autocollectnotebooksandpoints", "Auto Collect Notebooks and Points", "1.0.0")]
public class PickupPlugin : BaseUnityPlugin
{
    private void Awake() => new Harmony("denyscrasav4ik.thedumbfactory.autocollectnotebooksandpoints").PatchAll();
}

[HarmonyPatch(typeof(Notebook), "ClickableSighted")]
public class NotebookPatch
{
    internal static void Postfix(Notebook __instance, int player)
    {
        if (!__instance.collected)
            __instance.Clicked(player);
    }
}

[HarmonyPatch(typeof(Pickup), "ClickableSighted")]
public class PickupPatch
{
    internal static void Postfix(Pickup __instance, int player)
    {
        if (__instance.item != null && __instance.item.item is ITM_YTPs)
            __instance.Clicked(player);
    }
}
