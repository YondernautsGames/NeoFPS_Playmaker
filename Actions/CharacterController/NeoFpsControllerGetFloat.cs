using HutongGames.PlayMaker;
using NeoFPS.CharacterMotion.Parameters;
using UnityEngine;

namespace NeoFPS.PlayMaker.Actions
{
    [ActionCategory("NeoFPS.CharacterController")]
    [HutongGames.PlayMaker.Tooltip("Gets the value of a float parameter")]
    public class NeoFpsControllerGetFloat : NeoFpsControllerParameterAction
    {
        [ActionSection("Results")]

        [RequiredField]
        [UIHint(UIHint.Variable)]
        [HutongGames.PlayMaker.Tooltip("The float value of the motion graph parameter")]
        public FsmFloat result;

        FloatParameter m_Parameter = null;

        public override void Reset()
        {
            base.Reset();
            
            result = null;
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
            result.Value = m_Parameter.value;
        }

#if UNITY_EDITOR
        public override string AutoName()
        {
            return ActionHelpers.AutoNameGetProperty(this, parameterKey, result);
        }
#endif

    }
}
