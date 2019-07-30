using UnityEngine;

/// <summary>
/// Create mesh of any shape in the run-time;
///     vertices: all the vertices positions needed for one polygon; (A cube has 8 vertices)
///     triangles: set order of the vertices to form triangles, number indicates vertices index. 
///         Order in each triangles need to be clock-wise order. 
///     uvs: texture position for each vertices, from 0.0f to 1.0f for x and y axes. Up-left (0.0f,0.0f), 
///         down-right (1.0f,1.0f). Each element refer to the same index of vertices.
/// </summary>
public class CreateMesh : MonoBehaviour
{
    [SerializeField] private Material material;

    // Start is called before the first frame update
    void Start()
    {
        create_mesh();
    }

    private void create_mesh()
    {
        GameObject OBJ0 = new GameObject("0");
        GameObject OBJ1 = new GameObject("1");
        GameObject OBJ2 = new GameObject("2");
        GameObject OBJ3 = new GameObject("3");
        Mesh[] mesh = new Mesh[4];

        //T1;
        Vector3[] vertices0 = new Vector3[]
            { new Vector3(-1.0f,0.0f,0.0f), new Vector3(-1.0f,1.0f,0.0f),new Vector3(0.0f,0.0f,0.0f)};
        int[] triangles0 = new int[] { 0, 1, 2 };
        Vector2[] uvs0 = new Vector2[]
            {new Vector2(0.5f,0.0f),new Vector2(0.0f,0.0f),new Vector2(0.5f,0.5f)};
        mesh[0] = new Mesh();
        mesh[0].vertices = vertices0;
        mesh[0].triangles = triangles0;
        mesh[0].uv = uvs0;
        MeshFilter MF0 = OBJ0.AddComponent<MeshFilter>();
        MeshRenderer MR0 = OBJ0.AddComponent<MeshRenderer>();
        MF0.mesh = mesh[0];
        MF0.mesh.RecalculateNormals();
        MR0.material = material;

        //T2;
        Vector3[] vertices1 = new Vector3[]
            { new Vector3(-1.0f,1.0f,0.0f), new Vector3(0.0f,1.0f,0.0f),new Vector3(0.0f,0.0f,0.0f)};
        int[] triangles1 = new int[] { 0, 1, 2 };
        Vector2[] uvs1 = new Vector2[]
            {new Vector2(0.0f,0.0f),new Vector2(0.5f,0.0f),new Vector2(0.5f,0.5f)};
        mesh[1] = new Mesh();
        mesh[1].vertices = vertices1;
        mesh[1].triangles = triangles1;
        mesh[1].uv = uvs1;
        MeshFilter MF1 = OBJ1.AddComponent<MeshFilter>();
        MeshRenderer MR1 = OBJ1.AddComponent<MeshRenderer>();
        MF1.mesh = mesh[1];
        MF1.mesh.RecalculateNormals();
        MR1.material = material;

        //T3;
        Vector3[] vertices2 = new Vector3[]
            { new Vector3(0.0f,0.0f,0.0f), new Vector3(1.0f,0.0f,0.0f),new Vector3(1.0f,-1.0f,0.0f)};
        int[] triangles2 = new int[] { 0, 1, 2 };
        Vector2[] uvs2 = new Vector2[]
            {new Vector2(0.5f,0.5f),new Vector2(1.0f,0.5f),new Vector2(1.0f,1.0f)};
        mesh[2] = new Mesh();
        mesh[2].vertices = vertices2;
        mesh[2].triangles = triangles2;
        mesh[2].uv = uvs2;
        MeshFilter MF2 = OBJ2.AddComponent<MeshFilter>();
        MeshRenderer MR2 = OBJ2.AddComponent<MeshRenderer>();
        MF2.mesh = mesh[2];
        MF2.mesh.RecalculateNormals();
        MR2.material = material;

        //T4;
        Vector3[] vertices3 = new Vector3[]
            { new Vector3(0.0f,0.0f,0.0f), new Vector3(0.0f,-1.0f,0.0f),new Vector3(-1.0f,-1.0f,0.0f)};
        int[] triangles3 = new int[] { 2,0,1 };
        Vector2[] uvs3 = new Vector2[]
            {new Vector2(0.5f,0.5f),new Vector2(0.5f,1.0f),new Vector2(0.0f,1.0f)};
        mesh[3] = new Mesh();
        mesh[3].vertices = vertices3;
        mesh[3].triangles = triangles3;
        mesh[3].uv = uvs3;
        MeshFilter MF3 = OBJ3.AddComponent<MeshFilter>();
        MeshRenderer MR3 = OBJ3.AddComponent<MeshRenderer>();
        MF3.mesh = mesh[3];
        MF3.mesh.RecalculateNormals();
        MR3.material = material;

    }
}
