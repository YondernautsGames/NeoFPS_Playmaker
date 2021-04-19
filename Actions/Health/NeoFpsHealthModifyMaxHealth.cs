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
    [ActionCategory("NeoFPS.Health")]
    [HutongGames.PlayMaker.Tooltip("Gets the health of a NeoFPS character")]
    public class NeoFpsHealthModifyMaxHealth : NeoFpsHealthManagerAction
    {
        public HealthOp operation;

        [RequiredField]
        [HutongGames.PlayMaker.Tooltip("The value to apply to max health based on the op")]
        public FsmInt value;

        public enum HealthOp
        {
            Add,
            Subtract,
            Set
        }

        public override void Reset()
        {
            base.Reset();
            value = null;
        }

        protected override void DoHealthManagerAction()
        {
            switch (operation)
            {
                case HealthOp.Add:
                    healthManager.healthMax += value.Value;
                    break;
                case HealthOp.Subtract:
                    healthManager.healthMax -= value.Value;
                    break;
                case HealthOp.Set:
                    healthManager.healthMax = value.Value;
                    break;
            }
        }
    }
}

