using HutongGames.PlayMaker;
using HutongGames.PlayMaker.Actions;
using UnityEngine;

namespace NeoFPS.PlayMaker.Actions
{
    [ActionCategory("NeoFPS.Health")]
    [HutongGames.PlayMaker.Tooltip("Gets the health of a NeoFPS character")]
    public class NeoFpsHealthModifyHealth : NeoFpsHealthManagerAction
    {
        public HealthOp operation;

        [RequiredField]
        [HutongGames.PlayMaker.Tooltip("The health value to apply based on the op")]
        public FsmInt value;

        public enum HealthOp
        {
            Add,
            Subtract,
            Set
        }

        public override void Reset()
        {
            base.Reset();
            value = null;
        }

        protected override void DoHealthManagerAction()
        {
            switch (operation)
            {
                case HealthOp.Add:
                    healthManager.health += value.Value;
                    break;
                case HealthOp.Subtract:
                    healthManager.health -= value.Value;
                    break;
                case HealthOp.Set:
                    healthManager.health = value.Value;
                    break;
            }
        }
    }
}

