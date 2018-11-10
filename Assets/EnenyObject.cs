using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnenyObject : MonoBehaviour {
    public enum SpawState { SPAWNING,WAITING, COUNTING};
    public GameObject enemyPrefab;
    public float spawnTime = 1f;
    private float spawn= 1f;

    ObjectPooler objectPooler;
    private SpawState state = SpawState.COUNTING;

    private void Start()
    {
        objectPooler = ObjectPooler.Instance;
    }

    private void FixedUpdate()
    {
        if (spawn <= 0)
        {
            objectPooler.SpawnFromPool("Enemy", transform.position, transform.rotation);
            spawn = spawnTime;
        }
        else
        {
            spawn -= Time.deltaTime;
        }

        
    }

}
