using BepInEx;
using BepInEx.Logging;
using HarmonyLib;
using System.Reflection;

namespace UpFromTheDepths
{
    [BepInPlugin(PluginInfo.PLUGIN_GUID, PluginInfo.PLUGIN_NAME, PluginInfo.PLUGIN_VERSION)]
    [BepInDependency("com.snmodding.nautilus")]
    public class Plugin : BaseUnityPlugin
    {
        public new static ManualLogSource Logger { get; private set; }

        private static readonly Harmony harmony = new(PluginInfo.PLUGIN_GUID);

        // Set up the mod.
        private void Awake()
        {
            Logger = base.Logger;

            // Run patches and initialize things.
            harmony.PatchAll(Assembly.GetExecutingAssembly());

            // Not strictly necessary but is good to have.
            Logger.LogInfo("UpFromTheDepths loaded correctly!");
        }
    }
}