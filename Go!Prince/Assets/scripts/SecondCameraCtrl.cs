using UnityEngine;
using System.Collections;

public class SecondCameraCtrl : MonoBehaviour {
    public Transform princeTR; //왕자의 transform
    public float dist = 8.0f; //왕자와 카메라와의 거리
    public float height = 50.0f; //카메라의 높이 설정
    public float dampTrace = 10.0f; //부드러운 추적을 위한 변수

    private Transform secondCameraTr;

	// Use this for initialization
	void Start () {
        secondCameraTr = GetComponent<Transform>();
	}
	
	// Update is called once per frame
	void Update () {
        secondCameraTr.position = Vector3.Lerp(secondCameraTr.position,
                                    princeTR.position - (princeTR.forward * dist) + (Vector3.up * height ),
                                    Time.deltaTime * dampTrace);
        secondCameraTr.LookAt(princeTR.position);
	}
}
