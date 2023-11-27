using UnityEngine;

namespace PlayerActions
{
    public class ScavengeAction : PlayerAction
    {
        public ScavengeAction()
        {
            ButtonName = "Look for Wood";
        }
        public override void CalculateResult()
        {
            int woodToAdd = 0;
            woodToAdd++; // From using the action.
            if (GameManager.Instance.gameProperties.currentTile.Biome == Biomes.Forest)
            {
                int forestWood = Random.Range(2, 4);
                woodToAdd+= forestWood;
            }
            
            GameManager.Instance.playerResources.wood += woodToAdd;
            GameManager.Instance.FinishAction();
        }
    }
}
