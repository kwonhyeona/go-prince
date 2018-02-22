using UnityEngine;
using System.Collections;

public class SnowGizmos : MonoBehaviour {
    public Color _color = Color.yellow;
    public float _radius = 0.1f;

    // Use this for initialization
    void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
   
    void OnDrawGizmos()
    {
        Gizmos.color = _color;
        //구체 모양의 기즈모 생성
        Gizmos.DrawSphere(transform.position, _radius);
    }
}
