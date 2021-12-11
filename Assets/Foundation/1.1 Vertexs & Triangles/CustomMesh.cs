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
        vertices[0] = new Vector3(0,0,0);//左下角
        vertices[1] = new Vector3(0,1,0);//左上角
        vertices[2] = new Vector3(1,0,0);//右下角

        //三角形
        int[] triangles = new int[3];
        triangles[0] = 0;
        triangles[1] = 1;
        triangles[2] = 2;

        // //双面都能渲染的三角形
        // //顺时针一个，逆时针一个，就能避免背面没有被渲染的问题
        // //TIP:Shader里面也是支持双面渲染的，命令是 Cull off
        // int[] triangles = new int[6];
        // triangles[0] = 0;
        // triangles[1] = 1;
        // triangles[2] = 2;
        // triangles[3] = 0;
        // triangles[4] = 2;
        // triangles[5] = 1;

        //赋值顶点和三角形数据
        mesh.vertices = vertices;
        mesh.triangles = triangles;

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
