using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CustomMesh_1_2 : MonoBehaviour
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

        //设置顶点颜色，上面两个顶点设为红色，下面两个顶点设为白色
        //注意：创建出来的默认的UnlitShader里面是没有将顶点颜色参与计算，所以需要稍稍修改shader才能看到效果。
        Color[] colors = new Color[4];
        colors[0] = Color.white;//左下角
        colors[1] = Color.red;//左上角
        colors[2] = Color.red;//右上角
        colors[3] = Color.white;//右下角
       
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
