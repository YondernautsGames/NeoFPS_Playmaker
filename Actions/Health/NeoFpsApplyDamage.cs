using HutongGames.PlayMaker;
using HutongGames.PlayMaker.Actions;
using NeoFPS.CharacterMotion;
using UnityEngine;

namespace NeoFPS.PlayMaker.Actions
{
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
