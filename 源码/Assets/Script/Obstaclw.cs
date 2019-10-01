using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Obstaclw : MonoBehaviour {
    public int moveSpeed = 0;
    public AudioClip hit;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        transform.Translate(transform.forward*moveSpeed*Time.deltaTime);
	}

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            AudioSource.PlayClipAtPoint(hit,transform.position);

            PlayerAnimation._instatnce.animationUpdate = PlayerAnimation._instatnce.Die;
            Wndmanage._instance.isAlive = false;
            Invoke("Application.Quit()", 10);
        }
    }
}
