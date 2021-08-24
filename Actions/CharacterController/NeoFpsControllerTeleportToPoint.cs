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
using NeoFPS.CharacterMotion.Parameters;
using UnityEngine;

namespace NeoFPS.PlayMaker.Actions
{
    [ActionCategory("NeoFPS (CharacterController)")]
    [HutongGames.PlayMaker.Tooltip("Moves the character to a new position and rotation, and resets interpolation")]
    public class NeoFpsControllerTeleportToPoint : NeoFpsControllerAction
    {
        [RequiredField]
        [HutongGames.PlayMaker.Tooltip("The target teleport position")]
        public FsmVector3 position;

        [RequiredField]
        [HutongGames.PlayMaker.Tooltip("The target teleport rotation")]
        public FsmQuaternion rotation;

        public override void Reset()
        {
            base.Reset();

            position = null;
            rotation = null;
        }

        protected override void DoControllerAction()
        {
            motionController.characterController.Teleport(position.Value, rotation.Value, false);
        }

#if UNITY_EDITOR
        public override string AutoName()
        {
            return ActionHelpers.AutoName(this, position, rotation);
        }
#endif
    }
}




