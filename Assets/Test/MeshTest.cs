using System.Collections;
using System.Collections.Generic;
using UnityEngine;


#if UNITY_EDITOR

using UnityEditor;

[CustomEditor(typeof(MeshTest), true)]
[CanEditMultipleObjects]
public class MeshTestEditor : Editor {
    public override void OnInspectorGUI(){
        base.OnInspectorGUI();
        MeshTest meshImage = target as MeshTest;
        if(GUILayout.Button("Recreate Mesh")){
            meshImage.CreateMesh();
        }

        if(GUILayout.Button(meshImage.run ? "Stop" : "Run")){
            meshImage.Run();
        }
    }
}

#endif


public class MeshTest : MonoBehaviour
{
    public float range;
    public int count;
    public float speed = 1;
    MeshFilter meshFilter;
    Mesh mesh;
    // Start is called before the first frame update
    void Start()
    {
        meshFilter = GetComponent<MeshFilter>();
        CreateMesh();
    }

    
    public void CreateMesh(){
        mesh = new Mesh();
        
        Vector3[] vertices = new Vector3[count];
        for (int i = 0; i < vertices.Length; i++)
        {
            vertices[i] = new Vector3(Random.Range(-range,range),Random.Range(-range,range),Random.Range(-range,range));
        }

        int[] triangles = new int[count / 3 * 3];
        for (int i = 0; i < triangles.Length; i++)
        {
            triangles[i] = i;
        }

        Color[] colors = new Color[count];

        mesh.vertices = vertices;
        mesh.triangles = triangles;
        mesh.colors = colors;

        meshFilter.mesh = mesh;
    }

    [HideInInspector]
    public bool run;
    public void Run(){
        run = !run;
    }

    // Update is called once per frame
    void Update()
    {
        if(run){
            for (int i = 0; i < mesh.vertices.Length; i++)
            {
                
            }
            
            // for (int i = 0; i < mesh.triangles.Length; i++){

            // }
        }
    }


}
