using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class draw : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        // this.DrawTriangle();
        // this.DrawSquare();
        // this.DrawCircular();
        this.DrawUV();
    }

    // Update is called once per frame
    void Update()
    {
        
    }


    /// <summary>
    /// 
    /// </summary>
    void DrawTriangle()
    {
        gameObject.AddComponent<MeshFilter>();
        // gameObject.AddComponent<MeshRenderer>();
        // gameObject.GetComponent<MeshRenderer>().material = null;
 
        Mesh mesh = GetComponent<MeshFilter>().mesh;
        mesh.Clear();
 
        //设置顶点
        mesh.vertices = new Vector3[] {new Vector3(0, 0, 0), new Vector3(0, 1, 0), new Vector3(1, 1, 0)};

        //设置三角形顶点顺序，顺时针设置
        mesh.triangles = new int[] {0, 1, 2};

        // 这个颜色好像不起作用
        // mesh.colors32 = new Color32[]{ new Color32(1, 2, 3, 255), new Color32(64, 128, 192, 255), new Color32(255, 255, 255, 255)};
    }


    /// <summary>
    /// 正方形
    /// </summary>
    void DrawSquare()
    {
        Material mat = Resources.Load<Material>("Ron");
        gameObject.AddComponent<MeshFilter>();
        gameObject.AddComponent<MeshRenderer>();
        gameObject.GetComponent<MeshRenderer>().material = mat;
 
        Mesh mesh = GetComponent<MeshFilter>().mesh;
        mesh.Clear();
 
        mesh.vertices = new Vector3[] { new Vector3(0, 0, 0), new Vector3(0, 1, 0), new Vector3(1, 1, 0), new Vector3(1, 0, 0) };
        mesh.triangles = new int[]
        { 0, 1, 2,
          0, 2, 3
        };
    }


    void DrawCircular()
    {
        //顶点
        int segments = 24;
        float radius = 2f;
        Vector3 centerCircle = new Vector3(0, 0, 0);

        Vector3[] vertices = new Vector3[segments + 1];
        vertices[0] = centerCircle;
        float deltaAngle = Mathf.Deg2Rad * 360f / segments;
        float currentAngle = 0;
        for (int i = 1; i < vertices.Length; i++)
        {
            float cosA = Mathf.Cos(currentAngle);
            float sinA = Mathf.Sin(currentAngle);
            vertices[i] = new Vector3(cosA * radius + centerCircle.x, sinA * radius + centerCircle.y, 0);
            currentAngle += deltaAngle;
        }

        // 这里开始画
        Material mat = Resources.Load<Material>("Ron");
        gameObject.AddComponent<MeshFilter>();
        gameObject.AddComponent<MeshRenderer>();
        gameObject.GetComponent<MeshRenderer>().material = mat;
        Mesh mesh = GetComponent<MeshFilter>().mesh;
        mesh.Clear();
 
        mesh.vertices = vertices;
        int[] triangles = new int[segments * 3];
        for (int i = 0, j = 1; i < segments * 3 - 3; i += 3, j++)
        {
            triangles[i] = 0;
            triangles[i + 1] = j + 1;
            triangles[i + 2] = j;
        }
        triangles[segments * 3 - 3] = 0;
        triangles[segments * 3 - 2] = 1;
        triangles[segments * 3 - 1] = segments;
        mesh.triangles = triangles;
    }


    /// <summary>
    /// 
    /// </summary>
    void DrawUV()
    {
        Material mat = Resources.Load<Material>("Ron");
        mat.mainTexture = Resources.Load<Texture>("asasi");

        gameObject.AddComponent<MeshFilter>();
        gameObject.AddComponent<MeshRenderer>();
        gameObject.GetComponent<MeshRenderer>().material = mat;
 
        Mesh mesh = GetComponent<MeshFilter>().mesh;
        mesh.Clear();

        mesh.vertices = new Vector3[]{
            new Vector3(0,0,0), new Vector3(1, 0, 0),
            new Vector3(0,1,0), new Vector3(1, 1, 0)
        };

        mesh.triangles = new int[] {0, 2, 1, 1, 2, 3};
        mesh.uv = new Vector2[] {
            new Vector2(0, 0), new Vector2(1, 0),
            new Vector2(0, 1), new Vector2(1, 1)
        };
    }
}
