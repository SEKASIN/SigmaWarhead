using System;
using System.Linq;
using System.Timers;
using PluginAPI.Core;
using PluginAPI.Core.Attributes;
using PluginAPI.Enums;

namespace SigmaWarhead;

public class EventHandler
{
    private int TimeToLaunch;
    private bool DebugMode;
    private string LaunchMessage;
    private Timer _launchTimer;

    [PluginEvent(ServerEventType.MapGenerated)]
    internal void OnGenerated()
    {
        TimeToLaunch = SigmaWarhead.Reference.Config.ActivationTime;
        DebugMode = SigmaWarhead.Reference.Config.Debug;
        LaunchMessage = SigmaWarhead.Reference.Config.CassieLines.FirstOrDefault(x => x.Key == "launch").Value;

        _launchTimer = new Timer(TimeToLaunch * 1000 * 60);
        _launchTimer.Elapsed += LaunchSigmaWarhead;
        _launchTimer.AutoReset = false;
    }

    [PluginEvent(ServerEventType.RoundStart)]
    internal void OnRoundStart()
    {
        _launchTimer.Enabled = true;
        if (DebugMode){ Log.Debug("SigmaWarhead armed and will launch in " + TimeToLaunch + " minutes."); }
    }

    internal void LaunchSigmaWarhead(Object source, ElapsedEventArgs e)
    {
        Log.Info("SigmaWarhead launched.");
        AlphaWarheadController.Singleton.InstantPrepare();
        AlphaWarheadController.Singleton.StartDetonation(true, true);
        AlphaWarheadController.Singleton.IsLocked = true; //There is no escape.
        Cassie.Message(LaunchMessage, false, true, true);
    }
}
