using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MT : MonoBehaviour
{
    private Transform tar_TRANS;

    private void Awake()
    {
        this.tar_TRANS = null;
    }

    // Start is called before the first frame update
    void Start()
    {
        generate_mesh();
    }

    // Update is called once per frame
    void Update()
    {
        debug_mesh();
    }

    private void generate_mesh()
    {
        Mesh mesh = new Mesh();
        mesh.vertices = new Vector3[] {
                            new Vector3(0.0f,0.0f,0.0f),
                            new Vector3(1.0f,1.0f,0.0f),
                            new Vector3(2.0f,0.0f,0.0f)};
        mesh.triangles = new int[] { 0, 1, 2 };

        tar_TRANS = new GameObject("NM").transform;
        tar_TRANS.position = new Vector3(-10.0f, 0.0f, 0.0f);
        tar_TRANS.gameObject.AddComponent<MeshRenderer>();
        MeshFilter MF = tar_TRANS.gameObject.AddComponent<MeshFilter>();
        MF.mesh = mesh;
    }

    private void debug_mesh()
    {
        Mesh mesh = tar_TRANS.GetComponent<MeshFilter>().mesh;
        string res = "";
        foreach(Vector3 vert in mesh.vertices)
        {
            res += vert.ToString("F2") + " /// ";
        }
        Debug.Log("mesh " + res);
    }
}
