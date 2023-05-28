using System.Collections.Generic;
using System.ComponentModel;

namespace SigmaWarhead
{
    public sealed class Config
    {
        [Description("Is the Plugin enabled.")]
        public bool IsEnabled { get; set; } = true;

        [Description("Debug mode.")]
        public bool Debug { get; private set; } = false;

        public Dictionary<string, string> CassieLines { get; private set; } = new()
        {
            { "launch", "Automatic .G3 jam_020_5 Sigma .G1 Warhead has been activated by .G6 pitch_0.69 O5 pitch_1.00 . Time until jam_020_3 detonation is .G2 T minus 80 seconds ." },
        };

        [Description("Minutes since start of round to activate Sigma Warhead.")]
        public int ActivationTime { get; private set; } = 20;

        [Description("Seconds Sigma Warhead takes to detonate.")]
        public int DetonationTime { get; private set; } = 80;
    }
}