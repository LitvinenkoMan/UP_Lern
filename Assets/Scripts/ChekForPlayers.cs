using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChekForPlayers : MonoBehaviour
{
    public Collider BoxCollider;
    public Transform Player;
    public Light light1;
    public Light light2;

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "House")
        {
            light1.enabled = true;
            light2.enabled = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.tag == "House")
        {
            light1.enabled = false;
            light2.enabled = false;
        }
        
    }
}
