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
using HutongGames.PlayMaker;

namespace NeoFPS.PlayMaker
{
    [RequireComponent(typeof(IInteractiveObject))]
    [RequireComponent(typeof(PlayMakerFSM))]
    public class PlaymakerInteractiveObject : MonoBehaviour
    {
        [SerializeField, UnityEngine.Tooltip("[Required] The event name for the interactive object's onUsed event.")]
        private string m_OnPlayerCharacterChanged = "onUsed";
        [SerializeField, UnityEngine.Tooltip("[Optional] The variable name for the player character object variable in the PlayMaker FSM")]
        private string m_PlayerCharacterVariable = "playerCharacter";
		
        private PlayMakerFSM m_FSM = null;
        private FsmGameObject m_PlayerCharacter = null;
		
		void Awake()
		{
			// Get the FSM
            m_FSM = GetComponent<PlayMakerFSM>();
			
            // Get the character variable in the FSM
            if (!string.IsNullOrEmpty(m_PlayerCharacterVariable))
                m_PlayerCharacter = m_FSM.FsmVariables.FindFsmGameObject(m_PlayerCharacterVariable);
			
			// Attach to the interactive object event handler
			var interactiveObject = GetComponent<IInteractiveObject>();
			interactiveObject.onUsed += OnUsed;		
		}
		
		void OnUsed(ICharacter character)
		{
			// Set the player character variable
			if (m_PlayerCharacter != null)
				m_PlayerCharacter.Value = character.gameObject;
				
            // Send the onUsed event
            if (!string.IsNullOrEmpty(m_OnPlayerCharacterChanged))
                m_FSM.SendEvent(m_OnPlayerCharacterChanged);
		}
	}
}