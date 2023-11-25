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
            GameManager.Instance.playerResources.food += Random.Range(5, 10);
            GameManager.Instance.playerResources.water += Random.Range(0, 5);
            GameManager.Instance.FinishAction();
        }
    }
}