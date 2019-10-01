using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MultiPly : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
    private void OnTriggerEnter(Collider other) {
        if (other.tag == "Player") {
            //修改金币增加的倍数
            Wndmanage._instance.ChangMuliply();
            Destroy(this.gameObject);
        }
    }
}
