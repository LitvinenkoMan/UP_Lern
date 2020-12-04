using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerShot : MonoBehaviour
{
    public Transform TPlayer;
    public Camera camera;
    public Mesh mesh;
    public Material NewShotMaterial;
    public Material NewGranadeMaterial;
    public GameObject Cannon;
    public float ScaleOfObject = 0.5f;
    float time = 0;
    bool IsRedyToShot = true;

    IEnumerator TimeCounter()
    {
        while (true)
        {
            time += Time.deltaTime;
            if (time > 3)
            {
                IsRedyToShot = true;
                time = 3;
            }
            yield return null;
        }
    }
    private void Start()
    {
        StartCoroutine(TimeCounter());
    }

    void FixedUpdate()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Ray ray = camera.ScreenPointToRay(Input.mousePosition);
            //RaycastHit hit;

            //Physics.Raycast(ray, out hit, 10000);
            //Debug.DrawLine(ray.origin, hit.point);

            Vector3 scale = new Vector3(ScaleOfObject, ScaleOfObject, ScaleOfObject);
            Vector3 position = new Vector3(Cannon.transform.position.x, Cannon.transform.position.y, Cannon.transform.position.z);

            GameObject gameObject = new GameObject();
            gameObject.AddComponent<MeshFilter>().name = "Shot";
            gameObject.GetComponent<MeshFilter>().mesh = mesh;
            gameObject.AddComponent<MeshRenderer>().material = NewShotMaterial;
            gameObject.AddComponent<MeshCollider>().transform.localScale = scale;
            gameObject.GetComponent<MeshCollider>().convex = true;
            gameObject.AddComponent<Rigidbody>().useGravity = true;
            gameObject.AddComponent<Light>().color = Color.red;
            gameObject.GetComponent<Light>().intensity = 5;


            gameObject.transform.localRotation = Random.rotation;
            gameObject.transform.position = position;
            gameObject.tag = "Shot";
            gameObject.SetActive(true);

            gameObject.GetComponent<Rigidbody>().AddForce(ray.direction * 200000 * Time.deltaTime);
            Destroy(gameObject, 15f);

        }

        if (Input.GetMouseButtonDown(1) && IsRedyToShot)
        {
            Ray ray = camera.ScreenPointToRay(Input.mousePosition);
            //RaycastHit hit;

            //Physics.Raycast(ray, out hit, 10000);
            //Debug.DrawLine(ray.origin, hit.point);

            Vector3 scale = new Vector3(ScaleOfObject, ScaleOfObject, ScaleOfObject);
            Vector3 position = new Vector3(Cannon.transform.position.x, Cannon.transform.position.y, Cannon.transform.position.z);
            Cannon.GetComponent<AudioSource>().Play();
            for (int i = 0; i < 10; i++)
            {
                GameObject gameObject = new GameObject();
                gameObject.AddComponent<MeshFilter>().name = "Shot";
                gameObject.GetComponent<MeshFilter>().mesh = mesh;
                gameObject.AddComponent<MeshRenderer>().material = NewShotMaterial;
                gameObject.AddComponent<MeshCollider>().transform.localScale = scale;
                gameObject.GetComponent<MeshCollider>().convex = true;
                gameObject.AddComponent<Rigidbody>().useGravity = true;
                gameObject.AddComponent<Light>().color = Color.red;
                gameObject.GetComponent<Light>().intensity = 5;

                gameObject.transform.position = position;
                gameObject.transform.localRotation = Random.rotation;
                gameObject.tag = "Shot";
                gameObject.SetActive(true);

                gameObject.GetComponent<Rigidbody>().AddForce(ray.direction * 200000 * Time.deltaTime);
                Destroy(gameObject, 15f);
            }
            IsRedyToShot = false;
            time = 0;
        }

        if (Input.GetKeyDown(KeyCode.G))
        {
            Vector3 scale = new Vector3(ScaleOfObject * 1.5f, ScaleOfObject * 2, ScaleOfObject * 1.5f);
            Vector3 position = new Vector3(Cannon.transform.position.x, Cannon.transform.position.y, Cannon.transform.position.z);


            GameObject gameObject = new GameObject();
            gameObject.AddComponent<MeshFilter>().name = "Granade";
            gameObject.GetComponent<MeshFilter>().mesh = mesh;
            gameObject.AddComponent<MeshCollider>().transform.localScale = scale;
            gameObject.GetComponent<MeshCollider>().convex = true;
            gameObject.AddComponent<MeshRenderer>().material = NewGranadeMaterial;
            gameObject.AddComponent<Rigidbody>().useGravity = true;
            gameObject.AddComponent<Light>().color = Color.blue;
            gameObject.GetComponent<Light>().intensity = 5;
            gameObject.AddComponent<Granade>();

            gameObject.transform.localPosition = position;
            gameObject.transform.localRotation = Random.rotation;
            gameObject.tag = "Granade";
            gameObject.SetActive(true);

            Ray ray = camera.ScreenPointToRay(Input.mousePosition);
            gameObject.GetComponent<Rigidbody>().AddForce(ray.direction * 100000 * Time.deltaTime);
        }
    }
    private void OnMouseUp()
    {

    }
}
