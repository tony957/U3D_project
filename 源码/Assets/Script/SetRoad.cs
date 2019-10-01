using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SetRoad : MonoBehaviour {

    public GameObject curRoad;
    public GameObject otherRaod;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        if (transform.position.z > curRoad.transform.position.z + 32) {
            curRoad.transform.position = new Vector3(0,0,otherRaod.transform.position.z+32);
            GameObject temp = curRoad;
            curRoad = otherRaod;
            otherRaod = temp;
        }
	}
}
