# NeoFPS_Playmaker
Integration assets for using Playmaker with NeoFPS

It requires the assets [NeoFPS](https://assetstore.unity.com/packages/templates/systems/neofps-150179?aid=1011l58Ft) and [Playmaker](https://assetstore.unity.com/packages/tools/visual-scripting/playmaker-368?aid=1011l58Ft).

> [!WARNING]
> Do not place the integration folder inside the NeoFPS asset folder structure. If you do this then all of its scripts will be picked up by the NeoFPS assembly definition, which will limit what other scripts within the project they have access to. For more information on assembly definitions, see [the Unity Manual](https://docs.unity3d.com/Manual/ScriptCompilationAssemblyDefinitionFiles.html).

NB: This integration is under development. It is released as is because some elements are complete and usable.

Complete:
- Read and write motion graph parameters
- Read and write motion controller and NCC properties
- Read and write health manager properties
- Add & remove inventory items via playmaker FSM
- Take NeoFPS input
- Load a level
- Autosave or load from save
- Instantiate an NSGO
- Spawn a pooled object
- Watch common NeoFPS events (character change, player alive state change) and report

Pending:
- Spawn a character & spawn/attach player
- Interactive objects trigger an FSM
- Pickups trigger an FSM
- Trigger zones trigger an FSM
- Playmaker shooter module
- Trigger camera effects (kicker)
- Inventory actions
- Playmaker game mode
- Playmaker damage handler
- Health watcher (for non-player health managers)
- Inventory watcher

Feel free to make suggestions for other features on the [NeoFPS Discord](https://discord.neofps.com) 

The demo is also not fleshed out. It currently has a character with a number of playmaker FSMs attached, and a pistol that uses a playmaker ammo effect.
