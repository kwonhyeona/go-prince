using UnityEngine;
using System.Collections;

public class GUIManagerCtrl : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    public void OnClickBackButton(string msg)
    {
        Debug.Log("Click Back Button" + msg);
        Application.LoadLevel("ReadyScene");
    }
}
