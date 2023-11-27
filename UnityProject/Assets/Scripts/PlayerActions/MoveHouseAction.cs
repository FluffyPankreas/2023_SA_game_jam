using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.Windows.WebCam;

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
            GameManager.Instance.gameProperties.GenerateNewTile();
            GameManager.Instance.tileManager.CreateTile(GameManager.Instance.gameProperties.GenerateNewTile());
            GameManager.Instance.gameProperties.playerTileIndex++;
            GameManager.Instance.playerResources.wood -= GameManager.Instance.gameProperties.currentTile.TravelCost;
            GameManager.Instance.playerResources.water -= 1;
            AnimateHouse();
            GameManager.Instance.FinishAction();
            
        }

        private async void AnimateHouse()
        {
            GameManager.Instance.houseAnimator.SetBool("Walking",true);
            await Task.Delay(1750);
            GameManager.Instance.houseAnimator.SetBool("Walking",false);
        }
    }
}
