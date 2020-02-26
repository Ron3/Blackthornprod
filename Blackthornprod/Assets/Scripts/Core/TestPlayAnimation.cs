using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestPlayAnimation : MonoBehaviour
{

    /// <summary>
    /// 
    /// </summary>
    private void Start() 
    {
        Animator animator = this.gameObject.GetComponent<Animator>();
        animator.SetBool("isRun", true);
    }
    
    /// <summary>
    /// 
    /// </summary>
    public void onRonEvent(GameObject obj)
    {
        Debug.Log("onRonEvent!!");
        // Debug.Log($"onRonEvent.....{obj.name}");
    }
}

