using HutongGames.PlayMaker;
using NeoFPS.CharacterMotion.Parameters;
using UnityEngine;

namespace NeoFPS.PlayMaker.Actions
{
    [ActionCategory("NeoFPS.CharacterController")]
    [HutongGames.PlayMaker.Tooltip("Sets a trigger parameter")]
    public class NeoFpsControllerSetTrigger : NeoFpsControllerParameterAction
    {
        TriggerParameter m_Parameter = null;
        
        protected override bool GetParameter(int hash)
        {
            if (hash == -1)
                m_Parameter = null;
            else
                m_Parameter = motionController.motionGraph.GetTriggerProperty(hash);

            return (m_Parameter != null);
        }

        protected override void DoParameterAction()
        {
            m_Parameter.Trigger();
        }

#if UNITY_EDITOR
        public override string AutoName()
        {
            return ActionHelpers.AutoName(this, parameterKey);
        }
#endif
    }
}




