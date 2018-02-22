using UnityEngine;
using System.Collections;

public class UIManagerCtrl : MonoBehaviour {

	// Use this for initialization
	void Start () {
	    
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    public void OnClickStartButton(string msg)
    {
        Debug.Log("Click Start Button" + msg);
        Application.LoadLevel("MazeScene");
    }

    public void OnClickGuideButton(string msg)
    {
        Debug.Log("Click Guide Button" + msg);
        Application.LoadLevel("GuideScene");
    }

    public void OnClickExitButton(string msg)
    {
        Debug.Log("Click Exit Button" + msg);
        Application.Quit();
    }
}
