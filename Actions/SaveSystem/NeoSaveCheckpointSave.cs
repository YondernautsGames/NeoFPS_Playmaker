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

using HutongGames.PlayMaker;
using HutongGames.PlayMaker.Actions;
using NeoFPS.CharacterMotion;
using NeoSaveGames;
using UnityEngine;

namespace NeoFPS.PlayMaker.Actions
{
    [ActionCategory("NeoFPS (Save-Games)")]
    [HutongGames.PlayMaker.Tooltip("Performs a checkpoint autosave")]
    public class NeoSaveCheckpointSave : FsmStateAction
    {
        [ActionSection("Results")]

        [UIHint(UIHint.Variable)]
        [HutongGames.PlayMaker.Tooltip("True if the checkpoint save succeeded, false if not")]
        public FsmBool result;

        public override void Reset()
        {
            base.Reset();
            
            result = null;
        }

        public override void OnEnter()
        {
            var saved = SaveGameManager.AutoSave();
            if (result != null)
                result.Value = saved;

            Finish();
        }
    }
}



