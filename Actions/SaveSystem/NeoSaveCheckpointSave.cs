using HutongGames.PlayMaker;
using HutongGames.PlayMaker.Actions;
using NeoFPS.CharacterMotion;
using NeoSaveGames;
using UnityEngine;

namespace NeoFPS.PlayMaker.Actions
{
    [ActionCategory("NeoFPS.SaveGames")]
    [HutongGames.PlayMaker.Tooltip("Performs a checkpoint autosave")]
    public class NeoSaveCheckpointSave : FsmStateAction
    {
        [ActionSection("Results")]

        [UIHint(UIHint.Variable)]
        [HutongGames.PlayMaker.Tooltip("True if the checkpoint save succeeded, false if not")]
        public FsmBool result;

        public override void Reset()
        {
            base.Reset();
            
            result = null;
        }

        public override void OnEnter()
        {
            var saved = SaveGameManager.AutoSave();
            if (result != null)
                result.Value = saved;

            Finish();
        }
    }
}



