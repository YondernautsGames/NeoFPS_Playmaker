using HutongGames.PlayMaker;
using NeoFPS.CharacterMotion.Parameters;
using UnityEngine;

namespace NeoFPS.PlayMaker.Actions
{
    [ActionCategory("NeoFPS.CharacterController")]
    [HutongGames.PlayMaker.Tooltip("Sets the value of an int parameter")]
    public class NeoFpsControllerSetVector : NeoFpsControllerParameterAction
    {
        [RequiredField]
        [HutongGames.PlayMaker.Tooltip("The vector value to set in the motion graph parameter")]
        public FsmVector3 value;

        VectorParameter m_Parameter = null;

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
                m_Parameter = motionController.motionGraph.GetVectorProperty(hash);

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

