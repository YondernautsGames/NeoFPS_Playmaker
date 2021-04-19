using HutongGames.PlayMaker;
using NeoFPS.Constants;
using UnityEngine;

namespace NeoFPS.PlayMaker.Actions
{
    [ActionCategory("NeoFPS.Input")]
    [HutongGames.PlayMaker.Tooltip("Sends an Event when a button is pressed.")]
    public class NeoFpsInputGetButtonDown : FsmStateAction
    {
        [RequiredField]
        [HutongGames.PlayMaker.Tooltip("The button to test.")]
        public FpsInputButton button;
        public FsmEvent sendEvent;
        [UIHint(UIHint.Variable)]
        public FsmBool storeResult;

        public override void Reset()
        {
            sendEvent = null;
            button = FpsInputButton.None;
            storeResult = null;
        }

        public override void OnUpdate()
        {
            bool buttonDown = FpsSettings.keyBindings.GetButtonDown(button);

            if (buttonDown)
                Fsm.Event(sendEvent);

            storeResult.Value = buttonDown;
        }
    }
}
