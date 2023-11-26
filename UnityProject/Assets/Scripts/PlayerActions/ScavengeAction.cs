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

            GameManager.Instance.playerResources.wood += 2;
            GameManager.Instance.FinishAction();
        }
    }
}
