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
    private int TimeToDetonation;
    private bool DebugMode;
    private string CassieMessage;
    private Timer _launchTimer; //Minutes
    private Timer _detonationTimer; //Seconds
    
    [PluginEvent(ServerEventType.MapGenerated)]
    internal void OnGenerated()
    {
        TimeToLaunch = SigmaWarhead.Reference.Config.ActivationTime;
        TimeToDetonation = SigmaWarhead.Reference.Config.DetonationTime;
        DebugMode = SigmaWarhead.Reference.Config.Debug;
        CassieMessage = SigmaWarhead.Reference.Config.CassieLines.FirstOrDefault(x => x.Key == "launch").Value;
        
        _launchTimer = new Timer(TimeToLaunch * 1000 * 60);
        _launchTimer.Elapsed += LaunchSigmaWarhead;
        _launchTimer.AutoReset = false;
        _detonationTimer = new Timer(TimeToDetonation * 1000);
        _detonationTimer.Elapsed += DetonateSigmaWarhead;
        _detonationTimer.AutoReset = false;
    }

    [PluginEvent(ServerEventType.RoundStart)]
    internal void OnRoundStart()
    {
        _launchTimer.Enabled = true;
        if (DebugMode)
        {
            Log.Info("SigmaWarhead armed and will detonate in " + TimeToLaunch+ " minutes.");
        }
    }

    internal void LaunchSigmaWarhead(Object source, ElapsedEventArgs e)
    {
        Cassie.Message(CassieMessage);
        _detonationTimer.Enabled = true;
        if (DebugMode)
        {
            Log.Info("SigmaWarhead launched and will detonate in " + TimeToDetonation + " seconds.");
        }
    }

    internal void DetonateSigmaWarhead(Object source, ElapsedEventArgs e)
    {
        Cassie.Message("Sigma Warhead detonated");
        Warhead.Detonate();
    }
}