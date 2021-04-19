/*
* Copyright 2020 Yondernauts Game Studios Ltd
*
* Licensed under the Apache License, Version 2.0 (the "License");
* you may not use this file except in compliance with the License.
* You may obtain a copy of the License at
*
*       http://www.apache.org/licenses/LICENSE-2.0
*
* Unless required by applicable law or agreed to in writing, software
* distributed under the License is distributed on an "AS IS" BASIS,
* WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
* See the License for the specific language governing permissions and
* limitations under the License.
*/

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