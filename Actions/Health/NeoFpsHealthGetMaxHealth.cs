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
using UnityEngine;

namespace NeoFPS.PlayMaker.Actions
{
    [ActionCategory("NeoFPS (Health & Damage)")]
    [HutongGames.PlayMaker.Tooltip("Gets the max health of a NeoFPS character")]
    public class NeoFpsHealthGetMaxHealth : NeoFpsHealthManagerAction
    {
        [ActionSection("Results")]

        [RequiredField]
        [UIHint(UIHint.Variable)]
        [HutongGames.PlayMaker.Tooltip("The int variable to store the max health in")]
        public FsmInt result;

        public override void Reset()
        {
            base.Reset();
            result = null;
        }

        protected override void DoHealthManagerAction()
        {
            result.Value = Mathf.CeilToInt(healthManager.healthMax - 0.0001f);
        }
    }
}
