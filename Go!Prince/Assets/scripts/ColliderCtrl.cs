using UnityEngine;
using System.Collections;

public class ColliderCtrl : MonoBehaviour {
    double[] posX = {25, -55.09551, -83.30988 };
    double[] posY = { -2.091, -0.054, -2.06 };
    double[] posZ = { -22.38, -89, -16 };
    public GameObject move1, move2, move3;
    

    public GameObject prince;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    void OnCollisionEnter(Collision coll)
    {
        if(coll.collider.tag == "PLAYER")
        {
            Debug.Log("부딪혔다!");
            GameObject[] array = { move1, move2, move3 };
            int r = UnityEngine.Random.Range(0, 3);
            prince.transform.position = new Vector3(array[r].transform.position.x, array[r].transform.position.y, array[r].transform.position.z + 10.0f);
        }
    }
}
