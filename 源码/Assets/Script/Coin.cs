using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Coin : MonoBehaviour {

    public AudioClip audioclip;
    /// <summary>
    /// 碰撞金币的特效
    /// </summary>
    public GameObject effect;
    /// <summary>
    /// 旋转速度
    /// </summary>
    public int rotateSpeed = 500;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        //旋转的角度
        transform.Rotate(0,rotateSpeed*Time.deltaTime,0);
	}

    private void OnTriggerEnter(Collider other) 
    {
        //人物碰撞到金币
        if (other.tag == "Player") 
        {

            AudioSource.PlayClipAtPoint(audioclip, transform.position);

            Wndmanage._instance.AddCoin();
            //金币的特效
            Instantiate(effect,transform.position,Quaternion.identity);
            Destroy(this.gameObject);
        }
    }
}
