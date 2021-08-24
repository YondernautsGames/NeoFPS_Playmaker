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
    [ActionCategory("NeoFPS (Health & Damage)")]
    [HutongGames.PlayMaker.Tooltip("Applies damage to a NeoFPS damage handler")]
    public class NeoFpsApplyDamage : ComponentAction<BasicDamageHandler>
    {
        [RequiredField]
        [CheckForComponent(typeof(BasicDamageHandler))]
        [HutongGames.PlayMaker.Tooltip("The target. A BasicDamageHandler component is required")]
        public FsmOwnerDefault gameObject;

        [RequiredField]
        [HutongGames.PlayMaker.Tooltip("The health value to apply based on the op")]
        public FsmInt value;

        //public bool everyFrame;

        private bool m_Valid = false;

        protected BasicDamageHandler damageHandler
        {
            get;
            private set;
        }

        public override void Reset()
        {
            base.Reset();

            gameObject = null;
        }

        public override void OnEnter()
        {
            InternalDoControllerAction();
        }

        public override void OnUpdate()
        {
            InternalDoControllerAction();
        }

        void InternalDoControllerAction()
        {
            var go = Fsm.GetOwnerDefaultTarget(gameObject);
            if (!UpdateCache(go))
            {
                damageHandler = null;
                m_Valid = false;
                Finish();
                return;
            }
            else
            {
                if (damageHandler != cachedComponent)
                {
                    damageHandler = cachedComponent;
                    m_Valid = true;
                }
            }

            if (m_Valid)
                DoDamageHandlerAction();

            //if (!everyFrame)
            //    Finish();
        }

        void DoDamageHandlerAction()
        {
            damageHandler.AddDamage(value.Value);
        }
    }
}
