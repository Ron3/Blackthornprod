using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestRunInto : MonoBehaviour
{

    /// <summary>
    /// other. 这个的意思是说, 当前gameObject与other发生了碰撞.
    /// </summary>
    /// <param name="other"></param>
    private void OnTriggerEnter2D(Collider2D other)
    {
        Debug.Log($"TestRunInto ==> {other.gameObject.name}");
    }
}

