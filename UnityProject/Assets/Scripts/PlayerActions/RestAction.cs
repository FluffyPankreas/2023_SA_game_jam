using UnityEngine;

namespace PlayerActions
{
    public class RestAction : PlayerAction
    {
        public RestAction()
        {
            ButtonName = "Rest";
        }
        public override void CalculateResult()
        {
            Debug.Log("Rest Action.");
            GameManager.Instance.playerAttributes.houseStamina += 4;
            GameManager.Instance.FinishAction();
        }
    }
}
