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
            GameManager.Instance.AddFood(Random.Range(5, 10));
            GameManager.Instance.AddWater(Random.Range(0, 5));
        }
    }
}
