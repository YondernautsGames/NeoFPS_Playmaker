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
    [ActionCategory("NeoFPS (Inventory)")]
    [HutongGames.PlayMaker.Tooltip("Adds an inventory item to the player character's inventory")]
    public class NeoFpsInventoryAddItem : NeoFpsInventoryAction
    {
        [RequiredField]
        [CheckForComponent(typeof(FpsInventoryItemBase)), HutongGames.PlayMaker.Tooltip("The health value to apply based on the op")]
        public FsmGameObject itemPrefab;

        public override void Reset()
        {
            base.Reset();
            itemPrefab = null;
        }

        protected override void DoInventoryAction(FpsInventoryBase inventory)
        {
            var prefab = itemPrefab.Value;
            if (prefab != null)
                inventory.AddItemFromPrefab(prefab);
        }
    }
}
