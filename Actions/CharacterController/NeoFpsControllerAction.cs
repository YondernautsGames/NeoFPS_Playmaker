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
