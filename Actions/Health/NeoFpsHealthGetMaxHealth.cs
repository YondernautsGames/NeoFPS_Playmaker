using HutongGames.PlayMaker;
using HutongGames.PlayMaker.Actions;
using UnityEngine;

namespace NeoFPS.PlayMaker.Actions
{
    [ActionCategory("NeoFPS.Health")]
    [HutongGames.PlayMaker.Tooltip("Gets the max health of a NeoFPS character")]
    public class NeoFpsHealthGetMaxHealth : NeoFpsHealthManagerAction
    {
        [ActionSection("Results")]

        [RequiredField]
        [UIHint(UIHint.Variable)]
        [HutongGames.PlayMaker.Tooltip("The int variable to store the max health in")]
        public FsmInt result;

        public override void Reset()
        {
            base.Reset();
            result = null;
        }

        protected override void DoHealthManagerAction()
        {
            result.Value = Mathf.CeilToInt(healthManager.healthMax - 0.0001f);
        }
    }
}
