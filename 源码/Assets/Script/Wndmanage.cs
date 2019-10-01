using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Wndmanage : MonoBehaviour {
    public static Wndmanage _instance;


    public Text coinCountText;
    public int coinCount = 0;

    public bool isAlive = true;

    public int Multiply = 1;
	// Use this for initialization
	void Start () {
        _instance = this;
	}
	
	// Update is called once per frame
	void Update () {
        
        
	}

    public void AddCoin() 
    {
        coinCount+=Multiply;
        ShowCoinCount();
    }
    public void ShowCoinCount()
    {
        //将金币转成string
        coinCountText.text = coinCount.ToString();
    }

    public void ChangMuliply() {
        Multiply = 10;
        Invoke("ResetMuliply",10);
    }

    public void ResetMuliply() {
        Multiply = 1;
    }
}
