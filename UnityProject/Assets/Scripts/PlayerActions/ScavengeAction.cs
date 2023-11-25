using UnityEngine;

namespace PlayerActions
{
    public class ScavengeAction : PlayerAction
    {
        public ScavengeAction()
        {
            ButtonName = "Scavenge for Resources";
        }
        public override void CalculateResult()
        {
            Debug.Log("Scavenge Action.");

            var d10 = Random.Range(1, 10);
            switch (d10)
            {
                case (9):
                    GameManager.Instance.playerResources.food += 1;
                    break;

                case (8):
                    GameManager.Instance.playerResources.water += 1;
                    break;
                default:
                    GameManager.Instance.playerResources.wood += Random.Range(1, 10);
                    break;
            }
            
            GameManager.Instance.FinishAction();
        }
    }
}
