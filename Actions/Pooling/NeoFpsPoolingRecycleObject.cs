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
    [ActionCategory("NeoFPS (Pooling)")]
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

