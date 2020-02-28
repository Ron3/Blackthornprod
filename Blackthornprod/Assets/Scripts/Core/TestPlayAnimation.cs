using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestPlayAnimation : MonoBehaviour
{
    private Animator animator;
    private bool isShowLog = false;

    /// <summary>
    /// 
    /// </summary>
    private void Start() 
    {
        animator = this.gameObject.GetComponent<Animator>();
        // bool isRet1 = animator.GetCurrentAnimatorStateInfo(0).IsName("Idle");
        // bool isRet2 = animator.GetCurrentAnimatorStateInfo(0).IsName("character_run");
        // Debug.Log($"isRet1 ==>  {isRet1}, isRet2 ==> {isRet2}");
        // animator.SetBool("isRun", true);
    }
    
    /// <summary>
    /// 
    /// </summary>
    public void onRonEvent(GameObject obj)
    {
        Debug.Log("onRonEvent!!");
        // Debug.Log($"onRonEvent.....{obj.name}");
    }

    void Update()
    {  
        // AnimatorStateInfo info = animator.GetCurrentAnimatorStateInfo(0);    
        // if (info.normalizedTime >= 1.0f && this.isShowLog == false)  
        // {
        //     Debug.Log($"播放完毕后的逻辑代码 ===> {info.normalizedTime}");
        //     this.isShowLog = true;
        //     animator.SetBool("isSub", true);
        // }  
        // else
        // {
        //     bool isRet1 = animator.GetCurrentAnimatorStateInfo(0).IsName("Idle");
        //     bool isRet2 = animator.GetCurrentAnimatorStateInfo(0).IsName("character_run");
        //     Debug.Log($"isRet1 ==>  {isRet1}, isRet2 ==> {isRet2}");
        // }
    }

}

