using HutongGames.PlayMaker;
using NeoFPS.CharacterMotion.Parameters;
using UnityEngine;

namespace NeoFPS.PlayMaker.Actions
{
    [ActionCategory("NeoFPS.CharacterController")]
    [HutongGames.PlayMaker.Tooltip("Sets the value of a switch (bool) parameter")]
    public class NeoFpsControllerSetTransform : NeoFpsControllerParameterAction
    {
        [RequiredField]
        [HutongGames.PlayMaker.Tooltip("The gameobject of the transform value to set in the motion graph parameter")]
        public FsmGameObject value;

        TransformParameter m_Parameter = null;

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
                m_Parameter = motionController.motionGraph.GetTransformProperty(hash);

            return (m_Parameter != null);
        }

        protected override void DoParameterAction()
        {
            if (value.Value == null)
                m_Parameter.value = null;
            else
                m_Parameter.value = value.Value.transform;
        }

#if UNITY_EDITOR
        public override string AutoName()
        {
            return ActionHelpers.AutoNameGetProperty(this, parameterKey, value);
        }
#endif

    }
}



