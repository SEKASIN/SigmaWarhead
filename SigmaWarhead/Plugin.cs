using System.IO;
using PluginAPI.Core;
using PluginAPI.Core.Attributes;
using PluginAPI.Enums;
using PluginAPI.Events;

namespace SigmaWarhead
{
    public class SigmaWarhead
    {
        public static SigmaWarhead Reference { get; private set; }
        public static string DirectoryPath { get; private set; }

        [PluginConfig]
        public Config Config;

        [PluginPriority(LoadPriority.Medium)]
        [PluginEntryPoint("SigmaWarhead", "1.0.1", "SigmaWarhead", "Ten")]
        void Load()
        {
            if (!Config.IsEnabled) return;

            Reference = this;
            DirectoryPath = PluginHandler.Get(this).PluginDirectoryPath;
            EventManager.RegisterEvents<EventHandler>(this);

            if (!Directory.Exists(DirectoryPath))
            {
                Log.Warning("Config directory not found, creating...");
                Directory.CreateDirectory(DirectoryPath);
            }
        }
    }
}