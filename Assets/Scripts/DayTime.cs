using System.Collections.Generic;
using System.Collections;
using UnityEngine;
using System;

public class DayTime : MonoBehaviour
{
    public float dayTime = 0.1f;
    public Light directionalLight;
    public Light AqLight;
    bool AqLightOn = false;
    // Start is called before the first frame update
    IEnumerator TimeCounter()
    {
        while (true)
        {
            dayTime += Time.deltaTime;
            if (dayTime > 1440f)
            {
                dayTime = 0.1f;
            }
            if ((dayTime > 0f && dayTime < 300f) || (dayTime > 1200f && dayTime < 1440f))
            {
                AqLightOn = true;
            }
            else AqLightOn = false;


            yield return null;
        }
    }
    void Start()
    {
        StartCoroutine(TimeCounter());
    }

    // Update is called once per frame
    void Update()
    {
        float x = 360.0f / 1440.0f * dayTime;
        directionalLight.transform.rotation = Quaternion.Euler(x, 0, 0);

        if (AqLightOn)
            AqLight.enabled = true;
        else AqLight.enabled = false;
    }
}
