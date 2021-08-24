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
using NeoSaveGames;
using NeoSaveGames.Serialization;
using UnityEngine;

namespace NeoFPS.PlayMaker.Actions
{
    [ActionCategory("NeoFPS (Save-Games)")]
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




