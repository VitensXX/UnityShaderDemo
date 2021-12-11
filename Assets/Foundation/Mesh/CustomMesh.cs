using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CustomMesh : MonoBehaviour
{
    public Material mat;
    void Start()
    {
        Mesh customMesh = CreateCustomMesh();
        //加载渲染组件
        AddRenderComponent(customMesh);
    }

    //创建网格
    Mesh CreateCustomMesh(){
        Mesh mesh = new Mesh();
        //顶点
        Vector3[] vertices = new Vector3[3];
        vertices[0] = new Vector3(0,0,0);
        vertices[1] = new Vector3(0,1,0);
        vertices[2] = new Vector3(1,0,0);

        //三角形
        int[] triangles = new int[6];
        triangles[0] = 0;
        triangles[1] = 1;
        triangles[2] = 2;

        Color[] colors = new Color[3];
        colors[0] = Color.red;
        colors[1] = Color.green;
        colors[2] = Color.blue;
        

        //赋值顶点和三角形数据
        mesh.vertices = vertices;
        mesh.triangles = triangles;
        mesh.colors = colors;

        return mesh;
    }

    //加载渲染组件
    void AddRenderComponent(Mesh mesh){
        //创建MeshRender
        Renderer renderer = gameObject.AddComponent<MeshRenderer>();
        //设置自定义材质球
        renderer.material = mat;

        MeshFilter meshFilter = gameObject.AddComponent<MeshFilter>();
        meshFilter.mesh = mesh;
    }
}
