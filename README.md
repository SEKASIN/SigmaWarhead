# SigmaWarhead

> ![sigmawp](https://github.com/TenDRILLL/SigmaWarhead/assets/32621403/0266a0b0-d7a6-4417-a482-af1f6db2a860)
>
> A  SCP: Secret Laboratory PluginAPI plugin that re-creates Auto-Nuke feature with a custom C.A.S.S.I.E. voiceline and configurable timer.

Just edit the config to your liking.

### Installation
## Installation
Download SigmaWarhead.dll from [Releases](/Releases).

Move SigmaWarhead.dll to .config/EXILED/Plugins and restart server.

## Configuration
Edit values in .config/EXILED/Configs/PORT-config.yml

Example config with default values:
```yml
sigma_warhead:
# Is the Plugin enabled.
  is_enabled: true
  # Debug mode.
  debug: true
  # C.A.S.S.I.E. voicelines.
  cassie_lines:
    launch: Automatic .G3 jam_020_5 Sigma .G1 Warhead has been activated by .G6 pitch_0.69 O5 pitch_1.00 . Time until jam_020_3 detonation is .G2 T minus 90 seconds .
  # Minutes since start of round to activate Sigma Warhead.
  activation_time: 20
```
* is_enabled
> A boolean; Controls if SigmaWarhead is enabled or not.
* debug
> A boolean; Enables some extra logging.
* cassie_lines
> A dictionary with strings; Custom Cassie voicelines. Is a dict if I later implement more.
* activation_time
> An int; Defines how many minutes since the start of round to starting of Sigma Warhead.
