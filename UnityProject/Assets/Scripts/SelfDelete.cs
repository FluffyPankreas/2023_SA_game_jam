using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SelfDelete : MonoBehaviour
{
    public float delay;

    public void Update()
    {
        delay -= Time.deltaTime;
        if (delay <= 0)
        {
            Destroy(gameObject);
        }
    }
}
