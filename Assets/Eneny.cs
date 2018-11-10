using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Eneny : MonoBehaviour,IPoolObject {

    public float upForce = 1f;
    public float sideForce = 0.1f;

    public void OnObjectSpawn()
    {
        float xForce = Random.Range(-sideForce, -1);
        float yForce = Random.Range(upForce / 2f, upForce);

        Vector2 force = new Vector2(xForce, yForce);
        GetComponent<Rigidbody2D>().velocity = force;
    }

    // Use this for initialization
    
	
	// Update is called once per frame
	void Update () {
		
	}
}
