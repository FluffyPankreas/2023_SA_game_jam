using UnityEngine;

/// <summary>
/// Base class for player actions.
/// </summary>
public class PlayerAction
{
    /// <summary>
    /// Calculates the result when the action is taken.
    /// </summary>
    public virtual void CalculateResult()
    {
        Debug.Log("CalculateResult.");
    }
}
