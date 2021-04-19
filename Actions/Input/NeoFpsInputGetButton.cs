using HutongGames.PlayMaker;
using NeoFPS.Constants;
using UnityEngine;

namespace NeoFPS.PlayMaker.Actions
{
    [ActionCategory("NeoFPS.Input")]
    [HutongGames.PlayMaker.Tooltip("Gets the pressed state of a button.")]
    public class NeoFpsInputGetButton : FsmStateAction
    {
        [RequiredField]
        [HutongGames.PlayMaker.Tooltip("The button to test.")]
        public FpsInputButton button;

        [RequiredField]
        [UIHint(UIHint.Variable)]
        [HutongGames.PlayMaker.Tooltip("Store if the button is down (True) or up (False).")]
        public FsmBool storeResult;

        [HutongGames.PlayMaker.Tooltip("Repeat every frame. Useful if you're waiting for a button press/release.")]
        public bool everyFrame;

        public override void Reset()
        {
            button = FpsInputButton.None;
            storeResult = null;
            everyFrame = false;
        }

        public override void OnEnter()
        {
            DoGetKey();

            if (!everyFrame)
                Finish();
        }

        public override void OnUpdate()
        {
            DoGetKey();
        }

        void DoGetKey()
        {
            storeResult.Value = FpsSettings.keyBindings.GetButton(button);
        }

    }
}
