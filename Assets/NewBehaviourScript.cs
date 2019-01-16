using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NewBehaviourScript : MonoBehaviour {
	public GameObject canvas1;
	public GameObject canvas2;
	public GameObject image;
	public GameObject text;
	public GameObject text1;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public void ClickMy(int testInt){
		//canvas1.SetActive (false);
		//canvas2.SetActive (true);
        if (text.activeSelf) {
		text.SetActive(false);
        text1.SetActive(true);
        }

        else
        {
            text1.SetActive(false);
            text.SetActive(true);
        }
    }
}
