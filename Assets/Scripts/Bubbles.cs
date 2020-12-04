using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bubbles : MonoBehaviour
{
    public Transform ObjTransform;
    public Mesh mesh;
    public Material NewMaterial;
    public float ScaleOfObject = 0.1f;
    public float time;
    public bool IsBubbling;
    IEnumerator TestCorutine()
    {
        while (true)
        {
            if (time >= 36000 && IsBubbling)
            {
                //this.gameObject.GetComponent<AudioSource>().enabled = false;
                IsBubbling = false;
                time = 0;
            }
            else if (time >= 36000 && !IsBubbling)
            {
                //this.gameObject.GetComponent<AudioSource>().enabled = true;
                IsBubbling = true;
                time = 0;
            }
            time += Time.deltaTime;
            Debug.Log(time);
            yield return null;
        }
    }
    void Start()
    {
        IsBubbling = true;
        StartCoroutine(TestCorutine());
    }

    // Update is called once per frame
    void Update()
    {
        if (IsBubbling)
        {
            Vector3 scale = new Vector3(ScaleOfObject, ScaleOfObject, ScaleOfObject);
            Vector3 position = new Vector3(ObjTransform.transform.position.x, ObjTransform.transform.position.y, ObjTransform.transform.position.z + 0.3f);
            GameObject gameObject = new GameObject();
            gameObject.AddComponent<MeshFilter>().name = "Bubble";
            gameObject.GetComponent<MeshFilter>().mesh = mesh;
            gameObject.AddComponent<MeshRenderer>().material = NewMaterial;
            gameObject.AddComponent<Rigidbody>().useGravity = false;
            gameObject.transform.position = position;
            gameObject.transform.localScale = scale;
            gameObject.SetActive(true);

            gameObject.GetComponent<Rigidbody>().AddForce(0, 5000 * Time.deltaTime, 0);
            Destroy(gameObject, 0.5f);
        }
    }
}
