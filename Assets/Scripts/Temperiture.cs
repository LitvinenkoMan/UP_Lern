using System;
using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.UI;

public class Temperiture : MonoBehaviour
{
    public float timeForUp = 0;
    public float timeForDown = 0;
    public float time = 0;
    //public GameObject text;
    //public Text text2;
    public TextMesh text3;
    public GameObject Compressor;
    public float temperiture = 28;
    bool IsToUp = true;
    bool IsToDown = false;
    IEnumerator CheckForTemperiture()
    {
        while (true)
        {
            time += Time.deltaTime;
            timeForUp += Time.deltaTime;
            timeForDown += Time.deltaTime;

            if (Compressor.GetComponent<Bubbles>().IsBubbling)
            {
                IsToDown = false;
                IsToUp = true;
            }
            else
            {
                IsToDown = true;
                IsToUp = false;
            }

            yield return null;
        }
    }
    void Start()
    {
        StartCoroutine(CheckForTemperiture());
    }

    void Update()
    {
        text3.text = $"Temperature: {temperiture}\nTime after start: {Math.Round(time)}";

        if (Math.Round(timeForDown) > 2 && IsToDown && !Compressor.GetComponent<Bubbles>().IsBubbling && temperiture > 28)
        {
            //text.GetComponent<TextMesh>().text = $"Temperature: {temperiture}\nTime after start: {Math.Round(time)}";
            text3.text = $"Temperature: {temperiture}\nTime after start: {Math.Round(time)}";
            temperiture--;
            timeForDown = 0;
        }

        if (Math.Round(timeForUp) > 60 && IsToUp && Compressor.GetComponent<Bubbles>().IsBubbling && temperiture < 37)
        {
            //text.GetComponent<TextMesh>().text = $"Temperature: {temperiture}\n {Math.Round(time)}";
            text3.text = $"Temperature: {temperiture}\nTime after start: {Math.Round(time)}";
            temperiture += 3;
            timeForUp = 0;
        }
    }
}
