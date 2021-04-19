using HutongGames.PlayMaker;
using NeoFPS.CharacterMotion.Parameters;
using UnityEngine;

namespace NeoFPS.PlayMaker.Actions
{
    [ActionCategory("NeoFPS.CharacterController")]
    [HutongGames.PlayMaker.Tooltip("Sets the controller's capsule height")]
    public class NeoFpsControllerSetHeight : NeoFpsControllerAction
    {
        [RequiredField]
        [HutongGames.PlayMaker.Tooltip("The target controller height")]
        public FsmFloat value;

        public override void Reset()
        {
            base.Reset();

            value = null;
        }

        protected override void DoControllerAction()
        {
            motionController.characterController.height = value.Value;
        }

#if UNITY_EDITOR
        public override string AutoName()
        {
            return ActionHelpers.AutoName(this, value);
        }
#endif

    }
}



