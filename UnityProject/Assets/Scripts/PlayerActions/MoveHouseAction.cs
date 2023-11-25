using UnityEngine;
using UnityEngine.UIElements;

namespace PlayerActions
{
    public class MoveHouseAction : PlayerAction
    {
        public MoveHouseAction()
        {
            ButtonName = "Move the House";
        }
        public override void CalculateResult()
        {
            Debug.Log("Move House Action.");
            GameManager.Instance.FinishAction();
        }
    }
}
