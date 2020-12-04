using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FoodAppiers : MonoBehaviour
{
    public Transform ObjTransform;
    public Mesh mesh;
    public Material NewMaterial;
    public float ScaleOfObject;
    void Update()
    {
        Vector3 scale = new Vector3(ScaleOfObject, ScaleOfObject, ScaleOfObject);
        Vector3 position = new Vector3(ObjTransform.transform.position.x, ObjTransform.transform.position.y - 0.1f, ObjTransform.transform.position.z);
        GameObject gameObject = new GameObject();
        gameObject.AddComponent<MeshFilter>().name = "Food";
        gameObject.GetComponent<MeshFilter>().mesh = mesh;
        gameObject.AddComponent<MeshRenderer>().material = NewMaterial;
        gameObject.AddComponent<SphereCollider>().radius = ScaleOfObject * 5f;
        gameObject.AddComponent<Rigidbody>().useGravity = false;
        gameObject.tag = "Food";
        gameObject.transform.position = position;
        gameObject.transform.localScale = scale;
        gameObject.SetActive(true);
    }
}
