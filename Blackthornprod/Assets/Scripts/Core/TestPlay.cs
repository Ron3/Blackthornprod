using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestPlay : MonoBehaviour
{

    // /// <summary>
    // /// 
    // /// </summary>
    // private void Start() 
    // {
    //     Animator animator = this.gameObject.GetComponent<Animator>();
    //     animator.SetBool("isRun", true);
    // }
    
    /// <summary>
    /// 
    /// </summary>
    public void onRonEvent(GameObject obj)
    {
        Debug.Log("onRonEvent testPlay!!");
        // Debug.Log($"onRonEvent.....{obj.name}");

        Animator animator = this.gameObject.GetComponent<Animator>();
        Debug.Log($"animator.speed ==> {animator.speed}");

        // 改变动画播放速度
        float rate = 0.1f;
        if(animator.speed >= rate)
        {
            animator.speed -= rate;
        }
        else
        {
            animator.speed = 2;
        }

        // animator.runtimeAnimatorController;

        // float length = TestPlay.GetClipLength(animator, "character_run");
        // Debug.Log($"length ===> {length}");
    }


    public static float GetClipLength(Animator animator, string clipName) 
    {
        if(null== animator || string.IsNullOrEmpty(clipName) || null == animator.runtimeAnimatorController)
            return 0;

        // 获取所有的clips	
        AnimationClip[] clips = animator.runtimeAnimatorController.animationClips;
        if(null == clips || clips.Length <= 0) 
            return 0;

        AnimationClip clip = null;
        for (int i = 0, len = clips.Length; i < len ; ++i) 
        {
            clip = clips[i];
            // Debug.Log($"clip ===> {clip.name}");
            if(null != clip && clip.name == clipName)
            {
                AnimationEvent[] events = clip.events;
                foreach(AnimationEvent ev in events)
                {
                    // Debug.Log($"ev ===>{ev.functionName}");
                }
                return clip.length;
            }
                
        }
        return 0f;
    }
}

