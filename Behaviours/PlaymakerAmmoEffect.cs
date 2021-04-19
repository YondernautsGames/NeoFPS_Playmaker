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

using UnityEngine;
using NeoFPS.ModularFirearms;
using HutongGames.PlayMaker;

namespace NeoFPS.PlayMaker
{
    [RequireComponent(typeof(PlayMakerFSM))]
    public class PlaymakerAmmoEffect : BaseAmmoEffect
    {
        [SerializeField, UnityEngine.Tooltip("The event name for the on-hit event in the PlayMaker FSM")]
        private string m_OnHitEvent = "onHit";
        [SerializeField, UnityEngine.Tooltip("The variable name for the hit object variable in the PlayMaker FSM")]
        private string m_HitObjectVariable = "hitObject";
        [SerializeField, UnityEngine.Tooltip("The variable name for the ray direction variable in the PlayMaker FSM")]
        private string m_RayDirectionVariable = "rayDirection";
        [SerializeField, UnityEngine.Tooltip("The variable name for the hit point variable in the PlayMaker FSM")]
        private string m_HitPointVariable = "hitPoint";
        [SerializeField, UnityEngine.Tooltip("The variable name for the hit normal variable in the PlayMaker FSM")]
        private string m_HitNormalVariable = "hitNormal";
        [SerializeField, UnityEngine.Tooltip("The variable name for the source object (the character that fired the shot) variable in the PlayMaker FSM")]
        private string m_SourceObjectVariable = "sourceObject";

        private PlayMakerFSM m_FSM = null;
        private FsmGameObject m_HitObject = null;
        private FsmGameObject m_SourceObject = null;
        private FsmVector3 m_HitPoint = null;
        private FsmVector3 m_HitNormal = null;
        private FsmVector3 m_RayDirection = null;
        
        void Awake()
        {
            m_FSM = GetComponent<PlayMakerFSM>();
        }

        void Start()
        {
            // Get the relevant variables in the FSM
            if (!string.IsNullOrEmpty(m_HitObjectVariable))
                m_HitObject = m_FSM.FsmVariables.FindFsmGameObject(m_HitObjectVariable);
            if (!string.IsNullOrEmpty(m_SourceObjectVariable))
                m_SourceObject = m_FSM.FsmVariables.FindFsmGameObject(m_SourceObjectVariable);
            if (!string.IsNullOrEmpty(m_HitPointVariable))
                m_HitPoint = m_FSM.FsmVariables.FindFsmVector3(m_HitPointVariable);
            if (!string.IsNullOrEmpty(m_HitNormalVariable))
                m_HitNormal = m_FSM.FsmVariables.FindFsmVector3(m_HitNormalVariable);
            if (!string.IsNullOrEmpty(m_RayDirectionVariable))
                m_RayDirection = m_FSM.FsmVariables.FindFsmVector3(m_RayDirectionVariable);
        }

        public override void Hit(RaycastHit hit, Vector3 rayDirection, float totalDistance, float speed, IDamageSource damageSource)
        {
            // Record the hit object in a variable in the PlayMaker FSM
            if (m_HitObject != null)
                m_HitObject.Value = hit.collider.gameObject;

            // Record the hit point in a variable in the PlayMaker FSM
            if (m_HitPoint != null)
                m_HitPoint.Value = hit.point;

            // Record the hit point in a variable in the PlayMaker FSM
            if (m_HitNormal != null)
                m_HitNormal.Value = hit.normal;

            // Record the ray direction in a variable in the PlayMaker FSM
            if (m_RayDirection != null)
                m_RayDirection.Value = rayDirection;

            // Record the damage source object in a variable in the PlayMaker FSM
            if (m_SourceObject != null)
                m_SourceObject.Value = damageSource.controller.currentCharacter.gameObject;

            // Send the on-hit event
            m_FSM.SendEvent(m_OnHitEvent);
        }
    }
}