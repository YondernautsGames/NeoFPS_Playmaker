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
    [ActionCategory("NeoFPS (Input)")]
    [HutongGames.PlayMaker.Tooltip("Gets the pressed state of a button.")]
    public class NeoFpsInputGetButton : FsmStateAction
    {
        [RequiredField]
        [HutongGames.PlayMaker.Tooltip("The button to test.")]
        public FpsInputButton button;

        [RequiredField]
        [UIHint(UIHint.Variable)]
        [HutongGames.PlayMaker.Tooltip("Store if the button is down (True) or up (False).")]
        public FsmBool storeResult;

        [HutongGames.PlayMaker.Tooltip("Repeat every frame. Useful if you're waiting for a button press/release.")]
        public bool everyFrame;

        public override void Reset()
        {
            button = FpsInputButton.None;
            storeResult = null;
            everyFrame = false;
        }

        public override void OnEnter()
        {
            DoGetKey();

            if (!everyFrame)
                Finish();
        }

        public override void OnUpdate()
        {
            DoGetKey();
        }

        void DoGetKey()
        {
            storeResult.Value = FpsSettings.keyBindings.GetButton(button);
        }

    }
}
