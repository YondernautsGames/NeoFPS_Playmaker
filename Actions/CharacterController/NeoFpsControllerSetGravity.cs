using HutongGames.PlayMaker;
using NeoFPS.CharacterMotion.Parameters;
using UnityEngine;

namespace NeoFPS.PlayMaker.Actions
{
    [ActionCategory("NeoFPS.CharacterController")]
    [HutongGames.PlayMaker.Tooltip("Sets the controller's gravity vector")]
    public class NeoFpsControllerSetGravity : NeoFpsControllerAction
    {
        [RequiredField]
        [HutongGames.PlayMaker.Tooltip("The target gravity vector")]
        public FsmVector3 value;

        public override void Reset()
        {
            base.Reset();

            value = null;
        }

        protected override void DoControllerAction()
        {
            if (motionController.characterController.characterGravity != null)
                motionController.characterController.characterGravity.gravity = value.Value;
        }

#if UNITY_EDITOR
        public override string AutoName()
        {
            return ActionHelpers.AutoName(this, value);
        }
#endif

    }
}




