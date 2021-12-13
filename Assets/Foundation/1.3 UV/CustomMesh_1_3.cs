using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CustomMesh_1_3 : MonoBehaviour
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
        Vector3[] vertices = new Vector3[4];
        vertices[0] = new Vector3(-0.5f, -0.5f, 0);//左下角
        vertices[1] = new Vector3(-0.5f, 0.5f, 0);//左上角
        vertices[2] = new Vector3(0.5f, 0.5f, 0);//右上角
        vertices[3] = new Vector3(0.5f, -0.5f, 0);//右下角

        //两个三角形构成一个四边形
        int[] triangles = new int[6];
        triangles[0] = 0;
        triangles[1] = 1;
        triangles[2] = 2;
        triangles[3] = 0;
        triangles[4] = 2;
        triangles[5] = 3;

        // //设置顶点UV坐标
        // Vector2[] uv = new Vector2[4];
        // uv[0] = new Vector2(0, 0);//左下角
        // uv[1] = new Vector2(0, 1);//左上角
        // uv[2] = new Vector2(1, 1);//右上角
        // uv[3] = new Vector2(1, 0);//右下角

        //修改顶点的uv坐标，大概只显示中间部分
        Vector2[] uv = new Vector2[4];
        uv[0] = new Vector2(0, 0.35f);//左下角
        uv[1] = new Vector2(0, 0.65f);//左上角
        uv[2] = new Vector2(1, 0.65f);//右上角
        uv[3] = new Vector2(1, 0.35f);//右下角
       
        //赋值顶点和三角形数据
        mesh.vertices = vertices;
        mesh.triangles = triangles;
        mesh.uv = uv;

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
