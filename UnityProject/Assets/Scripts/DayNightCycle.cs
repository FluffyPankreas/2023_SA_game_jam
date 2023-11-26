using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Experimental.GlobalIllumination;

public class DayNightCycle : MonoBehaviour
{
    public Color[] colourPresets;
    public float[] rotationTargets;

    [SerializeField,Tooltip("The light that will be changed.")]
    private Light sunlight;

    [SerializeField]
    private float rotationSpeed;

    private float _targetRotation = 0;
    
    public void SetPreset(int presetIndex)
    {
        _targetRotation = rotationTargets[presetIndex];
        sunlight.color = colourPresets[presetIndex];
    }

    /*public void Update()
    {
        if (_targetRotation > transform.eulerAngles.x)
        {
            transform.eulerAngles = new Vector3(_targetRotation, 0, 0);
        }
        else if (_targetRotation < transform.eulerAngles.x)
        {

        }
    }*/
}
