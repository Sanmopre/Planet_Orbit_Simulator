using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Time_Manager : MonoBehaviour
{
    public float slowdown_factor = 0.05f;

    void Start()
    {
        Time.timeScale = slowdown_factor;
        Time.fixedDeltaTime = Time.timeScale * 0.02f;
    }

}
