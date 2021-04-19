using HutongGames.PlayMaker;
using NeoFPS.CharacterMotion.Parameters;
using UnityEngine;

namespace NeoFPS.PlayMaker.Actions
{
    [ActionCategory("NeoFPS.CharacterController")]
    [HutongGames.PlayMaker.Tooltip("Gets the controller's gravity vector")]
    public class NeoFpsControllerGetGravity : NeoFpsControllerAction
    {
        [ActionSection("Results")]

        [RequiredField]
        [UIHint(UIHint.Variable)]
        [HutongGames.PlayMaker.Tooltip("Where to store the controller gravity")]
        public FsmVector3 result;
        
        public override void Reset()
        {
            base.Reset();

            result = null;
        }
        
        protected override void DoControllerAction()
        {
            result.Value = motionController.characterController.gravity;
        }

#if UNITY_EDITOR
        public override string AutoName()
        {
            return ActionHelpers.AutoName(this, result);
        }
#endif

    }
}

