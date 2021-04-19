using HutongGames.PlayMaker;
using HutongGames.PlayMaker.Actions;
using NeoFPS.CharacterMotion;
using NeoSaveGames;
using NeoSaveGames.Serialization;
using UnityEngine;

namespace NeoFPS.PlayMaker.Actions
{
    [ActionCategory("NeoFPS.SaveGames")]
    [HutongGames.PlayMaker.Tooltip("Performs a checkpoint load")]
    public class NeoSaveInstantiate : ComponentAction<NeoSerializedGameObject>
    {
        [RequiredField]
        [CheckForComponent(typeof(BasicHealthManager))]
        [HutongGames.PlayMaker.Tooltip("The target. A BasicHealthManager component is required")]
        public FsmOwnerDefault gameObject;

        [RequiredField]
        [CheckForComponent(typeof(NeoSerializedGameObject))]
        [HutongGames.PlayMaker.Tooltip("The prefab to instantiate. Requires a NeoSerializedGameObject component.")]
        public FsmGameObject prefab;

        [ActionSection("Results")]

        [UIHint(UIHint.Variable)]
        [HutongGames.PlayMaker.Tooltip("The pooled object to recycle. A PooledObject component is required")]
        public FsmObject result;

        public override void Reset()
        {
            base.Reset();

            gameObject = null;
            prefab = null;
            result = null;
        }

        public override void OnEnter()
        {
            var go = Fsm.GetOwnerDefaultTarget(gameObject);
            if (!UpdateCache(go))
            {
                Finish();
                return;
            }
            else
            {
                if (prefab != null)
                {
                    var prefabNSGO = prefab.Value.GetComponent<NeoSerializedGameObject>();
                    var instantiated = cachedComponent.InstantiatePrefab(prefabNSGO);

                    if (result != null)
                        result.Value = instantiated;
                }
            }

            Finish();
        }
    }
}




