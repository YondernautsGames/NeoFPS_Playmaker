using HutongGames.PlayMaker;
using NeoFPS.CharacterMotion.Parameters;
using UnityEngine;

namespace NeoFPS.PlayMaker.Actions
{
    [ActionCategory("NeoFPS.CharacterController")]
    [HutongGames.PlayMaker.Tooltip("Sets the value of a switch (bool) parameter")]
    public class NeoFpsControllerSetSwitch : NeoFpsControllerParameterAction
    {
        [RequiredField]
        [HutongGames.PlayMaker.Tooltip("The switch (bool) value to set in the motion graph parameter")]
        public FsmBool value;

        SwitchParameter m_Parameter = null;

        public override void Reset()
        {
            base.Reset();

            value = null;
        }

        protected override bool GetParameter(int hash)
        {
            m_Parameter = motionController.motionGraph.GetSwitchProperty(hash);
            return (m_Parameter != null);
        }

        protected override void DoParameterAction()
        {
            m_Parameter.on = value.Value;
        }

#if UNITY_EDITOR
        public override string AutoName()
        {
            return ActionHelpers.AutoNameGetProperty(this, parameterKey, value);
        }
#endif

    }
}



