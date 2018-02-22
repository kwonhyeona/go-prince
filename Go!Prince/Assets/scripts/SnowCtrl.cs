﻿using UnityEngine;
using System.Collections;

public class SnowCtrl : MonoBehaviour {
    public int damage = 20; //총알의 파괴력
    public float speed = 1000.0f; //총알 발사 속도

    // Use this for initialization
    void Start () {
        GetComponent<Rigidbody>().AddForce(transform.forward * speed);
    }
	
    void OnCollisionEnter(Collision coll)
    {
        if(coll.collider.tag == "BADGUY")
        {
            Destroy(this, 0.1f);
        }
    }
	// Update is called once per frame
	void Update () {
	}
}
