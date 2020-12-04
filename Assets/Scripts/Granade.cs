using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Granade : MonoBehaviour
{
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.layer == 10)
        {
            Collider[] colliders = Physics.OverlapSphere(gameObject.transform.position, 5);
            foreach (Collider hit in colliders)
            {
                Rigidbody rb = hit.GetComponent<Rigidbody>();

                if (rb != null)
                    rb.AddExplosionForce(1000000 * Time.deltaTime, transform.position, 5);
                //rb ?.AddExplosionForce(1000000 * Time.deltaTime, transform.position, 5);
            }
            Destroy(gameObject);
            //collision.gameObject.GetComponent<Rigidbody>().AddExplosionForce(1000000 * Time.deltaTime, collision.gameObject.transform.position, 100);
            //gameObject.GetComponent<Rigidbody>().AddExplosionForce(10 * Time.deltaTime, gameObject.transform.position, 100, 100, ForceMode.Force);
        }
    }
}
