using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LampSwitch : MonoBehaviour
{
    public GameObject Lamp;
    public GameObject text;
    public Collider collider;
    public Material materialOn;
    public Material materialOff;
    public Light LampLight;
    private bool isLight = false;


    private void OnTriggerStay(Collider other)
    {
        text.SetActive(true);
        if (Input.GetKeyDown("e") && isLight && other == collider)
        {
            isLight = false;
            LampLight.intensity = 3;
            Lamp.GetComponent<MeshRenderer>().material = materialOn;
        }
        else if (Input.GetKeyDown("e") && !isLight && other == collider)
        {
            isLight = true;
            LampLight.intensity = 0;
            Lamp.GetComponent<MeshRenderer>().material = materialOff;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        text.SetActive(false);
    }
}
