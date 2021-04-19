using HutongGames.PlayMaker;
using HutongGames.PlayMaker.Actions;
using NeoFPS.CharacterMotion;
using UnityEngine;

namespace NeoFPS.PlayMaker.Actions
{
    [ActionCategory("NeoFPS.Pooling")]
    [HutongGames.PlayMaker.Tooltip("Recycles a pooled object")]
    public class NeoFpsPoolingRecycleObject : ComponentAction<PooledObject>
    {
        [RequiredField]
        [CheckForComponent(typeof(PooledObject))]
        [HutongGames.PlayMaker.Tooltip("The pooled object to recycle. A PooledObject component is required")]
        public FsmOwnerDefault gameObject;
        
        public override void Reset()
        {
            base.Reset();

            gameObject = null;
        }

        public override void OnEnter()
        {
            RecycleObject();
        }

        //public override void OnUpdate()
        //{
        //    RecycleObject();
        //}

        void RecycleObject()
        {
            var go = Fsm.GetOwnerDefaultTarget(gameObject);
            if (!UpdateCache(go))
            {
                Finish();
                return;
            }
            
            cachedComponent.ReturnToPool();

            Finish();
        }
    }
}

