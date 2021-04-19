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
using NeoSaveGames.SceneManagement;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace NeoFPS.PlayMaker.Actions
{
    [ActionCategory("NeoFPS.SceneManagement")]
    [HutongGames.PlayMaker.Tooltip("Spawns a pooled object based on a prefab")]
    public class NeoSceneManagerLoadScene : FsmStateAction
    {
        [HutongGames.PlayMaker.Tooltip("The reference options of the Scene")]
        public GetSceneActionBase.SceneSimpleReferenceOptions sceneReference;

        [HutongGames.PlayMaker.Tooltip("The name of the scene to load. The given sceneName can either be the last part of the path, without .unity extension or the full path still without the .unity extension")]
        public FsmString sceneByName;

        [HutongGames.PlayMaker.Tooltip("The index of the scene to load.")]
        public FsmInt sceneAtIndex;

        [HutongGames.PlayMaker.Tooltip("The reference options of the Scene")]
        public GetSceneActionBase.SceneSimpleReferenceOptions loadingSceneReference;

        [HutongGames.PlayMaker.Tooltip("The name of the scene to load. The given sceneName can either be the last part of the path, without .unity extension or the full path still without the .unity extension")]
        public FsmString loadingSceneName = new FsmString("Loading");

        [HutongGames.PlayMaker.Tooltip("The index of the scene to load.")]
        public FsmInt loadingSceneIndex = new FsmInt(1);

        [ActionSection("Result")]

        [HutongGames.PlayMaker.Tooltip("Event sent if the scene was loaded")]
        public FsmEvent successEvent;

        [HutongGames.PlayMaker.Tooltip("Event sent if a problem occurred, check log for information")]
        public FsmEvent failureEvent;


        public override void Reset()
        {
            sceneReference = GetSceneActionBase.SceneSimpleReferenceOptions.SceneAtIndex;
            sceneByName = null;
            sceneAtIndex = null;

            successEvent = null;
            failureEvent = null;
        }

        public override void OnEnter()
        {

            DoLoadScene();

            Finish();
        }

        void DoLoadScene()
        {
            if (sceneReference == GetSceneActionBase.SceneSimpleReferenceOptions.SceneAtIndex)
            {
                if (loadingSceneReference == GetSceneActionBase.SceneSimpleReferenceOptions.SceneAtIndex)
                    NeoSceneManager.LoadScene(sceneAtIndex.Value, loadingSceneIndex.Value, OnSceneLoaded);
                else
                    NeoSceneManager.LoadScene(sceneAtIndex.Value, loadingSceneName.Value, OnSceneLoaded);
            }
            else
            {
                if (loadingSceneReference == GetSceneActionBase.SceneSimpleReferenceOptions.SceneAtIndex)
                    NeoSceneManager.LoadScene(sceneByName.Value, loadingSceneIndex.Value, OnSceneLoaded);
                else
                    NeoSceneManager.LoadScene(sceneByName.Value, loadingSceneName.Value, OnSceneLoaded);
            }
        }

        void OnSceneLoaded()
        {
            // TODO: Success / Fail
            Fsm.Event(successEvent);
        }
    }
}



