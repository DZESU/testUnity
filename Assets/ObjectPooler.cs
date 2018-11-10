﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectPooler : MonoBehaviour {

    [System.Serializable]
    public class Pool
    {
        public string tag;
        public GameObject prefab;
        public int size;
    }

    public static ObjectPooler Instance;

    private void Awake()
    {
        Instance = this;
    }

    public List<Pool> pools;
    public Dictionary<string, Queue<GameObject>> poolDictionary;
	// Use this for initialization
	void Start () {
        poolDictionary = new Dictionary<string, Queue<GameObject>>();

        foreach(Pool pool in pools)
        {
            Queue<GameObject> objectPool = new Queue<GameObject>();
            for(int i = 0; i < pool.size; i++)
            {
                GameObject obj = Instantiate(pool.prefab);
                obj.SetActive(false);
                objectPool.Enqueue(obj);
            }

            poolDictionary.Add(pool.tag, objectPool);
        }


    }

    public GameObject SpawnFromPool(string tag, Vector2 position, Quaternion rotaion)
    {
        if (!poolDictionary.ContainsKey(tag)) {
            Debug.LogWarning("Pool with tag " + tag + "doesn't exist");
            return null;
        }

        GameObject gameObjectToSpawn = poolDictionary[tag].Dequeue();
        gameObjectToSpawn.SetActive(true);
        gameObjectToSpawn.transform.position = position;
        gameObjectToSpawn.transform.rotation = rotaion;

        IPoolObject poolObject =  gameObjectToSpawn.GetComponent<IPoolObject>();

        if (poolObject != null)
        {
            poolObject.OnObjectSpawn();
        }

        poolDictionary[tag].Enqueue(gameObjectToSpawn);
        
        return gameObjectToSpawn;
    }
	
}