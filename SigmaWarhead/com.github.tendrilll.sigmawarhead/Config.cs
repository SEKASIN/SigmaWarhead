using System.Collections.Generic;
using System.ComponentModel;
using Exiled.API.Interfaces;

namespace SigmaWarhead.com.github.tendrilll.sigmawarhead
{
    public sealed class Config : IConfig
    {
        [Description("Is the Plugin enabled.")]
        public bool IsEnabled { get; set; } = true;

        [Description("Debug mode.")]
        public bool Debug { get; set; } = false;

        [Description("C.A.S.S.I.E. voicelines.")]
        public Dictionary<string, string> CassieLines { get; set; } = new(){
            { "launch", "Automatic .G3 jam_020_5 Sigma .G1 Warhead has been activated by .G6 pitch_0.69 O5 pitch_1.00 . Time until jam_020_3 detonation is .G2 T minus 90 seconds ." }
        };

        [Description("Minutes since start of round to activate Sigma Warhead.")]
        public int ActivationTime { get; set; } = 20;
    }
}