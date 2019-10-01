using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SetCamera : MonoBehaviour {
    public Vector3 offset;
    public Transform playerTrans;

	// Use this for initialization
	void Start () {
        offset = transform.position - playerTrans.position;
	}
	
	// Update is called once per frame
	void Update () {
        transform.position = Vector3.Lerp(transform.position,offset+playerTrans.position,Time.deltaTime*5);
	}
}
