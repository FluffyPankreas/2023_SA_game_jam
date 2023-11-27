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
            GameManager.Instance.playerResources.wood += 2;
            GameManager.Instance.FinishAction();
        }
    }
}
