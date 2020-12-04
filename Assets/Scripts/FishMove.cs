using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FishMove : MonoBehaviour
{
    public Rigidbody RBFish;

    void Start()
    {
        RBFish.AddForce(Random.Range(-1000, 1000) * Time.deltaTime, Random.Range(-1000, 1000) * Time.deltaTime, Random.Range(-1000, 1000) * Time.deltaTime);
        //RBFish.MoveRotation(Random.rotation);
    }

    private void FixedUpdate()
    {
        RBFish.AddForce(Random.Range(-1000, 1000) * Time.deltaTime, Random.Range(-1000, 1000) * Time.deltaTime, Random.Range(-1000, 1000) * Time.deltaTime);
    }

    private void OnCollisionEnter(Collision collision)
    {
        RBFish.AddForce(Random.Range(-1000, 1000) * Time.deltaTime, Random.Range(-1000, 1000) * Time.deltaTime, Random.Range(-1000, 1000) * Time.deltaTime);
        if (collision.collider.tag == "Food")
        {
            Destroy(collision.gameObject);
        }
    }
}
