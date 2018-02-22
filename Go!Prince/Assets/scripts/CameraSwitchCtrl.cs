using UnityEngine;
using System.Collections;

public class CameraSwitchCtrl : MonoBehaviour {
    public Camera firstCamera;
    public Camera secondCamera;

    bool isToggle = false;

    // Use this for initialization
    void Start()
    {
        firstCamera.enabled = true;
        secondCamera.enabled = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            secondCamera.enabled = true;
            firstCamera.enabled = false;
        }
    }
}
