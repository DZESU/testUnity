using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TitleSponnerObject : MonoBehaviour {

    public GameObject tileObject;
    public Transform target;
    ObjectPooler objectPooler;

    private float tileWidth;

    private void Start()
    {
        tileWidth = tileObject.GetComponent<BoxCollider2D>().size.x;
        objectPooler = ObjectPooler.Instance;
    }

    private void FixedUpdate()
    {
        if(transform.position.x < target.transform.position.x)
        {
            objectPooler.SpawnFromPool("Tiles", transform.position, transform.rotation);
            transform.position = new Vector3(tileWidth+transform.position.x,transform.position.y,transform.position.z);
        }
        
    }
}
