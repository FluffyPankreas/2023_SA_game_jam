using UnityEngine;

namespace PlayerActions
{
    /// <summary>
    /// Base class for player actions.
    /// </summary>
    public abstract class PlayerAction
    {
        /// <summary>
        /// Calculates the result when the action is taken.
        /// </summary>
        public abstract void CalculateResult();
    }
}
