using System;
using Exiled.API.Features;
using Log = Exiled.API.Features.Log;

namespace SigmaWarhead.com.github.sekasin.sigmawarhead {
    public class SigmaWarhead : Plugin<Config> {
        public override string Name => "SigmaWarhead";
        public override string Author => "TenDRILLL";
        public override Version Version => new Version(1, 0, 4);
        public EventHandler EventHandler;

        public override void OnEnabled() {
            Log.Info("SigmaWarhead loading...");
            if (!Config.IsEnabled) {
                Log.Warn("SigmaWarhead disabled from config, unloading...");
                OnDisabled();
                return;                
            }
            EventHandler = new EventHandler(this);
            Log.Info("SigmaWarhead loaded.");
        }
        
        public override void OnDisabled() {
            EventHandler.UnregisterEvents();
            Log.Info("SigmaWarhead unloaded.");
        }
    }
}
