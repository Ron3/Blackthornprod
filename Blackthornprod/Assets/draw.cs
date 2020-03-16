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
        this.DrawCircular();
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
        int segments = 12;
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
        mesh.triangles = new int[]
        { 0, 1, 2,
          0, 2, 3,
          0, 3, 4,
          0, 4, 5,
          0, 5, 6,
          0, 6, 7,
          0, 7, 8,
          0, 8, 9,
          0, 9, 10,
          0, 10, 11,
          0, 11, 12,
          0, 12, 1
        //   0, 12, 13,
        //   0, 14, 15,
        //   0, 15, 16,
        };
    }
}
