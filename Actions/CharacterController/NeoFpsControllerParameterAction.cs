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
    public abstract class NeoFpsControllerParameterAction : ComponentAction<MotionController>
    {
        [RequiredField]
        [CheckForComponent(typeof(MotionController))]
        [HutongGames.PlayMaker.Tooltip("The target. An Animator component is required")]
        public FsmOwnerDefault gameObject;

        [RequiredField]
        [UIHint(UIHint.AnimatorFloat)]
        [HutongGames.PlayMaker.Tooltip("The animator parameter")]
        public FsmString parameterKey;

        public bool everyFrame;

        protected MotionController motionController
        {
            get;
            private set;
        }

        private int m_Hash = -1;
        private bool m_Valid = false;

        public override void Reset()
        {
            base.Reset();

            gameObject = null;
            parameterKey = null;
        }

        public override void Awake()
        {
            base.Awake();

            // get hash from the param for efficiency:
            m_Hash = Animator.StringToHash(parameterKey.Value);
        }

        public override void OnEnter()
        {
            DoParameterActionInternal();
        }

        public override void OnUpdate()
        {
            DoParameterActionInternal();
        }

        void DoParameterActionInternal()
        {
            var go = Fsm.GetOwnerDefaultTarget(gameObject);
            if (!UpdateCache(go))
            {
                motionController = null;
                m_Valid = false;
                GetParameter(-1);
                Finish();
                return;
            }
            else
            {
                if (motionController != cachedComponent)
                {
                    motionController = cachedComponent;
                    if (motionController.motionGraph != null)
                        m_Valid = GetParameter(m_Hash);
                    else
                        m_Valid = false;
                }
            }

            if (m_Valid)
                DoParameterAction();

            if (!everyFrame)
                Finish();
        }

        protected abstract bool GetParameter(int hash);
        protected abstract void DoParameterAction();
    }
}
