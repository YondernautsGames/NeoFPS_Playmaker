using HutongGames.PlayMaker;
using HutongGames.PlayMaker.Actions;
using UnityEngine;

namespace NeoFPS.PlayMaker.Actions
{
    [ActionCategory("NeoFPS.Health")]
    [HutongGames.PlayMaker.Tooltip("Gets the health of a NeoFPS character")]
    public class NeoFpsHealthGetHealth : NeoFpsHealthManagerAction
    {
        [ActionSection("Results")]

        [RequiredField]
        [UIHint(UIHint.Variable)]
        [HutongGames.PlayMaker.Tooltip("The int variable to store the health in")]
        public FsmInt result;

        public override void Reset()
        {
            base.Reset();
            result = null;
        }

        protected override void DoHealthManagerAction()
        {
            result.Value = Mathf.CeilToInt(healthManager.health - 0.0001f);
        }
    }
}
