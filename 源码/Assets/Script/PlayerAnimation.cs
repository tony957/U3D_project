using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAnimation : MonoBehaviour {
    //单实例
    public static PlayerAnimation _instatnce;
    public Animation playerAnimation;

    public System.Action animationUpdate;

	// Use this for initialization
	void Start () {
        _instatnce = this;
	    animationUpdate=PlayRun;
	}
	
	// Update is called once per frame
	void Update () {
		if(animationUpdate!=null){
            animationUpdate();
        }
	}
    void PlayRun(){
        playerAnimation.Play("Run");

    }

    public void PlayJumpLeft() {
        playerAnimation.Play("TurnLeft");
        //动画即将播放完       playerAnimation["TurnLeft"].normalizedTime = 1 结束
        if (playerAnimation["TurnLeft"].normalizedTime >= 0.95f) {
            animationUpdate = PlayRun;
            Debug.Log("PlayJumpLeft");
        }
    }

    public void PlayJumpRight()
    {
        playerAnimation.Play("TurnRight");
        //动画即将播放完       playerAnimation["TurnLeft"].normalizedTime = 1 结束
        if (playerAnimation["TurnRight"].normalizedTime >= 0.95f)
        {
            animationUpdate = PlayRun;
            Debug.Log("PlayJumpRight");
        }

    }

    public void PlayJumpRoll()
    {
        playerAnimation.Play("Roll");
        //动画即将播放完       playerAnimation["TurnLeft"].normalizedTime = 1 结束
        if (playerAnimation["Roll"].normalizedTime >= 0.95f)
        {
            animationUpdate = PlayRun;
        }
    }


    public void PlayJumpUp()
    {
        playerAnimation.Play("JumpUp");
        //动画即将播放完       playerAnimation["TurnLeft"].normalizedTime = 1 结束
        if (playerAnimation["JumpUp"].normalizedTime >= 0.95f)
        {
            animationUpdate = PlayRun;
            Debug.Log("PlayJumpUp");
        }
    }

    public void PlayJumpDown()
    {
        playerAnimation.Play("JumpDown");
        //动画即将播放完       playerAnimation["TurnLeft"].normalizedTime = 1 结束
        if (playerAnimation["JumpDown"].normalizedTime >= 0.95f)
        {
            animationUpdate = PlayRun;
            Debug.Log("PlayJumpDown");
        }
    }

    public void Die()
    {
        playerAnimation.Play("Dead");
        //动画即将播放完       playerAnimation["TurnLeft"].normalizedTime = 1 结束
        if (playerAnimation["Dead"].normalizedTime >= 0.95f)
        {
          
            Debug.Log("over");
        }
    }
    
}

