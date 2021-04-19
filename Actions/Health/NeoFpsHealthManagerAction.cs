using HutongGames.PlayMaker;
using HutongGames.PlayMaker.Actions;
using NeoFPS.CharacterMotion;
using UnityEngine;

namespace NeoFPS.PlayMaker.Actions
{
    public abstract class NeoFpsHealthManagerAction : ComponentAction<BasicHealthManager>
    {
        [RequiredField]
        [CheckForComponent(typeof(BasicHealthManager))]
        [HutongGames.PlayMaker.Tooltip("The target. A BasicHealthManager component is required")]
        public FsmOwnerDefault gameObject;

        public bool everyFrame;

        private bool m_Valid = false;

        protected BasicHealthManager healthManager
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
                healthManager = null;
                m_Valid = false;
                Finish();
                return;
            }
            else
            {
                if (healthManager != cachedComponent)
                {
                    healthManager = cachedComponent;
                    m_Valid = true;
                }
            }

            if (m_Valid)
                DoHealthManagerAction();

            if (!everyFrame)
                Finish();
        }

        protected abstract void DoHealthManagerAction();
    }
}
