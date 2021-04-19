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
    public abstract class NeoFpsControllerAction : ComponentAction<MotionController>
    {
        [RequiredField]
        [CheckForComponent(typeof(MotionController))]
        [HutongGames.PlayMaker.Tooltip("The target. An Animator component is required")]
        public FsmOwnerDefault gameObject;

        public bool everyFrame;

        protected MotionController motionController
        {
            get;
            private set;
        }

        private bool m_Valid = false;

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
                motionController = null;
                m_Valid = false;
                Finish();
                return;
            }
            else
            {
                if (motionController != cachedComponent)
                {
                    motionController = cachedComponent;
                    m_Valid = true;
                }
            }

            if (m_Valid)
                DoControllerAction();

            if (!everyFrame)
                Finish();
        }
        
        protected abstract void DoControllerAction();
    }
}
