using HarmonyLib;

namespace quiet_conditions.Patches
{
    [HarmonyPatch(typeof(ScriptableCondition))]
    internal class ScriptableConditionPatch
    {
        [HarmonyPatch("Apply_ConditionToEntity")]
        [HarmonyPrefix]
        private static void HushConditionsPatch(ref ScriptableCondition __instance)
        {
            if (__instance._conditionObject != null)
            {
                __instance._conditionObject = null;
            }
            if (__instance._endConditionObject != null)
            {
                __instance._endConditionObject = null;
            }
            if (__instance._tintEntityOnEffect)
            {
                __instance._tintEntityOnEffect = false;
            }
            if (__instance._shineEntityOnEffect)
            {
                __instance._shineEntityOnEffect = false;
            }
        }
    }
}