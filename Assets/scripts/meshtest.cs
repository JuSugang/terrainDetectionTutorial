using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class meshtest : MonoBehaviour {
    public GameObject before;
    public GameObject after;


    // Use this for initialization
    void Start () {

        
    }
	
	// Update is called once per frame
	void Update () {
        Mesh mesh = before.GetComponent<MeshFilter>().sharedMesh;
        Vector3[] vertices = mesh.vertices;
        int i = 0;
 
        //while (i < vertices.Length)
        //{
        //    vertices[i] = before.GetComponent<MeshFilter>().sharedMesh.vertices[i];
        //    i++;
        //}
        vertices = after.GetComponent<MeshFilter>().sharedMesh.vertices;
        //vertices = a.sharedMesh.vertices;
        mesh.vertices = vertices;
        mesh.RecalculateBounds();
    }
}
