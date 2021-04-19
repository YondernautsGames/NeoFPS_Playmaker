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
using NeoFPS.SinglePlayer;
using System;

namespace NeoFPS.PlayMaker
{
    [RequireComponent(typeof(PlayMakerFSM))]
    public class PlaymakerNeoFpsEventWatcher : MonoBehaviour
    {
        [SerializeField, UnityEngine.Tooltip("The event name for the player character change event in the PlayMaker FSM")]
        private string m_OnPlayerCharacterChanged = "onPlayerCharacterChanged";
        [SerializeField, UnityEngine.Tooltip("The variable name for the player character object variable in the PlayMaker FSM")]
        private string m_PlayerCharacterVariable = "playerCharacter";
        [SerializeField, UnityEngine.Tooltip("The variable name for the player inventory object variable in the PlayMaker FSM")]
        private string m_PlayerInventoryVariable = "playerInventory";
        [SerializeField, UnityEngine.Tooltip("The variable name for the player health manager object variable in the PlayMaker FSM")]
        private string m_PlayerHealthManagerVariable = "playerHealthManager";

        [SerializeField, UnityEngine.Tooltip("The event name for the player character alive change event in the PlayMaker FSM")]
        private string m_OnPlayerIsAliveChanged = "onPlayerIsAliveChanged";
        [SerializeField, UnityEngine.Tooltip("The variable name for the player character is alive variable in the PlayMaker FSM")]
        private string m_PlayerIsAliveVariable = "playerIsAlive";

        private PlayMakerFSM m_FSM = null;
        private FsmGameObject m_PlayerCharacter = null;
        private FsmGameObject m_PlayerInventory = null;
        private FsmGameObject m_PlayerHealthManager = null;
        private FsmBool m_PlayerIsAlive = null;
        private FpsSoloCharacter m_Character = null;

        void Awake()
        {
            m_FSM = GetComponent<PlayMakerFSM>();
        }

        void Start()
        {
            // Get the relevant variables in the FSM
            if (!string.IsNullOrEmpty(m_PlayerCharacterVariable))
                m_PlayerCharacter = m_FSM.FsmVariables.FindFsmGameObject(m_PlayerCharacterVariable);
            if (!string.IsNullOrEmpty(m_PlayerInventoryVariable))
                m_PlayerInventory = m_FSM.FsmVariables.FindFsmGameObject(m_PlayerInventoryVariable);
            if (!string.IsNullOrEmpty(m_PlayerHealthManagerVariable))
                m_PlayerHealthManager = m_FSM.FsmVariables.FindFsmGameObject(m_PlayerHealthManagerVariable);

            //if (!string.IsNullOrEmpty(m_OnPlayerIsAliveChanged))
            //    m_PlayerIsAlive = m_FSM.FsmEvents.(m_PlayerIsAliveVariable);
            if (!string.IsNullOrEmpty(m_PlayerIsAliveVariable))
                m_PlayerIsAlive = m_FSM.FsmVariables.FindFsmBool(m_PlayerIsAliveVariable);

            FpsSoloCharacter.onLocalPlayerCharacterChange += OnLocalPlayerCharacterChange;
            OnLocalPlayerCharacterChange(FpsSoloCharacter.localPlayerCharacter);
        }

        void OnLocalPlayerCharacterChange(FpsSoloCharacter character)
        {
            if (m_Character != null)
                m_Character.onIsAliveChanged -= OnCharacterIsAliveChanged;

            m_Character = character;
            if (character != null)
            {
                // Set the player character variable
                if (m_PlayerCharacter != null)
                    m_PlayerCharacter.Value = character.gameObject;

                // Set the player inventory variable
                if (m_PlayerInventory != null)
                {
                    var inventory = character.inventory as MonoBehaviour;
                    if (inventory != null)
                        m_PlayerInventory.Value = inventory.gameObject;
                    else
                        m_PlayerInventory.Value = null;
                }

                // Set the player health manager variable
                if (m_PlayerHealthManager != null)
                {
                    var healthManager = character.healthManager as MonoBehaviour;
                    if (healthManager != null)
                    {
                        m_PlayerHealthManager.Value = healthManager.gameObject;
                    }
                    else
                        m_PlayerHealthManager.Value = null;
                }

                // Add the character alive event handler
                character.onIsAliveChanged += OnCharacterIsAliveChanged;
                OnCharacterIsAliveChanged(character, character.isAlive);
            }
            else
            {
                // Null variable values
                if (m_PlayerCharacter != null)
                    m_PlayerCharacter.Value = null;
                if (m_PlayerInventory != null)
                    m_PlayerInventory.Value = null;
                if (m_PlayerHealthManager != null)
                    m_PlayerHealthManager.Value = null;
            }

            // Send the character change event
            if (!string.IsNullOrEmpty(m_OnPlayerCharacterChanged))
                m_FSM.SendEvent(m_OnPlayerCharacterChanged);
        }

        private void OnCharacterIsAliveChanged(ICharacter character, bool alive)
        {
            // Assign value
            if (m_PlayerIsAlive != null)
                m_PlayerIsAlive.Value = alive;

            // Send the is alive event
            if (!string.IsNullOrEmpty(m_OnPlayerIsAliveChanged))
                m_FSM.SendEvent(m_OnPlayerIsAliveChanged);
        }
    }
}