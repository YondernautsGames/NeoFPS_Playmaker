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
using UnityEngine;

namespace NeoFPS.PlayMaker.Actions
{
    public abstract class NeoFpsInventoryAction : ComponentAction<FpsInventoryBase>
    {
        [RequiredField]
        [CheckForComponent(typeof(IInventory))]
        [HutongGames.PlayMaker.Tooltip("The target. An inventory component is required")]
        public FsmOwnerDefault gameObject;

        private bool m_Valid = false;

        public override void Reset()
        {
            base.Reset();

            gameObject = null;
        }

        public override void OnEnter()
        {
            FpsInventoryBase inventory = null;
			
            var go = Fsm.GetOwnerDefaultTarget(gameObject);
            if (!UpdateCache(go))
            {
                m_Valid = false;
                Finish();
                return;
            }
            else
            {
                if (inventory != cachedComponent)
                {
                    inventory = cachedComponent;
                    m_Valid = true;
                }
            }

            if (m_Valid)
                DoInventoryAction(inventory);
			
			Finish();
        }

        protected abstract void DoInventoryAction(FpsInventoryBase inventory);
    }
}
