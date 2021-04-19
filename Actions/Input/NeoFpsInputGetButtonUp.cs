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
using NeoFPS.Constants;
using UnityEngine;

namespace NeoFPS.PlayMaker.Actions
{
    [ActionCategory("NeoFPS.Input")]
    [HutongGames.PlayMaker.Tooltip("Sends an Event when a button is released.")]
    public class NeoFpsInputGetButtonUp : FsmStateAction
    {
        [RequiredField]
        [HutongGames.PlayMaker.Tooltip("The button to test.")]
        public FpsInputButton button;
        public FsmEvent sendEvent;
        [UIHint(UIHint.Variable)]
        public FsmBool storeResult;

        public override void Reset()
        {
            sendEvent = null;
            button = FpsInputButton.None;
            storeResult = null;
        }

        public override void OnUpdate()
        {
            bool buttonUp = FpsSettings.keyBindings.GetButtonUp(button);

            if (buttonUp)
                Fsm.Event(sendEvent);

            storeResult.Value = buttonUp;
        }
    }
}

