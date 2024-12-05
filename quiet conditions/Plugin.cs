using BepInEx;
using BepInEx.Logging;
using HarmonyLib;
using quiet_conditions.Patches;

namespace quiet_conditions
{
    [BepInPlugin(modGUID, modName, modVersion)]
    public class QConditions : BaseUnityPlugin
    {
        private const string modGUID = "quiet-conditions";

        private const string modName = "quiet conditions";

        private const string modVersion = "1.0.2";

        private readonly Harmony harmony = new Harmony(modGUID);

        private static QConditions qconditions;

        public static ManualLogSource mls { get; private set; }

        private void Awake()
        {
            if (qconditions == null)
            {
                qconditions = this;
            }
            mls = BepInEx.Logging.Logger.CreateLogSource(modGUID);
            mls.LogInfo("quiet conditions initialized!");
            harmony.PatchAll(typeof(QConditions));
            harmony.PatchAll(typeof(ScriptableConditionPatch));
        }
    }
}

