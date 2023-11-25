using UnityEngine;

namespace PlayerActions
{
    public class ForageAction : PlayerAction
    {
        public ForageAction()
        {
            ButtonName = "Forage for Food";
        }

        public override void CalculateResult()
        {
            Debug.Log("Forage Action.");
        }
    }
}
