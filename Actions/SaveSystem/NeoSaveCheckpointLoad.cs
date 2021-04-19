using HutongGames.PlayMaker;
using HutongGames.PlayMaker.Actions;
using NeoFPS.CharacterMotion;
using NeoSaveGames;
using UnityEngine;

namespace NeoFPS.PlayMaker.Actions
{
    [ActionCategory("NeoFPS.SaveGames")]
    [HutongGames.PlayMaker.Tooltip("Performs a checkpoint load")]
    public class NeoSaveCheckpointLoad : FsmStateAction
    {
        [ActionSection("Results")]

        [UIHint(UIHint.Variable)]
        [HutongGames.PlayMaker.Tooltip("True if the checkpoint load succeeded, false if not")]
        public FsmBool result;

        public enum LoadType
        {
            AutoLoad,
            Continue
        }

        public override void Reset()
        {
            base.Reset();

            result = null;
        }

        public override void OnEnter()
        {
            var loaded = SaveGameManager.Continue();
            if (result != null)
                result.Value = loaded;

            Finish();
        }
    }
}




