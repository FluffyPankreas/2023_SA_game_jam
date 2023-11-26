using UnityEngine;

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
            GameManager.Instance.gameProperties.GenerateNewTile();
            GameManager.Instance.gameProperties.playerTileIndex++;
            GameManager.Instance.playerAttributes.houseStamina -=
            GameManager.Instance.gameProperties.currentTile.StaminaCost;
            GameManager.Instance.FinishAction();
        }
    }
}
