using System.Collections;
using System.Collections.Generic;
using NeoFPS.SinglePlayer;
using UnityEngine;

namespace NeoFPS.PlayMaker
{
    public class PlaymakerGameMode : FpsSoloGameMinimal
    {
        // TODO: PlaymakerGameMode

        // On Start

        // Was Save

        // Was Persistent Data

        protected override void OnPlayerCharacterIsAliveChanged(ICharacter character, bool alive)
        {
            if (inGame && !alive)
            {
                //IController player = character.controller;
                //StartCoroutine(DelayedDeathReactionCoroutine(player));
            }
        }

        protected override void OnPlayerCharacterChanged(ICharacter character)
        {
            // Keep base
            base.OnPlayerCharacterChanged(character);
        }
    }
}