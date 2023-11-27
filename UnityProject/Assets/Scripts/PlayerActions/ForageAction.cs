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
            GameManager.Instance.playerResources.food += 2;
            GameManager.Instance.playerResources.water += 2;
            GameManager.Instance.FinishAction();
        }
    }
}