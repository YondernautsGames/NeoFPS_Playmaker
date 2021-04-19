using HutongGames.PlayMaker;
using NeoFPS.CharacterMotion.Parameters;
using UnityEngine;

namespace NeoFPS.PlayMaker.Actions
{
    [ActionCategory("NeoFPS.CharacterController")]
    [HutongGames.PlayMaker.Tooltip("Checks if the controller is grounded")]
    public class NeoFpsControllerIsGrounded : NeoFpsControllerAction
    {
        [ActionSection("Results")]

        [RequiredField]
        [UIHint(UIHint.Variable)]
        [HutongGames.PlayMaker.Tooltip("Where to store the grounded check result")]
        public FsmBool result;

        public override void Reset()
        {
            base.Reset();

            result = null;
        }

        protected override void DoControllerAction()
        {
            result.Value = motionController.characterController.isGrounded;
        }

#if UNITY_EDITOR
        public override string AutoName()
        {
            return ActionHelpers.AutoName(this, result);
        }
#endif

    }
}



