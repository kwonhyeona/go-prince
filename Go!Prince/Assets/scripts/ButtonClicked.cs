using UnityEngine;
using System.Collections;

public class ButtonClicked : MonoBehaviour {

    private UnityEngine.UI.Button _thisObjBtn;
    public GameObject _target;
    public string _functionName = "Regame";

	// Use this for initialization
	void Start () {

        _thisObjBtn = gameObject.GetComponentInChildren<UnityEngine.UI.Button>();

    }
	
	// Update is called once per frame
    void Update()
    {

        
    }

    public void OnClickReplayButton()
    {
        if (_target != null)
        {
            Debug.Log("null ¾Æ´Ï¾ß");
            _target.SendMessage(_functionName, SendMessageOptions.DontRequireReceiver);
        }
    }
}
