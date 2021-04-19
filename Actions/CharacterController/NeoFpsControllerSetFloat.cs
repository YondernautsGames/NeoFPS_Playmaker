using HutongGames.PlayMaker;
using NeoFPS.CharacterMotion.Parameters;
using UnityEngine;

namespace NeoFPS.PlayMaker.Actions
{
    [ActionCategory("NeoFPS.CharacterController")]
    [HutongGames.PlayMaker.Tooltip("Sets the value of a float parameter")]
    public class NeoFpsControllerSetFloat : NeoFpsControllerParameterAction
    {
        [RequiredField]
        [HutongGames.PlayMaker.Tooltip("The float value to set in the motion graph parameter")]
        public FsmFloat value;

        FloatParameter m_Parameter = null;

        public override void Reset()
        {
            base.Reset();

            value = null;
        }

        protected override bool GetParameter(int hash)
        {
            if (hash == -1)
                m_Parameter = null;
            else
                m_Parameter = motionController.motionGraph.GetFloatProperty(hash);

            return (m_Parameter != null);
        }

        protected override void DoParameterAction()
        {
            m_Parameter.value = value.Value;
        }

#if UNITY_EDITOR
        public override string AutoName()
        {
            return ActionHelpers.AutoNameGetProperty(this, parameterKey, value);
        }
#endif

    }
}
