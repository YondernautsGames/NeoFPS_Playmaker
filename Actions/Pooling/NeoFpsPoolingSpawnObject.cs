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
    [ActionCategory("NeoFPS.Pooling")]
    [HutongGames.PlayMaker.Tooltip("Spawns a pooled object based on a prefab")]
    public class NeoFpsPoolingSpawnObject : FsmStateAction
    {
        [RequiredField]
        [CheckForComponent(typeof(PooledObject))]
        [HutongGames.PlayMaker.Tooltip("The pooled object to spawn. This should be a prefab with a PooledObject component")]
        public FsmGameObject prefab;

        [HutongGames.PlayMaker.Tooltip("The postion to spawn the object")]
        public FsmVector3 spawnPosition;

        [HutongGames.PlayMaker.Tooltip("The rotation to spawn the object")]
        public FsmQuaternion spawnRotation;

        [HutongGames.PlayMaker.Tooltip("Should the spawned object be activated immediately")]
        public FsmBool activateOnSpawn;

        [ActionSection("Results")]

        [UIHint(UIHint.Variable)]
        [HutongGames.PlayMaker.Tooltip("The pooled object to recycle. A PooledObject component is required")]
        public FsmObject result;

        public override void Reset()
        {
            base.Reset();

            prefab = null;
            result = null;
        }

        public override void OnEnter()
        {
            SpawnObject();
        }

        //public override void OnUpdate()
        //{
        //    RecycleObject();
        //}

        void SpawnObject()
        {
            if (prefab.Value != null)
            {
                var prefabObj = prefab.Value.GetComponent<PooledObject>();
                if (prefabObj != null)
                {
                    var spawned = PoolManager.GetPooledObject<PooledObject>(prefabObj, spawnPosition.Value, spawnRotation.Value, activateOnSpawn.Value).gameObject;
                    if (result != null)
                        result.Value = spawned;
                }
            }

            Finish();
        }
    }
}


