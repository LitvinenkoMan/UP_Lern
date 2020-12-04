using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GiveFood : MonoBehaviour
{
    public FoodAppiers foodAppiers;
    public float time = 0;
    IEnumerator TimeCounter()
    {
        while (true)
        {
            time += Time.deltaTime;
            if (Math.Round(time) % 60 == 0)
                foodAppiers.enabled = true;
            else foodAppiers.enabled = false;
            yield return null;
        }
    }
    private void Start()
    {
        StartCoroutine(TimeCounter());
    }
    private void OnTriggerStay(Collider collider)
    {
        if (Input.GetKey("e") && collider.tag == "Button")
            foodAppiers.enabled = true;
        else foodAppiers.enabled = false;
    }
}
